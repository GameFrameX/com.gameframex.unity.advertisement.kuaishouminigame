#if UNITY_WEBGL && ENABLE_KUAISHOU_MINI_GAME && ENABLE_KUAISHOU_MINI_GAME_ADVERTISEMENT

using System;
using GameFrameX.Advertisement.Runtime;
using GameFrameX.Runtime;
using UnityEngine;

namespace GameFrameX.Advertisement.KuaiShouMiniGame.Runtime
{
    /// <summary>
    /// 快手小游戏激励视频广告管理器，负责广告的加载、展示和生命周期管理。
    /// </summary>
    /// <remarks>
    /// KuaiShou mini-game rewarded video advertisement manager, responsible for ad loading, display, and lifecycle management.
    /// 渠道身份常量 <see cref="ChannelId"/> 供注册表互斥解析与显式路由使用；初始化统一走
    /// <see cref="Initialize(AdvertisementConfig)"/> 的强类型 <see cref="KuaiShouMiniGameAdvertisementConfig"/>
    /// （由 KuaiShouMiniGameAdvertisementBootstrap 工厂闭包注入，adUnitId 自组件宏选字段下沉而来）。
    /// </remarks>
    [UnityEngine.Scripting.Preserve]
    public class KuaiShouMiniGameAdvertisementManager : BaseAdvertisementManager
    {
        /// <summary>
        /// 快手小游戏渠道唯一标识。
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public const string ChannelId = "kuaishouminigame";

        private KSWASM.RewardVideoAd _adManager;
        private string _adUnitId;
        private KuaiShouVideoAdCallback _kuaiShouVideoAdCallback;

        /// <summary>
        /// 使用强类型配置初始化快手小游戏广告管理器。
        /// </summary>
        /// <remarks>
        /// Initializes the ad manager with the strongly-typed KuaiShou mini-game configuration.
        /// </remarks>
        /// <param name="config">快手小游戏渠道配置 / KuaiShou mini-game channel configuration</param>
        [UnityEngine.Scripting.Preserve]
        public override void Initialize(AdvertisementConfig config)
        {
            var kuaiShouConfig = config as KuaiShouMiniGameAdvertisementConfig;
            if (kuaiShouConfig == null)
            {
                throw new ArgumentException("Config must be KuaiShouMiniGameAdvertisementConfig", nameof(config));
            }

            GameFrameworkGuard.NotNullOrEmpty(kuaiShouConfig.adUnitId, nameof(kuaiShouConfig.adUnitId));
#pragma warning disable CS0618
            Initialize(kuaiShouConfig.adUnitId, kuaiShouConfig.isDebug);
#pragma warning restore CS0618
        }

        /// <summary>
        /// 初始化快手小游戏广告管理器。
        /// </summary>
        /// <remarks>
        /// Initializes the KuaiShou mini-game advertisement manager.
        /// </remarks>
        /// <param name="adUnitId">广告单元Id / Ad unit ID</param>
        /// <param name="debug">是否启用调试模式 / Whether to enable debug mode</param>
        /// <exception cref="ArgumentException">当 <paramref name="adUnitId"/> 为 null 或空字符串时抛出 / Thrown when <paramref name="adUnitId"/> is null or empty</exception>
        [UnityEngine.Scripting.Preserve]
        public override void Initialize(string adUnitId, bool debug = false)
        {
            GameFrameworkGuard.NotNullOrEmpty(adUnitId, nameof(adUnitId));
            _adUnitId = adUnitId;
            _kuaiShouVideoAdCallback = new KuaiShouVideoAdCallback();
        }

        [UnityEngine.Scripting.Preserve]
        void OnCloseCallback(KSWASM.KSRewardedVideoAdOnCloseResponse ksRewardedVideoAdOnCloseResponse)
        {
            _kuaiShouVideoAdCallback.ShowResult?.Invoke(ksRewardedVideoAdOnCloseResponse.isEnded);
            _kuaiShouVideoAdCallback.ShowResult = null;
            _adManager.Destroy();
            _adManager = null;
        }

