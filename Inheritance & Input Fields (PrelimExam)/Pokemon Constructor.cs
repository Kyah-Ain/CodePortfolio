using System.Collections; // Grants access to collections and data structures like ArrayList
using System.Collections.Generic; // Grants access to collections and data structures like List and Dictionary
using UnityEngine; // Grants access to Unity's core features 

[System.Serializable]
public class Character // ---------------------------------------- ACTS AS A DATABASE ----------------------------------------
{
    // ---------------- BUTTON UI STORED DATA -------------------
    public string name;
    public string level;
    public string element;
    public string gender;

    // ---------------- DATA CONSTRUCTORS -------------------

    public Character(string name, string level, string element, string gender) // Constructs template for values that will be passed on from other scripts
    {
        this.name = name;
        this.level = level;
        this.element = element;
        this.gender = gender;
    }

    public Character() // Constructs default value when there is no value passed on from the other scripts
    {
        this.name = "???";
        this.level = "?";
        this.element = "UNKNOWN";
        this.gender = "UNSPECIFIED";
    }

}

public enum ElementType { DARK, ELECTRIC, FIRE, GRASS, GROUND, NATURE, NORMAL, POISON, WATER, UNKNOWN} // Elemental Attributes for a pokemon
public enum Gender { MALE, FEMALE, BINARY, UNDEFINED } // Gender Attributes for a pokemon