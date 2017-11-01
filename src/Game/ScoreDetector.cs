using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDetector : MonoBehaviour {

	public AudioManager sfx;
	public Text ScoreText;

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Obstacles") {
			sfx.player_score.Play ();
			ScoreCalculator ();
			ScoreText.gameObject.SetActive (false);
			ScoreText.gameObject.SetActive (true);
		}
	}

	void ScoreCalculator(){
		if (GameData.pup_score_x2_active) {
			GameData.game_score = GameData.game_score += 16;
		} else {
			GameData.game_score = GameData.game_score += 8;
		}
	}
}
