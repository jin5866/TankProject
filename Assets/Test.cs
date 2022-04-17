using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour {
    
	// Use this for initialization
    void Awake()
    {
        //StartCoroutine(KamBBack());
    }
	void Start () {
        


    }
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(KamBBack());
    }

    IEnumerator KamBBack()
    {
        for(;;)
        {
            gameObject.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(0.3f);
            gameObject.GetComponent<Text>().text = "Item!!!";
            yield return new WaitForSeconds(0.3f);
        }

    }
}
