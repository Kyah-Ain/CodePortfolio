using System.Collections; // Grants access to collections structures like ArrayLists and Hashtables
using System.Collections.Generic; // Grants access to collections structures like Lists and Dictionaries   
using UnityEngine; // Grants access to Unity's core features like Datatypes, DateTime, Math, and Debug

public class GameManager : MonoBehaviour
{
    // ------------------------- VARIABLES -------------------------
    [Header("REFERENCE")]
    public List<NPCData> allNPCs = new List<NPCData>(); // List to store all NPCData instances, manually assigned in Inspector
    public GameObject dialoguePanel; // Reference to the dialogue panel GameObject

    [Header("AI ATTRIBUTES")]
    public bool isAIActive = false; // Boolean to check if AI is active
    public bool isAIAway = false; // Boolean to check if AI is away

    [Header("CHARACTER ATTRIBUTES")]
    public int playerHP; // Player's current health points

    // -------------------------- METHODS --------------------------
    void Start() // Start is called before the first frame update
    {
        CloseDialoguePanel(); // Closes the dialogue panel at the start of the game
    }

    private void Update() // Update is called once per frame
    {
        // Check if the player is dead
        if (playerHP <= 0)
        {
            // Handle player death (e.g., show game over screen, reset game, etc.)
            Debug.Log("Player is dead!"); // Placeholder for player death handling
        }
    }

    void ResetDialogueCounters() // Method to reset the dialogue counter for each NPC
    {
        foreach (NPCData npc in allNPCs) // Loops through all NPCData instances stored in the list
        {
            if (npc != null) // Ensures the NPCData is valid (not null)
            {
                npc.dialogueCounter = 0; // Resets the dialogue counter for this NPC
                //Debug.Log($"Reset dialogue counter for {npc.npcName}"); 
            }
        }
    }

    public void OpenDialoguePanel()
    {
        dialoguePanel.SetActive(true); // Activates the dialogue panel GameObject
    }

    public void CloseDialoguePanel()
    {
        dialoguePanel.SetActive(false); // Deactivates the dialogue panel GameObject
        ResetDialogueCounters(); // Calls the method to reset dialogue counters for all NPCs
    }
}
