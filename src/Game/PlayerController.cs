using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	float jumpForce = 19f;
	bool doubleJumping = false;
	Rigidbody2D PlayerRigid2D;
	Animator PlayerAnimator;

	public AudioManager sfx;
	public ShieldBehavior Shield;

    void InitGameData()
    {
        GameData.player_grounded = false;
        GameData.pup_invincibility_active = false;
        GameData.pup_score_x2_active = false;
        GameData.double_jump_active = PlayerPrefs.GetInt("Store.double_jump_active");

        GameData.pup_reset_invin_values = false;
        GameData.pup_reset_score_x2_values = false;

        PlayerRigid2D = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
    }

	void Awake(){
        InitGameData();
	}

	void Update(){
        CheckIfPlayerGrounded();
        DetectKeyboardControls();
	}

	public void PlayerJump(){
		if (GameData.player_grounded) {
			PlayerRigid2D.velocity = new Vector3 (PlayerRigid2D.velocity.x, jumpForce);
			sfx.player_jump.Play ();
			if (GameData.double_jump_active == 1) {
				doubleJumping = true;
			}
		} if (!GameData.player_grounded && doubleJumping == true) {
			PlayerRigid2D.velocity = new Vector3 (PlayerRigid2D.velocity.x, jumpForce);
			sfx.player_jump.Play ();
			doubleJumping = false;
		}
	}
    
    void DetectKeyboardControls()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerJump();
        }
    }

    void CheckIfPlayerGrounded()
    {
        if (GameData.player_grounded)
        {
            PlayerAnimator.SetInteger("State", 1);
        }
        else
        {
            PlayerAnimator.SetInteger("State", 0);
        }
    }

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Ground") {
			GameData.player_grounded = true;
		}

		if (col.gameObject.tag == "Gem") {
			Destroy (col.gameObject);
			sfx.gem_pick.Play ();
			GameData.total_gems += 1;
		}

		if (col.gameObject.tag == "PUP_Invincibility") {
			if (GameData.pup_invincibility_active) {
				Destroy (col.gameObject);
				Shield.gameObject.SetActive (true);
				GameData.pup_reset_invin_values = true;
				GameData.pup_invincibility_active = true;
				sfx.powerup_pick.Play ();
			} else if(!GameData.pup_invincibility_active){
				Destroy (col.gameObject);
				Shield.gameObject.SetActive (true);
				GameData.pup_invincibility_active = true;
				sfx.powerup_pick.Play ();
			}
		}

		if (col.gameObject.tag == "PUP_Score_X2") {
			if (GameData.pup_score_x2_active) {
				Destroy (col.gameObject);
				GameData.pup_reset_score_x2_values = true;
				GameData.pup_score_x2_active = true;
				sfx.powerup_pick.Play ();
			} else if(!GameData.pup_score_x2_active){
				Destroy (col.gameObject);
				GameData.pup_score_x2_active = true;
				sfx.powerup_pick.Play ();
			}
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Ground") {
			GameData.player_grounded = false;
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Obstacles") {
			if (!GameData.pup_invincibility_active) {
				RecordHighScore ();
				SceneManager.LoadScene ("gameover");
			}
		}
	}

	void RecordHighScore(){
		if (GameData.game_score > GameData.game_high_score) {
			PlayerPrefs.SetInt ("Game.high_score", GameData.game_score);
		}
	}
}
