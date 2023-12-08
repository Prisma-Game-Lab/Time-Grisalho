using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FotosReveladasManager : MonoBehaviour
{
    private List<GameObject> lFotosRev = new List<GameObject>(); // lista de fotos reveladas


    private void Awake()
    {
        for (int i = 0; i < GameObject.Find("Main Camera").GetComponent<InputCamera>().quantidadeDeFotos; i++)
        {
            lFotosRev.Add(GameObject.Find("Foto Rev " + (i + 1).ToString()));
            lFotosRev[i].SetActive(false);
        }
    }


    public void RevelaFoto(int fotoInd)
    {
        Debug.Log(fotoInd.ToString());  
        lFotosRev[fotoInd].SetActive(true);
    }
}
