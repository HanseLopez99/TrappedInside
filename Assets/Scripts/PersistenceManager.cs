using System.IO;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance;

    private string savePath;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        savePath =
            Application.persistentDataPath +
            "/savegame.json";
    }

    public void SaveGame()
    {
        SaveData data =
            new SaveData();

        GameObject player =
            GameObject.FindGameObjectWithTag(
                "Player"
            );

        if (player != null)
        {
            data.posX =
                player.transform.position.x;

            data.posY =
                player.transform.position.y;

            data.posZ =
                player.transform.position.z;

            PlayerHealth health =
                player.GetComponent<PlayerHealth>();

            if (health != null)
            {
                data.health =
                    health.GetCurrentHealth();
            }

            Debug.Log(
                "Guardando posicion: " +
                player.transform.position
            );
        }

        data.hasFlashlight =
            FlashlightPickup.HasFlashlight;

        data.hasKey =
            KeyPickup.HasKey;

        foreach (ItemData item in
                 InventoryManager.Instance.collectedItems)
        {
            data.inventoryItems.Add(
                item.itemName
            );
        }

        string json =
            JsonUtility.ToJson(
                data,
                true
            );

        File.WriteAllText(
            savePath,
            json
        );

        Debug.Log(
            "Juego guardado en:\n" +
            savePath
        );
    }

    public void LoadGame()
    {
        if (!File.Exists(savePath))
        {
            Debug.LogWarning(
                "No existe una partida guardada."
            );

            return;
        }

        string json =
            File.ReadAllText(
                savePath
            );

        SaveData data =
            JsonUtility.FromJson<SaveData>(
                json
            );

        GameObject player =
            GameObject.FindGameObjectWithTag(
                "Player"
            );

        if (player != null)
        {
            CharacterController cc =
                player.GetComponent<CharacterController>();

            if (cc != null)
            {
                cc.enabled = false;
            }

            Vector3 savedPosition =
                new Vector3(
                    data.posX,
                    data.posY,
                    data.posZ
                );

            Debug.Log(
                "Cargando posicion: " +
                savedPosition
            );

            player.transform.position =
                savedPosition;

            if (cc != null)
            {
                cc.enabled = true;
            }

            PlayerHealth health =
                player.GetComponent<PlayerHealth>();

            if (health != null)
            {
                health.SetCurrentHealth(
                    data.health
                );
            }
        }

        FlashlightPickup.HasFlashlight =
            data.hasFlashlight;

        KeyPickup.HasKey =
            data.hasKey;

        Debug.Log(
            "Juego cargado."
        );

        Debug.Log(
            "Items guardados: " +
            data.inventoryItems.Count
        );
    }

    public bool SaveExists()
    {
        return File.Exists(
            savePath
        );
    }
}