using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    private GameObject albumUI;
    void Start()
    {
        albumUI = GameObject.Find("AlbumUI");
        albumUI.SetActive(false);
    }
}
