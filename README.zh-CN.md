<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Advertisement (KuaiShou Mini Game)

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.advertisement.kuaishouminigame)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.kuaishouminigame/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.advertisement.kuaishouminigame)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.kuaishouminigame/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

独立游戏前后端一体化解决方案 · 独立游戏开发者的圆梦大使

<br />

[文档](https://gameframex.doc.alianblank.com) · [快速开始](#quick-start) · QQ群: 467608841 / 233840761

<br />

[English](README.md) | **简体中文** | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

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

编辑 Unity 项目的 `Packages/manifest.json`，添加 `scopedRegistries` 部分：

```json
{
  "scopedRegistries": [
    {
      "name": "GameFrameX",
      "url": "https://gameframex.upm.alianblank.uk",
      "scopes": [
        "com.gameframex"
      ]
    }
  ]
}
```

`scopes` 控制哪些包通过此注册表解析。只有以 `com.gameframex` 开头的包才会从这个注册表获取。

Then add the package to `dependencies`:

```json
{
  "dependencies": {
    "com.gameframex.unity.advertisement.kuaishouminigame": "1.0.0"
  }
}
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


## 依赖

| 包 | 说明 |
|----|------|
| (无) | - |

## 开源协议

详见 [LICENSE.md](LICENSE.md) 文件。
