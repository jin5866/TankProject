using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMonster : Monster {
    public float explosionRange = 5.0f;
    public float explosionForce = 1000F;
    public float exprosionRatio = 5f;

    public ParticleSystem m_ExplosionParticles;

    public float upForce = 1000f;

    private ParticleSystem explosion;

    void OnTriggerEnter(Collider other)
    {
        
       // Bomb();
    }
    private void Awake()
    {

        explosion = Instantiate(m_ExplosionParticles).GetComponent<ParticleSystem>();
        explosion.gameObject.SetActive(false);
    }
    // Use this for initialization
    void Start () {
        SetLevelWeight();
        if (target == null)
        {
            target = GameObject.FindGameObjectsWithTag("Player")[0];
        }
        if (follower == null)
        {
            follower = gameObject.GetComponent<PlayerFollower>();
        }
        if(targetHealth == null)
        {
            targetHealth = target.GetComponent<PlayerHealth>();
        }
        //isJump = false;
    }
	
	// Update is called once per frame
	void Update () {

        float a;
        if ((a = getDistance()) < attackDictance)
        {
            Attack(target);
        }

        /* 점프 테스트용
        if(Input.GetAxis("Jump")>0.0f)
        {
            Jump();
        }
        */
	}
    
    protected override void Attack(GameObject player)
    {
        //follower.SetEnable(false);
        //Jump();
        Bomb();
    } //아직 덜 구현됨 

    private void Bomb()
    {
        float damage;

        //폭발 범위 계산 
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRange);

        //폭발 충격 받기
        foreach (Collider something in colliders)
        {
            Rigidbody targetRigidbody = something.GetComponent<Rigidbody>();

            if (!targetRigidbody)
                continue;

            targetRigidbody.AddExplosionForce(explosionForce, transform.position, exprosionRatio);
        }
        //데미지 계산
        damage = maxDamage;

        //폭발 데미지
        targetHealth.DealDanage(damage * levelWeight);
        
        //폭발 이펙트
        explosion.transform.position = transform.position;
        explosion.gameObject.SetActive(true);
        explosion.Play();
        //파괴
        Destroy(gameObject); 
    }

    
}
