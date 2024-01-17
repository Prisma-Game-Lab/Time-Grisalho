using UnityEngine;

public class RenderCameraEffects : MonoBehaviour
{
    [SerializeField]
    private Camera renderCamera;
    [SerializeField]
    private Camera revealCamera;
    public float zoomSpeed = 1.0f;
    public float minSize = 0.7f; // Minimum orthographic size
    public float maxSize = 4.5f; // Maximum orthographic size
    private float scrollInput;

    private void Start()
    {
        renderCamera = GetComponent<Camera>();
        revealCamera = gameObject.transform.GetChild(0).GetComponent<Camera>();

    }
    void Update()
    {
        // Get the scroll wheel input
        scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // Update the orthographic size of the camera based on the scroll input
        renderCamera.orthographicSize -= scrollInput * zoomSpeed;
        revealCamera.orthographicSize -= scrollInput * zoomSpeed;

        // Use Mathf.Clamp to restrict the orthographic size within the defined range
        renderCamera.orthographicSize = Mathf.Clamp(renderCamera.orthographicSize, minSize, maxSize);
        revealCamera.orthographicSize = Mathf.Clamp(renderCamera.orthographicSize, minSize, maxSize);
    }
}
