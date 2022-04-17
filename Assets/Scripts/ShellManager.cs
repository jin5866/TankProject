using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellManager : MonoBehaviour {
    public float explosionRange = 10.0f;
    public float explosionForce = 1000F;
    public float exprosionRatio = 5f;
    public float maxLifeTime = 2f;
    public ParticleSystem m_ExplosionParticles;

    public float maxDamage = 100f;

    private ParticleSystem explosion;
    private GameObject _ex;
    private void Awake()
    {
        
        explosion = Instantiate(m_ExplosionParticles).GetComponent<ParticleSystem>();
        explosion.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        //폭발 범위 계산 
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRange);

        //폭발 충격 받기
        foreach(Collider something in colliders)
        {
            Rigidbody targetRigidbody = something.GetComponent<Rigidbody>();

            if (!targetRigidbody)
                continue;

            targetRigidbody.AddExplosionForce(explosionForce, transform.position, exprosionRatio);


        }
        //데미지 계산
        foreach (Collider something in colliders)
        {
            MonsterHealth monster = something.GetComponent<MonsterHealth>();
            if (!monster)
                continue;
            
            float damage = (1.0f-Mathf.Max(Vector3.Distance(something.transform.position, transform.position) / explosionRange, 0.0f)) * maxDamage;
            monster.GotDamage(damage);
        }

        explosion.transform.position = transform.position;
        explosion.gameObject.SetActive(true);
        //m_ExplosionParticles.transform.parent = null;
        //m_ExplosionParticles.Play();
        explosion.Play();
        Destroy(explosion.gameObject,1.5f);
        //Destroy(m_ExplosionParticles);
        Destroy(gameObject);
    }

	void Start () {

        Destroy(gameObject, maxLifeTime);
        //explosion = GetComponentInChildren<ParticleSystem>();
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
