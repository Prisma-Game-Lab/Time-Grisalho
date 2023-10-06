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
    private void Start()
    {
        gerenciadorDeCena = FindAnyObjectByType<ScenesManager>();
    }
    public void AumentaNumeroDeFases()
    {
        numDeFases.numeroDeFases++;
        gerenciadorDeCena.GoToScene();
    }
}
