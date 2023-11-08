using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputCamera : MonoBehaviour
{
    private Vector3 posMouse;
    private GameObject camera_player, areaFoto, areaFotoUI; // camera que o player puxa pra tirar foto, area efetiva da foto, alvo da foto
    private Vector2 topLeft, bottomRight;
    public TextMeshProUGUI txtBtn_LigaDeslCam;
    private ConcluiFase concluiFase;
    private SpriteRenderer background;
    [SerializeField]
    private float limite, speed;
    private float tamanho;
    public float tempoDeEsperaFeedbackPositivo = 5.0f, tempoDeEsperaFeedbackNegativo = 5.0f;


    private void cameraSegueMouse()
    {
        posMouse.z = Camera.main.nearClipPlane;
        posMouse = Camera.main.ScreenToWorldPoint(posMouse);
        camera_player.transform.position = posMouse;
    }

    private IEnumerator waiter_certo()
    {
        Debug.Log("Waiter started");
        yield return new WaitForSecondsRealtime(tempoDeEsperaFeedbackPositivo);
        Debug.Log("Waiter finished");
        concluiFase.AumentaNumeroDeFases();
    }

    private IEnumerator waiter_errado()
    {
        Debug.Log("Waiter started");
        yield return new WaitForSecondsRealtime(tempoDeEsperaFeedbackNegativo);
        Debug.Log("Waiter finished");
        Desativa_Ativa_CertoErrado.Instancia.Desativa_Certo_Errado(2);
    }


    private void tiraFoto()
    {
        if (Input.GetMouseButtonDown(1))
        {
            topLeft = areaFoto.GetComponent<BoxCollider2D>().bounds.min;
            bottomRight = areaFoto.GetComponent<BoxCollider2D>().bounds.max;
            if (Physics2D.OverlapArea(topLeft, bottomRight, LayerMask.GetMask("Alvo")))
            {
                Debug.Log("tirou foto certo!");
                Desativa_Ativa_CertoErrado.Instancia.Ativa_Certo_Errado(1);
                StartCoroutine(waiter_certo());
            }
            else
            {
                Debug.Log("tirou foto errado!");
                Desativa_Ativa_CertoErrado.Instancia.Ativa_Certo_Errado(2);
                StartCoroutine(waiter_errado());
            }
            //txtBtn_LigaDeslCam.text = "Abrir\nC�mera";
            camera_player.SetActive(false);
            areaFotoUI.SetActive(false);
        }
    }

    private void MexeCamera()
    {
        Vector3 delta = Vector3.zero;
        float posMousex = Camera.main.ScreenToWorldPoint(posMouse).x;
        float dx = posMousex - transform.position.x;
        tamanho = background.sprite.bounds.size.x / 2 - 8.9f;

        if (dx > limite || dx < -limite)
        {
            if (transform.position.x < posMousex && transform.position.x < tamanho)
            {
                delta = Vector3.right;
            }
            if (transform.position.x > posMousex && transform.position.x > -tamanho)
            {
                delta = Vector3.left;
            }
        }

        transform.Translate(Time.deltaTime * speed * delta);
    }

    private void Awake()
    {
        camera_player = GameObject.Find("Camera Player");
        areaFoto = GameObject.Find("AreaFoto");
        areaFotoUI = GameObject.Find("AreaFotoUI");
        concluiFase = FindAnyObjectByType<ConcluiFase>();
        camera_player.SetActive(false);
        areaFotoUI.SetActive(false);

        background = GameObject.FindGameObjectWithTag("Background").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!camera_player.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                camera_player.SetActive(true);
                areaFotoUI.SetActive(true);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                camera_player.SetActive(false);
                areaFotoUI.SetActive(false);
            }
            cameraSegueMouse();
            tiraFoto();
        }
    }
    private void LateUpdate()
    {
        posMouse = Input.mousePosition;
        MexeCamera();
    }
}
