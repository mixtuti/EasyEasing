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
