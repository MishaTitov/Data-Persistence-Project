using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string BestPlayer;
    public int BestScore;
    public string TmpPlayer;
    public int TmpScore;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string BestPlayer;
        public int BestScore;
    }

    public void SaveHighScore()
    {
        if (TmpScore > BestScore)
        {
            SaveData data = new SaveData();
            data.BestPlayer = TmpPlayer;
            data.BestScore = TmpScore;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestPlayer = data.BestPlayer;
            BestScore = data.BestScore;
        }
        else
        {
            BestPlayer = "";
            BestScore = 0;
        }
    }
}
