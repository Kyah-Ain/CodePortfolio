using UnityEngine;

public class sirRazPlayerPrefsManager : MonoBehaviour
{
    // Keys
    private const string PLAYER_NAME_KEY = "PlayerName";
    private const string PLAYER_SCORE_KEY = "PlayerScore";

    // Internal data to simulate input (or connect via inspector/input field)
    [Header("Mock Data")]
    public string mockPlayerName = "PlayerOne";
    public int mockPlayerScore = 1000;

    // Save — no parameters, uses mock data
    public void Save()
    {
        PlayerPrefs.SetString(PLAYER_NAME_KEY, mockPlayerName);
        PlayerPrefs.SetInt(PLAYER_SCORE_KEY, mockPlayerScore);
        PlayerPrefs.Save();
        Debug.Log("Saved to PlayerPrefs");
    }

    // Load — no parameters, logs result
    public void Load()
    {
        string playerName = PlayerPrefs.GetString(PLAYER_NAME_KEY, "DefaultName");
        int playerScore = PlayerPrefs.GetInt(PLAYER_SCORE_KEY, 0);
        Debug.Log($"Loaded from PlayerPrefs: Name = {playerName}, Score = {playerScore}");
    }

    // Clear — no parameters
    public void Clear()
    {
        PlayerPrefs.DeleteKey(PLAYER_NAME_KEY);
        PlayerPrefs.DeleteKey(PLAYER_SCORE_KEY);
        Debug.Log("PlayerPrefs cleared");
    }
}
