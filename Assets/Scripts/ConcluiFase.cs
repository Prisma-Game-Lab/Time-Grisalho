using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConcluiFase : MonoBehaviour
{
    [SerializeField]
    private ScenesManager gerenciadorDeCena;
    [SerializeField]
    private float timer_fimdejogo;
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
        yield return new WaitForSeconds(timer_fimdejogo);
        GameObject.Find("Main Camera").GetComponent<VaiParaAlbumTelaFim>().ativaTelaDeFim();
    }
}
