using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoyStick : MonoBehaviour {
    public RawImage Stick;
    public float maxStickMove = 200.0f;

    private Vector3 orignPos = Vector3.zero;
    private Vector3 direction;
    private float moveLength;

    void Awake()
    {

    }

    void Start()
    {
        orignPos = Stick.transform.position;
        //조이스틱의 반경을 계산해둔다.

    }

    public void OnDrag()
    {
        if (Stick == null)
            return;

        Touch touch = Input.GetTouch(0);
   

        direction = (new Vector3(touch.position.x, touch.position.y, orignPos.z) - orignPos).normalized;

        float touchAreaRadius = Vector3.Distance(orignPos, new Vector3(touch.position.x, touch.position.y, orignPos.z));
        if (touchAreaRadius > maxStickMove)
        {
            //반경을 넘어가는 경우는, 현재 가려는 방향으로, 반지름 만큼만 가도록 설정한다.
            Stick.rectTransform.position = orignPos + (direction * maxStickMove);
            moveLength = maxStickMove;
        }
        else
        {
            //조이스틱이 반경내로 움직일때만, 드래그 된 위치로 설정한다.
            Stick.rectTransform.position = touch.position;
            moveLength = touchAreaRadius;
        }
    }

    public void OnEndDrag()
    {
        if (Stick != null)
        {
            Stick.rectTransform.position = orignPos;
        }
        direction = Vector3.zero;
        moveLength = 0.0f;
    }

    public Vector3 getDirection()
    {
        return direction;
    }

    public float getMoveLength()
    {
        return moveLength;
    }
}
