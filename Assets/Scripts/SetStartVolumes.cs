using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolumes : MonoBehaviour
{
    private void Start()
    {
        VolumesController.musicVolumeStatic = 1;
        VolumesController.effectsVolumeStatic = 1;
    }
}
