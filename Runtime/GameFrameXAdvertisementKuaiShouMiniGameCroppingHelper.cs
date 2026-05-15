using UnityEngine;
using UnityEngine.Scripting;

namespace GameFrameX.Advertisement.KuaiShouMiniGame.Runtime
{
    /// <summary>
    /// 快手小游戏广告裁剪辅助器，用于确保类型引用在 IL2CPP 裁剪时被保留。
    /// </summary>
    /// <remarks>
    /// KuaiShou mini-game advertisement cropping helper, used to ensure type references are preserved during IL2CPP stripping.
    /// </remarks>
    [Preserve]
    public class GameFrameXAdvertisementKuaiShouMiniGameCroppingHelper : MonoBehaviour
    {
        [Preserve]
        private void Start()
        {
#if UNITY_WEBGL && ENABLE_KUAISHOU_MINI_GAME && ENABLE_KUAISHOU_MINI_GAME_ADVERTISEMENT
            _ = typeof(KuaiShouMiniGameAdvertisementManager);
            _ = typeof(GameFrameX.Advertisement.DouYinMiniGame.Runtime.KuaiShouVideoAdCallback);
#endif
        }
    }
}