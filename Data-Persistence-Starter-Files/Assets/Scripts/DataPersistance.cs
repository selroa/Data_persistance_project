using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class DataPersistance : MonoBehaviour
{
    public static DataPersistance Instance;
    public string playerName;
    public string bestPlayer;
    public int highScore;

    public void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance);

        LoadGame();
    }

    [System.Serializable]
    class GameInfo
    {
        public string bestPlayer;
        public int highscore;
    }

    public void SaveGame()
    {
        GameInfo data = new GameInfo();
        data.bestPlayer = bestPlayer;
        data.highscore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameInfo data = JsonUtility.FromJson<GameInfo>(json);

            bestPlayer = data.bestPlayer;
            highScore = data.highscore;
        }
    }
}
