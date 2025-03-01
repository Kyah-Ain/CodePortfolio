using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // To use Text Mesh Pro related functions 

public class Pokedex : MonoBehaviour
{
    public GameObject floatingPanel; // Refers to the panel that will be shown

    // POKEDEX FLOATING PANEL VARIABLES FOR POKEMON's STATS AND INFO
    public TextMeshProUGUI characterName_FP; 
    public TextMeshProUGUI currentHp_FP;
    public TextMeshProUGUI maxHp_FP;
    public TextMeshProUGUI level_FP;
    public Image characterImage_FP;

    public TextMeshProUGUI ability_FP;
    public TextMeshProUGUI description_FP; // No reference yet because dimopa ginagawan ng attribute sa Character Constructor
    

    //public bool floatingPanelState = false;

    //public void panelStateChecker()
    //{
    //    if (floatingPanelState == true)
    //    {
    //        OpenFloatingPanel();
    //    } 
    //    else
    //    {
    //        CloseFloatingPanel();
    //    }
    //}
    public void OpenFloatingPanel(Character character) // Function that accepts character's attributes as value to be used for modification 
    {
        floatingPanel.gameObject.SetActive(true); // Opens the Pokedex

        characterName_FP.text = character.name;
        currentHp_FP.text = $"{character.currentHp}";
        maxHp_FP.text = $"{character.maxHp}";
        level_FP.text = $"lvl. {character.level}";
        ability_FP.text = character.ability;
        description_FP.text = character.description;
        characterImage_FP.sprite = character.characterSprite;
    }

    public void CloseFloatingPanel()
    {
        floatingPanel.gameObject.SetActive(false); // Closes the Pokedex
    }
}
