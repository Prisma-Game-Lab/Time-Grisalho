using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : MonoBehaviour
{

    [SerializeField]
    private AudioClip som;
    private AudioSource fonte;
    private ScenesManager scenesManager;
    public static string cenaAnteriorOptions;
    private void Start()
    {
        scenesManager = FindObjectOfType<ScenesManager>();
        fonte = FindObjectOfType<AudioSource>();
        fonte.clip = som;
    }

    public void Clique()
    {
        scenesManager.GoToScene(cenaAnteriorOptions);
        fonte.Play();
    }
}

