using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoAlteraUI : MonoBehaviour
{
    [SerializeField]
    private AudioClip som;
    private AudioSource fonte;
    public GameObject albumUI, gameUI;
    public string qual_UI_sera_ativada; // atualmente pode ser album ou game (pode escrever com maiuscula e minuscula, so nao pode ter letras diferentes dessas nem acentos)

    private void Start()
    {
        fonte = FindObjectOfType<AudioSource>();
        fonte.clip = som;
    }

    public void Clique()
    {
        if (qual_UI_sera_ativada.ToLower() == "album")
        {
            albumUI.SetActive(true);
            gameUI.SetActive(false);
        }
        else if (qual_UI_sera_ativada.ToLower() == "game")
        {
            albumUI.SetActive(false);
            gameUI.SetActive(true);
        }
        fonte.Play();
    }

    private void alternaUIesc()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameUI.activeSelf) 
            {
                albumUI.SetActive(true);
                gameUI.SetActive(false);
            }
            else if (albumUI.activeSelf)
            {
                albumUI.SetActive(false);
                gameUI.SetActive(true);
            }
        }
    }

    private void Update()
    {
        alternaUIesc();
    }
}
