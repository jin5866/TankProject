using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour {
    public float explosionRange = 10.0f;
    public float explosionForce = 1000F;
    public float exprosionRatio = 5f;
    public float coolTime = 1.0f;

    public float maxDamage = 100f;

    public GameObject shockWave;
    public OnScreenButton skillButton;

    private float restTime;

    private bool isCanUse = false;
	// Use this for initialization
	void Start () {
        restTime = 0.0f;
        isCanUse = true;
	}
	
	// Update is called once per frame
	void Update () {
        restTime -= Time.deltaTime;

        if(restTime <= 0.0 && !isCanUse)
        {
            isCanUse = true;
            skillButton.SetActivityOfButton(true);
        }

        if(skillButton.isPress && isCanUse)
        {
            ShockSkill();
            skillButton.SetActivityOfButton(false);
        }
	}
    public void Restart()
    {
        isCanUse = true;
        skillButton.SetActivityOfButton(true);
    }

    void ShockSkill()
    {
        restTime = coolTime;
        isCanUse = false;

        //폭발 범위 계산 
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRange);

        //폭발 충격 받기
        foreach (Collider something in colliders)
        {
            if( something.tag == "Player" )
            {
                continue;
            }
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

            float damage = (1.0f - Mathf.Max(Vector3.Distance(something.transform.position, transform.position) / explosionRange, 0.0f)) * maxDamage;
            monster.GotDamage(damage);
        }

        GameObject shellInstance = Instantiate(shockWave, transform.position, transform.rotation);
    }
}
