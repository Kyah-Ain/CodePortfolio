using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class sirRazSaveData
{
    public sirRazPlayerData playerData;
    public sirRazInventoryData inventoryData;
    public sirRazGameSettings gameSettings;
}

[System.Serializable]
public class sirRazSerializableVector3
{
    public float x;
    public float y;
    public float z;

    // Constructor to convert from Unity's Vector3
    public sirRazSerializableVector3(Vector3 vector)
    {
        x = vector.x;
        y = vector.y;
        z = vector.z;
    }

    // Method to convert back to Unity's Vector3
    public Vector3 ToVector3()
    {
        return new Vector3(x, y, z);
    }
}

[System.Serializable]
public class sirRazPlayerData
{
    public int playerScore;
    public sirRazSerializableVector3 playerPosition;  
    public string playerName;
}

[System.Serializable]
public class sirRazInventoryItem
{
    public string itemName;
    public int quantity;
}

[System.Serializable]
public class sirRazInventoryData
{
    public sirRazInventoryItem[] items;
}

[System.Serializable]
public class sirRazGameSettings
{
    public float soundVolume;
    public float musicVolume;
}