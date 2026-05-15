<div align="center">

![GameFrameX Logo](https://download.alianblank.com/gameframex/gameframex_logo_320.png)

# Game Frame X Advertisement (KuaiShou Mini Game)

[![Version](https://img.shields.io/github/v/release/gameframex/com.gameframex.unity.advertisement.kuaishouminigame?label=version&color=green)](https://github.com/gameframex/com.gameframex.unity.advertisement.kuaishouminigame/releases)
[![License](https://img.shields.io/badge/license-MIT+Apache%202.0-orange.svg)](LICENSE.md)
[![Documentation](https://img.shields.io/badge/docs-gameframex-brightgreen.svg)](https://gameframex.doc.alianblank.com)

**独立游戏前后端一体化解决方案 · 独立游戏开发者的圆梦大使**

[📖 文档](https://gameframex.doc.alianblank.com) • [🚀 快速开始](#快速开始) • [💬 QQ群](https://qm.qq.com/q/urCUAqJCJm)

---

🌐 **语言**: [English](README.md) | **简体中文** | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

---

</div>

## 项目简介

[Game Frame X 广告系统](https://github.com/GameFrameX/com.gameframex.unity.advertisement)的快手小游戏平台适配器。为发布到快手小游戏平台的游戏提供激励视频广告集成。

### 功能特性

- 基于快手小游戏 SDK 的激励视频广告支持
- 自动加载广告，展示失败自动重试
- IL2CPP 代码裁剪保护
- 条件编译（`ENABLE_KUAISHOU_MINI_GAME`、`ENABLE_KUAISHOU_MINI_GAME_ADVERTISEMENT`）
- 与 Game Frame X 广告组件无缝集成

## 架构概览

本包是 Game Frame X 广告核心 `BaseAdvertisementManager` 的**适配器实现**。通过 Unity Inspector 配置 `AdvertisementComponent` 后，自动发现并加载。

| 类 | 说明 |
|----|------|
| `KuaiShouMiniGameAdvertisementManager` | 激励视频广告管理器 — 加载、展示及生命周期管理 |
| `KuaiShouVideoAdCallback` | 广告加载/展示事件回调处理器 |
| `GameFrameXAdvertisementKuaiShouMiniGameCroppingHelper` | IL2CPP link.xml 替代方案 — 保留类型引用 |

## 快速开始

### 安装

1. 安装[广告核心包](https://github.com/GameFrameX/com.gameframex.unity.advertisement)
2. 通过 Unity Package Manager (UPM) 添加本适配器：

```json
{
  "dependencies": {
    "com.gameframex.unity.advertisement": "https://github.com/GameFrameX/com.gameframex.unity.advertisement.git",
    "com.gameframex.unity.advertisement.kuaishouminigame": "https://github.com/gameframex/com.gameframex.unity.advertisement.kuaishouminigame.git"
  }
}
```

或在 Unity Package Manager 窗口中通过 git URL 添加。

### 使用示例

在 Unity Inspector 中配置：将 `AdvertisementComponent` 添加到 GameObject，然后在实现类型下拉框中选择 `KuaiShouMiniGameAdvertisementManager`。

```csharp
using GameFrameX.Advertisement.Runtime;

// 获取广告组件（通常从游戏入口获取）
var adComponent = GameEntry.GetComponent<AdvertisementComponent>();

// 设置服务端验证数据（可选）
adComponent.SetExtraData("userId", player.UserId);

// 播放激励视频广告
var option = new AdvertisementPlayOption
{
    OnSuccess    = (data) => Debug.Log("广告展示成功"),
    OnFail       = (err) => Debug.LogError($"广告展示失败: {err}"),
    OnShowResult = (watched) =>
    {
        if (watched)
        {
            // 发放奖励
        }
    },
};
adComponent.Play(option);
```

## 平台支持

| 平台 | 支持 |
|------|------|
| 快手小游戏 (WebGL) | 是 |
| Android | 否 |
| iOS | 否 |
| Standalone | 否 |

> 需要 `UNITY_WEBGL` 和 `ENABLE_KUAISHOU_MINI_GAME` 脚本宏定义。

## 文档与资源

- [Game Frame X 文档](https://gameframex.doc.alianblank.com)
- [快手小游戏开发者平台](https://mp.kuaishou.com/)

## 社区与支持

- QQ群：[加入](https://qm.qq.com/q/urCUAqJCJm)
- GitHub Issues：[报告问题](https://github.com/gameframex/com.gameframex.unity.advertisement.kuaishouminigame/issues)

## 更新日志

### v1.0.0

- 初始发布
- 支持快手小游戏平台激励视频广告
- IL2CPP 裁剪保护

## 开源协议

本项目基于 [MIT 许可证](LICENSE.md) 和 [Apache 许可证 2.0](LICENSE.md) 双重授权。
