using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private Light flashlightLight;
    private AudioSource audioSource;

    public AudioClip soundOn;
    public AudioClip soundOff;

    public bool IsOn { get; private set; }

    void Start()
    {
        flashlightLight = GetComponent<Light>();
        audioSource = GetComponent<AudioSource>();

        // La linterna empieza apagada
        flashlightLight.enabled = false;
        IsOn = false;
    }

    void Update()
    {
        // ❌ No permitir usar la linterna si no ha sido recogida
        if (!FlashlightPickup.HasFlashlight)
            return;

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ToggleFlashlight();
        }
    }

    void ToggleFlashlight()
    {
        IsOn = !IsOn;
        flashlightLight.enabled = IsOn;

        audioSource.clip = IsOn ? soundOn : soundOff;
        audioSource.Play();
    }
}