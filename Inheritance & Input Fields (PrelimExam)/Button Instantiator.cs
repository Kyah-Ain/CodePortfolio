using System.Collections; // Grants access to collections and data structures like ArrayList
using System.Collections.Generic; // Grants access to collections and data structures like List and Dictionary
using UnityEngine; // Grants access to Unity's core features 
using TMPro; // To use Text Mesh Pro related functions  
using UnityEngine.UI; // Provides UI components functions like Button, Image, and InputField

public class ButtonInstantiator : MonoBehaviour
{
    // -------------------- LIST AND UI ELEMENTS --------------------
    public static List<Character> characterList = new List<Character>(); // LIST OF ALL THE CHARACTER CREATED
    public GameObject buttonPrefab; // CONTAINER FOR UNITY OBJECTS YOU WANT TO INSTANTIATE 
    public Transform buttonContainer; // CONTAINER FOR THE PARENT OF THE OBJECT YOU WANT TO INSTANTIATE

    // --------------------- TEXTMESH PRO INPUTS ---------------------
    public TMP_InputField inputName; // Refers to the TextMeshPRO's User Input for the Character Name of the button
    public TMP_InputField inputLevel; // Refers to the TextMeshPRO's User Input for the Level Displayed on the button
    public TextMeshProUGUI inputElement; // Refers to the TextMeshPRO's User Input for the Element Displayed on the button
    public TextMeshProUGUI inputGender; // Refers to the TextMeshPRO's User Input for the Element Displayed on the button

    // --------------------- TEXTMESH PRO OUTPUT REFERENCE ---------------------
    public ButtonCharacter buttonCharacterScript; // Grants access to the TextMeshPro Output Texts

    public void Start() // A function that called only once at the start of the program
    {
        characterList.Clear(); // To clean the list on every run of the program (OPTIONAL)
    }

    //public void Update()
    //{
    //    Debug.Log(buttonCharacterScript.outputElementType.text); // Outputs Element Type
    //    Debug.Log(inputElement.text); // Outputs Fire
    //}

    public void ButtonGenerator() // Generates button based from the data on the list
    {

        foreach (Character i in characterList) // Creates buttons for each Pokemon characters on the list
        {
            CreateCharacterButton(i); // Generates a button based on the current character in the list 
            Debug.Log($"Creating button for {i.name}, Level: {i.level}"); // Monitors the creation of each button
        }

        //Debug.Log("ButtonGenerator Called!");

        //if (characterList.Count == 0)
        //{
        //    Debug.LogWarning("No characters available! Add a character first.");
        //    return;
        //}

        //Debug.Log($"Generating buttons for {characterList.Count} characters...");
    }

    public void PokemonGenerator() // Generates data and pass it all to the list
    {
        // --------------------- BUTTON UI ELEMENTS ---------------------
        // Passed on User Inputs to the Button's Displayed Variables
        buttonCharacterScript.outputCharacterName.text = inputName.text; // Display Variable for Button's Character Name
        buttonCharacterScript.outputCurrentLevel.text = inputLevel.text; // Display Variable for Button's Displayed Level
        buttonCharacterScript.outputElementType.text = inputElement.text; // Display Variable for Button's Element Type
        buttonCharacterScript.outputGenderType.text = inputGender.text; // Display Variable for Button's Gender Type

        // -------------------------- POKEMONS --------------------------
        Character newCharac = new Character(buttonCharacterScript.outputCharacterName.text, buttonCharacterScript.outputCurrentLevel.text, buttonCharacterScript.outputElementType.text, buttonCharacterScript.outputGenderType.text); // Creates charac

        // Appends the character along with it's attributes to the list
        characterList.Add(newCharac);

        // --------------------- DEBUGGING ---------------------
        //Debug.Log("PokemonGeneratorWorks!");
        Debug.Log("PokemonGenerator was clicked!");
        Debug.Log($"Total characters: {characterList.Count}");
        foreach (Character c in characterList)
        {
            Debug.Log($"Character: {c.name}, Level: {c.level}");
        }
    }

    public void CreateCharacterButton(Character character) //
    {
        // --------------------- BUTTON INSTANTIATION ---------------------
        GameObject characterButton = Instantiate(buttonPrefab, buttonContainer); // Instantiates a button under buttonContainer
        ButtonCharacter pokemonButton = characterButton.GetComponent<ButtonCharacter>(); // Grants access to the features of ButtonCharacter Script ???
        Button button = pokemonButton.GetComponent<Button>(); // Grants access to the features of Button ???

        button.onClick.AddListener(() => OnClickCharacterButton(character)); // For having a function for when the created button was clicked???
        pokemonButton.SetData(character); // Update UI with character data
    }

    public void OnClickCharacterButton(Character character) // Displays a message to the console whenever the button is clicked
    {
        Debug.Log($"You obtained {character.name} at lvl.{character.level}."); // Possible message to be displayed
    }

}