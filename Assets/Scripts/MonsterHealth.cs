using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour {
    public float maxHealth = 10f;
    public float minHealth = 0f;

    public ParticleSystem m_ExplosionParticles;

    public control_script motionControl;
    public Score score;

    private ParticleSystem explosion;

    private float levelWeight;
    private float m_Health;
    // Use this for initialization
    private bool isDead = false;
    private void Awake()
    {
        if (m_ExplosionParticles == null)
            return;
        explosion = Instantiate(m_ExplosionParticles).GetComponent<ParticleSystem>();
        explosion.gameObject.SetActive(false);
    }
    void Start () {
        SetLevelWeight();

        m_Health = maxHealth*levelWeight;

        if(score == null)
        {
            score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        }

        isDead = false;


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GotDamage(float damage)
    {
        m_Health -= damage;
        if(m_Health<=minHealth)
        {
            Dead();
        }
    }

    public bool GetIsDead()
    {
        return isDead;
    }

    private void Dead()
    {
        isDead = true;
        //점수 증가
        score.GotKillScore();

        //폭발 이펙트
        if (explosion != null)
        {
            explosion.transform.position = transform.position;
            explosion.gameObject.SetActive(true);
            explosion.Play();
        }

        //없애기
        gameObject.SetActive(false);


        /*
        //죽는 모션 후 없애기
        if (motionControl != null)
        {


            StartCoroutine(WaitAndDead());

        }
        else //그냥 없애기
        {

            gameObject.SetActive(false);
        }
        */




    }

    private void SetLevelWeight()
    {
        if(LevelManager.level == LevelManager.VERY_EASY)
        {
            levelWeight = 0.5f;
        }
        else if(LevelManager.level==LevelManager.EASY)
        {
            levelWeight = 0.7f;
        }
        else if(LevelManager.level == LevelManager.NORMAL)
        {
            levelWeight = 1.0f;
        }
        else if(LevelManager.level == LevelManager.HARD)
        {
            levelWeight = 1.4f;
        }
        else if(LevelManager.level == LevelManager.VERY_HARD)
        {
            levelWeight = 2.0f;
        }
    }

    IEnumerator WaitAndDead()
    {
        //gameObject.SetActive(true);
        motionControl.Death();
        yield return new WaitForSeconds(1.0f);
        gameObject.SetActive(false);
    }
}
