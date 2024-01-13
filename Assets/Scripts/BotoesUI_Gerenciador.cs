using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotoesUI_Gerenciador : MonoBehaviour
{
    public GameObject[] lBotoesUI = new GameObject[2];

    public void AtivaBotoes()
    {
        foreach(GameObject botao in lBotoesUI)
        {
            botao.SetActive(true);
        }
    }

    public void DesativaBotoes()
    {
        foreach (GameObject botao in lBotoesUI)
        {
            botao.SetActive(false);
        }
    }
}
