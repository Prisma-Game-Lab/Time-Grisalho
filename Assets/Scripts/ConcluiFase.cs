using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConcluiFase : MonoBehaviour
{
    [SerializeField]
    private NumDeFases numDeFases;
    [SerializeField]
    private ScenesManager gerenciadorDeCena;
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
        numDeFases.numeroDeFases++;
        yield return new WaitForSeconds(3.0f);
        gerenciadorDeCena.GoToScene();
    }
}
