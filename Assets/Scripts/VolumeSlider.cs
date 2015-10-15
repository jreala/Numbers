using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour {

    private AudioSource audioSource;
    public Slider slider;

    void Awake()
    {
        audioSource = GameInformation.GetAudioSource();
        slider.value = audioSource.volume;
    }

    public void OnValueChanged(float newValue)
    {
        audioSource.volume = newValue;
        PlayerPrefs.SetFloat("VolumeLevel", newValue);
    }

}
