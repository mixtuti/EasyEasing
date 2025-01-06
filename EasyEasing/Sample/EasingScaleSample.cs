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
