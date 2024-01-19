using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class Teclado : MonoBehaviour
{
    [SerializeField]
    private GameObject albumUI, gameUI, voltar, main_camera;
    private Vector2 movimento;
    private void Start()
    {
        albumUI = GameObject.Find("Canvas").transform.Find("AlbumUI").gameObject;
        gameUI = GameObject.Find("Canvas").transform.Find("GameUI").gameObject;
        main_camera = GameObject.Find("Main Camera");
    }
    private void Update()
    {
        if (albumUI.activeInHierarchy)
        {
            voltar = albumUI.transform.Find("Voltar").gameObject;
        }
        else
        {
            voltar = gameUI.transform.Find("Voltar").gameObject;
        }
    }

    public void Troca()
    {
        voltar.GetComponent<BotaoAlteraUI>().Clique();
    }

    public void Movimento(InputAction.CallbackContext context)
    {
        movimento = context.ReadValue<Vector2>();
    }

    private void LateUpdate()
    {
        main_camera.transform.Translate(Time.deltaTime * main_camera.GetComponent<InputCamera>().speed * movimento);
    }
}
