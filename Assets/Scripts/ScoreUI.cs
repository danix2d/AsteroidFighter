using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreUI : MonoBehaviour
{
    public IntVariable PlayerScore;
    public TMP_Text statsTxt;

    private int score;

    private void Start()
    {
        UpdateScore();
    }

    public void UpdateScore()
    {
        score = PlayerScore.Value;

        statsTxt.text = score.ToString();
    }
}
