using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConcluiFase : MonoBehaviour
{
    [SerializeField]
    private NumDeFases numDeFases;
    private void Start()
    {
        numDeFases.numeroDeFases++;
    }
}
