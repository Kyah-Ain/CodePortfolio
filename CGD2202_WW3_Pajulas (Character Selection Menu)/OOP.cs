using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OOPSample : MonoBehaviour
{
    public List<Character> characterList = new List<Character>(); // LIST OF ALL THE CHARACTER CREATED
    public GameObject buttonPrefab; // CONTAINER FOR UNITY OBJECTS YOU WANT TO INSTANTIATE 
    public Transform buttonContainer; // CONTAINER FOR THE PARENT OF THE OBJECT YOU WANT TO INSTANTIATE

    public Pokedex pokeDex;

    public void Start()
    {
        // -------------------------- FILLING A CLASS VARIABLES FROM "CHARACTER" SCRIPT (METHOD 1: LONG METHOD) --------------------------
        //Character officer = new Character();
        //officer.name = "lazareto";
        //officer.description = "Supplier";
        //officer.specialAbility = "Infinite Supply";
        //officer.salary = 500;
        //officer.state = State.WALK;

        //Character intel = new Character();
        //intel.name = "Pagbilao";
        //intel.description = "Hacker";
        //intel.specialAbility = "InstantBypass";
        //intel.salary = 300;
        //intel.state = State.CRAWL;

        //Character specialOPS = new Character();
        //specialOPS.name = "Padel";
        //specialOPS.description = "Swat";
        //specialOPS.specialAbility = "MultiKill";
        //specialOPS.salary = 100;
        //specialOPS.state = State.CROUCH;

        //Character corpsman = new Character();
        //corpsman.name = "Pajulas";
        //corpsman.description = "Medic";
        //corpsman.specialAbility = "Overtime";
        //corpsman.salary = 80;
        //corpsman.state = State.RUN;

        //Character general = new Character();
        //general.name = "Tuliao";
        //general.description = "Strategist";
        //general.specialAbility = "Reincarnation";
        //general.salary = 1000;
        //general.state = State.WALK;

        //Debug.Log($"Name: {general.name}, Description: {general.description}, Special Ability: {general.specialAbility}, Salary: {general.salary}");

        // -------------------------- FILLING A CLASS VARIABLES FROM "CHARACTER" SCRIPT (METHOD 2: SHORT METHOD) --------------------------
        //Character officer = new Character("Lazareto", "SUPPLIER", "Infinite Supply", 500, State.WALK);
        //Character intel = new Character("Pagbilao", "HACKER", "InstantBypass", 300, State.CRAWL);
        //Character specialOPS = new Character("Padel", "SWAT", "MultiKill", 100, State.CROUCH);
        //Character corpsman = new Character("Pajulas", "MEDIC", "Overtime", 80, State.RUN);
        //Character general = new Character("Tuliao", "STRATEGIST", "Reincarnation", 1000, State.WALK);

        //characterList.Add(officer);
        //characterList.Add(intel);
        //characterList.Add(specialOPS);
        //characterList.Add(corpsman);
        //characterList.Add(general);

        pokeDex = FindObjectOfType<Pokedex>();    

        // -------------------------- POKEMONS --------------------------
        characterList.Clear(); // To make sure the list is cleared before loading one (to avoid ghost buttons)

        Character torchic = new Character("Torchic", 21, 21, 5, "Meteor", "Might become a phoenix or a lechon manok someday.", Resources.Load<Sprite>("POKEMONS/Torchic"));
        Character mudkip = new Character("Mudkip", 48, 48, 16, "Tsunami", "Likes to wet the bed.", Resources.Load<Sprite>("POKEMONS/Mudkip"));
        Character treecko = new Character("Treecko", 207, 207, 100, "Climate Change", "Hates Vegans.", Resources.Load<Sprite>("POKEMONS/Treecko"));

        characterList.Add(torchic); // Appends the character along with it's attributes to the list
        characterList.Add(mudkip); // Same as the one above me
        characterList.Add(treecko); // Same as the one above me

        foreach (Character i in characterList) // Creates buttons for each Pokemon characters on the list
        {
            CreateCharacterButton(i); // Creates a button based on the current character indexed
            //if (characterList.Count != 3)
            //{
            //    //Debug.Log(characterList.Count);

            //    CreateCharacterButton(i);
            //}
        }

    }

    public void CreateCharacterButton(Character character)
    {
        GameObject characterButton = Instantiate(buttonPrefab, buttonContainer);
        ButtonCharacter buttonCharacter = characterButton.GetComponent<ButtonCharacter>();
        Button button = buttonCharacter.GetComponent<Button>();

        button.onClick.AddListener(() => OnClickCharacterButton(character));
        buttonCharacter.SetData(character); // Update UI with character data
    }


    public void OnClickCharacterButton(Character character)
    {
        if (character.name != "")
        {
            Debug.Log($"You obtained {character.name} at lvl.{character.level}.");
            pokeDex.OpenFloatingPanel(character); // Pass on the existing character's data to be used 
        }
        else
        {
            Debug.Log("There seems to be a problem with the data. Try again later. : (");
        }
    }

}
