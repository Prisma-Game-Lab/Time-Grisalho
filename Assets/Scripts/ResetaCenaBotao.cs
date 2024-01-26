using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetaCena : MonoBehaviour
{
    [SerializeField]
    private AudioClip som;
    private AudioSource fonte;

    private void Start()
    {
        fonte = FindObjectOfType<AudioSource>();
        fonte.clip = som;
    }

    public void ResetaACena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        fonte.Play();
    }
}
