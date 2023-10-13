using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicOnStart : MonoBehaviour
{

    [SerializeField] private AudioClip _clip;

    private void Start()
    {
        SoundManager.Instancia.PlayMusic(_clip);
    }
}
