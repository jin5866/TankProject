using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowingCamera : MonoBehaviour {

    public GameObject player;
    public float offsetX = 0f;
    public float offsetY = 7.0f;
    public float offsetZ = 10.0f;
    public float offsetCameraSpeed = 0.8f;

    public float maxZ = 53.0f;

    //private float offsetRotation = 1.0f;
    // private float offsetHeight = 1.0f;


    //private Transform target;
    private float m_X;
    private float m_Y;
    private float m_Z;
    private float m_CameraSpeed;
    private Vector3 cameraPosition;

    private GameObject m_player;


    // Use this for initialization
    void Start()
    {
        m_X = offsetX;
        m_Y = offsetY;
        m_Z = offsetZ;
        m_CameraSpeed = offsetCameraSpeed;
        if (!player)
        {
            m_player = GameObject.FindWithTag("Player");
        }
        else
        {
            m_player = player;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        cameraPosition.x = m_player.transform.position.x + m_X;
        cameraPosition.y = m_player.transform.position.y + m_Y;
        cameraPosition.z = m_player.transform.position.z + m_Z;

        //벽에 가림현상 제거
        if(cameraPosition.z<-maxZ)
        {
            cameraPosition.z = -maxZ;
        }

        transform.position = Vector3.Lerp(transform.position, cameraPosition, m_CameraSpeed * Time.deltaTime);
        //transform.LookAt(player.transform);
    }
}
