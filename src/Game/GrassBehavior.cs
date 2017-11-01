using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBehavior : MonoBehaviour {

	float grassSpeed = 11f;

	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (-grassSpeed * Time.deltaTime, 0, 0));
	}
}
