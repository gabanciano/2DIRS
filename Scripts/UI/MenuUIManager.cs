using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour {

	public Text UpgradeInvincibilityButton;
	public Text UpgradeScoreX2Button;
	public Text UnlockDoubleJumpButton;

	public Slider UpgradeProgressInvinSlider;
	public Slider UpgradeScoreX2Slider;

	public Image StoreInvinPrice;
	public Image StoreScoreX2Price;
	public Image StoreDoubleJumpPrice;

	public Text TopScoreText;
	public Text TotalGemsText;

	public Image StorePanel;
	public Text StoreErrorText;

	void Awake(){
		GameData.game_high_score = PlayerPrefs.GetInt ("Game.high_score", 0);	
		GameData.total_gems = PlayerPrefs.GetInt ("Game.total_gems", 0);
	}

	void Start(){
		CheckUnlockedItems ();
		CheckCurrentInvinLevel ();
		CheckCurrentScoreX2Level ();
		TopScoreText.text = "   " + GameData.game_high_score;
		TotalGemsText.text = "   " + GameData.total_gems;
	}

	void Update(){
		TotalGemsText.text = "   " + GameData.total_gems;
        DetectKeyboardControls();
	}

    void DetectKeyboardControls()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            PlayGame();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            OpenStore();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            HideStore();
        }
    }

    void CheckUnlockedItems(){
		if(PlayerPrefs.GetInt("Store.double_jump_active") == 1){
			UnlockDoubleJumpButton.text = "Unlocked!";
			UnlockDoubleJumpButton.alignment = TextAnchor.MiddleCenter;
			StoreDoubleJumpPrice.gameObject.SetActive (false);
			UnlockDoubleJumpButton.GetComponent<Button> ().interactable = false;
		}
	}

	void CheckCurrentInvinLevel(){
		int current_upgrade_level = PlayerPrefs.GetInt ("Store.invincibility_upgrade", 0);
		if (current_upgrade_level == 1) {
			UpgradeProgressInvinSlider.value = 6f;
		} else if (current_upgrade_level == 2) {
			UpgradeProgressInvinSlider.value = 7f;
		} else if (current_upgrade_level == 3) {
			UpgradeProgressInvinSlider.value = 8f;
		} else if (current_upgrade_level == 4) {
			UpgradeProgressInvinSlider.value = 9f;
		} else if (current_upgrade_level == 5) {
			UpgradeProgressInvinSlider.value = 10f;
			DisableUpgradeInvin ();
		}
	}

	void DisableUpgradeInvin(){
		UpgradeInvincibilityButton.text = "Maxed!";
		UpgradeInvincibilityButton.alignment = TextAnchor.MiddleCenter;
		StoreInvinPrice.gameObject.SetActive (false);
	}

	void CheckCurrentScoreX2Level(){
		int current_upgrade_level = PlayerPrefs.GetInt ("Store.score_x2_upgrade", 0);
		if (current_upgrade_level == 1) {
			UpgradeScoreX2Slider.value = 12f;
		} else if (current_upgrade_level == 2) {
			UpgradeScoreX2Slider.value = 14f;
		} else if (current_upgrade_level == 3) {
			UpgradeScoreX2Slider.value = 16f;
		} else if (current_upgrade_level == 4) {
			UpgradeScoreX2Slider.value = 18f;
		} else if (current_upgrade_level == 5) {
			UpgradeScoreX2Slider.value = 20f;
			DisableUpgradeScoreX2 ();
		}
	}

	void DisableUpgradeScoreX2(){
		UpgradeScoreX2Button.text = "Maxed!";
		UpgradeScoreX2Button.alignment = TextAnchor.MiddleCenter;
		StoreScoreX2Price.gameObject.SetActive (false);
	}

	public void PlayGame(){
		SceneManager.LoadScene ("game");	
	}

	public void OpenStore(){
		StorePanel.gameObject.SetActive (true);
		StorePanel.GetComponent<Animator> ().SetInteger("State", 1);
	}

	public void HideStore(){
		StorePanel.GetComponent<Animator> ().SetInteger("State", 0);
	}

	public void UpgradeInvincibility(){
		if (PlayerPrefs.GetInt ("Store.invincibility_upgrade", 0) != 5) {
			if (GameData.total_gems >= 100) {
				GameData.total_gems -= 100;
				PlayerPrefs.SetInt ("Game.total_gems", GameData.total_gems);
				PlayerPrefs.SetInt ("Store.invincibility_upgrade", PlayerPrefs.GetInt ("Store.invincibility_upgrade", 0) + 1);
				if (PlayerPrefs.GetInt ("Store.invincibility_upgrade", 0) >= 5) {
					DisableUpgradeInvin ();
				}
				int current_upgrade_level = PlayerPrefs.GetInt ("Store.invincibility_upgrade", 0);
				if (current_upgrade_level == 1) {
					UpgradeProgressInvinSlider.value = 6f;
				} else if (current_upgrade_level == 2) {
					UpgradeProgressInvinSlider.value = 7f;
				} else if (current_upgrade_level == 3) {
					UpgradeProgressInvinSlider.value = 8f;
				} else if (current_upgrade_level == 4) {
					UpgradeProgressInvinSlider.value = 9f;
				} else if (current_upgrade_level == 5) {
					UpgradeProgressInvinSlider.value = 10f;
				}
			} else {
				StoreErrorText.gameObject.SetActive (false);
				StoreErrorText.gameObject.SetActive (true);
			}
		}
	}
	public void UpgradeScoreX2(){
		if (PlayerPrefs.GetInt ("Store.score_x2_upgrade", 0) != 5) {
			if (GameData.total_gems >= 100) {
				GameData.total_gems -= 100;
				PlayerPrefs.SetInt ("Game.total_gems", GameData.total_gems);
				PlayerPrefs.SetInt ("Store.score_x2_upgrade", PlayerPrefs.GetInt ("Store.score_x2_upgrade", 0) + 1);
				if (PlayerPrefs.GetInt ("Store.score_x2_upgrade", 0) >= 5) {
					DisableUpgradeScoreX2 ();
				}
				int current_upgrade_level = PlayerPrefs.GetInt ("Store.score_x2_upgrade", 0);
				if (current_upgrade_level == 1) {
					UpgradeScoreX2Slider.value = 12f;
				} else if (current_upgrade_level == 2) {
					UpgradeScoreX2Slider.value = 14f;
				} else if (current_upgrade_level == 3) {
					UpgradeScoreX2Slider.value = 16f;
				} else if (current_upgrade_level == 4) {
					UpgradeScoreX2Slider.value = 18f;
				} else if (current_upgrade_level == 5) {
					UpgradeScoreX2Slider.value = 20f;
				}
			} else {
				StoreErrorText.gameObject.SetActive (false);
				StoreErrorText.gameObject.SetActive (true);
			}
		}
	}
	public void UnlockDoubleJump(){
		if (GameData.total_gems >= 1200) {
			GameData.total_gems -= 1200;
			PlayerPrefs.SetInt ("Game.total_gems", GameData.total_gems);
			PlayerPrefs.SetInt ("Store.double_jump_active", 1);
			UnlockDoubleJumpButton.text = "Unlocked!";
			UnlockDoubleJumpButton.alignment = TextAnchor.MiddleCenter;
			StoreDoubleJumpPrice.gameObject.SetActive (false);
			UnlockDoubleJumpButton.GetComponent<Button> ().interactable = false;
		} else {
			StoreErrorText.gameObject.SetActive (false);
			StoreErrorText.gameObject.SetActive (true);
		}
	}
}
