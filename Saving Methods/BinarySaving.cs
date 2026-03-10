using System.Runtime.Serialization.Formatters.Binary; // Grants access to classes for binary serialization and deserialization, such as BinaryFormatter.
using System.IO; // Grants access to file handling classes and functions, such as File, StreamReader, StreamWriter, etc.
using UnityEngine; // Grants access to Unity's core classes and functions, such as MonoBehaviour, GameObject, Transform, etc.

public class BinarySaving : MonoBehaviour
{
    // ------------------------- VARIABLES -------------------------

    [Header("Class Reference")]
    public SimplePlayerInfo simplePlayerInfo; // Reference to the SimplePlayerInfo.cs script for accessing player info

    [Header("File Path & Data")]
    private string savedFilePath; // Path to save/load the binary file
    public SavedData savedData; // Instance of the SavedData class to hold the data to be saved/loaded

    // -------------------------- METHODS ---------------------------

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        savedFilePath = Application.persistentDataPath + "/BinarySavedData.bin"; // Set the file path for saving/loading data
    }

    // Save using Binary
    public void SaveInBinary(SavedData savedData) 
    {
        // Create a file stream to write the binary data to the specified file path
        FileStream file = File.Create(savedFilePath); // Create or overwrite the file at the specified path
        BinaryFormatter bf = new BinaryFormatter(); // Create a BinaryFormatter to handle the serialization
        bf.Serialize(file, savedData); // Serialize the savedData object and write it to the file
        file.Close(); // Close the file stream to release resources

        // Log a message indicating successful save
        simplePlayerInfo.savingPromptLog.text = $"Player {savedData.playerData.playerName} with a score of {savedData.playerData.playerScore} successfully saved at {savedFilePath}! You saved using BINARY.";
        Debug.LogWarning($"Player {savedData.playerData.playerName} with a score of {savedData.playerData.playerScore} successfully saved at {savedFilePath}! You saved using BINARY.");
    }

    // Load using Binary
    public void LoadInBinary()
    {
        // Check if the saved file exists before attempting to load
        if (File.Exists(savedFilePath))
        {
            // Open the file stream to read the binary data from the specified file path
            FileStream file = File.Open(savedFilePath, FileMode.Open); // Open the file at the specified path
            BinaryFormatter bf = new BinaryFormatter(); // Create a BinaryFormatter to handle the deserialization
            SavedData loadedData = (SavedData)bf.Deserialize(file); // Deserialize the data from the file and cast it to SavedData
            file.Close(); // Close the file stream to release resources

            // Log a message indicating successful load
            simplePlayerInfo.savingPromptLog.text = $"Player {savedData.playerData.playerName} with a score of {savedData.playerData.playerScore} successfully loaded from {savedFilePath}!";
            Debug.LogWarning($"Player {savedData.playerData.playerName} with a score of {savedData.playerData.playerScore} successfully loaded from {savedFilePath}!");

            this.savedData = loadedData; // Store the loaded data in the class variable for further use
        }
        else
        {
            // Log a warning if the file does not exist
            simplePlayerInfo.savingPromptLog.text = $"Binary saved file at {savedFilePath} was not found! : (";
            Debug.LogWarning($"Binary saved file at {savedFilePath} was not found! : (");
        }
    }

    // Optional Return Type Method
    public SavedData LoadAndReturnBinary()
    {
        // Check if the saved file exists before attempting to load
        if (File.Exists(savedFilePath))
        {
            // Open the file stream to read the binary data from the specified file path
            FileStream file = File.Open(savedFilePath, FileMode.Open); // Open the file at the specified path
            BinaryFormatter bf = new BinaryFormatter(); // Create a BinaryFormatter to handle the deserialization
            SavedData data = (SavedData)bf.Deserialize(file); // Deserialize the data from the file and cast it to SavedData
            file.Close(); // Close the file stream to release resources

            // Log a message indicating successful load
            simplePlayerInfo.savingPromptLog.text = $"Player {data.playerData.playerName} with a score of {data.playerData.playerScore} successfully loaded from {savedFilePath}!";
            Debug.LogWarning($"Player {data.playerData.playerName} with a score of {data.playerData.playerScore} successfully loaded from {savedFilePath}!");

            return data; // Return the loaded data for further use
        }
        else
        {
            // Log a warning if the file does not exist
            simplePlayerInfo.savingPromptLog.text = $"Binary saved file at {savedFilePath} was not found! : (";
            Debug.LogWarning($"Binary saved file at {savedFilePath} was not found! : (");
            return null; // Return null if the file does not exist
        }
    }
}