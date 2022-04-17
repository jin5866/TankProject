using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHOS : MonoBehaviour {
    public float rotateZ = 15f;

    private Vector3 rotateRatio;
	// Use this for initialization
	void Start () {
        rotateRatio = new Vector3(0, 0, rotateZ);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotateRatio * Time.deltaTime);
	}
}
