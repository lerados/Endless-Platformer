using UnityEngine;
using System.Collections;

public class PlatformAnyar : MonoBehaviour {

	public GameObject[] platform;
	public Transform titikGenerasi;
	public float jarakAntara;
	public float lebarPlatform;

	void Start(){
		
	}

	void Update(){
		if(transform.position.x < titikGenerasi.position.x){
			transform.position = new Vector3(transform.position.x + jarakAntara, transform.position.y, transform.position.z);
			Instantiate(platform[Random.Range(0,4)], transform.position, transform.rotation);
		}
	}

}
