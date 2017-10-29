using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

	float obstacleSpeed;
	bool shieldead = false;

	public AudioSource sfx_shield_hit;

	void Awake(){
		obstacleSpeed = Random.Range (13f, 16f);
	}
	// Update is called once per frame
	void Update () {
		if (!shieldead) {
			transform.Translate (new Vector3 (-obstacleSpeed * Time.deltaTime, 0, 0));
		} else {
			transform.Translate (new Vector3 (18 * Time.deltaTime, 8 * Time.deltaTime, 0));
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Shield") {
			shieldead = true;
			if (GameData.pup_score_x2_active) {
				GameData.game_score += 2;
			} else if (!GameData.pup_score_x2_active) {
				GameData.game_score += 1;
			}
			sfx_shield_hit.Play ();
		}
	}
}
