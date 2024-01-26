using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaiParaAlbumTelaFim : MonoBehaviour
{
    public GameObject GameUI, AlbumUI, FimUI, voltar_pFaseButton, voltar_pFimButton;

    private void Awake()
    {
        FimUI.SetActive(false);
        voltar_pFimButton.SetActive(false);
    }

    public void alternaDoFimParaAlbum()
    {
        AlbumUI.SetActive(true);
        FimUI.SetActive(false);
        voltar_pFaseButton.SetActive(false);
        voltar_pFimButton.SetActive(true);
    }

    public void ativaTelaDeFim()
    {
        GameUI.SetActive(false);
        AlbumUI.SetActive(false);
        FimUI.SetActive(true);
    }
}
