using System.Collections; // Use for some arrays and collections
using System.Collections.Generic; // Used for things like lists and dictionaries
using UnityEngine; // Uses basic system functions like date and time, math functions, and data types

public class ClassSystem : MonoBehaviour
{
    [Header("REFERENCES")]
    private Adventurer adventurerCurrentClass; // Reference to the class of Adventurer.cs script

    [Header("CLASS BUTTONS")]
    [Header("Beginner")]
    public GameObject[] adventurerButton;

    [Header("Lvl.1")]
    public GameObject[] sorceressButton;
    public GameObject[] clericButton;

    [Header("Lvl.2")]
    public GameObject[] mysticButton;
    public GameObject[] elementalistButton;

    public GameObject[] paladinButton;
    public GameObject[] priestButton;

    [Header("Lvl.3")]
    public GameObject[] warMageButton;
    public GameObject[] chaosMageButton;

    public GameObject[] pyromancerButton;
    public GameObject[] iceWitchButton;


    public GameObject[] crusaderButton;
    public GameObject[] inquisitorButton;

    public GameObject[] guardianButton;
    public GameObject[] saintButton;

    // ---------------------------- Beginner ---------------------------
    public void ChooseAdventurer() // Choose the base class
    {
        adventurerCurrentClass = gameObject.AddComponent<Adventurer>();
        adventurerCurrentClass.Execute();
        foreach (GameObject button in adventurerButton)
        {
            button.SetActive(true);
        }
    }

    // ----------------------------- Lvl 1 -----------------------------
    public void ChooseSorceress() 
    {
        adventurerCurrentClass = gameObject.AddComponent<Sorceress>();
        adventurerCurrentClass.Execute();

        foreach (GameObject button in sorceressButton)
        {
            button.SetActive(true);
        }

        foreach (GameObject button in clericButton)
        {
            button.SetActive(false);
        }
    }

    public void ChooseCleric() 
    {
        adventurerCurrentClass = gameObject.AddComponent<Cleric>();
        adventurerCurrentClass.Execute();

        foreach (GameObject button in clericButton)
        {
            button.SetActive(true);
        }

        foreach (GameObject button in sorceressButton)
        {
            button.SetActive(false);
        }
    }

    // ----------------------------- Lvl 2 -----------------------------
    public void ChooseMystic()
    {
        adventurerCurrentClass = gameObject.AddComponent<Sorceress>();
        adventurerCurrentClass.Execute();

        foreach (GameObject button in mysticButton)
        {
            button.SetActive(true);
        }

        foreach (GameObject button in elementalistButton)
        {
            button.SetActive(false);
        }
    }

    public void ChooseElementalist()
    {
        adventurerCurrentClass = gameObject.AddComponent<Sorceress>();
        adventurerCurrentClass.Execute();

        foreach (GameObject button in elementalistButton)
        {
            button.SetActive(true);
        }

        foreach (GameObject button in mysticButton)
        {
            button.SetActive(false);
        }
    }

    public void ChoosePaladin()
    {
        adventurerCurrentClass = gameObject.AddComponent<Cleric>();
        adventurerCurrentClass.Execute();

        foreach (GameObject button in paladinButton)
        {
            button.SetActive(true);
        }

        foreach (GameObject button in priestButton)
        {
            button.SetActive(false);
        }
    }

    public void ChoosePriest()
    {
        adventurerCurrentClass = gameObject.AddComponent<Cleric>();
        adventurerCurrentClass.Execute();

        foreach (GameObject button in priestButton)
        {
            button.SetActive(true);
        }

        foreach (GameObject button in paladinButton)
        {
            button.SetActive(false);
        }
    }

    // ----------------------------- Lvl 3 -----------------------------
    public void ChooseWarMage()
    {
        adventurerCurrentClass = gameObject.AddComponent<Sorceress>();
        adventurerCurrentClass.Execute();

        foreach (GameObject button in warMageButton)
        {
            button.SetActive(true);
        }

        foreach (GameObject button in chaosMageButton)
        {
            button.SetActive(false);
        }
    }

    public void ChooseChaosMage()
    {
        adventurerCurrentClass = gameObject.AddComponent<Sorceress>();
        adventurerCurrentClass.Execute();

        foreach (GameObject button in chaosMageButton)
        {
            button.SetActive(true);
        }

        foreach (GameObject button in warMageButton)
        {
            button.SetActive(false);
        }
    }


    public void ChoosePyromancer()
    {
        adventurerCurrentClass = gameObject.AddComponent<Sorceress>();
        adventurerCurrentClass.Execute();

        foreach (GameObject button in pyromancerButton)
        {
            button.SetActive(true);
        }

        foreach (GameObject button in iceWitchButton)
        {
            button.SetActive(false);
        }
    }

    public void ChooseIceWitch()
    {
        adventurerCurrentClass = gameObject.AddComponent<Sorceress>();
        adventurerCurrentClass.Execute();

        foreach (GameObject button in iceWitchButton)
        {
            button.SetActive(true);
        }

        foreach (GameObject button in pyromancerButton)
        {
            button.SetActive(false);
        }
    }


    public void ChooseCrusader()
    {
        adventurerCurrentClass = gameObject.AddComponent<Cleric>();
        adventurerCurrentClass.Execute();

        foreach (GameObject button in crusaderButton)
        {
            button.SetActive(true);
        }

        foreach (GameObject button in inquisitorButton)
        {
            button.SetActive(false);
        }
    }

    public void ChooseInquisitor()
    {
        adventurerCurrentClass = gameObject.AddComponent<Cleric>();
        adventurerCurrentClass.Execute();

        foreach (GameObject button in inquisitorButton)
        {
            button.SetActive(true);
        }

        foreach (GameObject button in crusaderButton)
        {
            button.SetActive(false);
        }
    }


    public void ChooseGuardian()
    {
        adventurerCurrentClass = gameObject.AddComponent<Cleric>();
        adventurerCurrentClass.Execute();

        foreach (GameObject button in guardianButton)
        {
            button.SetActive(true);
        }

        foreach (GameObject button in saintButton)
        {
            button.SetActive(false);
        }
    }

    public void ChooseSaint()
    {
        adventurerCurrentClass = gameObject.AddComponent<Cleric>();
        adventurerCurrentClass.Execute();

        foreach (GameObject button in saintButton)
        {
            button.SetActive(true);
        }

        foreach (GameObject button in guardianButton)
        {
            button.SetActive(false);
        }
    }
}
