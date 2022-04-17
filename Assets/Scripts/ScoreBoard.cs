using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreBoard : MonoBehaviour {
    public int numberOfScores = 5;
    public Score scoreManager;

    public Text[] nameBoards;
    public Text[] scoreBoards;

    private string[] names;
    private int[] scores;

    string userName = "Name";
    string score = "Score";

    bool isNewSaves = false;

    string levelName;
    // Use this for initialization
    void Start () {
        GetLevelName();

        names = new string[numberOfScores];
        scores = new int[numberOfScores];

        GetData();
        SetBoard();
	}
	
    public void Renewing()
    {
        GetLevelName();
        GetData();
        SetBoard();
    }
	// Update is called once per frame
	void Update () {
		
	}

    public void SaveData()
    {
        GetLevelName();

        if (names == null)
            return;
        if (scores == null)
            return;

        for(int i=1;i<=numberOfScores;i++)
        {
            PlayerPrefs.SetString(userName + levelName+ i, names[i-1]);
            PlayerPrefs.SetInt(score + levelName+ i, scores[i-1]);
        }
    }

    void GetData()
    {
        GetLevelName();

        if (names == null)
            return;
        if (scores == null)
            return;
        for (int i = 1; i <= numberOfScores; i++)
        {
            names[i - 1] = PlayerPrefs.GetString(userName+levelName + i);
            scores[i - 1] = PlayerPrefs.GetInt(score+levelName + i);

            if(names[i-1]==null)
            {
                names[i - 1] = "noname";
                scores[i - 1] = 0;
            }
        }
    }

    void SetBoard()
    {
        if (names == null)
            return;
        if (scores == null)
            return;

        for (int i =0; i<numberOfScores;i++)
        {
            nameBoards[i].text = names[i];
            scoreBoards[i].text = scores[i].ToString();
        }
    }

    void GetLevelName()
    {
        if (LevelManager.level == LevelManager.VERY_EASY)
        {
            levelName = "VeryEasy";
        }
        else if (LevelManager.level == LevelManager.EASY)
        {
            levelName = "Easy";
        }
        else if (LevelManager.level == LevelManager.NORMAL)
        {
            levelName = "Normal";
        }
        else if (LevelManager.level == LevelManager.HARD)
        {
            levelName = "Hard";
        }
        else if (LevelManager.level == LevelManager.VERY_HARD)
        {
            levelName = "VeryHard";
        }
    }
    public void NewScore(string newName,int newScore)
    {
        if (isNewSaves)
            return;

        int i=0;
        while(i<numberOfScores)
        {
            if (newScore > scores[i])
                break;
            i++;
        }
        if (i == numberOfScores)
            return;

        string defName;
        int defScore;
        string toInputName = newName;
        int toInputScore = newScore;

        for(int j=i;j<numberOfScores;j++)
        {
            defName = names[j];
            defScore = scores[j];
            names[j] = toInputName;
            scores[j] = toInputScore;
            toInputName = defName;
            toInputScore = defScore;
        }

        SaveData();
        SetBoard();

        isNewSaves = true;
    }


    public void Restart()
    {
        isNewSaves = false;
    }
}
