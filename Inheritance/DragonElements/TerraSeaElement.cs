using UnityEngine;

public class TerraSeaElement : MonoBehaviour
{
    public Dragons dragonScript;

    public void AcidRain() // Deals continous damage and weaken defense
    {
        Debug.Log($"{dragonScript.dragonName} used Acid Rain!!");
    }

    public void Storm() // Deals heavy damage and weaken defense
    {
        Debug.Log($"{dragonScript.dragonName} called a storm!!");
    }

    public void Tsunami() // Deals heavy damage
    {
        Debug.Log($"{dragonScript.dragonName} brings a Tsunami!!");
    }
}
