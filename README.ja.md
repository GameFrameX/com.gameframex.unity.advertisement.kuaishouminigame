<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Advertisement (KuaiShou Mini Game)

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.advertisement.kuaishouminigame)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.kuaishouminigame/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.advertisement.kuaishouminigame)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.kuaishouminigame/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

インディゲーム開発者向けオールインワンソリューション · インディ開発者の夢を支援

<br />

[ドキュメント](https://gameframex.doc.alianblank.com) · [クイックスタート](#quick-start) · QQグループ: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | **日本語** | [한국어](README.ko.md)

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

Unity プロジェクトの `Packages/manifest.json` を編集し、`scopedRegistries` セクションを追加してください：

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

`scopes` は、どのパッケージをこのレジストリから解決するかを制御します。`com.gameframex` で始まるパッケージのみがこのレジストリから取得されます。

Then add the package to `dependencies`:

```json
{
  "dependencies": {
    "com.gameframex.unity.advertisement.kuaishouminigame": "1.0.0"
  }
}
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
