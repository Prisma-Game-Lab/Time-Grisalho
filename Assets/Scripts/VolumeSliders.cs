using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliders : MonoBehaviour
{
    [SerializeField] private Slider _masterVolumeSlider, _musicVolumeSlider, _effectsVolumeSlider;

    private void Start()
    {
        SoundManager.Instancia.ChangeMasterVolume(_masterVolumeSlider.value);
        SoundManager.Instancia.ChangeMusicVolume(_musicVolumeSlider.value);
        SoundManager.Instancia.ChangeEffectsVolume(_effectsVolumeSlider.value);
        _masterVolumeSlider.onValueChanged.AddListener(val => SoundManager.Instancia.ChangeMasterVolume(val));
        _musicVolumeSlider.onValueChanged.AddListener(val => SoundManager.Instancia.ChangeMusicVolume(val));
        _effectsVolumeSlider.onValueChanged.AddListener(val => SoundManager.Instancia.ChangeEffectsVolume(val));
    }
}
