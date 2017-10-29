using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehavior : MonoBehaviour {

	float powerSpeed = 3f;

	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (-powerSpeed * Time.deltaTime, 0, 0));
	}
}
