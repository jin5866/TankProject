using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {
    public float healthItem = 30.0f;

    public float greenDamage = 20.0f;
    public GameObject itemAppearText;

    public ParticleSystem fireExplosion;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HealthItem()
    {
        gameObject.GetComponent<PlayerHealth>().HealHealth(healthItem);
        itemAppearText.SetActive(false);
    }

    public void GreenItem()
    {
        GameObject[] monsters;
        ParticleSystem newFire;
        monsters = GameObject.FindGameObjectsWithTag("Monster");
        foreach(GameObject a in monsters)
        {
            a.GetComponent<MonsterHealth>().GotDamage(greenDamage);
            newFire = Instantiate(fireExplosion).GetComponent<ParticleSystem>();
            newFire.transform.position = a.transform.position;
            newFire.Play();
            Destroy(newFire.gameObject, 1.0f);
        }
        itemAppearText.SetActive(false);

    }


}
