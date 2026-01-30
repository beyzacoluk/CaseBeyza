using UnityEngine;
using BayatGames.SaveGameFree; 

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SaveGameData(string key, object data)
    {
        SaveGame.Save(key, data);
        Debug.Log("Oyun kaydedildi");
    }

    public T LoadGameData<T>(string key, T defaultValue)
    {
        return SaveGame.Exists(key) ? SaveGame.Load<T>(key) : defaultValue;
    }
}
