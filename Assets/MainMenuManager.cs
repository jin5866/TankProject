using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
    public GameObject veryEasy;
    public GameObject easy;
    public GameObject normal;
    public GameObject hard;
    public GameObject veryHard;

    public GameObject playButton;

	// Use this for initialization
	void Start () {
        SetLevelButtonActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetLevelButtonActive(bool active)
    {
        veryEasy.SetActive(active);
        easy.SetActive(active);
        normal.SetActive(active);
        hard.SetActive(active);
        veryHard.SetActive(active);
    }

    public void OnPlayButtonClicked()
    {
        SetLevelButtonActive(true);
    }

    public void OnExitClicked()
    {
        Application.Quit();
    }

    public void OnVeryEasyClisked()
    {
        LevelManager.level = LevelManager.VERY_EASY;
        PlayGame();
    }

    public void OnEasyClidked()
    {
        LevelManager.level = LevelManager.EASY;
        PlayGame();
    }

    public void OnNormalClicked()
    {
        LevelManager.level = LevelManager.NORMAL;
        PlayGame();
    }

    public void OnHardClicked()
    {
        LevelManager.level = LevelManager.HARD;
        PlayGame();
    }

    public void OnVeryHardClicked()
    {
        LevelManager.level = LevelManager.VERY_HARD;
        PlayGame();
    }

    private void PlayGame()
    {
        SceneManager.LoadScene("_1");
    }
}
