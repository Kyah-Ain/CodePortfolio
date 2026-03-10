using System.IO;
using UnityEngine;

public class sirRazJsonSaveManager : MonoBehaviour
{
    private string saveFilePath;
    public sirRazSaveData data;

    void Awake()
    {
        saveFilePath = Application.persistentDataPath + "/saveData.json";
    }

    // Save using JSON
    public void SaveToJson()
    {
        string json = JsonUtility.ToJson(data, true); // true = pretty print
        File.WriteAllText(saveFilePath, json);
        Debug.Log("Game saved to JSON at: " + saveFilePath);
    }

    // Load using JSON

    public void LoadFromJson()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            sirRazSaveData data = JsonUtility.FromJson<sirRazSaveData>(json);
            Debug.Log("Game loaded from JSON.");

            this.data = data;
        }
        else
        {
            Debug.LogWarning("JSON save file not found!");
        }
       
    }

    public sirRazSaveData GetLoadedData()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            sirRazSaveData data = JsonUtility.FromJson<sirRazSaveData>(json);
            Debug.Log("Game loaded from JSON.");

            return data;
        }
        else
        {
            Debug.LogWarning("JSON save file not found!");
            return null;
        }
    }
}
