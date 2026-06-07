<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Advertisement (KuaiShou Mini Game)

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.advertisement.kuaishouminigame)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.kuaishouminigame/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.advertisement.kuaishouminigame)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.kuaishouminigame/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

獨立遊戲前後端一體化解決方案 · 獨立遊戲開發者的圓夢大使

<br />

[文檔](https://gameframex.doc.alianblank.com) · [快速開始](#quick-start) · QQ群: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | **繁體中文** | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

## 項目簡介

[Game Frame X 廣告系統](https://github.com/GameFrameX/com.gameframex.unity.advertisement)的快手小遊戲平台適配器。為發佈到快手小遊戲平台的遊戲提供激勵影片廣告整合。

### 功能特性

- 基於快手小遊戲 SDK 的激勵影片廣告支援
- 自動載入廣告，展示失敗自動重試
- IL2CPP 程式碼裁剪保護
- 條件編譯（`ENABLE_KUAISHOU_MINI_GAME`、`ENABLE_KUAISHOU_MINI_GAME_ADVERTISEMENT`）
- 與 Game Frame X 廣告元件無縫整合

## 架構概覽

本套件是 Game Frame X 廣告核心 `BaseAdvertisementManager` 的**適配器實現**。透過 Unity Inspector 設定 `AdvertisementComponent` 後，自動發現並載入。

| 類別 | 說明 |
|------|------|
| `KuaiShouMiniGameAdvertisementManager` | 激勵影片廣告管理器 — 載入、展示及生命週期管理 |
| `KuaiShouVideoAdCallback` | 廣告載入/展示事件回調處理器 |
| `GameFrameXAdvertisementKuaiShouMiniGameCroppingHelper` | IL2CPP link.xml 替代方案 — 保留類型引用 |

## 快速開始

### 安裝

編輯 Unity 專案的 `Packages/manifest.json`，添加 `scopedRegistries` 部分：

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

`scopes` 控制哪些套件透過此註冊表解析。只有以 `com.gameframex` 開頭的套件才會從這個註冊表取得。

Then add the package to `dependencies`:

```json
{
  "dependencies": {
    "com.gameframex.unity.advertisement.kuaishouminigame": "1.0.0"
  }
}
```

## 平台支援

| 平台 | 支援 |
|------|------|
| 快手小遊戲 (WebGL) | 是 |
| Android | 否 |
| iOS | 否 |
| Standalone | 否 |

> 需要 `UNITY_WEBGL` 和 `ENABLE_KUAISHOU_MINI_GAME` 腳本巨集定義。

## 文檔與資源

- [Game Frame X 文檔](https://gameframex.doc.alianblank.com)
- [快手小遊戲開發者平台](https://mp.kuaishou.com/)

## 社區與支援

- QQ群：[加入](https://qm.qq.com/q/urCUAqJCJm)
- GitHub Issues：[回報問題](https://github.com/gameframex/com.gameframex.unity.advertisement.kuaishouminigame/issues)

## 更新日誌

### v1.0.0

- 初始發佈
- 支援快手小遊戲平台激勵影片廣告
- IL2CPP 裁剪保護


## 依賴

| 套件 | 說明 |
|------|------|
| (无) | - |

## 開源協議

詳見 [LICENSE.md](LICENSE.md) 檔案。
