using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWave : MonoBehaviour {
    public float biggerSpeed = 9.0f;
    public float lifeTime = 1.0f;

    float age;
	// Use this for initialization
	void Start () {
        age = 0.0f;
        Destroy(gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
        age += Time.deltaTime;
        transform.localScale = new Vector3(age * biggerSpeed, age * biggerSpeed, age * biggerSpeed);
	}
}
