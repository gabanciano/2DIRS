using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUIManager : MonoBehaviour {

	public Text FinalScoreText;
	public Text FinalVerdictText;

	public AudioSource player_death;

	void Awake(){
		PlayerPrefs.SetInt ("Game.total_gems", GameData.total_gems);	
	}

	void Start(){
		player_death.Play ();
		FinalScoreText.text = "" + GameData.game_score;
		if (GameData.game_score > GameData.game_high_score) {
			FinalVerdictText.text = "NEW HIGH SCORE!";
		}
	}

    void Update()
    {
        DetectKeyboardControls();
    }

    void DetectKeyboardControls()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Retry();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Menu();
        }
    }

    public void Retry(){
		SceneManager.LoadScene ("game");
	}

	public void Menu(){
		SceneManager.LoadScene ("menu");
	}
}
