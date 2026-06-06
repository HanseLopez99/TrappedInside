using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    // Posición del jugador
    public float posX;
    public float posY;
    public float posZ;

    // Estado del jugador
    public int health;

    // Objetos importantes
    public bool hasFlashlight;
    public bool hasKey;

    // Inventario
    public List<string> inventoryItems =
        new List<string>();
}