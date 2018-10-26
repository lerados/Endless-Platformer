﻿using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

	private Player player;

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Player")){
			player.Damage(2);

			StartCoroutine(player.Knockback(0.02f, 250, player.transform.position));
		}
	}

}
