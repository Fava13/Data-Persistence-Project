using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager2 : MonoBehaviour
{
    public static MainManager2 Instance;
    public string PlayerName;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        loadPlayerName();
    }

    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
    }

    public void save()
    {
        SaveData data = new SaveData();
        data.PlayerName = PlayerName;
        string JSON = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/SaveFile.JSON", JSON);
    }

    public void loadPlayerName()
    {
        string path = Application.persistentDataPath + "/SaveFile.JSON";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            PlayerName = data.PlayerName;
        }

    }
}
