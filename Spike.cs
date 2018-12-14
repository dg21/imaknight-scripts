using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spike : MonoBehaviour {

    public int TakeDamage;
    public GameObject player;
	//Use this for initialization
	void Start () {
		
	}

   public void OnTriggerEnter2D(Collider2D other)
    {

           player.GetComponent<Player>().TakeDamage(TakeDamage);
           Debug.Log("damage");
    }

}
