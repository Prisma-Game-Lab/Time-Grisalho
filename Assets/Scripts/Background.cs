using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float startPos, length;
    [SerializeField]
    private GameObject cam;
    [SerializeField]
    private float efeitoParallax;

    private void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void FixedUpdate()
    {
        float dist = cam.transform.position.x * efeitoParallax;

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
    }
}
