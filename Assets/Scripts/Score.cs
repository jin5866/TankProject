using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public float scorePerSceond = 5f;
    public float scorePerKill = 100f;

    public Text text;

    float levelWeight;
    float score;
    bool isStarted;
	// Use this for initialization
	void Start () {
        SetLevelWeight();
        score = 0.0f;
        isStarted = true;
	}
	public void newStart()
    {
        SetLevelWeight();
        score = 0.0f;
        isStarted = true;
    }
	// Update is called once per frame
	void Update () {
        
        text.text = "Score:"+score.ToString("N0");
        if (!isStarted)
            return;

        GotTimeScore();

    }

    public void GotKillScore()
    {
        if(isStarted)
        {
            score += scorePerKill*levelWeight;
        }
    }

    public void ResetScore()
    {
        score = 0.0f;
    }

    public void SetScoreActive(bool active)
    {
        isStarted = active;
    }
    public float GetScore()
    {
        return score;
    }

    private void GotTimeScore()
    {
        score += scorePerSceond * levelWeight * Time.deltaTime;
    }

    private void SetLevelWeight()
    {
        if (LevelManager.level == LevelManager.VERY_EASY)
        {
            levelWeight = 0.2f;
        }
        else if (LevelManager.level == LevelManager.EASY)
        {
            levelWeight = 0.5f;
        }
        else if (LevelManager.level == LevelManager.NORMAL)
        {
            levelWeight = 1.0f;
        }
        else if (LevelManager.level == LevelManager.HARD)
        {
            levelWeight = 2f;
        }
        else if (LevelManager.level == LevelManager.VERY_HARD)
        {
            levelWeight = 4f;
        }
    }
}
