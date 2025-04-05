using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour
{
    public abstract void NPCTalk(); // Requires the subclass to pass on values

    public virtual void NPCAttack() // Lets the subclass to pass on values
    {
        // Default value of the Method/Function
        Debug.Log("No Damage Has been hit!"); 
    }

    private void Start() // Call at the start of the runtime
    {
        NPCTalk();
        NPCAttack();
    }
}
