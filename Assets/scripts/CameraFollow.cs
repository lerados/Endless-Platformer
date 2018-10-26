using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private Vector2 velociti;

	public float smoothTimeY;
	public float smoothTimeX;

	public GameObject pemain;

	public bool bounds;

	public Vector3 minCameraPos;
	public Vector3 maxCameraPos;

	void Start () {
		pemain = GameObject.Find("Player");
	}

	void FixedUpdate(){
		
		float posX = Mathf.SmoothDamp(transform.position.x, pemain.transform.position.x, ref velociti.x, smoothTimeX);
		//float posY = Mathf.SmoothDamp(transform.position.y, pemain.transform.position.y, ref velociti.y, smoothTimeY);

		transform.position = new Vector3(posX, transform.position.y, transform.position.z);
	
		if(bounds){
			transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
				Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
				Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
		}
	}

	public void SetMinCamPosition(){
		minCameraPos = gameObject.transform.position;
	}

	public void SetMaxCamPosition(){
		maxCameraPos = gameObject.transform.position;
	}
}
