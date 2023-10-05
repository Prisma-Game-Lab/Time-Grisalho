using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class AlbumLayoutScript : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonPrefab;
    [SerializeField]
    private NumDeFases numDeFases;
    private void Start()
    {
        CreateButton();
    }

    private void CreateButton()
    {
        for (int i = 0; i < numDeFases.numeroDeFases; i++)
        {
            var newButton = Instantiate(buttonPrefab);
            newButton.transform.SetParent(gameObject.transform);
            newButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "Fase " + (i + 1).ToString();
            newButton.GetComponent<ScenesManager>().nextScene = "Fase " + (i + 1).ToString();
        }
    }
}
