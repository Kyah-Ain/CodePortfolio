using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// -------------------------- ACTS AS A DATABASE --------------------------

[System.Serializable]
public class Character
{
    // ---------------- BUTTON UI STORED DATA -------------------
    public string name; // Stores the pokemon's name
    public float currentHp; // Stores the pokemon's current HP
    public float maxHp; // Stores the pokemon's max HP
    public float level; // Stores the pokemon's price
    public string ability; // Stores the pokemon's ability deatil
    public string description; // Stores the pokemon's description
    public Sprite characterSprite; // Stores the pokemon's sprite

    public State state;

    // ---------------- DATA CONSTRUCTORS -------------------

    public Character(string name, float currentHp, float maxHp, float level, string ability, string description, Sprite characterSprite) // Constructs template for values that will be passed on from other scripts
    {
        this.name = name;
        this.currentHp = currentHp;
        this.maxHp = maxHp;
        this.level = level;
        this.ability = ability;
        this.description = description;
        this.characterSprite = characterSprite;
        //this.state = state;
    }

    public Character() // Constructs default value when there is no value passed on from the other scripts
    {
        name = "UNKNOWN";
        currentHp = 0;
        maxHp = 0;
        level = 0;
        ability = "UNKNOWN";
        description = "UNKNOWN";
        characterSprite = null;
        state = State.UNKNOWN;
    }

}

public enum State { WALK, RUN, CROUCH, CRAWL, UNKNOWN } // Just a random states that could help me in the future