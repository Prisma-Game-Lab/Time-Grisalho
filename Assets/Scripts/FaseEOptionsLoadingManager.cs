using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FaseEOptionsLoadingManager : MonoBehaviour
{
    public bool estaNaFase = true;

    public void Update()
    {
        if (estaNaFase && (!GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled || !GameObject.Find("EventSystem").GetComponent<EventSystem>().enabled))
        {
            GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = true;
            GameObject.Find("EventSystem").GetComponent<EventSystem>().enabled = true;
        }
    }
}
