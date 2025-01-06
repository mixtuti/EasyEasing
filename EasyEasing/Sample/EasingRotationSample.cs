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
