using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehavior : MonoBehaviour {

	public PlayerController player;
	void Update(){
		transform.position = player.transform.position;
		if (!GameData.pup_invincibility_active) {
			this.gameObject.SetActive (false);
		}
	}
}
