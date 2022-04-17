using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightButton : MonoBehaviour {
    public bool isPress = false;

    public int offsetRed = 120;
    public int offsetGreen = 120;
    public int offsetBlue = 120;
    public RawImage image;

    private RawImage m_thisImage;
    private Color nonClicked;
    private Color Clicked;
    // Use this for initialization
    void Start()
    {
        m_thisImage = image;
        nonClicked = new Color(1, 1, 1);
        Clicked = new Color((float)offsetRed / 255, (float)offsetGreen / 255, (float)offsetBlue / 255);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnDrag()
    {
        isPress = true;
        m_thisImage.color = Clicked;
    }

    public void OnEndDrag()
    {
        isPress = false;
        m_thisImage.color = nonClicked;
    }
}