        /// <summary>
        /// 播放激励视频广告，自动完成加载和展示流程。
        /// </summary>
        /// <remarks>
        /// Plays a rewarded video ad, automatically completing the loading and display process.
        /// </remarks>
        /// <param name="playResult">播放结果回调，参数表示是否成功观看完整广告 / Play result callback, parameter indicates whether the ad was watched completely</param>
        /// <param name="customData">自定义透传数据 / Custom transparent data</param>
        [UnityEngine.Scripting.Preserve]
        public override void Play(Action<bool> playResult, string customData = null)
        {
            Load((x) => { Show((s) => { Debug.Log($"Play Success：{s}"); }, (f) => { Debug.Log($"Play Fail：{f}"); }, playResult); }, (x) =>
            {
                Debug.Log($"Play Fail：{x}");
                playResult?.Invoke(false);
            }, customData);
        }

        public override void Play(AdvertisementPlayOption option)
        {
#pragma warning disable CS0618
            Load((s) => { Show(option.OnSuccess, option.OnFail, option.OnShowResult, option.customData); }, (fail) =>
            {
                Debug.Log($"[KuaiShouMiniGameAdvertisementManager] Play Load Fail: {fail}");
                option.OnFail?.Invoke(fail);
                option.OnShowResult?.Invoke(false);
            }, option.extraData);
#pragma warning restore CS0618
        }

        /// <summary>
        /// 展示已加载的激励视频广告。
        /// </summary>
        /// <remarks>
        /// Shows the loaded rewarded video ad.
        /// </remarks>
        /// <param name="success">展示成功回调 / Show success callback</param>
        /// <param name="fail">展示失败回调 / Show failure callback</param>
        /// <param name="onShowResult">展示结果回调，参数表示用户是否观看完整广告 / Show result callback, parameter indicates whether the user watched the ad completely</param>
        /// <param name="customData">自定义透传数据 / Custom transparent data</param>
        [UnityEngine.Scripting.Preserve]
        public override void Show(Action<string> success, Action<string> fail, Action<bool> onShowResult, string customData = null)
        {
            OnShowResult = onShowResult;
            _kuaiShouVideoAdCallback.SetShowCallback(success, fail);
            _kuaiShouVideoAdCallback.ShowResult = onShowResult;

            if (_adManager == null)
            {
                fail?.Invoke("广告未初始化");
                onShowResult?.Invoke(false);
                return;
            }

            _adManager.OnError((response) => { fail?.Invoke(response.errorMsg); });
            _adManager.OnClose(OnCloseCallback);
            _adManager.Show();

            void OnCloseCallback(KSWASM.KSRewardedVideoAdOnCloseResponse response)
            {
                if (response.isEnded)
                {
                    success?.Invoke(customData);
                    onShowResult?.Invoke(true);
                }
                else
                {
                    onShowResult?.Invoke(false);
                }
            }
        }

        /// <summary>
        /// 加载激励视频广告资源。
        /// </summary>
        /// <remarks>
        /// Loads the rewarded video ad resources.
        /// </remarks>
        /// <param name="success">加载成功回调 / Load success callback</param>
        /// <param name="fail">加载失败回调 / Load failure callback</param>
        /// <param name="customData">自定义透传数据 / Custom transparent data</param>
        [UnityEngine.Scripting.Preserve]
        public override void Load(Action<string> success, Action<string> fail, string customData = null)
        {
            if (_adManager != null)
            {
                success?.Invoke(customData);
                return;
            }

            _adManager = KSWASM.KS.CreateRewardedVideoAd(_adUnitId);
            _kuaiShouVideoAdCallback.SetLoadCallback(success, fail);
            success?.Invoke(customData);
        }
    }
}

#endif