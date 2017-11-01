using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour {

	public Text ScoreText;
	public GameObject Shield;

	float pup_invin_duration;
	float pup_score_x2_duration;

	float pup_invin_radial_duration;
	float pup_score_x2_radial_duration;

	public Image PupInvinRadial;
	public Image PupScoreX2Radial;
	public Image PupDoubleJumpRadial;
	public Text PupInvinCounter;
	public Text PupScoreX2Counter;
	public Text PupScoreX2Indicator;

	public Text TotalGemText;

	void Awake() {
		GameData.total_gems = PlayerPrefs.GetInt ("Game.total_gems", 0);
		GameData.game_high_score = PlayerPrefs.GetInt ("Game.high_score", 0);	
		GameData.game_score = 0;

		GameData.current_invincibility_upgrade = PlayerPrefs.GetInt ("Store.invincibility_upgrade", 0);
		GameData.current_score_x2_upgrade = PlayerPrefs.GetInt ("Store.score_x2_upgrade", 0);
		GameData.double_jump_active = PlayerPrefs.GetInt ("Store.double_jump_active");
	}

	void Start(){
		GetInvincibilityDuration ();
		GetScoreX2Duration ();
	}

	// Update is called once per frame
	void Update () {
		Debug.Log (pup_score_x2_duration);
		IncreaseScore ();
		CheckActivePowerUps ();
	}

	void IncreaseScore(){
		ScoreText.text = "" + GameData.game_score.ToString("000000");
		TotalGemText.text = "   " + GameData.total_gems;
		if (GameData.game_score > GameData.game_high_score) {
			ScoreText.color = new Color32 (255, 227, 0, 255);
		}
	}

	void CheckActivePowerUps(){
		if (GameData.double_jump_active == 1) {
			PupDoubleJumpRadial.gameObject.SetActive (true);
		}

		if (GameData.pup_invincibility_active) {
			if (!GameData.pup_reset_invin_values) {
				PupInvinRadial.gameObject.SetActive (true);
				pup_invin_duration -= Time.deltaTime;
				PupInvinRadial.fillAmount -= pup_invin_radial_duration * Time.deltaTime;
				PupInvinCounter.text = "" + Mathf.RoundToInt ((float)(pup_invin_duration));
				if (pup_invin_duration <= 2) {
					Shield.GetComponent<SpriteRenderer> ().color = new Color32 (255, 0 ,0 ,85);
				}
				if (pup_invin_duration <= 0) {
					PupInvinRadial.gameObject.SetActive (false);
					GetInvincibilityDuration ();
					PupInvinRadial.fillAmount = 1f;
					PupInvinCounter.text = "5";
					GameData.pup_invincibility_active = false;
					Shield.GetComponent<SpriteRenderer> ().color = new Color32 (0, 234 ,255 ,85);
				}
			} else if (GameData.pup_reset_invin_values) {
				GetInvincibilityDuration ();
				PupInvinRadial.fillAmount = 1f;
				GameData.pup_reset_invin_values = false;
			}
		} 

		if (GameData.pup_score_x2_active) {
			if (!GameData.pup_reset_score_x2_values) {
				PupScoreX2Radial.gameObject.SetActive (true);
				PupScoreX2Indicator.gameObject.SetActive (true);
				ScoreText.GetComponent<Outline> ().enabled = true;
				pup_score_x2_duration -= Time.deltaTime;
				PupScoreX2Radial.fillAmount -= pup_score_x2_radial_duration * Time.deltaTime;
				PupScoreX2Counter.text = "" + Mathf.RoundToInt ((float)(pup_score_x2_duration));
				if (pup_score_x2_duration <= 0) {
					PupScoreX2Radial.gameObject.SetActive (false);
					PupScoreX2Indicator.gameObject.SetActive (false);
					GetScoreX2Duration ();
					PupScoreX2Radial.fillAmount = 1f;
					PupScoreX2Counter.text = "10";
					ScoreText.color = Color.white;
					ScoreText.GetComponent<Outline> ().enabled = false;
					GameData.pup_score_x2_active = false;
				}
			} else if (GameData.pup_reset_score_x2_values) {
				GetScoreX2Duration ();
				PupScoreX2Radial.fillAmount = 1f;
				GameData.pup_reset_score_x2_values = false;
			}
		} 
	}

	void GetInvincibilityDuration(){
		if (GameData.current_invincibility_upgrade == 0) {
			pup_invin_duration = 5f;
			pup_invin_radial_duration = 0.20f;
		} else if (GameData.current_invincibility_upgrade == 1) {
			pup_invin_duration = 6f;
			pup_invin_radial_duration = 0.18f;
		} else if (GameData.current_invincibility_upgrade == 2) {
			pup_invin_duration = 7f;
			pup_invin_radial_duration = 0.16f;
		} else if (GameData.current_invincibility_upgrade == 3) {
			pup_invin_duration = 8f;
			pup_invin_radial_duration = 0.14f;
		} else if (GameData.current_invincibility_upgrade == 4) {
			pup_invin_duration = 9f;
			pup_invin_radial_duration = 0.12f;
		} else if (GameData.current_invincibility_upgrade == 5) {
			pup_invin_duration = 10f;
			pup_invin_radial_duration = 0.10f;
		}
	}

	void GetScoreX2Duration(){
		if (GameData.current_score_x2_upgrade == 0) {
			pup_score_x2_duration = 10f;
			pup_score_x2_radial_duration = 0.1f;
		} else if (GameData.current_score_x2_upgrade == 1) {
			pup_score_x2_duration = 12f;
			pup_score_x2_radial_duration = 0.09f;
		} else if (GameData.current_score_x2_upgrade == 2) {
			pup_score_x2_duration = 14f;
			pup_score_x2_radial_duration = 0.08f;
		} else if (GameData.current_score_x2_upgrade == 3) {
			pup_score_x2_duration = 16f;
			pup_score_x2_radial_duration = 0.07f;
		} else if (GameData.current_score_x2_upgrade == 4) {
			pup_score_x2_duration = 18f;
			pup_score_x2_radial_duration = 0.06f;
		} else if (GameData.current_score_x2_upgrade == 5) {
			pup_score_x2_duration = 20f;
			pup_score_x2_radial_duration = 0.05f;
		}
	}
}
