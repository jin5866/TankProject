using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerFollower : MonoBehaviour {
    public float speed = 3.5f;
    public float acceleration = 8.0f;

    public float veryEasyWeight = 0.7f;
    public float easySpeedWeight = 0.9f;

    private Animator ani;
    private NavMeshAgent navi;

    private GameObject m_Player;
    private Transform playersPosition;

    private float levelWeight;



    // Use this for initialization
    void Start () {
        m_Player = GameObject.FindGameObjectWithTag("Player");
        navi = gameObject.GetComponent<NavMeshAgent>();
        SetLevelWeight();

        navi.speed = this.speed * levelWeight;
        navi.acceleration = this.acceleration * levelWeight;
    }

    // Update is called once per frame
    void Update () {
        navi.SetDestination(m_Player.transform.position);
        
        
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Wall")
            transform.Rotate(Vector3.up*180*Time.deltaTime);
    }

    public void SetEnable(bool active)
    {
        navi.enabled = active;
    }

    protected void SetLevelWeight()
    {
        if (LevelManager.level == LevelManager.VERY_EASY)
        {
            levelWeight = veryEasyWeight;
        }
        else if (LevelManager.level == LevelManager.EASY)
        {
            levelWeight = easySpeedWeight;
        }
        else if (LevelManager.level == LevelManager.NORMAL)
        {
            levelWeight = 1.0f;
        }
        else if (LevelManager.level == LevelManager.HARD)
        {
            levelWeight = 1.0f;
        }
        else if (LevelManager.level == LevelManager.VERY_HARD)
        {
            levelWeight = 2.0f;
        }
    }
}
