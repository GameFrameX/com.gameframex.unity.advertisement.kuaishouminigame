<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Advertisement (KuaiShou Mini Game)

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.advertisement.kuaishouminigame)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.kuaishouminigame/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.advertisement.kuaishouminigame)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.kuaishouminigame/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

All-in-One Solution for Indie Game Development · Empowering Indie Developers' Dreams

<br />

[Documentation](https://gameframex.doc.alianblank.com) · [Quick Start](#quick-start) · QQ Group: 467608841 / 233840761

<br />

**English** | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

## Project Overview

KuaiShou Mini Game platform adapter for the [Game Frame X Advertisement](https://github.com/GameFrameX/com.gameframex.unity.advertisement) system. This package provides rewarded video ad integration for games published on the KuaiShou Mini Game platform.

### Features

- Rewarded video ad support via KuaiShou Mini Game SDK
- Automatic ad loading with show-failure retry
- IL2CPP code stripping protection
- Conditional compilation (`ENABLE_KUAISHOU_MINI_GAME`, `ENABLE_KUAISHOU_MINI_GAME_ADVERTISEMENT`)
- Seamless integration with the Game Frame X Advertisement component

## Architecture

This package is an **adapter implementation** of `BaseAdvertisementManager` from the Game Frame X Advertisement core. It is discovered and loaded automatically by `AdvertisementComponent` via Unity Inspector configuration.

| Class | Description |
|-------|-------------|
| `KuaiShouMiniGameAdvertisementManager` | Rewarded video ad manager — load, show, and lifecycle |
| `KuaiShouVideoAdCallback` | Callback handler for ad load/show events |
| `GameFrameXAdvertisementKuaiShouMiniGameCroppingHelper` | IL2CPP link.xml alternative — preserves type references |

## Quick Start

### Installation

Choose one of the following methods:

1. Edit your Unity project's `Packages/manifest.json` and add the `scopedRegistries` section:
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
     ],
     "dependencies": {
       "com.gameframex.unity.advertisement.kuaishouminigame": "1.0.0"
     }
   }
   ```

   `scopes` controls which packages are resolved through this registry. Only packages whose names start with `com.gameframex` will be fetched from it.

2. Add to `manifest.json` dependencies:
   ```json
   {
      "com.gameframex.unity.advertisement.kuaishouminigame": "https://github.com/gameframex/com.gameframex.unity.advertisement.kuaishouminigame.git"
   }
   ```
3. Use **Package Manager** in Unity with **Git URL**: `https://github.com/gameframex/com.gameframex.unity.advertisement.kuaishouminigame.git`
4. Clone the repository into your Unity project's `Packages` directory. It will be loaded automatically.
## Platform Support

| Platform | Supported |
|----------|-----------|
| KuaiShou Mini Game (WebGL) | Yes |
| Android | No |
| iOS | No |
| Standalone | No |

> Requires `UNITY_WEBGL` and `ENABLE_KUAISHOU_MINI_GAME` scripting define symbols.

## Documentation & Resources

- [Game Frame X Documentation](https://gameframex.doc.alianblank.com)
- [KuaiShou Mini Game Developer Portal](https://mp.kuaishou.com/)

## Community & Support

- QQ Group: [Join](https://qm.qq.com/q/urCUAqJCJm)
- GitHub Issues: [Report a bug](https://github.com/gameframex/com.gameframex.unity.advertisement.kuaishouminigame/issues)

## Changelog

### v1.0.0

- Initial release
- Rewarded video ad support for KuaiShou Mini Game platform
- IL2CPP cropping protection


## Dependencies

| Package | Description |
|---------|-------------|
| (无) | - |

## License

See [LICENSE.md](LICENSE.md) for license information.
