using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {
    public float maxGenTime = 3.0f;
    
    public float minGenTime = 1.5f;


    public float itemGenTime = 60.0f;
    public float itemLifeTime = 20.0f;


    public GameObject box;
    public GameObject[] monsterPrefep;
    public GameObject[] itemprefep;

    public float[] levelScore;


    public Score scoreManager;

    public ScoreBoard scoreBoard;

    public float y=10.0f;


    public GameObject itemAppearText;

    private List<GameObject> boxes = null;
    private List<GameObject> monsters = null;
    private GameObject lastItem = null;

    private GameObject player;


    private float x;
    private float z;

    private float sizeX;
    private float sizeY;
    private float sizeZ;


    private GameObject[] monsterGen;
    private GameObject[] itemGen;
    private int genCounter;

    private float time;
    private float itemTime;

    private bool isGenActived = false;
    //private Color color;

    private int maxLevel;
    private int nowLevel;
    private float genTime;
    // Use this for initialization
    void Start () {
        boxes = new List<GameObject>();
        monsters = new List<GameObject>();

        player = GameObject.FindGameObjectWithTag("Player");
        monsterGen = GameObject.FindGameObjectsWithTag("MonsterGen");
        itemGen = GameObject.FindGameObjectsWithTag("ItemGen");

        genCounter = monsterGen.Length;

        isGenActived = true;

        maxLevel = levelScore.Length;
        nowLevel = 1;
        genTime = maxGenTime;

        itemAppearText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (!isGenActived)
            return;
        time += Time.deltaTime;
        itemTime += Time.deltaTime;

        if(nowLevel<=maxLevel)
        {
            if (levelScore[nowLevel - 1] <= scoreManager.GetScore())
            {
                nowLevel++;
                genTime -= (maxGenTime - minGenTime) / maxLevel;
            }
        }

        

        if(time>=genTime)
        {
            CreatMonster();
            time -= genTime;
        }

        if(itemTime>=itemGenTime)
        {
            CreatIten();
            itemTime -= itemGenTime;
        }

        if(itemTime>=itemLifeTime)
        {
            itemAppearText.SetActive(false);
        }


	}
    //제시작
    public void Restart()
    {
        time = 0.0f;
        itemTime = 0.0f;

        scoreBoard.Renewing();
        
        ClearItem();
        ClearAllMonsters();
        PlayerReset();
        scoreManager.ResetScore();
        scoreManager.SetScoreActive(true);

        nowLevel = 1;
        genTime = maxGenTime;

        itemAppearText.SetActive(false);
    }

    //일시정지
    public void SetPause(bool active)
    {
        if(active)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    //테스트용
    public void CreatBox()
    {
        float red = Random.Range(0f, 1f);
        float green = Random.Range(0f, 1f);
        float blue = Random.Range(0f, 1f);

        x = Random.Range(-20.0f, 20.0f);
        z = Random.Range(-20.0f, 20.0f);

        //color = new Color(red, green, blue);

        GameObject newBox = Instantiate(box, new Vector3(x, 10, z), new Quaternion(Random.Range(0f, 90f), Random.Range(0f, 90f), Random.Range(0f, 90f), 0));

        sizeX = Random.Range(0f, 2f);
        sizeY = Random.Range(0f, 2f);
        sizeZ = Random.Range(0f, 2f);
        newBox.GetComponent<Transform>().localScale = new Vector3(sizeX, sizeY, sizeZ);
        newBox.GetComponent<BoxCollider>().size = new Vector3(sizeX, sizeY, sizeZ);

        boxes.Add(newBox);
    }
    //테스트용2
    public void ClearAllBoxes()
    {
        foreach(GameObject toRemove in boxes)
        {
            Destroy(toRemove);
        }
        boxes.Clear();
    }
    

    //몬스터 제거
    private void ClearAllMonsters()
    {
        foreach(GameObject toRemove in monsters )
        {
            Destroy(toRemove);
        }
        monsters.Clear();
    }

    //아이템 제거
    private void ClearItem()
    {
        if(lastItem != null)
        {
            Destroy(lastItem);
        }
    }
    //플레이어 원위치
    private void PlayerReset()
    {
        player.GetComponent<Skill>().Restart();
        player.GetComponent<PlayerHealth>().NewStart();
        player.transform.position = Vector3.zero;
        player.transform.rotation = new Quaternion(0, 0, 0, 0);
        player.gameObject.SetActive(true);
    }
    //몬스터 생성
    private void CreatMonster()
    {
        GameObject newMonster;
        if (Random.Range(1,6)==3)
        {
            newMonster = Instantiate(monsterPrefep[0]);
        }
        else
        {
            newMonster = Instantiate(monsterPrefep[1]);
        }

        newMonster.transform.position = monsterGen[Random.Range(0, genCounter)].transform.position;
        monsters.Add(newMonster);
    }
    //아이템 생성
    private void CreatIten()
    {
        GameObject newItem;
        newItem = Instantiate(itemprefep[Random.Range(0, itemprefep.Length)]);

        newItem.transform.position = itemGen[Random.Range(0, itemGen.Length)].transform.position - Vector3.up;

        Destroy(newItem, itemLifeTime);
        lastItem = newItem;
        itemAppearText.SetActive(true);

    }
    /*
    IEnumerator ShowItem()
    {
        int i = 0;
        while(i<itemLifeTime)
        {
            itemAppearText.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            itemAppearText.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            i++;
        }

    }
    z*/
}
