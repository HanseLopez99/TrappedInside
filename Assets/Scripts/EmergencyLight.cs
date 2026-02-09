using UnityEngine;

public class EmergencyLight : MonoBehaviour
{
    private Light emergencyLightComponent;

    [Header("References")]
    public GameObject emergencyLight;
    public GameObject sirenSound;

    [Header("Settings")]
    public float alarmDuration = 10f; // ⏱duración de la alarma

    private bool theThiefIsNear;
    private bool alarmActive = false;

    private GameObject sirenInstance;

    // Control del diálogo (solo una vez)
    private bool dialogueShown = false;

    void Start()
    {
        emergencyLightComponent = emergencyLight.GetComponent<Light>();
        theThiefIsNear = false;
        alarmActive = false;
    }

    void Update()
    {
        if (theThiefIsNear && alarmActive)
        {
            emergencyLightComponent.enabled = true;
            emergencyLightComponent.intensity =
                Mathf.Abs(Mathf.Sin(Time.time * 8)) * 15;
        }
        else
        {
            emergencyLightComponent.enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Emergency"))
        {
            theThiefIsNear = true;

            // Activar alarma solo una vez
            if (!alarmActive)
            {
                alarmActive = true;

                sirenInstance = Instantiate(sirenSound);
                sirenInstance.GetComponent<AudioSource>().Play();

                // ⏱️ Apagar alarma tras X segundos
                Invoke(nameof(StopAlarm), alarmDuration);

                // Control del diálogo (solo una vez)
                if (!dialogueShown)
                {
                    dialogueShown = true;
                    Invoke(nameof(ShowAlarmThought), 0.3f);
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Emergency"))
        {
            theThiefIsNear = false;
        }
    }

    // APAGAR ALARMA
    void StopAlarm()
    {
        alarmActive = false;

        if (sirenInstance != null)
        {
            Destroy(sirenInstance);
            sirenInstance = null;
        }
    }

    void ShowAlarmThought()
    {
        if (DialogueManager.Instance != null)
        {
            DialogueManager.Instance.ShowThought(
                "Ohh no creo que active la alarma!!"
            );
        }
    }
}