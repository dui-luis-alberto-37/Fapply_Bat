using UnityEngine;
using TMPro;
using System.IO;


public class ScoreManager : MonoBehaviour
{
    private int score;
    private int bestScore;
    public TextMeshProUGUI textMeshPro;



    // public GameObject player;

    // private float saveTime = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // score = 0;
        // bestScore = LoadScore();
        // Debug.Log(bestScore);
        // string finaltex = "Best Score: " + bestScore.ToString() + "\nScore: " + score.ToString();
        // textMeshPro.text = finaltex;
    }

    // Update is called once per frame
    void Update()
    {
        
        // string finaltex = "Best Score: " + bestScore.ToString() + "\nScore: " + score.ToString();
        // textMeshPro.text = finaltex;
        // saveTime -= Time.deltaTime;
        // if (saveTime <= 0)
        // {
        //     SaveScore();
        //     Debug.Log("Score Saved");
        //     saveTime = 3f;
        // }
    }

    // void SaveScore()
    // {
    //     string path = Application.persistentDataPath + "/scores.json";
    //     GameData data = new GameData();
    //     data.score = score;
    //     data.bestScore = 0;
    //     string json = JsonUtility.ToJson(data);
    //     File.WriteAllText(path, json);
    //     string fileContent = File.ReadAllText(path);
    //     Debug.Log(fileContent);
        
    // }

    public int LoadScore()
    {   
        // Debug.Log("Loading Score");
        string path = Application.persistentDataPath + "/scores.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(json);
            // Debug.Log(path);
            // score = data.score;
            bestScore = data.bestScore;
            return bestScore;
        }
        else {
            return 0;
        }
    }

    public void Update_text(int score)
    {
        if (score > bestScore)
        {
            bestScore = score;
        }
        string path = Application.persistentDataPath + "/scores.json";
        string json = File.ReadAllText(path);
        GameData data = JsonUtility.FromJson<GameData>(json);
        data.score = score;
        data.bestScore = bestScore;
        string json2 = JsonUtility.ToJson(data);
        File.WriteAllText(path, json2);
        string finaltex = "Best Score: " + bestScore.ToString() + "\nScore: " + score.ToString();
        textMeshPro.text = finaltex;
    }

    public void NewLastScore(int score)
    {
        string path = Application.persistentDataPath + "/scores.json";
        if (!File.Exists(path))
        {
            GameData newData = new GameData();
            // data.latestScores = new System.Collections.Generic.List<int>() {0,0,0,0,0,0,0,0,0,0};
            string jsonInit = JsonUtility.ToJson(newData);
            File.WriteAllText(path, jsonInit);
        }
        string json = File.ReadAllText(path);
        GameData data = JsonUtility.FromJson<GameData>(json);
        data.latestScores.Insert(0, score);
        data.latestScores.RemoveAt(9);
        string json2 = JsonUtility.ToJson(data);
        File.WriteAllText(path, json2);
        Debug.Log(data.latestScores);
    }
}
