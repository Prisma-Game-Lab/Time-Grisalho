using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaFotoUISegueMouse : MonoBehaviour
{
    private RectTransform rectTransform;

    private void Start()
    {
        // Get the RectTransform of the UI element
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        // Get the mouse position in screen space
        Vector3 mousePosition = Input.mousePosition;

        // Convert the screen space mouse position to canvas space
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform.parent as RectTransform, mousePosition, null, out Vector2 localPoint))
        {
            // Set the UI element's position to match the mouse position in canvas space
            rectTransform.localPosition = localPoint;
        }
    }
}