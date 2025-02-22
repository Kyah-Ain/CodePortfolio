using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using TMPro;
using UnityEngine.UI;

public class ButtonInstantiator : MonoBehaviour
{
    public List<Character> characterList = new List<Character>(); // LIST OF ALL THE CHARACTER CREATED
    public GameObject buttonPrefab; // CONTAINER FOR UNITY OBJECTS YOU WANT TO INSTANTIATE 
    public Transform buttonContainer; // CONTAINER FOR THE PARENT OF THE OBJECT YOU WANT TO INSTANTIATE

    public TMP_InputField inputName;
    public TMP_InputField inputLevel;

    public void Start()
    {
        
        characterList.Clear(); // To make sure the list is cleared before loading one (to avoid ghost buttons)
    }

    public void PokemonGenerator()
    {
        // -------------------------- POKEMONS --------------------------
        Character torchic = new Character("Torchic", "5", ElementType.FIRE, Gender.FEMALE);
        torchic.name = inputName.text;
        Character mudkip = new Character("Mudkip", "48", ElementType.WATER, Gender.MALE);
        mudkip.name = inputLevel.text;
        Character treecko = new Character("Treecko", "207", ElementType.GRASS, Gender.BINARY);

        characterList.Add(torchic); // Appends the character along with it's attributes to the list
        characterList.Add(mudkip); // Same as the one above me
        characterList.Add(treecko); // Same as the one above me

        foreach (Character i in characterList) // Creates buttons for each Pokemon characters on the list
        {
            CreateCharacterButton(i); // Creates a button based on the current character indexed
        }
    }

    public void CreateCharacterButton(Character character)
    {
        GameObject characterButton = Instantiate(buttonPrefab, buttonContainer);
        ButtonCharacter pokemonButton = characterButton.GetComponent<ButtonCharacter>();
        Button button = pokemonButton.GetComponent<Button>();

        button.onClick.AddListener(() => OnClickCharacterButton(character));
        pokemonButton.SetData(character); // Update UI with character data
    }


    public void OnClickCharacterButton(Character character)
    {
        if (character.name != "")
        {
            Debug.Log($"You obtained {character.name} at lvl.{character.level}.");
        }
        else
        {
            Debug.Log("There seems to be a problem with the data. Try again later. : (");
        }
    }

}