using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBehavior : MonoBehaviour {

	float gemSpeed = 11f;

	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (-gemSpeed * Time.deltaTime, 0, 0));
	}
}
