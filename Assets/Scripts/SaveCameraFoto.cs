using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveCameraFoto : MonoBehaviour
{
    //get reference of camera from inspector
    private RenderTexture secondCameraRenderTexture;
    public static SaveCameraFoto Instancia;
    public RawImage rawImage { get; private set; }

    private void Awake()
    {
        secondCameraRenderTexture = GetComponent<Camera>().targetTexture;
        rawImage = GameObject.Find("TakenPicture").GetComponent<RawImage>();
        if (Instancia == null)
        {
            Instancia = this;
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowsTakenPicture(Sprite sprite, RawImage rawImage)
    {
        if (sprite != null)
        {
            // Convert the Sprite to a Texture2D
            Texture2D texture = sprite.texture;

            // Assign the Texture2D to the RawImage
            rawImage.texture = texture;
        }
    }

    //method to render from camera
    public Sprite CaptureScreen()
    {
        Texture2D texture = new Texture2D(secondCameraRenderTexture.width, secondCameraRenderTexture.height, TextureFormat.RGBA32, false);
        RenderTexture.active = secondCameraRenderTexture;
        texture.ReadPixels(new Rect(0, 0, secondCameraRenderTexture.width, secondCameraRenderTexture.height), 0, 0);
        texture.Apply();
        RenderTexture.active = null;

        // Create a sprite from the captured texture
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

        return sprite;
    }
}