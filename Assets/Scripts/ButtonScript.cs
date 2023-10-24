using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    [SerializeField]
    private AudioClip som;
    private AudioSource fonte;
    private ScenesManager scenesManager;
    [SerializeField]
    public string proximaCena;
    private void Start()
    {
        scenesManager = FindObjectOfType<ScenesManager>();
        fonte = FindObjectOfType<AudioSource>();
        fonte.clip = som;
    }

    public void Clique()
    {
        scenesManager.GoToScene(proximaCena);
        fonte.Play();
    }
}
