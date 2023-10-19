using UnityEngine;

public class MoveRenderCamera : MonoBehaviour
{
    private Vector3 mousePosition;
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition; // Place the camera at the mouse position   
    }
}
