using UnityEngine;
using System.Collections;

public class MenuFlashlightFlicker : MonoBehaviour
{
    private Light lightComp;
    private AudioSource audioSource;

    [Header("Base Flicker")]
    public float baseIntensity = 9f;
    public float minMultiplier = 4.5f;
    public float flickerSpeed = 1.2f;

    [Header("Hard Flicker")]
    public float hardFlickerInterval = 6f;
    public int hardFlickerTicks = 3;
    public float hardFlickerDelay = 0.08f;

    private bool hardFlickerActive = false;

    void Start()
    {
        lightComp = GetComponent<Light>();
        audioSource = GetComponent<AudioSource>();

        lightComp.intensity = baseIntensity;

        StartCoroutine(HardFlickerRoutine());
    }

    void Update()
    {
        if (hardFlickerActive) return;

        float noise = Mathf.PerlinNoise(Time.time * flickerSpeed, 0f);

        float multiplier = Mathf.Lerp(
            minMultiplier,
            4f,
            noise
        );

        lightComp.intensity = baseIntensity * multiplier + 7;
    }

    IEnumerator HardFlickerRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(hardFlickerInterval);

            hardFlickerActive = true;

            float savedIntensity = lightComp.intensity;

            // sonido eléctrico
            if (audioSource != null)
                audioSource.Play();

            for (int i = 0; i < hardFlickerTicks; i++)
            {
                lightComp.intensity = 0f;
                yield return new WaitForSeconds(hardFlickerDelay);

                lightComp.intensity = savedIntensity;
                yield return new WaitForSeconds(hardFlickerDelay);
            }

            hardFlickerActive = false;
        }
    }
}