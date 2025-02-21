using UnityEngine; // Grants access to Unity's core features

public class TerraElement : Dragons // Derived Class or Child Class
{
    public void Earthquake() // Deals continous damage and a slight chance to trigger a stun
    {
        Debug.Log($"{dragonName} uses EarthQuake!");
    }

    public void Landslide() // Deals heavy damage and destroys defense
    {
        Debug.Log($"{dragonName} uses EarthQuake!");
    }

    public void MeteorShower() // Deals continous damage 
    {
        Debug.Log($"{dragonName} uses Meteor Shower!");
    }
}
