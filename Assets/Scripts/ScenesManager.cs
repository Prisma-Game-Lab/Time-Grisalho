using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    [SerializeField]
    private string nextScene;
    public void GoToScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
