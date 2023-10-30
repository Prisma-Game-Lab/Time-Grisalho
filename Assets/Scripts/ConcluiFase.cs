using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConcluiFase : MonoBehaviour
{
    [SerializeField]
    private NumDeFases numDeFases;
    [SerializeField]
    private ScenesManager gerenciadorDeCena;
    [SerializeField]
    private float timer;
    private IEnumerator coroutine;
    private void Start()
    {
        gerenciadorDeCena = FindAnyObjectByType<ScenesManager>();
        coroutine = Espera();
    }
    public void AumentaNumeroDeFases()
    {
        StartCoroutine(coroutine);
    }

    private IEnumerator Espera()
    {
        string nomeFase = SceneManager.GetActiveScene().name;
        if (numDeFases.numeroDeFases <= (nomeFase[nomeFase.Length - 1] - '0'))
        {
            numDeFases.numeroDeFases++;
        }
        yield return new WaitForSeconds(timer);
        gerenciadorDeCena.GoToScene("Album");
    }
}
