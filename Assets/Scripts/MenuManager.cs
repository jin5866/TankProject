using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public GameObject resume;
    public GameObject removeAllBox;
    public GameObject restart;
    public GameObject selectControl;
    public GameObject exit;

    public GameObject ct_JoyStick;
    public GameObject ct_CrossButton;
    public GameObject ct_NoButton;

    public GameObject joyStickBall;
    public GameObject upButton;
    public GameObject downButton;
    public GameObject rightButton;
    public GameObject leftButton;

    public GameObject nameInputButton;

    public InputField nameInputField;

    public GameObject scoreBoard;
    public Score scoreManager;
    public MapManager mapManager;

    public Transform startPosition;

    public int R = 120;
    public int G = 120;
    public int B = 120;
    public int alpa = 120;

    private Color clickedColor;
    private Color nonClickedColor;

    public RawImage thisImage;

    

    private bool bottonActivity = true;
	// Use this for initialization
    void OnAwake()
    {


    }
	void Start () {



        clickedColor = new Color((float)R / 255, (float)G / 255, (float)B / 255, (float)alpa / 255);
        nonClickedColor = Color.white;

        if(!thisImage)
            thisImage = GetComponent<RawImage>();

        SetMenuActive(false);
        SetButtonAvtive(true);
        SetControlButtonActive(false);
        SetScoreBoardActive(false);
        if (!mapManager)
            GameObject.FindGameObjectsWithTag("MapManager");
	}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(bottonActivity)
            {
                OpenTheMenu();
            }
            else
            {
                CloseTheMenu();
                CloseControlMenu();
            }
        }

    }
    
    public void SetMenuActive(bool active)//메뉴 안 버튼들 활성 비활성
    {
        
        resume.SetActive(active);
        //removeAllBox.SetActive(active);
        restart.SetActive(active);
        selectControl.SetActive(active);
        exit.SetActive(active);
    }
    
    private void SetButtonAvtive(bool active)//메뉴 버튼 활성 비활성
    {
        mapManager.SetPause(!active);

        if (active)
        {
            thisImage.color = nonClickedColor;
            bottonActivity = true;
        }
        else
        {
            thisImage.color = clickedColor;
            bottonActivity = false;
        }
    }

    private void SetControlButtonActive(bool active)
    {
        ct_CrossButton.SetActive(active);
        ct_JoyStick.SetActive(active);
        ct_NoButton.SetActive(active);
    }

    private void SetScoreBoardActive(bool active)
    {
        scoreBoard.SetActive(active);
        if(active)
        {
            scoreBoard.GetComponent<ScoreBoard>().Renewing();
        }
    }


    private void SetJoyStick(bool active)
    {
        joyStickBall.SetActive(active);
    }//조이스틱 온오프

    private void SetCrossButton(bool active)
    {
        upButton.SetActive(active);
        downButton.SetActive(active);
        rightButton.SetActive(active);
        leftButton.SetActive(active);
    }//크로스 버튼 온오프


    private void CloseTheMenu() //메뉴닫기
    {
        SetMenuActive(false);
        SetButtonAvtive(true);
    }

    private void OpenTheMenu() //메뉴 멸기
    {
        SetMenuActive(true);
        SetButtonAvtive(false);
    }

    private void CloseControlMenu()
    {
        SetControlButtonActive(false);
        SetButtonAvtive(true);
    }//컨트롤 버튼 닫기



    
    public void OnMenuClicked() //메뉴버튼 눌리면
    {
        if (!bottonActivity)
            return;


        OpenTheMenu();
    }

    public void OnResumeClicked() 
    {
        CloseTheMenu();
    }

    public void OnRemoveAllBoxClicked()
    {
        mapManager.ClearAllBoxes();
        CloseTheMenu();
    }
   
    public void OnRestartClicked() //mapManager에 restart 실행
    {
        scoreBoard.GetComponent<ScoreBoard>().Restart();
        mapManager.Restart();
        CloseTheMenu();
    }

    public void OnExitClicked()
    {
        scoreBoard.GetComponent<ScoreBoard>().SaveData();
        mapManager.Restart();
        
        CloseTheMenu();
        SceneManager.LoadScene("MainMenu");
        //Application.Quit();
    }

    public void OnSelectControlClicked()
    {
        SetMenuActive(false);
        SetControlButtonActive(true);
    }

    public void OnCTJoyStickClicked()
    {
        SetJoyStick(true);
        SetCrossButton(false);
        CloseControlMenu();
    }

    public void OnCTCrossButtonClicked()
    {
        SetJoyStick(false);
        SetCrossButton(true);
        CloseControlMenu();
    }

    public void OnCTNoButtonClicked()
    {
        SetJoyStick(false);
        SetCrossButton(false);
        CloseControlMenu();
    }


    public void OnNameInputButtonClicked()
    {
        scoreBoard.GetComponent<ScoreBoard>().NewScore(nameInputField.text, (int)scoreManager.GetScore());
        scoreBoard.SetActive(false);
    }

    public void ScoreBoardActive(bool active)
    {
        SetScoreBoardActive(active);
    }
    
}
