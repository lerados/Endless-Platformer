using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public Sprite[] HeartSprites;

	public Image HeartUI;

	private Player player;

	void Start(){
		player = GameObject.Find("Player").GetComponent<Player>();
	}

	void Update(){
		if(player.qurHealth <= 0){
			player.qurHealth = 0;
		}
		HeartUI.sprite = HeartSprites[player.qurHealth];
	}
}
