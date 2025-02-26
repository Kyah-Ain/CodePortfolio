using System.Collections; // Grants access to collections and data structures like ArrayList
using System.Collections.Generic; // Grants access to collections and data structures like List and Dictionary
using UnityEngine; // Grants access to Unity's core features 
using TMPro; // To use Text Mesh Pro related functions 

public class PanelToggler : MonoBehaviour
{
    public GameObject floatingPanel; // Refers to the panel that will be shown

    public void OpenFloatingPanel() // Opens the panel
    {
        floatingPanel.gameObject.SetActive(true); // Opens the Pokedex
    }

    public void CloseFloatingPanel()
    {
        floatingPanel.gameObject.SetActive(false); // Closes the Panel
    }
}
