using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderTakenPicture : MonoBehaviour
{
    private RawImage rawImage;
    public static RenderTakenPicture Instancia;
    private void Awake()
    {
        rawImage = GameObject.Find("TakenPicture").GetComponent<RawImage>();
        if ( Instancia == null )
        {
            Instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ShowsTakenPicture(Sprite sprite)
    {
        if (sprite != null)
        {
            // Convert the Sprite to a Texture2D
            Texture2D texture = sprite.texture;

            // Assign the Texture2D to the RawImage
            rawImage.texture = texture;
        }
    }
}
