using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMover : MonoBehaviour {

	float scrollSpeed = 6f;
	Vector2 offset;

	void Update () {
		offset = new Vector2 (Time.time * -scrollSpeed, 0);
		GetComponent<Renderer> ().material.mainTextureOffset = offset;
	} 
}
