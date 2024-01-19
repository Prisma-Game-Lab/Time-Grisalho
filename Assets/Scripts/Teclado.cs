using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;
public class Teclado : MonoBehaviour
{
    [SerializeField]
    private GameObject albumUI, gameUI, voltar, main_camera;
    private InputCamera script_camera;
    private Vector2 movimento, sentido;
    [SerializeField]
    private SpriteRenderer background;
    private void Start()
    {
        albumUI = GameObject.Find("Canvas").transform.Find("AlbumUI").gameObject;
        gameUI = GameObject.Find("Canvas").transform.Find("GameUI").gameObject;
        main_camera = GameObject.Find("Main Camera");
        script_camera = main_camera.GetComponent<InputCamera>();
        background = GameObject.FindGameObjectWithTag("Background").GetComponent<SpriteRenderer>();
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
        float posMousex = Camera.main.ScreenToWorldPoint(script_camera.posMouse).x;
        float dx = posMousex - main_camera.transform.position.x;

        if (dx < script_camera.limite && dx > -script_camera.limite)
        {
            main_camera.transform.Translate(Time.deltaTime * script_camera.speed * movimento);
            main_camera.transform.position = new Vector3(Mathf.Clamp(main_camera.transform.position.x, -script_camera.tamanho, script_camera.tamanho), 0, -10);
        }
    }
}
