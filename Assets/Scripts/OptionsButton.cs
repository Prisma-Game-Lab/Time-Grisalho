using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (SceneManager.loadedSceneCount != 1)
        {
            CliqueOptionsParaFase();
        }
        scenesManager.GoToScene(cenaAnteriorOptions);
        fonte.Play();
    }

    public void CliqueOptionsParaFase()
    {
        GameObject.Find("Troca de Cena Fase Manager").GetComponent<FaseEOptionsLoadingManager>().estaNaFase = true;
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(1));
        fonte.Play();
    }
}

