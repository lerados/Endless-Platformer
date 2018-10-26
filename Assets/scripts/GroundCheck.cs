using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	private Player player;

	void Start(){
		player = gameObject.GetComponentInParent<Player>();
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Ground")){
			player.grounded = true;
		}
	}

	void OnTriggerStay2D(Collider2D col){
		if(col.CompareTag("Ground")){
			player.grounded = true;
			player.speed = 50f;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		player.grounded = false;
	}

}
