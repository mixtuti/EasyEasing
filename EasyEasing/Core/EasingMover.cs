using UnityEngine;
using Cysharp.Threading.Tasks;

namespace EasyEasing
{
    public static class EasingMover
    {
        // イージングを使って指定された時間内で移動する
        public static async UniTask MoveEase(Transform target, Vector3 startPosition, Vector3 endPosition, float duration, EasingType easingType)
        {
            float elapsedTime = 0f;

            // 移動が完了するまで
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(elapsedTime / duration); // 0 から 1 に正規化

                // イージング関数で進行具合を計算
                float easedT = UseEase.Ease(elapsedTime, duration, startPosition.x, endPosition.x, easingType); // 修正：elapsedTimeを渡す

                // x, y, z軸それぞれにイージングを適用
                float easedY = UseEase.Ease(elapsedTime, duration, startPosition.y, endPosition.y, easingType);
                float easedZ = UseEase.Ease(elapsedTime, duration, startPosition.z, endPosition.z, easingType);

                // イージングを適用した位置を計算
                target.position = new Vector3(easedT, easedY, easedZ); 

                await UniTask.Yield(); // 次のフレームを待機
            }

            // 最終位置を確実に設定
            target.position = endPosition;
        }

        // イージングを使って指定された時間内で回転する
        public static async UniTask RotateEase(Transform target, Quaternion startRotation, Quaternion endRotation, float duration, EasingType easingType)
        {
            float elapsedTime = 0f;

            // 回転が完了するまで
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(elapsedTime / duration); // 0 から 1 に正規化
                float easedT = UseEase.Ease(t, 1f, 0f, 1f, easingType); // イージング処理

                // 回転にイージングを適用
                target.rotation = Quaternion.Slerp(startRotation, endRotation, easedT);

                await UniTask.Yield(); // 次のフレームを待機
            }

            // 最終回転を確実に設定
            target.rotation = endRotation;
        }

        // イージングを使って指定された時間内でスケールする
        public static async UniTask ScaleEase(Transform target, Vector3 startScale, Vector3 endScale, float duration, EasingType easingType)
        {
            float elapsedTime = 0f;

            // スケールが完了するまで
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(elapsedTime / duration); // 0 から 1 に正規化
                float easedT = UseEase.Ease(t, 1f, 0f, 1f, easingType); // イージング処理

                target.localScale = Vector3.Lerp(startScale, endScale, easedT); // イージングを適用したスケール

                await UniTask.Yield(); // 次のフレームを待機
            }

            // 最終スケールを確実に設定
            target.localScale = endScale;
        }

        // 2Dでの移動も同様に修正
        public static async UniTask MoveEase2D(Transform target, Vector3 startPosition, Vector3 endPosition, float duration, EasingType easingType)
        {
            float elapsedTime = 0f;

            // 2D移動（z軸は変更しない）
            Vector3 start = new Vector3(startPosition.x, startPosition.y, target.position.z);
            Vector3 end = new Vector3(endPosition.x, endPosition.y, target.position.z);

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(elapsedTime / duration); // 0 から 1 に正規化
                
                // イージング処理を適用
                float easedT = UseEase.Ease(elapsedTime, duration, start.x, end.x, easingType); // 修正：elapsedTimeを渡す
                float easedY = UseEase.Ease(elapsedTime, duration, start.y, end.y, easingType);

                // イージングを適用した位置を計算
                target.position = new Vector3(easedT, easedY, target.position.z); 

                await UniTask.Yield(); // 次のフレームを待機
            }

            // 最終位置を確実に設定（z軸はそのまま）
            target.position = end;
        }

        // イージングを使って指定された時間内で回転する (2D)
        public static async UniTask RotateEase2D(Transform target, float startRotation, float endRotation, float duration, EasingType easingType)
        {
            float elapsedTime = 0f;

            // 回転が完了するまで
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(elapsedTime / duration); // 0 から 1 に正規化
                float easedT = UseEase.Ease(t, 1f, 0f, 1f, easingType); // イージング処理

                // 回転にイージングを適用
                float currentRotation = Mathf.Lerp(startRotation, endRotation, easedT);

                // 回転を設定
                target.rotation = Quaternion.Euler(0f, 0f, currentRotation);

                await UniTask.Yield(); // 次のフレームを待機
            }

            // 最終回転を確実に設定
            target.rotation = Quaternion.Euler(0f, 0f, endRotation);
        }

        // イージングを使って指定された時間内でスケールする (2D)
        public static async UniTask ScaleEase2D(Transform target, Vector3 startScale, Vector3 endScale, float duration, EasingType easingType)
        {
            float elapsedTime = 0f;

            // 2Dスケール（z軸は変更しない）
            Vector3 start = new Vector3(startScale.x, startScale.y, target.localScale.z);
            Vector3 end = new Vector3(endScale.x, endScale.y, target.localScale.z);

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(elapsedTime / duration); // 0 から 1 に正規化
                float easedT = UseEase.Ease(t, 1f, 0f, 1f, easingType); // イージング処理

                // 2Dスケールにイージングを適用
                target.localScale = new Vector3(
                    Mathf.Lerp(start.x, end.x, easedT),
                    Mathf.Lerp(start.y, end.y, easedT),
                    target.localScale.z); // Z軸は変更しない

                await UniTask.Yield(); // 次のフレームを待機
            }

            // 最終スケールを確実に設定（z軸はそのまま）
            target.localScale = new Vector3(end.x, end.y, target.localScale.z);
        }
    }
}
