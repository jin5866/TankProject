using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoverForPhone : MonoBehaviour {
    public UpButton upButton;
    public DownButton downButton;
    public RightButton rightButton;
    public LeftButton leftButton;

    public float rotationSpeed = 90f;
    public float moveSpeed = 1.0f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(upButton.isPress)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * Time.timeScale);
        }
        if(downButton.isPress)
        {
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime * Time.timeScale);
        }
        if(rightButton.isPress)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * Time.timeScale);
        }
        if(leftButton.isPress)
        {
            transform.Rotate(-Vector3.up * rotationSpeed * Time.deltaTime * Time.timeScale);
        }
	}
}
