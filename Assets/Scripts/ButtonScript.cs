using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        if (proximaCena == "Options" && SceneManager.GetActiveScene().name != "Controles")
        {
            OptionsButton.cenaAnteriorOptions = SceneManager.GetActiveScene().name;
        }
        scenesManager.GoToScene(proximaCena);
        fonte.Play();
    }
}
