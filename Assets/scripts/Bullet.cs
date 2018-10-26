using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private Player player;
	private float waktu;

	void Start(){
		
	}

	void Update(){
		waktu += Time.deltaTime;
		if(waktu > 3f){
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.isTrigger != true){
			if(col.CompareTag("Player")){
				col.GetComponent<Player>().Damage(1);
				Destroy(gameObject);
			}
		}
	}
}
