using System.Collections; // Use for some arrays and collections
using System.Collections.Generic; // Used for things like lists and dictionaries
using UnityEngine; // Uses basic system functions like date and time, math functions, and data types

public class Crusader : Paladin
{
    public override void Execute() // This method overrides the Execute method in the Paladin class
    {
        Debug.Log("Crusader attacks with a sword and shield!");
    }
}
