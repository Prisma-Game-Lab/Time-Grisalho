using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//colocar na MainCamera pra controlar os elementos 
public class Desativa_Ativa_CertoErrado : MonoBehaviour
{
    public static Desativa_Ativa_CertoErrado Instancia;
    private GameObject certoUI, erradoUI;

    private void Start()
    {
        certoUI = GameObject.Find("CertoUI");
        erradoUI = GameObject.Find("ErradoUI");
        certoUI.SetActive(false);
        erradoUI.SetActive(false);
        if (Instancia == null)
        {
            Instancia = this;
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    //qual = 1 -> "certo" ou 2 -> "errado";
    public void Ativa_Certo_Errado(int qual)
    {
        if(qual == 1)
        {
            certoUI.SetActive(true);
        }
        if (qual == 2)
        {
            erradoUI.SetActive(true);
        }
    }

    //qual = 1 -> "certo" ou 2 -> "errado";
    public void Desativa_Certo_Errado(int qual)
    {
        if (qual == 1)
        {
            certoUI.SetActive(false);
        }
        if (qual == 2)
        {
            erradoUI.SetActive(false);
        }
    }
}
