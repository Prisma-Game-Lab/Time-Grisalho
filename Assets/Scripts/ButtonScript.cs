using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
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
            if (proximaCena == "MainMenu")
            {
                scenesManager.GoToScene(proximaCena);
                fonte.Play();
            }
            cliqueOptionsInGame();
        }
        else
        {
            if (proximaCena == "Options" && SceneManager.GetActiveScene().name != "Controles")
            {
                OptionsButton.cenaAnteriorOptions = SceneManager.GetActiveScene().name;
            } if (proximaCena == "Options do Controle")
            {
                scenesManager.GoToScene("Options");
                fonte.Play();
                return;
            }
            print(proximaCena);
            scenesManager.GoToScene(proximaCena);
            fonte.Play();
        }
    }
    
    private void cliqueOptionsInGame()
    {
        if (proximaCena == "Controles")
        {
            GameObject.Find("Troca de Cena Options Manager").GetComponent<optionsAtivaDesativaAudioEvent>().ativaDesativa("desativa");
            SceneManager.LoadScene(proximaCena, LoadSceneMode.Additive);
            fonte.Play();
        }
        else if (proximaCena == "Options do Controle")
        {
            GameObject.Find("Troca de Cena Options Manager").GetComponent<optionsAtivaDesativaAudioEvent>().ativaDesativa("ativa");
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(2));
        }
        else
        {
            CliqueOptionsParaFase();
        }
    }

    //vai pra options da fase principal sem dar unload na fase (pra manter a cena funcionando)
    public void CliqueFaseParaOptions()
    {
        if (proximaCena == "Options" && SceneManager.GetActiveScene().name != "Controles")
        {
            OptionsButton.cenaAnteriorOptions = SceneManager.GetActiveScene().name;
        }

        GameObject.Find("Troca de Cena Fase Manager").GetComponent<FaseEOptionsLoadingManager>().estaNaFase = false;
        GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = false;
        GameObject.Find("EventSystem").GetComponent<EventSystem>().enabled = false;
        SceneManager.LoadScene(proximaCena, LoadSceneMode.Additive);
        fonte.Play();
    }

    public void CliqueOptionsParaFase()
    {
        GameObject.Find("Troca de Cena Fase Manager").GetComponent<FaseEOptionsLoadingManager>().estaNaFase = true;
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(1));
        fonte.Play();
    }
}
