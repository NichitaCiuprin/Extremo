using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Animator scullAnimator;

    private int score;

    private void Awake()
    {
        instance = this;
        score = 0;
    }

    public void IncrementScore()
    {
        ++score;
        scoreText.text = score.ToString();
        scullAnimator.SetTrigger("Burn");
    }
    public void ResetScore()
    {
        score = 0;
        scoreText.text = score.ToString();
    }
}
