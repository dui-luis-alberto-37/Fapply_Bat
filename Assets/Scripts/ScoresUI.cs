using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class ScoresUI : MonoBehaviour
{
    public List<TextMeshProUGUI> scoreTexts;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScoresUI();
    }

    // Update is called once per frame
    void UpdateScoresUI()
    {
        Debug.Log("Updating Scores UI");
        if (ScoreListManager.Instance == null)
        {
            Debug.LogWarning("ScoreListManager Instance is null");
            return;
        }
        List<int> latestScores = ScoreListManager.Instance.latestScores;

        for (int i = 0; i < scoreTexts.Count; i++)
        {
            if (i < latestScores.Count)
                scoreTexts[i].text = "Number " + (i+1).ToString() + ": " + latestScores[i].ToString();
            else
                scoreTexts[i].text = "-";
        }
    }
}
