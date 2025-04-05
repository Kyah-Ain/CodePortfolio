using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : NPC // Subclass of the NPC.cs script
{
    public override void NPCTalk() // Method that will overwriten
    {
        // Dialogue that must be passed on
        Debug.Log("Hmmm! Aheuhh!!!"); 
    }

    public override void NPCAttack() // Method that can be overwritten Method/Function
    {
        // Dialogue that could be passed on
        Debug.Log($"The villager deals no damage.");
        Debug.Log($"You have been offered a stick in exchange of emerald.");
    }
}
