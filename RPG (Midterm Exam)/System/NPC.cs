using System.Collections; // Grants access to collections structure like ArrayLists and Hashtables
using System.Collections.Generic; // Grants access to collections structure like Lists and Dictionaries
using UnityEngine; // Grants access to Unity's core features like Datatypes, Time, Math, and Debug

public class NPC : MonoBehaviour
{
    // ------------------------- VARIABLES -------------------------
    public ManRunnerDialogue ManRunnerDialogue; // ManRunnerDialogue.cs Script Reference
    public GirlRunnerDialogue GirlRunnerDialogue; // GirlRunnerDialogue.cs Script Reference

    // -------------------------- METHODS --------------------------
    public void Interact() // Initiates a conversation with the NPC
    {
        if (gameObject.CompareTag("ManRunner")) // Checks if the NPC has the tag "ManRunner"
        {
            ManRunnerDialogue.Talk(); // Calls the Talk method from the NPCData.cs script
        }
        else if (gameObject.CompareTag("GirlRunner")) // Checks if the NPC has the tag "ManRunner"
        {
            GirlRunnerDialogue.Talk(); // Calls the Talk method from the NPCData.cs script
        }
    }
}
