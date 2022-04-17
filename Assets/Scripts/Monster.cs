using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
    public float maxDamage = 30f;
    public float attackDictance = 100.0f;
    public float jumpPower = 100f;

    protected GameObject target;
    protected PlayerFollower follower;
    protected PlayerHealth targetHealth;

    protected bool isJump;
    protected float levelWeight;
    // Use this for initialization
    void Awake()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
    }
	void Start () {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
        if(follower == null)
        {
            follower = gameObject.GetComponent<PlayerFollower>();
        }
        if (targetHealth == null)
        {
            targetHealth = target.GetComponent<PlayerHealth>();
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    protected virtual void Attack(GameObject player)
    {

    }

    protected float getDistance()
    { 
         
        return Vector3.Distance(gameObject.transform.position, target.transform.position);
    }

    protected void SetLevelWeight()
    {
        if (LevelManager.level == LevelManager.VERY_EASY)
        {
            levelWeight = 0.5f;
        }
        else if (LevelManager.level == LevelManager.EASY)
        {
            levelWeight = 0.7f;
        }
        else if (LevelManager.level == LevelManager.NORMAL)
        {
            levelWeight = 1.0f;
        }
        else if (LevelManager.level == LevelManager.HARD)
        {
            levelWeight = 1.4f;
        }
        else if (LevelManager.level == LevelManager.VERY_HARD)
        {
            levelWeight = 2.0f;
        }
    }
    /*점프 안됨
    protected void Jump()
    {
        if (isJump)
            return;
        Rigidbody th_rigid = GetComponent<Rigidbody>();
        th_rigid.AddForce(Vector3.up*1000, ForceMode.Impulse);
        //GetComponent<Rigidbody>().AddForce(Vector3.up * 1000, ForceMode.Impulse);
    }
    */
}
