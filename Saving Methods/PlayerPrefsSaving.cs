using System.Collections; // Grants access to collections and data structures like ArrayList, Hashtable, etc.
using System.Collections.Generic; // Grants access to generic collections like List, Dictionary, etc.
using UnityEngine; // Grants access to Unity's core classes and functions, such as MonoBehaviour, GameObject, Transform, etc.

public class PlayerPrefsSaving : MonoBehaviour
{
    // ------------------------- VARIABLES -------------------------

    [Header("PlayerPrefs Keys")]
    private const string PLAYER_NAME_KEY = "PlayerName"; // Key for storing the player's name
    private const string PLAYER_SCORE_KEY = "PlayerScore"; // Key for storing the player's score

    [Header("Class Reference")]
    public CoinManager coinManager; // Reference to the CoinManager.cs script for accessing coin data
    public SimplePlayerInfo simplePlayerInfo; // Reference to the SimplePlayerInfo.cs script for accessing player info

    [Header("Sample Data")] 
    public string samplePlayerName = "Salazar"; // Sample player name to be saved
    public int sampleSavedScore = -9999; // Sample score to be saved

    // -------------------------- METHODS ---------------------------

    // Quick saving method to store progress using PlayerPrefs
    public virtual void Save() 
    {
        PlayerPrefs.SetString(PLAYER_NAME_KEY, samplePlayerName); // Save the player's name using PlayerPrefs
        PlayerPrefs.SetInt(PLAYER_SCORE_KEY, sampleSavedScore); // Save the player's score using PlayerPrefs
        PlayerPrefs.Save(); // Ensure the data is written to disk

        simplePlayerInfo.savingPromptLog.text = $"Player {samplePlayerName} with a score of {sampleSavedScore} successfully \"saved\"! You saved using PLAYERPREFS.";
        Debug.LogWarning($"Player {samplePlayerName} with a score of {sampleSavedScore} successfully \"saved\"! You saved using PLAYERPREFS.");
    }

    // Quick loading method to implement back all the records saved using PlayerPrefs
    public virtual void Load() 
    {
        string playerName = PlayerPrefs.GetString(PLAYER_NAME_KEY, "Anonymouse"); // Load the player's name using PlayerPrefs, default to "Anonymouse" if not found
        int playerScore = PlayerPrefs.GetInt(PLAYER_SCORE_KEY, -1); // Load the player's score using PlayerPrefs, default to -1 if not found

        samplePlayerName = playerName; // Update the sample player name variable with the loaded name
        simplePlayerInfo.playerDisplayName.text = samplePlayerName; 
        
        sampleSavedScore = playerScore; // Update the sample score variable with the loaded score
        coinManager.coinCount = sampleSavedScore; 

        simplePlayerInfo.savingPromptLog.text = $"Player {samplePlayerName} with a score of {sampleSavedScore} successfully \"loaded\"! You load using PLAYERPREFS.";
        Debug.LogWarning($"Player {samplePlayerName} with a score of {sampleSavedScore} successfully \"loaded\"! You load using PLAYERPREFS.");
    }

    // Method to clear all records saved using PlayerPrefs
    public virtual void Clear() 
    {
        PlayerPrefs.DeleteKey(PLAYER_NAME_KEY);
        PlayerPrefs.DeleteKey(PLAYER_SCORE_KEY);
        PlayerPrefs.DeleteAll();

        Debug.LogWarning($"All saved files are now empty as new!");
    }
}