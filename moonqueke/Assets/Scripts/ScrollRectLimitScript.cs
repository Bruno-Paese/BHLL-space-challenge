using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRectLimitScript : MonoBehaviour
{
    public ScrollRect scrollRect;
    public float maxScrollX = 100.0f; // Adjust this to set the maximum horizontal scroll position.
    public float maxScrollY = 100.0f; // Adjust this to set the maximum vertical scroll position.

    private void Update()
    {
        // Ensure that the content position stays within the defined bounds.
        Vector2 clampedPosition = new Vector2(
            Mathf.Clamp(scrollRect.content.anchoredPosition.x, -maxScrollX, maxScrollX),
            Mathf.Clamp(scrollRect.content.anchoredPosition.y, -maxScrollY, maxScrollY)
        );

        scrollRect.content.anchoredPosition = clampedPosition;
    }
}
