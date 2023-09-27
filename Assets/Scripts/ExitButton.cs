using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void GoToScene()
    {
        Application.Quit();
        Debug.Log("saiu do jogo");
    }
}
