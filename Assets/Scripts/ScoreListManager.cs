using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class ScoreListManager : MonoBehaviour
{
    public static ScoreListManager Instance;
    public List<int> latestScores = new List<int>();

    string path;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {   
        Debug.Log("ScoreListManager Awake");
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        path = Application.persistentDataPath + "/scores.json";
        LoadScores();
    }

    void LoadScores()
    {
        if (!File.Exists(path))
        {
            Debug.LogWarning("No score file found");
            return;
        }

        string json = File.ReadAllText(path);
        GameData data = JsonUtility.FromJson<GameData>(json);
        latestScores = data.latestScores;
    }
}
