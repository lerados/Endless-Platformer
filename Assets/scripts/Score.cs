using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Player player;
	public Text score;
	public Text highscore;
	public float skor;
	public float hiskor;

	void Start(){
		if(PlayerPrefs.HasKey("Highscore")){
			hiskor = PlayerPrefs.GetFloat("Highscore");
		}
		score.text = "0";
		highscore.text = "" + Mathf.Round(hiskor);
		//PlayerPrefs.SetFloat("Highscore", 0);
	}

	void Update(){
		if(skor - 6.54f > player.transform.position.x){
			skor = skor + 0;
		}
		else{
			skor = player.transform.position.x + 6.54f;
		}
		score.text = "" + Mathf.Round(skor);

		if(skor > hiskor){
			hiskor = skor;
			PlayerPrefs.SetFloat("Highscore", hiskor);
		}
	}

}
