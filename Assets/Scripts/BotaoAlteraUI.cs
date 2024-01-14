using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoAlteraUI : MonoBehaviour
{
    [SerializeField]
    private AudioClip som;
    private AudioSource fonte;
    public GameObject albumUI, gameUI;

    private void Start()
    {
        albumUI = GameObject.Find("Canvas").transform.Find("AlbumUI").gameObject;
        gameUI = GameObject.Find("Canvas").transform.Find("GameUI").gameObject;
        fonte = FindObjectOfType<AudioSource>();
        fonte.clip = som;
    }

    public void Clique()
    {
        if (gameUI.activeSelf)
        {
            albumUI.SetActive(true);
            gameUI.SetActive(false);
        }
        else
        {
            albumUI.SetActive(false);
            gameUI.SetActive(true);
        }
        fonte.Play();
    }
}
