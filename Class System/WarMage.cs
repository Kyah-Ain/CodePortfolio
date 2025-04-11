using System.Collections; // Use for some arrays and collections
using System.Collections.Generic; // Used for things like lists and dictionaries
using UnityEngine; // Uses basic system functions like date and time, math functions, and data types

public class WarMage : Mystic
{
    public override void Execute() // This method overrides the Execute method in the Mystic class
    {
        Debug.Log("War Mage attacks with a powerful spell!");
    }
}
