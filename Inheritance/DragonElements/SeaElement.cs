using UnityEngine; // Grants access to Unity's core features

public class SeaElement : Dragons // Derived Class or Child Class
{
    public void AcidRain() // Deals continous damage and weaken defense
    {
        Debug.Log($"{dragonName} used Acid Rain!!");
    }

    public void Flood() // Deals heavy damage
    {
        Debug.Log($"{dragonName} uses Flood!");
    }

    public void Storm() // Deals heavy damage and weaken defense
    {
        Debug.Log($"{dragonName} called a storm!!");
    }

    public void Tsunami() // Deals heavy damage
    {
        Debug.Log($"{dragonName} brings a Tsunami!!");
    }

    public void Whirlpool() // Deals heavy damage and a slight chance to trigger a stun
    {
        Debug.Log($"{dragonName} uses Flood!");
    }
}
