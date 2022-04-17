using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoverForJoystick : MonoBehaviour {
    public JoyStick joyStick;

    public float moveSpeed = 10.0F;
    public float rotateSpeed = 90.0f;

    private float maxJoystickMove;
    private Vector3 direction;
    private float moveRatio;
	// Use this for initialization
	void Start () {
        maxJoystickMove = joyStick.maxStickMove;
	}
	
	// Update is called once per frame
	void Update () {
        direction = joyStick.getDirection();
        moveRatio = joyStick.getMoveLength()/maxJoystickMove;

        //x축 회전 보정
        recorrection();

        transform.Rotate(moveRatio * direction.x * Vector3.up * rotateSpeed * Time.deltaTime * Time.timeScale);
        transform.Translate(moveRatio * direction.y * Vector3.forward * moveSpeed * Time.deltaTime * Time.timeScale);
    }

    void recorrection()
    {
        if(direction.x>0)
        {
            direction.x = Mathf.Max(direction.x - 0.1f, 0.0f);
        }
        else
        {
            direction.x = Mathf.Min(direction.x + 0.1f, 0.0f);
        }

        direction.Normalize();
    }
}
