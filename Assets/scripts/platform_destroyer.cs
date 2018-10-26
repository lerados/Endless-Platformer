using UnityEngine;
using System.Collections;

public class platform_destroyer : MonoBehaviour {

	public GameObject platformHancur;

	void Start(){
		
	}

	void Update(){
		if(transform.position.x < platformHancur.transform.position.x){
			Destroy(gameObject);
		}
	}

}
