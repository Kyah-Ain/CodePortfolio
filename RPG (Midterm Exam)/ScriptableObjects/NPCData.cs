using System.Collections; // Grants access to collections structures like Lists and Dictionaries
using System.Collections.Generic; // Grants access to collections structures like Lists and Dictionaries
using UnityEngine; // Grants access to Unity's core features like Datatypes, DateTime, Math, and Debug

[CreateAssetMenu(fileName = "New NPC", menuName = "NPC/Create NPC", order = 1)] // Creates a new NPC ASSET in the project

public class NPCData : ScriptableObject
{
    // ------------------------- VARIABLES -------------------------
    //[Header("Reference Scripts")]
    //public ManRunnerDialogue manRunnerDialogue; // Reference to the ManRunnerDialogue.cs script
    //public GirlRunnerDialogue girlRunnerDialogue; // Reference to the GirlRunnerDialogue.cs script

    [Header("IDENTITY")]
    public Sprite npcPortrait; // Portrait image of the NPC
    public string npcName; // Name of the NPC
    public string [] npcDialogue; // Dialogue lines for the NPC
    public int dialogueCounter; // Counter for the current dialogue line

    [Header("ATTRIBUTES")]
    public int health; // Health of the NPC
    public int attack; // Attack power of the NPC
}
