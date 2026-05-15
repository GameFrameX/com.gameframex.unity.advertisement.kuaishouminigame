<div align="center">

![GameFrameX Logo](https://download.alianblank.com/gameframex/gameframex_logo_320.png)

# Game Frame X - クアイシォウミニゲーム広告

[![Version](https://img.shields.io/github/v/release/gameframex/com.gameframex.unity.advertisement.kuaishouminigame?label=version&color=green)](https://github.com/gameframex/com.gameframex.unity.advertisement.kuaishouminigame/releases)
[![License](https://img.shields.io/badge/license-MIT+Apache%202.0-orange.svg)](LICENSE.md)
[![Documentation](https://img.shields.io/badge/docs-gameframex-brightgreen.svg)](https://gameframex.doc.alianblank.com)

**インディゲーム開発者向けオールインワンソリューション · インディ開発者の夢を支援**

[📖 ドキュメント](https://gameframex.doc.alianblank.com) • [🚀 クイックスタート](#クイックスタート)

---

🌐 **言語**: [English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | **日本語** | [한국어](README.ko.md)

---

</div>

## プロジェクト概要

GameFrameX 広告コンポーネントのクアイシォウ（快手）ミニゲーム適配レイヤー。クアイシォウミニゲーム SDK をベースに、リワード動画広告の読み込み、表示、ライフサイクル管理をラップしています。

## クイックスタート

**方法1：`manifest.json` を編集**

```json
{
  "com.gameframex.unity.advertisement.kuaishouminigame": "https://github.com/gameframex/com.gameframex.unity.advertisement.kuaishouminigame.git"
}
```

**方法2：Unity Package Manager**

`Window > Package Manager` を開き、`+` をクリックして `Add package from git URL` を選択：

```
https://github.com/gameframex/com.gameframex.unity.advertisement.kuaishouminigame.git
```

**方法3：手動インストール**

このリポジトリを Unity プロジェクトの `Packages/` ディレクトリにクローンすると自動的に認識されます。

## 使用例

このパッケージは `com.gameframex.unity.advertisement` のサブコンポーネントであり、公開 API を直接公開しません。メイン広告パッケージから統一的にアクセスしてください：

- メインパッケージ：[com.gameframex.unity.advertisement](https://github.com/gameframex/com.gameframex.unity.advertisement)

## アーキテクチャ

### 機能

- リワード動画広告の読み込みと表示
- 広告の読み込み/表示の成功・失敗コールバック
- 広告クローズ時の有効視聴自動判定
- IL2CPP コードストリッピング対策（`Preserve` 属性 + `CroppingHelper`）
- 条件付きコンパイル（`UNITY_WEBGL` + `ENABLE_KUAISHOU_MINI_GAME`）

### 依存関係

| 依存関係 | 説明 |
|:---------|:-----|
| `com.gameframex.unity.advertisement` | メイン広告パッケージ、`BaseAdvertisementManager` 基底クラスを提供 |
| `KSWASM` | クアイシォウミニゲームランタイムライブラリ |

### プロジェクト構成

```
Runtime/
├── KuaiShouMiniGame/
│   ├── DouYinMiniGameAdvertisementManager.cs   # 広告マネージャー、BaseAdvertisementManager を継承
│   └── DouYinVideoAdCallback.cs                # 動画広告コールバックハンドラー
├── GameFrameXAdvertisementKuaiShouMiniGameCroppingHelper.cs  # ストリッピング防止ヘルパー
└── GameFrameX.Advertisement.KuaiShouMiniGame.Runtime.asmdef   # アセンブリ定義
```

## プラットフォーム対応

- コードは `UNITY_WEBGL`、`ENABLE_KUAISHOU_MINI_GAME`、および `ENABLE_KUAISHOU_MINI_GAME_ADVERTISEMENT` が定義されている場合のみコンパイルされます。

## ドキュメントとリソース

- [ドキュメント](https://gameframex.doc.alianblank.com)
- [変更履歴](./CHANGELOG.md)

## ライセンス

[MIT](./LICENSE.md)
