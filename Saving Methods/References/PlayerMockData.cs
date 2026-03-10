using UnityEngine;

public class PlayerMockData : MonoBehaviour
{
    public sirRazBinarySaveManager binarySaveManager;
    public sirRazSaveData mockData;

    public void Save()
    {
        CodeSaving();
        binarySaveManager.SaveGame(mockData);
    }
    public void Load()
    {
       mockData = binarySaveManager.LoadGame();
    }

    void CodeSaving()
    {
        // Create mocked SaveData

        // Mock PlayerData
        mockData.playerData = new sirRazPlayerData();
        mockData.playerData.playerName = "MockHero";
        mockData.playerData.playerScore = 9999;
        mockData.playerData.playerPosition = new sirRazSerializableVector3(new Vector3(10f, 2f, 5f));

        // Mock InventoryData
        mockData.inventoryData = new sirRazInventoryData();
        mockData.inventoryData.items = new sirRazInventoryItem[]
        {
            new sirRazInventoryItem { itemName = "Sword", quantity = 1 },
            new sirRazInventoryItem { itemName = "Health Potion", quantity = 5 },
            new sirRazInventoryItem { itemName = "Mana Potion", quantity = 3 }
        };

        // Mock GameSettings
        mockData.gameSettings = new sirRazGameSettings();
        mockData.gameSettings.soundVolume = 0.8f;
        mockData.gameSettings.musicVolume = 0.6f;

        // Save it using SaveManager
        binarySaveManager.SaveGame(mockData);
    }
}
