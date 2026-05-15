<div align="center">

![GameFrameX Logo](https://download.alianblank.com/gameframex/gameframex_logo_320.png)

# Game Frame X - 快手小游戏广告

[![Version](https://img.shields.io/github/v/release/gameframex/com.gameframex.unity.advertisement.kuaishouminigame?label=version&color=green)](https://github.com/gameframex/com.gameframex.unity.advertisement.kuaishouminigame/releases)
[![License](https://img.shields.io/badge/license-MIT+Apache%202.0-orange.svg)](LICENSE.md)
[![Documentation](https://img.shields.io/badge/docs-gameframex-brightgreen.svg)](https://gameframex.doc.alianblank.com)

**独立游戏前后端一体化解决方案 · 独立游戏开发者的圆梦大使**

[📖 文档](https://gameframex.doc.alianblank.com) • [🚀 快速开始](#快速开始)

---

🌐 **语言**: [English](README.md) | **简体中文** | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

---

</div>

## 项目简介

GameFrameX 广告组件的快手小游戏适配层，基于快手小游戏 SDK 封装激励视频广告的加载、展示与生命周期管理。

## 快速开始

**方式一：修改 `manifest.json`**

```json
{
  "com.gameframex.unity.advertisement.kuaishouminigame": "https://github.com/gameframex/com.gameframex.unity.advertisement.kuaishouminigame.git"
}
```

**方式二：Unity Package Manager**

打开 `Window > Package Manager`，点击 `+` 选择 `Add package from git URL`，输入：

```
https://github.com/gameframex/com.gameframex.unity.advertisement.kuaishouminigame.git
```

**方式三：手动安装**

将本仓库克隆到 Unity 项目的 `Packages/` 目录下即可自动识别。

## 使用示例

本包为 `com.gameframex.unity.advertisement` 的子组件，不直接对外暴露接口。请通过主广告包统一调用：

- 主广告包：[com.gameframex.unity.advertisement](https://github.com/gameframex/com.gameframex.unity.advertisement)

## 架构概览

### 功能特性

- 激励视频广告加载与展示
- 广告加载/展示成功与失败回调
- 广告关闭时自动判断有效观看
- IL2CPP 代码裁剪防护（`Preserve` 属性 + `CroppingHelper`）
- 条件编译（`UNITY_WEBGL` + `ENABLE_KUAISHOU_MINI_GAME`）

### 依赖

| 依赖 | 说明 |
|:-----|:-----|
| `com.gameframex.unity.advertisement` | 广告主包，提供 `BaseAdvertisementManager` 基类 |
| `KSWASM` | 快手小游戏运行时库 |

### 项目结构

```
Runtime/
├── KuaiShouMiniGame/
│   ├── DouYinMiniGameAdvertisementManager.cs   # 广告管理器，继承 BaseAdvertisementManager
│   └── DouYinVideoAdCallback.cs                # 视频广告回调处理器
├── GameFrameXAdvertisementKuaiShouMiniGameCroppingHelper.cs  # 防裁剪辅助类
└── GameFrameX.Advertisement.KuaiShouMiniGame.Runtime.asmdef   # 程序集定义
```

## 平台支持

- 代码仅在 `UNITY_WEBGL` 且定义了 `ENABLE_KUAISHOU_MINI_GAME` 和 `ENABLE_KUAISHOU_MINI_GAME_ADVERTISEMENT` 宏时编译。

## 文档与资源

- [文档](https://gameframex.doc.alianblank.com)
- [更新日志](./CHANGELOG.md)

## 开源协议

[MIT](./LICENSE.md)
