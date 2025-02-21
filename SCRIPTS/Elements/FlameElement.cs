using UnityEngine; // Grants access to Unity's core features

public class FlameElement : Dragons // Derived Class or Child Class
{
    public void BurningLava() // Deals burning effect
    {
        Debug.Log($"{dragonName} uses Burning Lava!");
    }

    public void FlameThrower() // Deals continous damage and ignores defense
    {
        Debug.Log($"{dragonName} uses Flamethrower!");
    }

    public void MeteorShower() // Deals heavy and continous damage
    {
        Debug.Log($"{dragonName} uses Meteor Shower!");
    }
}
