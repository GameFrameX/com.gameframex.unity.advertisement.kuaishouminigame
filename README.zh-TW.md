<div align="center">

![GameFrameX Logo](https://download.alianblank.com/gameframex/gameframex_logo_320.png)

# Game Frame X Advertisement (KuaiShou Mini Game)

[![Version](https://img.shields.io/github/v/release/gameframex/com.gameframex.unity.advertisement.kuaishouminigame?label=version&color=green)](https://github.com/gameframex/com.gameframex.unity.advertisement.kuaishouminigame/releases)
[![License](https://img.shields.io/badge/license-MIT+Apache%202.0-orange.svg)](LICENSE.md)
[![Documentation](https://img.shields.io/badge/docs-gameframex-brightgreen.svg)](https://gameframex.doc.alianblank.com)

**獨立遊戲前後端一體化解決方案 · 獨立遊戲開發者的圓夢大使**

[📖 文檔](https://gameframex.doc.alianblank.com) • [🚀 快速開始](#快速開始) • [💬 QQ群](https://qm.qq.com/q/urCUAqJCJm)

---

🌐 **語言**: [English](README.md) | [简体中文](README.zh-CN.md) | **繁體中文** | [日本語](README.ja.md) | [한국어](README.ko.md)

---

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

1. 安裝[廣告核心套件](https://github.com/GameFrameX/com.gameframex.unity.advertisement)
2. 透過 Unity Package Manager (UPM) 新增本適配器：

```json
{
  "dependencies": {
    "com.gameframex.unity.advertisement": "https://github.com/GameFrameX/com.gameframex.unity.advertisement.git",
    "com.gameframex.unity.advertisement.kuaishouminigame": "https://github.com/gameframex/com.gameframex.unity.advertisement.kuaishouminigame.git"
  }
}
```

或在 Unity Package Manager 視窗中透過 git URL 新增。

### 使用範例

在 Unity Inspector 中設定：將 `AdvertisementComponent` 新增到 GameObject，然後在實作類型下拉選單中選擇 `KuaiShouMiniGameAdvertisementManager`。

```csharp
using GameFrameX.Advertisement.Runtime;

// 取得廣告元件（通常從遊戲入口取得）
var adComponent = GameEntry.GetComponent<AdvertisementComponent>();

// 設定伺服器端驗證資料（可選）
adComponent.SetExtraData("userId", player.UserId);

// 播放激勵影片廣告
var option = new AdvertisementPlayOption
{
    OnSuccess    = (data) => Debug.Log("廣告展示成功"),
    OnFail       = (err) => Debug.LogError($"廣告展示失敗: {err}"),
    OnShowResult = (watched) =>
    {
        if (watched)
        {
            // 發放獎勵
        }
    },
};
adComponent.Play(option);
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

## 開源協議

本專案基於 [MIT 授權](LICENSE.md) 和 [Apache 授權 2.0](LICENSE.md) 雙重授權。
