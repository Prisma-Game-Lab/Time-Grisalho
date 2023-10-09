using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LigaDesligaCam : MonoBehaviour
{
    private GameObject camera_player;
    public Button btn_ligaDeslCam;

    private void ligaDesligaCamBtn()
    {
        if (!camera_player.activeSelf)
        {
            camera_player.SetActive(true);
        }
        else
        {
            camera_player.SetActive(false);
        }
    }

    private void Awake()
    {
        btn_ligaDeslCam.onClick.AddListener(ligaDesligaCamBtn);
    }

    private void Start()
    {
        camera_player = GameObject.Find("Camera");
    }
}
