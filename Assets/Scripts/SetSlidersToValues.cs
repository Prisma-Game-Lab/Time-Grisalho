using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSlidersToValues : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSource, _effectSource;
    [SerializeField] private Slider _masterVolumeSlider, _musicVolumeSlider, _effectsVolumeSlider;
    private void Awake()
    {
        _masterVolumeSlider.value = AudioListener.volume;
        _musicVolumeSlider.value = VolumesController.musicVolumeStatic;
        _effectsVolumeSlider.value = VolumesController.effectsVolumeStatic;
    }
}
