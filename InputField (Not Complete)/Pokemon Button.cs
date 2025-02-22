using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.TextCore.Text;
using TMPro; // To use Text Mesh Pro related functions 

public class ButtonCharacter : MonoBehaviour
{
    // ---------------- BUTTON UI ELEMENTS -------------------
    public TextMeshProUGUI characterName;  // Refers to the TEXT details displayed on the button
    public TextMeshProUGUI currentLevel; // Same as the one above me
    public TextMeshProUGUI elementType; // Same as the one above me
    public TextMeshProUGUI genderType; // Refers to the float value displayed on the button

    // --------------------- REFERENCES -----------------------
    private ButtonInstantiator buttonInstantiator; // Importing data from the "OOP" script
    public Character newCharacter; // Importing data from the "Character" script

    // Counter to track added Pokemons
    public static int counter = 0;

    public void Start()
    {
        buttonInstantiator = FindObjectOfType<ButtonInstantiator>(); // Searches the scene for a GameObject with a script specified inside the Diamond
    }

    public void BuyMore() // Function for creating new more characters when a button was pressed
    {
        //Debug.Log("I WAS EXECUTED AT START");

        counter++; // Increases the counter whenever the button is clicked

        // Adds new character one at a time based on the "counter's" current value

        switch (counter)
        {
            case 1:
                Character charmander = new Character("Charmander", "15", ElementType.FIRE, Gender.FEMALE);
                buttonInstantiator.characterList.Add(charmander);
                break;
            case 2:
                Character ditto = new Character("Ditto", "15", ElementType.FIRE, Gender.FEMALE);
                buttonInstantiator.characterList.Add(ditto);
                break;
            case 3:
                Character pikachu = new Character("Pikachu", "15", ElementType.FIRE, Gender.FEMALE);
                buttonInstantiator.characterList.Add(pikachu);
                break;
        }

        if (counter + 2 < buttonInstantiator.characterList.Count) // Specified that the new buttons would base from new added buttons rather than the existing ones
        {
            newCharacter = buttonInstantiator.characterList[counter + 2]; // Looks for the last character created from the OOP's function and copies it
            buttonInstantiator.CreateCharacterButton(newCharacter); // Calls the CreateCharacterButton function from the other script and pass on values from the data inside the parenthesis 
        }
        else
        {
            Debug.Log("UNLOCK MORE LEVELS TO UNLOCK MORE POKEMONS");
        }

        //Debug.Log(counter);
    }

    public void SetData(Character character) // Displays the compiled data of the pokemon to the button
    {
        this.characterName.text = character.name; // Pass on the name of the pokemon to the button
        this.currentLevel.text = currentLevel.text; // Pass on the current HP and max HP of the pokemon to the button
        this.elementType.text = elementType.text; // Pass on the max HP of the pokemon to the button
        this.genderType.text = genderType.text; // Pass on the value of a pokemon to the button
    }


}