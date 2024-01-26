using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    private GameObject albumUI;
    private static GameObject instance;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        albumUI = GameObject.Find("AlbumUI");
        albumUI.SetActive(false);

        if (instance == null)
        {
            instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
