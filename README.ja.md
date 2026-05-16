<div align="center">

![GameFrameX Logo](https://download.alianblank.com/gameframex/gameframex_logo_320.png)

# Game Frame X Advertisement (KuaiShou Mini Game)

[![Version](https://img.shields.io/github/v/release/gameframex/com.gameframex.unity.advertisement.kuaishouminigame?label=version&color=green)](https://github.com/gameframex/com.gameframex.unity.advertisement.kuaishouminigame/releases)
[![License](https://img.shields.io/badge/license-MIT+Apache%202.0-orange.svg)](LICENSE.md)
[![Documentation](https://img.shields.io/badge/docs-gameframex-brightgreen.svg)](https://gameframex.doc.alianblank.com)

**インディゲーム開発者向けオールインワンソリューション · インディ開発者の夢を支援**

[📖 ドキュメント](https://gameframex.doc.alianblank.com) • [🚀 クイックスタート](#クイックスタート) • [💬 QQグループ](https://qm.qq.com/q/urCUAqJCJm)

---

🌐 **言語**: [English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | **日本語** | [한국어](README.ko.md)

---

</div>

## プロジェクト概要

[Game Frame X 広告システム](https://github.com/GameFrameX/com.gameframex.unity.advertisement)の快手（クアイシォウ）ミニゲームプラットフォームアダプター。快手ミニゲームプラットフォームに公開するゲーム向けにリワード動画広告の統合を提供します。

### 機能

- 快手ミニゲーム SDK によるリワード動画広告サポート
- 広告の自動ロードと表示失敗時のリトライ
- IL2CPP コードストリッピング保護
- 条件付きコンパイル（`ENABLE_KUAISHOU_MINI_GAME`、`ENABLE_KUAISHOU_MINI_GAME_ADVERTISEMENT`）
- Game Frame X 広告コンポーネントとのシームレスな統合

## アーキテクチャ

本パッケージは Game Frame X 広告コアの `BaseAdvertisementManager` の**アダプター実装**です。Unity Inspector で `AdvertisementComponent` を設定することで自動的に検出・読み込みされます。

| クラス | 説明 |
|--------|------|
| `KuaiShouMiniGameAdvertisementManager` | リワード動画広告マネージャー — ロード、表示、ライフサイクル管理 |
| `KuaiShouVideoAdCallback` | 広告ロード/表示イベントのコールバックハンドラー |
| `GameFrameXAdvertisementKuaiShouMiniGameCroppingHelper` | IL2CPP link.xml の代替 — 型参照を保持 |

## クイックスタート

### インストール

1. [広告コアパッケージ](https://github.com/GameFrameX/com.gameframex.unity.advertisement)をインストール
2. 本アダプターを Unity Package Manager (UPM) で追加：

```json
{
  "dependencies": {
    "com.gameframex.unity.advertisement": "https://github.com/GameFrameX/com.gameframex.unity.advertisement.git",
    "com.gameframex.unity.advertisement.kuaishouminigame": "https://github.com/gameframex/com.gameframex.unity.advertisement.kuaishouminigame.git"
  }
}
```

または Unity Package Manager ウィンドウで git URL から追加。

### 使用例

Unity Inspector で設定：GameObject に `AdvertisementComponent` を追加し、実装タイプのドロップダウンから `KuaiShouMiniGameAdvertisementManager` を選択します。

```csharp
using GameFrameX.Advertisement.Runtime;

// 標準: GameEntry 経由（com.gameframex.unity.entry 非依存）
var adComponent = GameEntry.GetComponent<AdvertisementComponent>();

// サーバーサイド検証データを設定（オプション）
adComponent.SetExtraData("userId", player.UserId);

// リワード動画広告を再生
var option = new AdvertisementPlayOption
{
    OnSuccess    = (data) => Debug.Log("広告の表示に成功しました"),
    OnFail       = (err) => Debug.LogError($"広告の表示に失敗しました: {err}"),
    OnShowResult = (watched) =>
    {
        if (watched)
        {
            // ユーザーに報酬を付与
        }
    },
};
adComponent.Play(option);

// ショートカット: GameApp 経由（com.gameframex.unity.entry が必要）
GameApp.Advertisement.SetExtraData("userId", player.UserId);
var option2 = new AdvertisementPlayOption
{
    OnSuccess    = (data) => Debug.Log("広告の表示に成功しました"),
    OnFail       = (err) => Debug.LogError($"広告の表示に失敗しました: {err}"),
    OnShowResult = (watched) =>
    {
        if (watched)
        {
            // ユーザーに報酬を付与
        }
    },
};
GameApp.Advertisement.Play(option2);
```

## プラットフォーム対応

| プラットフォーム | 対応 |
|------------------|------|
| 快手ミニゲーム (WebGL) | はい |
| Android | いいえ |
| iOS | いいえ |
| Standalone | いいえ |

> `UNITY_WEBGL` と `ENABLE_KUAISHOU_MINI_GAME` スクリプト定義シンボルが必要です。

## ドキュメントとリソース

- [Game Frame X ドキュメント](https://gameframex.doc.alianblank.com)
- [快手ミニゲーム開発者ポータル](https://mp.kuaishou.com/)

## コミュニティとサポート

- QQグループ：[参加](https://qm.qq.com/q/urCUAqJCJm)
- GitHub Issues：[バグ報告](https://github.com/gameframex/com.gameframex.unity.advertisement.kuaishouminigame/issues)

## 変更履歴

### v1.0.0

- 初回リリース
- 快手ミニゲームプラットフォームのリワード動画広告対応
- IL2CPP ストリッピング保護

## ライセンス

本プロジェクトは [MIT ライセンス](LICENSE.md) および [Apache ライセンス 2.0](LICENSE.md) のデュアルライセンスです。
