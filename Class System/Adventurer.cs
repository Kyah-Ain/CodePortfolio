using System.Collections; // Use for some arrays and collections
using System.Collections.Generic; // Used for things like lists and dictionaries
using UnityEngine; // Uses basic system functions like date and time, math functions, and data types

public class Adventurer : MonoBehaviour
{
    public virtual void Execute() // Blank template that stores data from the child classes (like a database)
    {
        Debug.Log("Adventurer attacks!"); 
    }
}
