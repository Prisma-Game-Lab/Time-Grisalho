using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LigaDesligaCam : MonoBehaviour
{
    public GameObject camera_player;
    public GameObject areaFotoUI;
    public Button btn_ligaDeslCam;

    private void ligaDesligaCamBtn()
    {
        if (!camera_player.activeSelf)
        {
            camera_player.SetActive(true);
            areaFotoUI.SetActive(true);
        }
        else
        {
            camera_player.SetActive(false);
            areaFotoUI.SetActive(false);
        }
    }

    private void Start()
    {
        //camera_player = GameObject.Find("Camera Player");
        //areaFotoUI = GameObject.Find("AreaFotoUI");
        btn_ligaDeslCam.onClick.AddListener(ligaDesligaCamBtn);
    }
}
