<div align="center">

![GameFrameX Logo](https://download.alianblank.com/gameframex/gameframex_logo_320.png)

# Game Frame X - KuaiShou Mini Game Advertisement

[![Version](https://img.shields.io/github/v/release/gameframex/com.gameframex.unity.advertisement.kuaishouminigame?label=version&color=green)](https://github.com/gameframex/com.gameframex.unity.advertisement.kuaishouminigame/releases)
[![License](https://img.shields.io/badge/license-MIT+Apache%202.0-orange.svg)](LICENSE.md)
[![Documentation](https://img.shields.io/badge/docs-gameframex-brightgreen.svg)](https://gameframex.doc.alianblank.com)

**All-in-One Solution for Indie Game Development · Empowering Indie Developers' Dreams**

[📖 Documentation](https://gameframex.doc.alianblank.com) • [🚀 Quick Start](#quick-start)

---

🌐 **Language**: **English** | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

---

</div>

## Project Overview

KuaiShou Mini Game ad adapter layer for the GameFrameX advertisement component. Built on the KuaiShou Mini Game SDK, it wraps rewarded video ad loading, display, and lifecycle management.

## Quick Start

**Option 1: Edit `manifest.json`**

```json
{
  "com.gameframex.unity.advertisement.kuaishouminigame": "https://github.com/gameframex/com.gameframex.unity.advertisement.kuaishouminigame.git"
}
```

**Option 2: Unity Package Manager**

Open `Window > Package Manager`, click `+` and select `Add package from git URL`:

```
https://github.com/gameframex/com.gameframex.unity.advertisement.kuaishouminigame.git
```

**Option 3: Manual Install**

Clone this repository into your Unity project's `Packages/` directory. It will be detected automatically.

## Usage Examples

This package is a sub-component of `com.gameframex.unity.advertisement` and does not expose public APIs directly. Use the main advertisement package for unified access:

- Main package: [com.gameframex.unity.advertisement](https://github.com/gameframex/com.gameframex.unity.advertisement)

## Architecture

### Features

- Rewarded video ad loading and display
- Ad load/show success and failure callbacks
- Automatic valid-view detection on ad close
- IL2CPP code stripping protection (`Preserve` attribute + `CroppingHelper`)
- Conditional compilation (`UNITY_WEBGL` + `ENABLE_KUAISHOU_MINI_GAME`)

### Dependencies

| Dependency | Description |
|:-----------|:------------|
| `com.gameframex.unity.advertisement` | Main ad package, provides `BaseAdvertisementManager` base class |
| `KSWASM` | KuaiShou Mini Game runtime library |

### Project Structure

```
Runtime/
├── KuaiShouMiniGame/
│   ├── DouYinMiniGameAdvertisementManager.cs   # Ad manager, inherits BaseAdvertisementManager
│   └── DouYinVideoAdCallback.cs                # Video ad callback handler
├── GameFrameXAdvertisementKuaiShouMiniGameCroppingHelper.cs  # Anti-stripping helper
└── GameFrameX.Advertisement.KuaiShouMiniGame.Runtime.asmdef   # Assembly definition
```

## Platform Support

- Code compiles only when `UNITY_WEBGL`, `ENABLE_KUAISHOU_MINI_GAME`, and `ENABLE_KUAISHOU_MINI_GAME_ADVERTISEMENT` are defined.

## Documentation & Resources

- [Documentation](https://gameframex.doc.alianblank.com)
- [Changelog](./CHANGELOG.md)

## License

[MIT](./LICENSE.md)
