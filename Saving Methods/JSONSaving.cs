using System.IO; // Grants access to file handling classes and functions, such as File, StreamReader, StreamWriter, etc.
using UnityEngine; // Grants access to Unity's core classes and functions, such as MonoBehaviour, GameObject, Transform, etc.

public class JSONSaving : MonoBehaviour
{
    // ------------------------- VARIABLES -------------------------

    [Header("Class Reference")]
    public SimplePlayerInfo simplePlayerInfo; // Reference to the SimplePlayerInfo.cs script for accessing player info

    [Header("File Path & Data")]
    private string savedFilePath; // Path to save/load the binary file
    public SavedData savedData; // Instance of the SavedData class to hold the data to be saved/loaded

    // -------------------------- METHODS ---------------------------

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Set the file path for saving/loading data
        savedFilePath = Application.persistentDataPath + "/JsonSavedData.json"; // Set the file path for saving/loading data
    }

    // Save using JSON
    public void SaveToJson(SavedData savedData) 
    {
        // Convert the savedData object to a JSON string
        string json = JsonUtility.ToJson(savedData, true); // true = pretty-print (well-formatted for readability)
        File.WriteAllText(savedFilePath, json); // Write the JSON string to the specified file path

        // Log a message indicating successful save
        simplePlayerInfo.savingPromptLog.text = $"Player {savedData.playerData.playerName} with a score of {savedData.playerData.playerScore} successfully saved at {savedFilePath}! You saved using JSON.";
        Debug.LogWarning($"Player {savedData.playerData.playerName} with a score of {savedData.playerData.playerScore} successfully saved at {savedFilePath}! You saved using JSON.");
    }

    // Load using JSON
    public void LoadFromJSON() 
    {
        // Check if the saved file exists
        if (File.Exists(savedFilePath))
        {
            // Read the JSON string from the specified file path
            string json = File.ReadAllText(savedFilePath); // Read the JSON string from the file
            SavedData data = JsonUtility.FromJson<SavedData>(json); // Convert the JSON string back to a SavedData object
            this.savedData = data; // Assign the loaded data to the class variable

            // Log a message indicating successful load
            simplePlayerInfo.savingPromptLog.text = $"Player {data.playerData.playerName} with a score of {data.playerData.playerScore} successfully loaded from {savedFilePath}! You saved using JSON.";
            Debug.LogWarning($"Player {data.playerData.playerName} with a score of {data.playerData.playerScore} successfully loaded from {savedFilePath}! You saved using JSON.");
        }
        else 
        {
            // Log a warning if the file does not exist
            simplePlayerInfo.savingPromptLog.text = $"JSON saved file at {savedFilePath} was not found! : (";
            Debug.LogWarning($"JSON saved file at {savedFilePath} was not found! : (");
        }
    }

    // Optional Return Type Method
    public SavedData LoadAndReturnJSON() 
    {
        // Check if the saved file exists
        if (File.Exists(savedFilePath))
        {
            // Read the JSON string from the specified file path
            string json = File.ReadAllText(savedFilePath); // Read the JSON string from the file
            SavedData data = JsonUtility.FromJson<SavedData>(json); // Convert the JSON string back to a SavedData object

            simplePlayerInfo.savingPromptLog.text = $"Player {data.playerData.playerName} with a score of {data.playerData.playerScore} successfully loaded from {savedFilePath}! You saved using JSON.";
            Debug.LogWarning($"Player {data.playerData.playerName} with a score of {data.playerData.playerScore} successfully loaded from {savedFilePath}! You saved using JSON.");

            return data; // Return the loaded data
        }
        else
        {
            // Log a warning if the file does not exist
            simplePlayerInfo.savingPromptLog.text = $"JSON saved file at {savedFilePath} was not found! : (";
            Debug.LogWarning($"JSON saved file at {savedFilePath} was not found! : (");

            return null; // Return null if the file does not exist
        }
    }
}