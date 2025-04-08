using System.Collections; // Grants access to collections structures like Lists and Dictionaries
using System.Collections.Generic; // Grants access to collections structures like Lists and Dictionaries
using UnityEngine; // Grants access to Unity's core features like Datatypes, DateTime, Math, and Debug

public class AIAwakeTrigger : MonoBehaviour
{
    // ------------------------- VARIABLES -------------------------
    [Header("REFERENCE")]
    public GameManager gameManager; // Reference to the GameManager.cs Script

    // -------------------------- METHODS --------------------------
    public void OnTriggerEnter(Collider actor)
    {
        if (actor.CompareTag("Player")) // Checks if the actor has the tag "Player"
        {
            gameManager.isAIActive = true; // Set AI active
        }
    }

    public void OnTriggerStay(Collider actor) 
    {
        if (actor.CompareTag("AI")) // Checks if the actor has the tag "AI"
        {
            gameManager.isAIAway = false; // Set AI away
        }
    }

    public void OnTriggerExit(Collider actor)
    {
        if (actor.CompareTag("Player")) // Checks if the actor has the tag "Player"
        {
            gameManager.isAIActive = false; // Set AI inactive
        }

        if (actor.CompareTag("AI")) // Checks if the actor has the tag "AI"
        {
            gameManager.isAIAway = true; // Set AI away
        }
    }
}
