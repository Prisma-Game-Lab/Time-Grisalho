using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float startPos;
    private GameObject cam;
    [SerializeField]
    private float efeitoParallax;

    private void Start()
    {
        startPos = transform.position.x;
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        float dist = cam.transform.position.x * efeitoParallax;

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
    }
}
