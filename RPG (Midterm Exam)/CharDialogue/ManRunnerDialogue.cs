using System.Collections; // Grants access to collections structures like Lists and Dictionaries
using System.Collections.Generic; // Grants access to collections structures like Lists and Dictionaries
using TMPro; // Grants access to TextMeshPro features like TextMeshProUGUI
using UnityEngine; // Grants access to Unity's core features like Datatypes, DateTime, Math, and Debug

public class ManRunnerDialogue : MonoBehaviour
{
    [Header("REFERENCE")]
    public GameManager gameManager; // Reference to the GameManager.cs script
    public NPCData npcData; // Reference to the NPCData.cs scriptable object

    [Header("DIALOGUE DISPLAY")]
    public TextMeshProUGUI npcNameTMPro; // TextMeshProUGUI component for displaying the NPC's name
    public TextMeshProUGUI dialogueBoxTMPro; // TextMeshProUGUI component for displaying dialogue

    public void Talk() // Talk method for the NPC
    {
        if (npcData.dialogueCounter < npcData.npcDialogue.Length)
        {
            gameManager.OpenDialoguePanel(); // Calls the OpenDialoguePanel method from the GameManager.cs script to open the dialogue panel
            DisplayDialogue(); // Calls the DisplayDialogue method to show the first dialogue line
            Debug.Log(npcData.npcDialogue[npcData.dialogueCounter]); // Prints the current dialogue line to the console
            npcData.dialogueCounter += 1; // Increments the dialogue counter
            //Debug.Log($"After increment: dialogueCounter = {dialogueCounter}");
        }
        else
        {
            gameManager.CloseDialoguePanel(); // Calls the CloseDialoguePanel method from the GameManager.cs script to close the dialogue panel
            Application.Quit(); // Quits the application
        }
    }

    public void DisplayDialogue() // Displays the current dialogue line
    {
        // Sets the NPC's name and dialogue in the TextMeshProUGUI components
        npcNameTMPro.text = npcData.npcName; // Sets the NPC's name in the TextMeshProUGUI component
        dialogueBoxTMPro.text = npcData.npcDialogue[npcData.dialogueCounter]; // Sets the current dialogue line in the TextMeshProUGUI component
    }
}
