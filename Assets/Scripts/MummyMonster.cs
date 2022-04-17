using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyMonster : Monster {
    public float attackDelay = 1.0f;
    public control_script motionControl;
    public MonsterHealth monsterHealth;
    private bool isAttack;

    private float beforeAttackTime;
	// Use this for initialization
	void Start () {
        SetLevelWeight();

        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
        if (follower == null)
        {
            follower = gameObject.GetComponent<PlayerFollower>();
        }
        if (targetHealth == null)
        {
            targetHealth = target.GetComponent<PlayerHealth>();
        }
        isAttack = false;
        motionControl.OtherIdle();
    }
	
	// Update is called once per frame
	void Update () {
        if(monsterHealth.GetIsDead())
        {
            motionControl.Death();
            return;
        }

        beforeAttackTime += Time.deltaTime;

        if(beforeAttackTime>attackDelay)
        {
            isAttack = false;
            motionControl.Walk();
        }
        /*
        if(!isAttack)
        {
            motionControl.Walk();
        }*/

        if ( getDistance() < attackDictance)
        {
            if(beforeAttackTime>attackDelay)
            {
                Attack(target);
            }
        }
    }

    protected override void Attack(GameObject player)
    {
        motionControl.Attack();
        targetHealth.DealDanage(maxDamage * levelWeight);
        isAttack = true;
        beforeAttackTime = 0.0f;
        //Wait();
        //motionControl.OtherIdle();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.0f);
    }
}
