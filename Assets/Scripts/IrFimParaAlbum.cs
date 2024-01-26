using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IrFimParaAlbum : MonoBehaviour
{
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
        GameObject.Find("Main Camera").GetComponent<VaiParaAlbumTelaFim>().alternaDoFimParaAlbum();
        fonte.Play();
    }
}
