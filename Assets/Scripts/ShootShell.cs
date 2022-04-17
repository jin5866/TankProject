using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootShell : MonoBehaviour {
    public GameObject shell = null;
    public OnScreenButton shootButton = null;

    public float maxGauge = 100.0f;
    public float minGauge = 10.0f;
    public float gaugeCharging = 30.0f;
    public Transform m_FireTransform ;

    public float shotOffsetX = 0.0f;
    public float shotOffsetY = 1.6f;
    public float shotOffsetZ = 1.05f;

    public float shotRoteX = -15f;

    public float m_ReflectForce = 250f;
    public float m_ReflectRatio = 5.0f;
    public float shootDelay = 0.5f;

    private GameObject newShell;
    private Rigidbody m_Tank;

    private bool beforePressed = false;

    private float beforeShootTime = 0.0f;

    private float gauge;
    private Vector3 shotPosition;
    private Vector3 creatPositon;
    private Quaternion shotRotate;
    // Use this for initialization
    void Start () {
        gauge = 0.0f;
        shotPosition = new Vector3(shotOffsetX, shotOffsetY, shotOffsetZ);
        creatPositon = new Vector3(0, 0, 0);
        m_Tank = GetComponent<Rigidbody>();
        shotRotate = new Quaternion(shotRoteX, 0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {

        beforeShootTime += (Time.deltaTime * Time.timeScale);

        if (beforeShootTime < shootDelay)
            return;

        if (shootButton.isPress)
        {
            if(!beforePressed)
            {
                beforePressed = true;
                gauge = minGauge;
            }
            else if(beforePressed)
            {
                if(gauge>maxGauge)
                {
                    shot();
                }
                else
                {
                    gauge += gaugeCharging * Time.deltaTime;
                }
            }
        }
        else
        {
            if(beforePressed)
            {
                shot();
            }
        }
	}

    private void shot()
    {
        beforePressed = false;
        shotPosition =  transform.position+transform.forward * shotOffsetZ + transform.right * shotOffsetX + transform.up * shotOffsetY;
        shotRotate = transform.rotation;
        
        GameObject shellInstance = Instantiate(shell, shotPosition, shotRotate);
        shellInstance.GetComponent<Rigidbody>().velocity = gauge * transform.forward;
        beforeShootTime = 0.0f;
        //reflect
        //m_Tank.AddExplosionForce(m_ReflectForce * gauge / minGauge, shotPosition, m_ReflectRatio);
    }
}
