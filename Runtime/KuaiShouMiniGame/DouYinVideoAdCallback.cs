#if UNITY_WEBGL && ENABLE_KUAISHOU_MINI_GAME && ENABLE_KUAISHOU_MINI_GAME_ADVERTISEMENT
using System;
using UnityEngine.Scripting;

namespace GameFrameX.Advertisement.DouYinMiniGame.Runtime
{
    /// <summary>
    /// 快手视频广告回调处理器，管理广告加载、展示和关闭等事件的回调。
    /// </summary>
    /// <remarks>
    /// KuaiShou video ad callback handler, managing callbacks for ad loading, display, and close events.
    /// </remarks>
    [Preserve]
    internal class KuaiShouVideoAdCallback
    {
        private Action<string> loadSuccess;
        private Action<string> loadFail;
        private Action<string> showSuccess;
        private Action<string> showFail;
        /// <summary>
        /// 获取或设置广告展示结果回调，参数表示用户是否观看了有效时长。
        /// </summary>
        /// <remarks>
        /// Gets or sets the ad show result callback, parameter indicates whether the user watched the effective duration.
        /// </remarks>
        /// <value>展示结果回调 / Show result callback</value>
        [Preserve] public Action<bool> ShowResult { get; set; }
        
        /// <summary>
        /// 当视频广告加载完成时调用。
        /// </summary>
        /// <remarks>
        /// Called when the video ad has finished loading.
        /// </remarks>
        [Preserve]
        public void OnVideoLoaded()
        {
            loadSuccess?.Invoke(null);
        }

        /// <summary>
        /// 当视频广告成功展示时调用。
        /// </summary>
        /// <remarks>
        /// Called when the video ad is successfully shown.
        /// </remarks>
        /// <param name="timestamp">广告展示的时间戳 / Timestamp when the ad was shown</param>
        [Preserve]
        public void OnVideoShow(long timestamp)
        {
            showSuccess?.Invoke(timestamp.ToString());
        }

        /// <summary>
        /// 当广告发生错误时调用。
        /// </summary>
        /// <remarks>
        /// Called when an ad error occurs.
        /// </remarks>
        /// <param name="errCode">错误码 / Error code</param>
        /// <param name="errorMessage">错误信息 / Error message</param>
        [Preserve]
        public void OnError(int errCode, string errorMessage)
        {
            loadFail?.Invoke(errorMessage);
            showFail?.Invoke(errorMessage);
        }

        /// <summary>
        /// 当视频广告被关闭时调用，根据观看时长判断是否为有效观看。
        /// </summary>
        /// <remarks>
        /// Called when the video ad is closed, determines whether the view is effective based on watched duration.
        /// </remarks>
        /// <param name="watchedTime">实际观看时长（秒） / Actual watched duration in seconds</param>
        /// <param name="effectiveTime">有效观看时长阈值（秒） / Effective watch duration threshold in seconds</param>
        /// <param name="duration">视频总时长（秒） / Total video duration in seconds</param>
        [Preserve]
        public void OnVideoClose(int watchedTime, int effectiveTime, int duration)
        {
            ShowResult?.Invoke(watchedTime >= effectiveTime);
            ShowResult = null;
        }

        /// <summary>
        /// 设置广告加载阶段的回调。
        /// </summary>
        /// <remarks>
        /// Sets the callbacks for the ad loading phase.
        /// </remarks>
        /// <param name="success">加载成功回调 / Load success callback</param>
        /// <param name="fail">加载失败回调 / Load failure callback</param>
        [Preserve]
        public void SetLoadCallback(Action<string> success, Action<string> fail)
        {
            loadSuccess = success;
            loadFail = fail;
        }

        /// <summary>
        /// 设置广告展示阶段的回调。
        /// </summary>
        /// <remarks>
        /// Sets the callbacks for the ad display phase.
        /// </remarks>
        /// <param name="success">展示成功回调 / Show success callback</param>
        /// <param name="fail">展示失败回调 / Show failure callback</param>
        [Preserve]
        public void SetShowCallback(Action<string> success, Action<string> fail)
        {
            showSuccess = success;
            showFail = fail;
        }
    }
}
#endif