using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steve : NPC // Subclass of the NPC.cs script
{
    public override void NPCTalk() // Method that will overwriten
    {
        // Dialogue that must be passed on
        Debug.Log("I am Steve!!"); 
    }

    public override void NPCAttack() // Method that can be overwritten Method/Function
    {
        // Dialogue that could be passed on
        Debug.Log($"Steve turns into Herobrine!");
        Debug.Log($"Your PC crashed!! OH NOOO!");
    }
}
