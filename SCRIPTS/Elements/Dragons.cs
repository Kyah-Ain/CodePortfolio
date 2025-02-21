using UnityEngine; // Grants access to Unity's core features

public class Dragons : MonoBehaviour // Base Class or Default Class
{
    // ------------------------- VARIABLES -------------------------
    public string dragonName; // Accepts strings values or Game Object with text
    public int level; // Accepts integer values or GameObjects with numbers
    public int hp; // Accepts integer values or GameObjects with numbers
    public DragonStatus dragonStatus = DragonStatus.NONE; // Sets the state value of the dragon to be at default

    // ------------------------- FUNCTIONS -------------------------
    void Start() // Start is called once before the first frame update 
    {
        
    }

    // 
    public void NormalAttack() // Deals normal damage to the enemies
    {
        Debug.Log($"{dragonName} initiate an attack!");
    }

    public void HardCharge() // Deals more damage than usual
    {
        Debug.Log($"{dragonName} deals critical damage!!");
    }

    public void StunningHit() // Stuns the target
    {
        Debug.Log($"{dragonName} used stunning hit!!");
    }
}
 public enum DragonStatus { STUNNED, SLEEP, POISONED, BURN, NONE }