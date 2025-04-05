using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creeper : NPC // Subclass of the NPC.cs script
{
    public override void NPCTalk() // Method that must overwriten the Method/Function
    {
        // Dialogue that must be passed on
        Debug.Log("Tsss!!"); 
    }

    public override void NPCAttack() // Method that can be overwritten Method/Function
    {
        // Dialogue that could be passed on
        Debug.Log($"The creeper deals 100% critical damage!");
        Debug.Log($"You died!");
    }
}
