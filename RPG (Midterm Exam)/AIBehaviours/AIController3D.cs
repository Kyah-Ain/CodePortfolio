using System.Collections; // Grants access to collections structures like Lists and Dictionaries
using System.Collections.Generic; // Grants access to collections structures like Lists and Dictionaries
using UnityEngine; // Grants access to Unity's core features like Datatypes, DateTime, Math, and Debug
using UnityEngine.AI; // Grants access to Unity's AI features like NavMeshAgent and NavMeshObstacle

public class AIController3D : MonoBehaviour
{
    // ------------------------- VARIABLES -------------------------
    [Header("REFERENCE")]
    public GameManager gameManager; // Reference to the GameManager.cs Script
    public Transform[] wayPoints; // Array of waypoints for the AI to follow
    public NavMeshAgent navMeshAgent; // Reference to the NavMeshAgent component
    public GameObject player; // Reference to the player GameObject

    [Header("ATTRIBUTES")]
    public float distance = 1f; // Distance to the waypoint
    public int destinationPoint = 0; // Index of the current destination point in the wayPoints array

    public GameObject moodState; // Reference to the mood state GameObject
    public Material inactiveState; // Shows to check if the AI is in inactive
    public Material alertState; // Shows to check if the AI is alerted
    public Material hostileState; // Shows to check if the AI is hostile

    public bool isAIHostile = false; // Shows to check if the AI is hostile

    [Header("AUDIO")]
    public AudioSource[] audioSource; // Reference to the AudioSource component
    //public AudioClip alertClip; // Audio clip to play

    // -------------------------- METHODS --------------------------
    private void Start() // Start is called before the first frame update
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); // Automatically references the NavMeshAgent component
        navMeshAgent.autoBraking = false; // Disables automatic stopping at waypoints
        if (gameManager.isAIActive)
        {
            GoToNextPoint(); // Start patrolling if AI is active
        }
    }

    private void Update() // Update is called once per frame
    {
        if (gameManager.isAIActive)
        {
            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < distance && !isAIHostile)
            {
                moodState.GetComponent<Renderer>().material = alertState; // Change the material to alert state
                GoToNextPoint(); // Call the GoToNextPoint method
                // You could also activate an Animation here (animator.SetBool("anim", anim))
            }

            else if (isAIHostile)
            {
                navMeshAgent.SetDestination(player.transform.position); // Set the destination to the player's position
                moodState.GetComponent<Renderer>().material = hostileState; // Change the material to hostile state
                // You could also activate an Animation here (animator.SetBool("anim", anim))
            }
        }

        else
        {
            moodState.GetComponent<Renderer>().material = inactiveState; // Change the material to inactive state
            navMeshAgent.autoBraking = true; // Stop moving when AI is inactive
            // You could also deactivate an Animation here (animator.SetBool("anim", anim))
        }
    }

    public void OnCollisionEnter(Collision other) // Called when a collision begins
    {
        if (other.gameObject.CompareTag("Player")) // Check if collided object is the player
        {
            gameManager.playerHP -= 1; // Reduce player HP
            Debug.Log("Player has been hit"); // Debug message
        }
    }

    public void OnTriggerEnter(Collider other) // Called when something enters the trigger
    {
        if (other.gameObject.CompareTag("Player")) // Check if the entering object is the player
        {
            isAIHostile = true; // Set the AI to hostile
            Debug.Log("AI is now hostile");
            PlayAudio(); // Play Audio Clips
        }
    }

    public void OnTriggerExit(Collider other) // Called when something exits the trigger
    {
        if (other.gameObject.CompareTag("Player")) // Check if the exiting object is the player
        {
            isAIHostile = false; // Set the AI to not hostile
            Debug.Log("AI is no longer hostile");
            StopAudio(); // Stop Audio Clips
        }
    }

    void GoToNextPoint() // Move to the next waypoint
    {
        if (wayPoints.Length == 0) // If there are no waypoints, disable the script
        {
            enabled = false; // Disable this script
            return;
        }

        navMeshAgent.destination = wayPoints[destinationPoint].position; // Set the next destination
        destinationPoint = (destinationPoint + 1) % wayPoints.Length; // Cycle through waypoints
    }

    void PlayAudio() // Play audio files related
    {
        if (audioSource != null) {
            foreach (AudioSource audio in audioSource) // Loop through all audio sources
            {
                Debug.Log($"Playing {audio}"); // Debug message
                audio.Play(); // Plays audio clip
            }
        } 
    }

    void StopAudio() // Play audio files related
    {
        if (audioSource != null)
        {
            foreach (AudioSource audio in audioSource) // Loop through all audio sources
            {
                audio.Stop(); // Plays audio clip
            }
        }
    }
}
