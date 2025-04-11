using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleClassSystem : MonoBehaviour
{
    [Header("REFERENCES")]
    private Adventurer adventurerCurrentClass; // Reference to the class of Adventurer.cs script

    [Header("CLASS BUTTONS")]
    [Header("Lvl.1")]
    public GameObject sorceressButton;
    public GameObject clericButton;

    [Header("Lvl.2")]
    public GameObject mysticButton;
    public GameObject elementalistButton;

    public GameObject paladinButton;
    public GameObject priestButton;

    [Header("Lvl.3")]
    public GameObject warMageButton;
    public GameObject chaosMageButton;

    public GameObject pyromancerButton;
    public GameObject iceWitchButton;


    public GameObject crusaderButton;
    public GameObject inquisitorButton;

    public GameObject guardianButton;
    public GameObject saintButton;

    // ----------------------------- Lvl 1 -----------------------------
    public void ChooseSorceress()
    {
        adventurerCurrentClass = gameObject.AddComponent<Sorceress>();
        sorceressButton.SetActive(true);
        adventurerCurrentClass.Execute();
    }

    public void ChooseCleric()
    {
        adventurerCurrentClass = gameObject.AddComponent<Cleric>();
        clericButton.SetActive(true);
        adventurerCurrentClass.Execute();
    }

    // ----------------------------- Lvl 2 -----------------------------
    public void ChooseMystic()
    {
        adventurerCurrentClass = gameObject.AddComponent<Sorceress>();
        mysticButton.SetActive(true);
        adventurerCurrentClass.Execute();
    }

    public void ChooseElementalist()
    {
        adventurerCurrentClass = gameObject.AddComponent<Sorceress>();
        elementalistButton.SetActive(true);
        adventurerCurrentClass.Execute();
    }

    public void ChoosePaladin()
    {
        adventurerCurrentClass = gameObject.AddComponent<Cleric>();
        paladinButton.SetActive(true);
        adventurerCurrentClass.Execute();
    }

    public void ChoosePriest()
    {
        adventurerCurrentClass = gameObject.AddComponent<Cleric>();
        priestButton.SetActive(true);
        adventurerCurrentClass.Execute();
    }

    // ----------------------------- Lvl 3 -----------------------------
    public void ChooseWarMage()
    {
        adventurerCurrentClass = gameObject.AddComponent<Sorceress>();
        warMageButton.SetActive(true);
        adventurerCurrentClass.Execute();
    }

    public void ChooseChaosMage()
    {
        adventurerCurrentClass = gameObject.AddComponent<Sorceress>();
        chaosMageButton.SetActive(true);
        adventurerCurrentClass.Execute();
    }


    public void ChoosePyromancer()
    {
        adventurerCurrentClass = gameObject.AddComponent<Sorceress>();
        pyromancerButton.SetActive(true);
        adventurerCurrentClass.Execute();
    }

    public void ChooseIceWitch()
    {
        adventurerCurrentClass = gameObject.AddComponent<Sorceress>();
        iceWitchButton.SetActive(true);
        adventurerCurrentClass.Execute();
    }


    public void ChooseCrusader()
    {
        adventurerCurrentClass = gameObject.AddComponent<Cleric>();
        crusaderButton.SetActive(true);
        adventurerCurrentClass.Execute();
    }

    public void ChooseInquisitor()
    {
        adventurerCurrentClass = gameObject.AddComponent<Cleric>();
        inquisitorButton.SetActive(true);
        adventurerCurrentClass.Execute();
    }


    public void ChooseGuardian()
    {
        adventurerCurrentClass = gameObject.AddComponent<Cleric>();
        guardianButton.SetActive(true);
        adventurerCurrentClass.Execute();
    }

    public void ChooseSaint()
    {
        adventurerCurrentClass = gameObject.AddComponent<Cleric>();
        saintButton.SetActive(true);
        adventurerCurrentClass.Execute();
    }
}
