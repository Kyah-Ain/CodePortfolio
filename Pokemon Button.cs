using UnityEngine; // Grants access to Unity's core features 
using TMPro; // To use Text Mesh Pro related functions 

public class ButtonCharacter : MonoBehaviour
{
    // --------------------- TEXTMESH PRO OUTPUTS ---------------------
    public TextMeshProUGUI outputCharacterName;  // Refers to the TextMeshPRO's CHARACTER NAME displayed
    public TextMeshProUGUI outputCurrentLevel; // Refers to the he TextMeshPRO's CURRENT LEVEL displayed 
    public TextMeshProUGUI outputElementType; // Refers to the TextMeshPRO's ELEMENT displayed 
    public TextMeshProUGUI outputGenderType; // Refers to the TextMeshPRO's GENDER displayed 

    public void SetData(Character character) // Displays the compiled data of the pokemon to the button
    {
        this.outputCharacterName.text = character.name; // Passes the CHARACTER NAME of the pokemon to the button
        this.outputCurrentLevel.text = character.level; // Passes the current LEVEL of the pokemon to the button
        this.outputElementType.text = $"{character.element}"; // Passes the ELEMENT of the pokemon to the button
        this.outputGenderType.text = $"{character.gender}"; // Passes the GENDER of a pokemon to the button
    }
}