using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {
    public float moveSpeed =1.0F;
    public float rotateSpeed = 1.0f;

    private float m_herizontal;
    private float m_vertical;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(Input.GetAxis("Horizontal") * (new Vector3(0, 1, 0)) * rotateSpeed * Time.deltaTime * Time.timeScale);
        transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime * Time.timeScale);
	}
}
