using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class optionsAtivaDesativaAudioEvent : MonoBehaviour
{
    // modo = ativa / modo = desativa
    public void ativaDesativa(string modo)
    {
        if (modo == "ativa")
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("MainCamera"))
            {
                print(go.scene.name);
                if (go.scene.name == "Options")
                {
                    go.GetComponent<AudioListener>().enabled = true;
                }
            }
            GameObject.FindObjectsOfType<EventSystem>()[1].enabled = true;
        } else if (modo == "desativa")
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("MainCamera"))
            {
                print(go.scene.name);
                if (go.scene.name == "Options")
                {
                    go.GetComponent<AudioListener>().enabled = false;
                }
            }
            GameObject.FindObjectsOfType<EventSystem>()[1].enabled = false;
        }
    }
}
