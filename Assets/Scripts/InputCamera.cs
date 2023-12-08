using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputCamera : MonoBehaviour
{
    public static InputCamera Instancia;
    private Vector3 posMouse;
    private GameObject camera_player, areaFoto, camera__; // camera que o player puxa pra tirar foto, area efetiva da foto, alvo da foto
    private Vector2 topLeft, bottomRight;
    public TextMeshProUGUI txtBtn_LigaDeslCam;
    private ConcluiFase concluiFase;
    private SpriteRenderer background;

    [SerializeField]
    private float limite, speed;
    private float tamanho;

    public float tempoDeEsperaFeedbackPositivo = 5.0f, tempoDeEsperaFeedbackNegativo = 5.0f;

    public int quantidadeDeFotos = 2; // SEMPRE TEM QUE SER MESMA QUANTIDADE DE ALVOS
    [SerializeField] private List<bool> ljaTirouFotos = new List<bool>(); // para cada alvo na lista lAlvos indica se a foto ja foi tirada ou nao
    private List<GameObject> lAlvos = new List<GameObject>(); // lista de alvos
    [SerializeField] private List<Sprite> lfotosTiradas = new List<Sprite>(); //lista de sprites
    


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
        Desativa_Ativa_CertoErrado.Instancia.Desativa_Certo_Errado(1);
        if (jaTirouTdsFotos())
        {
            concluiFase.AumentaNumeroDeFases();
        }
    }

    private IEnumerator waiter_errado()
    {
        Debug.Log("Waiter started");
        yield return new WaitForSecondsRealtime(tempoDeEsperaFeedbackNegativo);
        Debug.Log("Waiter finished");
        Desativa_Ativa_CertoErrado.Instancia.Desativa_Certo_Errado(2);
    }

    private bool estaOverlapping()
    {
        if (Physics2D.OverlapArea(topLeft, bottomRight, LayerMask.GetMask("Alvo"))) { return true; }
        return false;

    }

    private int qualEstaOverlapping()
    {
        for (int i = 0; i < quantidadeDeFotos; i++)
        {
            if (Physics2D.OverlapCircle(lAlvos[i].GetComponent<CircleCollider2D>().bounds.center, lAlvos[i].GetComponent<CircleCollider2D>().radius, LayerMask.GetMask("AreaFoto"))) {
                return i;
            }
        }
        return -1;
    }

    private bool jaTirouTdsFotos()
    {
        for(int i = 0; i < quantidadeDeFotos; i++)
        {
            if (!ljaTirouFotos[i])
            {
                return false;
            }
        }
        return true;
    }

    private void tiraFoto()
    {
        if (Input.GetMouseButtonDown(1))
        {
            topLeft = areaFoto.GetComponent<BoxCollider2D>().bounds.min;
            bottomRight = areaFoto.GetComponent<BoxCollider2D>().bounds.max;
            if (estaOverlapping())
            {
                // Debug.Log("tirou foto certo!");
                int alvoAtual = qualEstaOverlapping();
                if (!ljaTirouFotos[alvoAtual])
                {
                    Debug.Log("tirou foto certo!");
                    lfotosTiradas[alvoAtual] = GameObject.Find("Camera Reveladora").GetComponent<SaveCameraFoto>().CaptureScreen();
                    GameObject.Find("Camera Reveladora").GetComponent<SaveCameraFoto>().ShowsTakenPicture(GameObject.Find("Camera Reveladora").GetComponent<SaveCameraFoto>().CaptureScreen(), GameObject.Find("Camera Reveladora").GetComponent<SaveCameraFoto>().rawImage);
                    Desativa_Ativa_CertoErrado.Instancia.Ativa_Certo_Errado(1);
                    GameObject.Find("Canvas").GetComponent<FotosReveladasManager>().RevelaFoto(alvoAtual);
                    StartCoroutine(waiter_certo());
                    ljaTirouFotos[alvoAtual] = true;
                }
                //for (int i = 0; i < quantidadeDeFotos; i++)
                //{
                //    if (!ljaTirouFotos[i])
                //    {
                //        if (areaFoto.GetComponent<BoxCollider2D>().bounds.Intersects(lAlvos[i].GetComponent<CircleCollider2D>().bounds))
                //       {
                //            Debug.Log("tirou foto certo!");
                //            lfotosTiradas[i] = SaveCameraFoto.Instancia.CaptureScreen();
                //            SaveCameraFoto.Instancia.ShowsTakenPicture(SaveCameraFoto.Instancia.CaptureScreen());
                //            Desativa_Ativa_CertoErrado.Instancia.Ativa_Certo_Errado(1);
                //            StartCoroutine(waiter_certo());
                //           ljaTirouFotos[i] = true; break;
                //        }
                //    }
                //}
                // ADICIONAR COMPARAÇÃO PRA SABER QUAL DOS ALVOS TIROU FOTO A PARTIR DAS LISTAS!!
                /*
                                Debug.Log("tirou foto certo!");
                                SaveCameraFoto.Instancia.ShowsTakenPicture(SaveCameraFoto.Instancia.CaptureScreen());
                                Desativa_Ativa_CertoErrado.Instancia.Ativa_Certo_Errado(1);
                                StartCoroutine(waiter_certo());*/
            }
            else
            {
                Debug.Log("tirou foto errado!");
                SaveCameraFoto.Instancia.ShowsTakenPicture(SaveCameraFoto.Instancia.CaptureScreen(), SaveCameraFoto.Instancia.rawImage);
                Desativa_Ativa_CertoErrado.Instancia.Ativa_Certo_Errado(2);
                StartCoroutine(waiter_errado());
            }
            //txtBtn_LigaDeslCam.text = "Abrir\nC�mera";
            camera_player.SetActive(false);
            camera__.SetActive(false);
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

    private void InicializaJaTirouFotosAlvos()
    {
        for(int i = 0; i < quantidadeDeFotos; i++) {
            ljaTirouFotos.Add(false);
            lAlvos.Add(GameObject.Find("Alvo " +  (i + 1).ToString() ));
            lfotosTiradas.Add(null);
        }
    }

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

        camera_player = GameObject.Find("Camera Player");
        areaFoto = GameObject.Find("AreaFoto");
        camera__ = GameObject.Find("Camera");
        concluiFase = FindAnyObjectByType<ConcluiFase>();
        camera_player.SetActive(false);
        camera__.SetActive(false);
        InicializaJaTirouFotosAlvos();

        background = GameObject.FindGameObjectWithTag("Background").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!camera_player.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                camera_player.SetActive(true);
                camera__.SetActive(true);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                camera_player.SetActive(false);
                camera__.SetActive(false);
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
