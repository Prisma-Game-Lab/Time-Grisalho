using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class InputCamera : MonoBehaviour
{
    private Vector3 posMouse;
    private GameObject camera_player, areaFoto; // camera que o player puxa pra tirar foto, area efetiva da foto, alvo da foto
    private Vector2 topLeft, bottomRight;
    public TextMeshProUGUI txtBtn_LigaDeslCam;
    private ConcluiFase concluiFase;
    private SpriteRenderer background;
    [SerializeField]
    private float limite;
    [SerializeField]
    private float speed;

    private void cameraSegueMouse()
    {
        posMouse.z = Camera.main.nearClipPlane;
        posMouse = Camera.main.ScreenToWorldPoint(posMouse);
        camera_player.transform.position = posMouse;
    }

    private IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(5);
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
                StartCoroutine(waiter());
                concluiFase.AumentaNumeroDeFases();
            }
            else
            {
                Debug.Log("tirou foto errado!");
            }
            //txtBtn_LigaDeslCam.text = "Abrir\nC�mera";
            camera_player.SetActive(false);
        }
    }

    private void mexeCamera()
    {
        Vector3 delta = Vector3.zero;
        float posMousex = Camera.main.ScreenToWorldPoint(posMouse).x;
        float dx = posMousex - transform.position.x;
        if (dx > limite || dx < -limite)
        {
            if (transform.position.x < posMousex)
            {
                delta = Vector3.right;
            }
            if (transform.position.x > posMousex)
            {
                delta = Vector3.left;
            }
            // if(transform.position.x >)
        }

        transform.Translate(delta * Time.deltaTime * speed);
    }

    private void Start()
    {
        camera_player = GameObject.Find("Camera");
        areaFoto = GameObject.Find("AreaFoto");
        concluiFase = FindAnyObjectByType<ConcluiFase>();
        camera_player.SetActive(false);
        background = GameObject.FindGameObjectWithTag("Background").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!camera_player.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                camera_player.SetActive(true);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                camera_player.SetActive(false);
            }
            cameraSegueMouse();
            tiraFoto();
        }
    }
    private void LateUpdate()
    {
        posMouse = Input.mousePosition;
        mexeCamera();
        Debug.Log(background.sprite.border.x);
    }
}
