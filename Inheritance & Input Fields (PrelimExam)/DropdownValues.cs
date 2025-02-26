using System.Collections; // Grants access to collections and data structures like ArrayList
using System.Collections.Generic; // Grants access to collections and data structures like List and Dictionary
using UnityEngine; // Grants access to Unity's core features 

public class DropdownValues : MonoBehaviour
{
    public ButtonInstantiator buttonInstantiatorScript; // Grants access to the ButtonInstantiator's variables

    public void DropdownElement(int indexElement) 
    {
        switch (indexElement)
        {
            case 0: buttonInstantiatorScript.inputElement.text = "Fire"; break;
            case 1: buttonInstantiatorScript.inputElement.text = "Nature"; break;
            case 2: buttonInstantiatorScript.inputElement.text = "Water"; break;
        }
    }

    public void DropdownGender(int indexGender)
    {
        switch (indexGender)
        {
            case 0: buttonInstantiatorScript.inputGender.text  = "Male"; break;
            case 1: buttonInstantiatorScript.inputGender.text = "Female"; break;
            case 2: buttonInstantiatorScript.inputGender.text = "Binary"; break;
        }
    }
}
