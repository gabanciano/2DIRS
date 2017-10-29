using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehavior : MonoBehaviour {

	float cloudSpeed = 0.50f;

	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (-cloudSpeed * Time.deltaTime, 0, 0));
	}
}
