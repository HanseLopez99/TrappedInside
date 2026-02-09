using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        // Cargar volumen guardado
        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 0.7f);

        // Asignar sin disparar evento
        volumeSlider.SetValueWithoutNotify(savedVolume);
        AudioListener.volume = savedVolume;

        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat("MasterVolume", value);
    }
}