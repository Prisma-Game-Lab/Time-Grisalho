using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecaColisaoAlvo : MonoBehaviour
{
    public ChecaColisaoAlvo Instancia { get; private set; }
    public bool estaColidindo { get; private set; }

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(estaColidindo.ToString());
        if (collision.gameObject.tag == "AreaFoto")
        {
            estaColidindo = false;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(estaColidindo.ToString());
        if (collision.gameObject.tag == "AreaFoto")
        {
            estaColidindo = true;
        }
    }
}