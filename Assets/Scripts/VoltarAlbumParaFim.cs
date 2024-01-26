using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoltarAlbumParaFim : MonoBehaviour
{
    public GameObject AlbumUI, FimUI;
    [SerializeField]
    private AudioClip som;
    private AudioSource fonte;

    private void Start()
    {
        fonte = FindObjectOfType<AudioSource>();
        fonte.clip = som;
    }

    public void Clique()
    {
        AlbumUI.gameObject.SetActive(false);
        FimUI.gameObject.SetActive(true);
        fonte.Play();
    }
}
