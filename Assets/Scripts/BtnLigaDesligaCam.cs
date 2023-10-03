using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LigaDesligaCam : MonoBehaviour
{
    public GameObject camera_player;
    public Button btn_ligaDeslCam;
    public TextMeshProUGUI txt_btn;

    private void ligaDesligaCamBtn()
    {
        if (!camera_player.activeSelf)
        {
            camera_player.SetActive(true);
            txt_btn.text = "Fechar\nCâmera";
        }
        else
        {
            camera_player.SetActive(false);
            txt_btn.text = "Abrir\nCâmera";
        }
    }

    private void Awake()
    {
        btn_ligaDeslCam.onClick.AddListener(ligaDesligaCamBtn);
    }

    private void Update()
    {
        
    }
}
