using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teclado : MonoBehaviour
{
    [SerializeField]
    public GameObject albumUI, gameUI, voltar;
    private void Start()
    {
        albumUI = GameObject.Find("Canvas").transform.Find("AlbumUI").gameObject;
        gameUI = GameObject.Find("Canvas").transform.Find("GameUI").gameObject;
    }
    private void Update()
    {
        if (albumUI.activeInHierarchy)
        {
            voltar = albumUI.transform.Find("Voltar").gameObject;
        }
        else
        {
            voltar = gameUI.transform.Find("Voltar").gameObject;
        }
    }

    public void Troca()
    {
        voltar.GetComponent<BotaoAlteraUI>().Clique();
    }
}
