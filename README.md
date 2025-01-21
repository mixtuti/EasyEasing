# EasyEasing

![代替テキスト](https://img.shields.io/badge/Unity-2022.3+-orange) <img src="http://img.shields.io/badge/UniTask-2.5.10-orange.svg?style=flat"> <img src="http://img.shields.io/badge/License-MIT-blue.svg?style=flat"> <img src="http://img.shields.io/badge/Language-C%23-green.svg?style=flat"><br>
Unityで使用できるイージング関数をまとめたライブラリ

## システム要件

Unity 2022.3.28 での動作は確認済みです。</br>
UniTask 2.5.10 が必要になります。

https://github.com/Cysharp/UniTask

## 概要

このライブラリは、Unityにおけるアニメーションでイージングを使用するためのツールです。<br>
オブジェクトの移動、回転、スケーリングを滑らかに制御するために、複数のイージング関数を簡単に適用できます。

## 依存関係

UniTask 2.5.10

## 導入方法

### 1. プロジェクトへの導入
導入方法は大きく分けて2つあります。お好きな方法で導入してください。

#### 1. Unity Package Managerを使う方法
「Window > Package Manager」を開き、「Add Package from git URL」を選択します。<br>
その後、以下のURLを入力してください。
```
https://github.com/mixtuti/EasyEasing?path=EasyEasing
```
#### 2. Import Packageを使う方法
リリースから最新のUnity Packageをダウンロードし、インポートします。
> [!TIP]
> 更新が遅くなることが多いので1の方法を使うことをお勧めします。

### 2. 利用方法
イージングを利用するスクリプトの先頭に
```cs
using EasyEasing;
using Cysharp.Threading.Tasks;
```
と記述することで利用できます。

## 実装しているイージングの種類

### 線形補間 (Linear)
---
#### Linear<br>
一定速度で動くシンプルな補間。

### 2次補間 (Quad)
---
#### EaseInQuad<br>
最初は遅く、最後は速く動く。
#### EaseOutQuad
最初は速く、最後は遅く動く。
#### EaseInOutQuad
最初と最後は遅く、途中は速く動く。

### 3次補間 (Cubic)
---
#### EaseInCubic
最初は遅く、途中で速く、最後はゆっくり動く。
#### EaseOutCubic
最初は速く、途中で遅く、最後はゆっくり動く。
#### EaseInOutCubic
最初と最後は遅く、途中は速く動く。

### 4次補間 (Quart)
---
#### EaseInQuart
最初は遅く、最後は速く動く（3次補間より強く加速）。
#### EaseOutQuart
最初は速く、最後は遅く動く（3次補間より強く減速）。
#### EaseInOutQuart
最初と最後は遅く、途中は速く動く（3次補間より強く加減速）。

### 5次補間 (Quint)
---
#### EaseInQuint
最初は遅く、最後は非常に速く動く。
#### EaseOutQuint
最初は速く、最後は非常に遅く動く。
#### EaseInOutQuint
最初と最後は遅く、途中は非常に速く動く。

### 正弦波補間 (Sine)
---
#### EaseInSine
正弦波のような自然な動きで、最初と最後は遅く、途中は速く。
#### EaseOutSine
最初は速く、最後は遅く動く。
#### EaseInOutSine
最初と最後は遅く、途中は速く動く。

### 指数補間 (Expo)
---
#### EaseInExpo
初めは遅く、途中で急激に加速する。
#### EaseOutExpo
最初は速く、途中で急激に減速する。
#### EaseInOutExpo
最初と最後は遅く、途中で急激に加減速する。

### 円弧補間 (Circ)
---
#### EaseInCirc
初めは遅く、途中で速く、最後は急に減速する。
#### EaseOutCirc
最初は速く、途中で減速する。
#### EaseInOutCirc
最初と最後は遅く、途中は速く動く。

### バック補間 (Back)
---
#### EaseInBack
初めに少し戻るように動き、最後に加速する。
#### EaseOutBack
初めは速く動き、最後に少し戻るように減速する。
#### EaseInOutBack
最初と最後は遅く、途中は速く、最終的に戻るように動く。

### バウンス補間 (Bounce)
---
#### EaseInBounce
弾むように動き、最後に弾む。
#### EaseOutBounce
最初は速く、最後に弾むように動く。
#### EaseInOutBounce
最初と最後は遅く、途中で弾むように動く。

### ばね補間 (Elastic)
---
#### EaseInElastic
弾力のある動きで、最初に引き戻された後に加速する。
#### EaseOutElastic
最初は速く、最後に弾力のある動きで減速する。
#### EaseInOutElastic
最初と最後は遅く、途中で弾力のある動きで加減速する。

## スクリプトの解説

### 1. UseEase.cs
複数のイージングタイプに基づく補間計算を行うためのクラスです。<br>
このクラスでは、指定したイージングタイプに従い、時間の経過とともに値がどのように変化するかを計算する汎用的な Ease 関数を提供します。

## 関数

### 1. Ease(float t, float total, float begin, float end, EasingType easingType)
指定された進行度に基づいて、イージングを適用した値を計算するメソッド。<br>
- 引数:
  - t (float): 現在の進行度を示す値（通常は 0 から total の範囲の数値）。
  - total (float): アニメーションの総時間（例: アニメーションが完了するまでの時間）。
  - begin (float): アニメーション開始時の値（アニメーションの開始点）。
  - end (float): アニメーション終了時の値（アニメーションの終了点）。
  - easingType (EasingType): 使用するイージング関数のタイプ。
- 戻り値: float型の補間後の現在の値<br>
指定された進行度に基づいてイージングを計算し、補間後の値を返します。<br>
easingType に応じて、様々な補間方法（例えば、線形、二次補間、三次補間など）が選択され、アニメーションに自然な加速や減速を適用します。

### 2. MoveEase(Transform target, Vector3 startPosition, Vector3 endPosition, float duration, EasingType easingType)
指定された時間内でイージングを使って対象オブジェクトを移動させるメソッド。<br>
- 引数:
  - target (Transform): 移動させる対象の Transform。
  - startPosition (Vector3): 移動開始時の位置。
  - endPosition (Vector3): 移動終了時の位置。
  - duration (float): 移動にかかる時間（秒）。
  - easingType (EasingType): 使用するイージングタイプ（線形補間やカスタム補間など）。
- 戻り値: UniTask 型（非同期処理）<br>
このメソッドは、対象オブジェクトを指定した開始位置から終了位置に向けて、イージングを適用しながら移動させます。<br>
移動が進行する間、各フレームでイージング関数が呼ばれ、スムーズに進行します。

### 3. RotateEase(Transform target, Quaternion startRotation, Quaternion endRotation, float duration, EasingType easingType)
指定された時間内でイージングを使って対象オブジェクトを回転させるメソッド。<br>
- 引数:
  - target (Transform): 回転させる対象の Transform。
  - startRotation (Quaternion): 回転開始時の回転（Quaternion 型）。
  - endRotation (Quaternion): 回転終了時の回転（Quaternion 型）。
  - duration (float): 回転にかかる時間（秒）。
  - easingType (EasingType): 使用するイージングタイプ（線形補間やカスタム補間など）。
- 戻り値: UniTask 型（非同期処理）<br>
このメソッドは、対象オブジェクトを指定した開始回転から終了回転に向けて、イージングを適用しながら回転させます。<br>
回転はクォータニオン補間（Quaternion.Slerp）を用いてスムーズに行われます。

### 4. ScaleEase(Transform target, Vector3 startScale, Vector3 endScale, float duration, EasingType easingType)
指定された時間内でイージングを使って対象オブジェクトのスケールを変更するメソッド。<br>
- 引数:
  - target (Transform): スケールを変更する対象の Transform。
  - startScale (Vector3): スケール変更開始時のスケール。
  - endScale (Vector3): スケール変更終了時のスケール。
  - duration (float): スケール変更にかかる時間（秒）。
  - easingType (EasingType): 使用するイージングタイプ（線形補間やカスタム補間など）。
- 戻り値: UniTask 型（非同期処理）<br>
このメソッドは、対象オブジェクトを指定した開始スケールから終了スケールに向けて、イージングを適用しながらスケール変更を行います。<br>
スケールの補間には Vector3.Lerp が使用され、進行具合に応じてスムーズにサイズが変更されます。

### 5. MoveEase2D(Transform target, Vector3 startPosition, Vector3 endPosition, float duration, EasingType easingType)
2D環境で指定された時間内でイージングを使って対象オブジェクトを移動させるメソッド。<br>
- 引数:
  - target (Transform): 移動させる対象の Transform。
  - startPosition (Vector3): 移動開始時の位置。
  - endPosition (Vector3): 移動終了時の位置。
  - duration (float): 移動にかかる時間（秒）。
  - easingType (EasingType): 使用するイージングタイプ（線形補間やカスタム補間など）。
- 戻り値: UniTask 型（非同期処理）<br>
このメソッドは、対象オブジェクトを指定した開始位置から終了位置に向けて、イージングを適用しながら移動させます。<br>
2Dでの移動であり、Z軸の位置は変更されません。

### 6. RotateEase2D(Transform target, float startRotation, float endRotation, float duration, EasingType easingType)
2D環境で指定された時間内でイージングを使って対象オブジェクトを回転させるメソッド。<br>
- 引数:
  - target (Transform): 回転させる対象の Transform。
  - startRotation (float): 回転開始時の角度（度数）。
  - endRotation (float): 回転終了時の角度（度数）。
  - duration (float): 回転にかかる時間（秒）。
  - easingType (EasingType): 使用するイージングタイプ（線形補間やカスタム補間など）。
- 戻り値: UniTask 型（非同期処理）<br>
このメソッドは、対象オブジェクトを指定した開始回転から終了回転に向けて、イージングを適用しながら回転させます。<br>
回転は角度補間（Mathf.Lerp）を用いて行われ、スムーズに進行します。

### 7. ScaleEase2D(Transform target, Vector3 startScale, Vector3 endScale, float duration, EasingType easingType)
2D環境で指定された時間内でイージングを使って対象オブジェクトのスケールを変更するメソッド。<br>
- 引数:
  - target (Transform): スケールを変更する対象の Transform。
  - startScale (Vector3): スケール変更開始時のスケール。
  - endScale (Vector3): スケール変更終了時のスケール。
  - duration (float): スケール変更にかかる時間（秒）。
  - easingType (EasingType): 使用するイージングタイプ（線形補間やカスタム補間など）。
- 戻り値: UniTask 型（非同期処理）<br>
このメソッドは、対象オブジェクトを指定した開始スケールから終了スケールに向けて、イージングを適用しながらスケール変更を行います。<br>
2Dのスケール変更では、Z軸のスケールは変更されません。

## リファレンス
```cs
using UnityEngine;
using EasyEasing;
using Cysharp.Threading.Tasks;

public class EasingSample : MonoBehaviour
{
    public Transform target;
    public Vector3 targetPosition;
    public float duration = 2f;
    public EasingType easingType = EasingType.EaseInOutQuad;

    void Start()
    {
        // 移動を非同期で行う
        MoveSprite().Forget();
    }

    // 移動処理を行う非同期メソッド
    private async UniTaskVoid MoveSprite()
    {
        // 2D移動をイージングで行う
        await EasingMover.MoveEase2D(target, transform.position, targetPosition, duration, easingType);
    }
}
```
```cs
using UnityEngine;
using EasyEasing;
using Cysharp.Threading.Tasks;

public class EasingScaleSample : MonoBehaviour
{
    public Transform target;
    public float duration = 2f;
    public Vector3 targetScale;
    public EasingType easingType = EasingType.EaseInOutQuad;

    void Start()
    {
        // スケールの変更を非同期で行う
        ScaleSprite().Forget();
    }

    // スケール処理を行う非同期メソッド
    private async UniTaskVoid ScaleSprite()
    {
        // スケール処理をイージングで行う
        await EasingMover.ScaleEase2D(target, target.localScale, targetScale, duration, easingType);
    }
}
```
```cs
using UnityEngine;
using EasyEasing;
using Cysharp.Threading.Tasks;

public class EasingRotationSample : MonoBehaviour
{
    public Transform target;          // 回転させる対象のTransform
    public float duration = 2f;       // 回転にかける時間
    public float targetRotation;      // 目標回転角度（度数）
    public EasingType easingType = EasingType.EaseInOutQuad; // イージングタイプ

    void Start()
    {
        // 回転の変更を非同期で行う
        RotateSprite().Forget();
    }

    // 回転処理を行う非同期メソッド
    private async UniTaskVoid RotateSprite()
    {
        // 開始回転角度（現在のZ軸の回転角度）
        float startRotation = target.eulerAngles.z;

        // 回転処理をイージングで行う
        await EasingMover.RotateEase2D(target, startRotation, targetRotation, duration, easingType);
    }
}
```
