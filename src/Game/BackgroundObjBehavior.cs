using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObjBehavior : MonoBehaviour {

	float hillSpeed = 11f;

	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (-hillSpeed * Time.deltaTime, 0, 0));
	}
}
