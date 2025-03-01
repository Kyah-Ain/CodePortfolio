using System.Collections; // Grants access to collections and data structures like ArrayList
using System.Collections.Generic; // Grants access to collections and data structures like List and Dictionary
using UnityEngine; // Grants access to Unity's core features 

public class EnemyDamage : MonoBehaviour
{
    // ------------------------- VARIABLES -------------------------
    public HealthManager healthManagerScript; // Grants access to the "HP" functions of the controllable character

    public float opassumDamage; // Damage of ground enemy "Opassum"
    public float vultureDamage; // Damage of air enemy "Vulture"

    // ------------------------- FUNCTIONS -------------------------
    private void OnCollisionStay2D(Collision2D collision) // Triggers when a gameObject enters a collision with something that have this script
    {
        //Debug.Log("Collision Detected!");
        if (collision.gameObject.CompareTag("Opassum")) // Specifies the collision to execute the code when collided with Opassum 
        {
            healthManagerScript.TakeDamage(opassumDamage); // Pass on values to the damage would impact to the player's health bar
            //Debug.Log("Damage Executed!");
        }

        else if (collision.gameObject.CompareTag("Vulture")) // Specifies the collision to execute the code when collided with Opassum Vulture
        {
            healthManagerScript.TakeDamage(vultureDamage); // Pass on values to the damage would impact to the player's health bar
            Debug.Log("Vulture Damage Executed!");
        }
    }

}
