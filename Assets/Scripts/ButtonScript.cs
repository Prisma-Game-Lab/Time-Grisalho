using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
        if (SceneManager.loadedSceneCount != 1)
        {
            if(proximaCena == "Controles")
            {
                SceneManager.LoadScene(proximaCena, LoadSceneMode.Additive);
                fonte.Play();
            } else if (proximaCena == "Options do Controle")
            {
                SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(2));
            }
            else
            {
                CliqueOptionsParaFase();
            }
        }
        else
        {
            if (proximaCena == "Options" && SceneManager.GetActiveScene().name != "Controles")
            {
                OptionsButton.cenaAnteriorOptions = SceneManager.GetActiveScene().name;
            }
            scenesManager.GoToScene(proximaCena);
            fonte.Play();
        }
    }
    
    //vai pra options da fase principal sem dar unload na fase (pra manter a cena funcionando)
    public void CliqueFaseParaOptions()
    {
        if (proximaCena == "Options" && SceneManager.GetActiveScene().name != "Controles")
        {
            OptionsButton.cenaAnteriorOptions = SceneManager.GetActiveScene().name;
        }

        GameObject.Find("Troca de Cena Options Manager").GetComponent<FaseEOptionsLoadingManager>().estaNaFase = false;
        GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = false;
        GameObject.Find("EventSystem").GetComponent<EventSystem>().enabled = false;
        SceneManager.LoadScene(proximaCena, LoadSceneMode.Additive);
        fonte.Play();
    }

    public void CliqueOptionsParaFase()
    {
        GameObject.Find("Troca de Cena Options Manager").GetComponent<FaseEOptionsLoadingManager>().estaNaFase = true;
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(1));
        fonte.Play();
    }
}
