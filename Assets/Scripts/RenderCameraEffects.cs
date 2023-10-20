using UnityEngine;

public class RenderCameraEffects : MonoBehaviour
{
    public Camera renderCamera;
    public float zoomSpeed = 1.0f;
    public float minSize = 0.7f; // Minimum orthographic size
    public float maxSize = 4.5f; // Maximum orthographic size
    private float scrollInput;

    void Update()
    {
        // Get the scroll wheel input
        scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // Update the orthographic size of the camera based on the scroll input
        renderCamera.orthographicSize -= scrollInput * zoomSpeed;

        // Use Mathf.Clamp to restrict the orthographic size within the defined range
        renderCamera.orthographicSize = Mathf.Clamp(renderCamera.orthographicSize, minSize, maxSize);
    }
}
