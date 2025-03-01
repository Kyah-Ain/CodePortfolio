using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int levelAt; // This identifies the player's current level

    // Start is called before the first frame update
    void Start()
    {
        // This updates the level save
        PlayerPrefs.SetInt("p_lastLevel", levelAt);

        if (PlayerPrefs.GetInt("p_levelAt") < levelAt)
        {
            PlayerPrefs.SetInt("p_levelAt", levelAt);
        }
        PlayerPrefs.Save();
        // End level save update
    }


}
