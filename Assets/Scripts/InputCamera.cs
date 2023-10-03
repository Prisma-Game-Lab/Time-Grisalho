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
    Vector3 posMouse;
    public GameObject camera_player, areaFoto, alvo; // camera que o player puxa pra tirar foto, area efetiva da foto, alvo da foto
    private Vector2 topLeft, bottomRight;
    public TextMeshProUGUI txtBtn_LigaDeslCam;

    private void cameraSegueMouse() 
    {
        posMouse = Input.mousePosition;
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
        if(Input.GetMouseButtonDown(1))
        {
            topLeft = areaFoto.GetComponent<BoxCollider2D>().bounds.min;
            bottomRight = areaFoto.GetComponent<BoxCollider2D>().bounds.max;
            if (Physics2D.OverlapArea(topLeft, bottomRight, LayerMask.GetMask("Alvo")))
            {
                Debug.Log("tirou foto certo!");
                StartCoroutine(waiter());
                SceneManager.LoadScene("MainMenu");
            } 
            else
            {
                Debug.Log("tirou foto errado!");
            }
            txtBtn_LigaDeslCam.text = "Abrir\nCâmera";
            camera_player.SetActive(false);
        }
    }

    

    private void Start()
    {
        camera_player.SetActive(false);
    }
    
    void Update()
    {
        if (!camera_player.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                camera_player.SetActive(true);
            }
        } else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                camera_player.SetActive(false);
            }
            cameraSegueMouse();
            tiraFoto();
        }
    }
}
