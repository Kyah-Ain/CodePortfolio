using UnityEngine; // Grants access to Unity's core features
using System.Collections; // Grants access to collections and data structures like ArrayList 
using System.Collections.Generic; // Grants access to collections and data data structures like List and Dictionary

public class DragonManager : MonoBehaviour
{
    // ------------------------- VARIABLES -------------------------
    // Placeholder of Parent gameObjects from the scene 
    //public GameObject dragonParents; // Parent of all Dragons
    public GameObject terraTypesParent; // Parent of all TerraTypes
    public GameObject seaTypesParent; // Parent of all SeaTypes
    public GameObject flameTypesParent; // Parent of all FlameTypes

    // Creates a list based from the gameObjects we would passed on from the Scene
    public List<Dragons> dragons = new List<Dragons>(); // List that should contains "Dragons" Class

    public List<TerraElement> terraTypes = new List<TerraElement>(); // List that should contains "TerraElement" Class
    public List<SeaElement> seaTypes = new List<SeaElement>(); // List that should contain "SeaElement" Class
    public List<FlameElement> flameTypes = new List<FlameElement>(); // List that should contain "FlameElement" Class

    // ------------------------- FUNCTIONS -------------------------
    void Start() // Start is called once before the first frame update 
    {
        // Game Object dependent way (Long but Precise Method)
        // list name | function | Game Object to be passed on | Script that it contains 
        terraTypes.AddRange(terraTypesParent.GetComponentsInChildren<TerraElement>());
        seaTypes.AddRange(seaTypesParent.GetComponentsInChildren<SeaElement>());
        flameTypes.AddRange(flameTypesParent.GetComponentsInChildren<FlameElement>());
        //dragons.AddRange(dragonParents.GetComponentsInChildren<Dragons>());

        // Listing-list way (Shortcut Method)
        dragons.AddRange(terraTypes);
        dragons.AddRange(seaTypes);
        dragons.AddRange(flameTypes);

        // Loop | Class | Variable | List Range
        foreach (Dragons f in dragons) // loops through flameTypes list to access FlameElements functions per every variable
        {
            f.HardCharge(); // Calls the function per gameObject being passed on
        }

        foreach (TerraElement f in terraTypes) // loops through terraTypes list to access TerraElements functions per every variable
        {
            f.MeteorShower(); // Calls the function per gameObject being passed on
        }

        foreach (SeaElement f in seaTypes) // loops through seaTypes list to access SeaElements functions per every variable
        {
            f.AcidRain(); // Calls the function per gameObject being passed on
        }

        foreach (FlameElement f in flameTypes) // loops through flameTypes list to access FlameElements functions per every variable
        {
            f.FlameThrower(); // Calls the function per gameObject being passed on
        }

    }   
    
    void Update() // Update is called once per frame
    {
        
    }
}
