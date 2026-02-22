using System;
using UnityEngine;
using UnityEngine.UI;

namespace SlimeColorShop
{
    public static class Utility
    {
        public static T GetRandomEnumValue<T>() where T : Enum
        {
            Array values = Enum.GetValues(typeof(T));
            return (T)values.GetValue(UnityEngine.Random.Range(0, values.Length));
        }

        public static long GetCurrentTimestamp()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

        public static void HideCanvasGroup(CanvasGroup canvasGroup)
        {
            canvasGroup.alpha = 0f;
            DisableCanvasGroupInteractable(canvasGroup);
        }

        public static void ShowCanvasGroup(CanvasGroup canvasGroup, bool isIncludingInteractable = true)
        {
            canvasGroup.alpha = 1f;
            if (isIncludingInteractable)
                EnableCanvasGroupInteractable(canvasGroup);
            else
                DisableCanvasGroupInteractable(canvasGroup);
        }

        public static void DisableCanvasGroupInteractable(CanvasGroup canvasGroup)
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }

        public static void EnableCanvasGroupInteractable(CanvasGroup canvasGroup)
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }

        public static Vector2 GetRandomPositionFromCenterBottomAnchoredRectTransform(RectTransform rectTransform)
        {
            float
                xMin = rectTransform.anchoredPosition.x - rectTransform.sizeDelta.x / 2f,
                xMax = rectTransform.anchoredPosition.x + rectTransform.sizeDelta.x / 2f,
                yMin = rectTransform.anchoredPosition.y,
                yMax = rectTransform.anchoredPosition.y + rectTransform.sizeDelta.y;
            
            return new Vector2(
                UnityEngine.Random.Range(xMin, xMax),
                UnityEngine.Random.Range(yMin, yMax)
            );
        }

        public static float GetPreferredWidth(RectTransform rectTransform)
        {
            float preferredWidth = LayoutUtility.GetPreferredWidth(rectTransform);
            return preferredWidth;
        }
    }
}
