using UnityEngine;

namespace EasyEasing
{
    public static class UseEase
    {
        // 汎用的なイージング関数
        public static float Ease(float t, float total, float begin, float end, EasingType easingType)
        {
            // t を 0 から 1 に正規化
            float normalizedT = Mathf.Clamp01(t / total); 
            float s = 1.70158f;
            float a = 0;
            float p = 0;

            // イージングタイプに応じて関数を選択
            switch (easingType)
            {
                case EasingType.Linear:
                    return EasingFunctions.EaseLinear(normalizedT, 1f, begin, end);
                case EasingType.EaseInQuad:
                    return EasingFunctions.EaseInQuad(normalizedT, 1f, begin, end);
                case EasingType.EaseOutQuad:
                    return EasingFunctions.EaseOutQuad(normalizedT, 1f, begin, end);
                case EasingType.EaseInOutQuad:
                    return EasingFunctions.EaseInOutQuad(normalizedT, 1f, begin, end);
                case EasingType.EaseInCubic:
                    return EasingFunctions.EaseInCubic(normalizedT, 1f, begin, end);
                case EasingType.EaseOutCubic:
                    return EasingFunctions.EaseOutCubic(normalizedT, 1f, begin, end);
                case EasingType.EaseInOutCubic:
                    return EasingFunctions.EaseInOutCubic(normalizedT, 1f, begin, end);
                case EasingType.EaseInQuart:
                    return EasingFunctions.EaseInQuart(normalizedT, 1f, begin, end);
                case EasingType.EaseOutQuart:
                    return EasingFunctions.EaseOutQuart(normalizedT, 1f, begin, end);
                case EasingType.EaseInOutQuart:
                    return EasingFunctions.EaseInOutQuart(normalizedT, 1f, begin, end);
                case EasingType.EaseInQuint:
                    return EasingFunctions.EaseInQuint(normalizedT, 1f, begin, end);
                case EasingType.EaseOutQuint:
                    return EasingFunctions.EaseOutQuint(normalizedT, 1f, begin, end);
                case EasingType.EaseInOutQuint:
                    return EasingFunctions.EaseInOutQuint(normalizedT, 1f, begin, end);
                case EasingType.EaseInSine:
                    return EasingFunctions.EaseInSine(normalizedT, 1f, begin, end);
                case EasingType.EaseOutSine:
                    return EasingFunctions.EaseOutSine(normalizedT, 1f, begin, end);
                case EasingType.EaseInOutSine:
                    return EasingFunctions.EaseInOutSine(normalizedT, 1f, begin, end);
                case EasingType.EaseInExpo:
                    return EasingFunctions.EaseInExpo(normalizedT, 1f, begin, end);
                case EasingType.EaseOutExpo:
                    return EasingFunctions.EaseOutExpo(normalizedT, 1f, begin, end);
                case EasingType.EaseInOutExpo:
                    return EasingFunctions.EaseInOutExpo(normalizedT, 1f, begin, end);
                case EasingType.EaseInCirc:
                    return EasingFunctions.EaseInCirc(normalizedT, 1f, begin, end);
                case EasingType.EaseOutCirc:
                    return EasingFunctions.EaseOutCirc(normalizedT, 1f, begin, end);
                case EasingType.EaseInOutCirc:
                    return EasingFunctions.EaseInOutCirc(normalizedT, 1f, begin, end);
                case EasingType.EaseInBack:
                    return EasingFunctions.EaseInBack(normalizedT, 1f, begin, end, s);
                case EasingType.EaseOutBack:
                    return EasingFunctions.EaseOutBack(normalizedT, 1f, begin, end, s);
                case EasingType.EaseInOutBack:
                    return EasingFunctions.EaseInOutBack(normalizedT, 1f, begin, end, s);
                case EasingType.EaseInBounce:
                    return EasingFunctions.EaseInBounce(normalizedT, 1f, begin, end);
                case EasingType.EaseOutBounce:
                    return EasingFunctions.EaseOutBounce(normalizedT, 1f, begin, end);
                case EasingType.EaseInOutBounce:
                    return EasingFunctions.EaseInOutBounce(normalizedT, 1f, begin, end);
                case EasingType.EaseInElastic:
                    return EasingFunctions.EaseInElastic(normalizedT, 1f, begin, end, a, p);
                case EasingType.EaseOutElastic:
                    return EasingFunctions.EaseOutElastic(normalizedT, 1f, begin, end, a, p);
                case EasingType.EaseInOutElastic:
                    return EasingFunctions.EaseInOutElastic(normalizedT, 1f, begin, end, a, p);
                default:
                    // デフォルトではLinearを使用
                    return EasingFunctions.EaseLinear(normalizedT, 1f, begin, end);
            }
        }
    }
}
