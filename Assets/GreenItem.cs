using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenItem : MonoBehaviour {
   // public GameObject itemAppearText;
    public int lifeTime = 10;
    // Use this for initialization
    void Start () {
        //itemAppearText = GameObject.FindGameObjectWithTag("ItemText");
       // ShowItem();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        Item tank = col.gameObject.GetComponent<Item>();
        if (!tank)
            return;
        tank.GreenItem();
        Destroy(gameObject);
    }

    /*
    IEnumerator ShowItem()
    {
        int i = 0;
        while (i < lifeTime)
        {
            itemAppearText.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            itemAppearText.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }

    }
    */
}
