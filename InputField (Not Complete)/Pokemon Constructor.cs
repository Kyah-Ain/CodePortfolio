using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// -------------------------- ACTS AS A DATABASE --------------------------

[System.Serializable]
public class Character
{
    // ---------------- BUTTON UI STORED DATA -------------------
    public string name;
    public string level;
    public ElementType element;
    public Gender gender;

    // ---------------- DATA CONSTRUCTORS -------------------

    public Character(string name, string level, ElementType element, Gender gender) // Constructs template for values that will be passed on from other scripts
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
        this.element = ElementType.UNKNOWN;
        this.gender = Gender.UNDEFINED;
    }

}

public enum ElementType { DARK, ELECTRIC, FIRE, GRASS, GROUND, ICE, NORMAL, POISON, WATER, UNKNOWN} // Elemental Attributes for a pokemon
public enum Gender { MALE, FEMALE, BINARY, UNDEFINED}