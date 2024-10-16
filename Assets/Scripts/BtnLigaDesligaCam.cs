using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LigaDesligaCam : MonoBehaviour
{
    public GameObject camera_player;
    public GameObject camera__;
    public Button btn_ligaDeslCam;

    private void ligaDesligaCamBtn()
    {
        if (!camera_player.activeSelf)
        {
            camera_player.SetActive(true);
            camera__.SetActive(true);
            GameObject.Find("Main Camera").GetComponent<BotoesUI_Gerenciador>().DesativaBotoes();
        }
        else
        {
            camera_player.SetActive(false);
            camera__.SetActive(false);
            GameObject.Find("Main Camera").GetComponent<BotoesUI_Gerenciador>().AtivaBotoes();
        }
    }

    private void Start()
    {
        //camera_player = GameObject.Find("Camera Player");
        //areaFotoUI = GameObject.Find("AreaFotoUI");
        btn_ligaDeslCam.onClick.AddListener(ligaDesligaCamBtn);
    }
}
