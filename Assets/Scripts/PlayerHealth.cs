using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public float maxHealth = 100f;
    public float minHealth = 0.0f;
    public ParticleSystem m_ExplosionParticles;
    public Slider healthBar;
    public MenuManager menu;
    private ParticleSystem explosion;

    private Score score;
    private float m_Health;

    private void Awake()
    {

        explosion = Instantiate(m_ExplosionParticles).GetComponent<ParticleSystem>();
        explosion.gameObject.SetActive(false);
    }
    private bool isDead;
	// Use this for initialization
	void Start () {
        m_Health = maxHealth;
        isDead = false;
        healthBar.value = 1.0f;

        if (score == null)
        {
            score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        }
    }

	public void NewStart()
    {
        m_Health = maxHealth;
        isDead = false;
        healthBar.value = 1.0f;
    }
	// Update is called once per frame
	void Update () {
		
	}

    public void DealDanage(float damage)
    {
        if (isDead)
            return;

        m_Health -= damage;
        //체력바 갱신
        healthBar.value = Mathf.Max(0.0f,m_Health / maxHealth);
        
        if(m_Health <= minHealth)
        {
            Dead();
        }
    }

    public void HealHealth(float heal)
    {
        m_Health += heal;
    }

    private void Dead()
    {
        //
        isDead = true;
        //파괴 이팩트 실행
        explosion.transform.position = transform.position;
        explosion.gameObject.SetActive(true);
        explosion.Play();
        explosion.gameObject.SetActive(false);
        //Destroy(explosion.gameObject, 1.5f);

        //파괴
        gameObject.SetActive(false);

        //스코어 정지
        score.SetScoreActive(false);

        //점수창
        menu.ScoreBoardActive(true);
    }
}
