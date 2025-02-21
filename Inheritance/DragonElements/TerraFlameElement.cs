using UnityEngine;

public class TerraFlameElement : MonoBehaviour
{
    public Dragons dragonScript;

    public void BurningLava() // Deals burning effect
    {
        Debug.Log($"{dragonScript.dragonName} uses Burning Lava!");
    }

    public void Earthquake() // Deals continous damage and a slight chance to trigger a stun
    {
        Debug.Log($"{dragonScript.dragonName} uses EarthQuake!");
    }

    public void MeteorShower() // Deals continous damage 
    {
        Debug.Log($"{dragonScript.dragonName} uses Meteor Shower!");
    }
}
