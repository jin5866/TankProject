using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnScreenButton : MonoBehaviour {

    public bool isPress = false;

    public int offsetRed = 120;
    public int offsetGreen = 120;
    public int offsetBlue = 120;
    public RawImage image;

    private RawImage m_thisImage;
    private Color nonClicked;
    private Color Clicked;
    private Color unActived;
    private bool isActive;
    // Use this for initialization
    void Start()
    {
        isActive = true;
        m_thisImage = image;
        nonClicked = new Color(1, 1, 1);
        Clicked = new Color((float)offsetRed / 255, (float)offsetGreen / 255, (float)offsetBlue / 255);
        unActived = new Color((float)offsetRed / 255, (float)offsetGreen / 255, (float)offsetBlue / 255);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnDrag()
    {
        if (!isActive)
            return;

        isPress = true;
        m_thisImage.color = Clicked;
    }

    public void OnEndDrag()
    {

        if (!isActive)
            return;

        isPress = false;
        m_thisImage.color = nonClicked;
    }



    public void SetActivityOfButton(bool active)
    {
        isActive = active;
        if(active)
        {
            m_thisImage.color = nonClicked;
        }
        else
        {
            m_thisImage.color = unActived;
            isPress = false;
        }
    }
}
