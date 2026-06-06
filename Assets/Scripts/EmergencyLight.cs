using UnityEngine;

public class EmergencyLight : MonoBehaviour
{
    private Light emergencyLightComponent;

    [Header("References")]
    public GameObject emergencyLight;
    public GameObject sirenSound;

    [Header("Settings")]
    public float alarmDuration = 1.5f;

    private bool theThiefIsNear;

    // Controla si la alarma está sonando actualmente
    private bool alarmActive = false;

    // NUEVO: evita que vuelva a activarse nunca más
    private bool alarmTriggered = false;

    private GameObject sirenInstance;

    private bool dialogueShown = false;

    void Start()
    {
        emergencyLightComponent =
            emergencyLight.GetComponent<Light>();

        theThiefIsNear = false;
        alarmActive = false;
        alarmTriggered = false;

        emergencyLightComponent.enabled = false;
    }

    void Update()
    {
        if (alarmActive)
        {
            emergencyLightComponent.enabled = true;

            emergencyLightComponent.intensity =
                Mathf.Abs(
                    Mathf.Sin(Time.time * 8)
                ) * 15;
        }
        else
        {
            emergencyLightComponent.enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Emergency"))
            return;

        // SOLO UNA VEZ EN TODA LA PARTIDA
        if (alarmTriggered)
            return;

        alarmTriggered = true;
        alarmActive = true;

        sirenInstance = Instantiate(
            sirenSound,
            transform.position,
            Quaternion.identity
        );

        AudioSource audio =
            sirenInstance.GetComponent<AudioSource>();

        if (audio != null)
        {
            audio.Play();
        }

        Invoke(
            nameof(StopAlarm),
            alarmDuration
        );

        if (!dialogueShown)
        {
            dialogueShown = true;

            Invoke(
                nameof(ShowAlarmThought),
                0.3f
            );
        }
    }

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
                "Oh no... creo que activé la alarma."
            );
        }
    }
}