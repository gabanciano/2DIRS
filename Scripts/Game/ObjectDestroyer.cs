using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Obstacles" || col.gameObject.tag == "Hill" || col.gameObject.tag == "Grass" || col.gameObject.tag == "Clouds") {
			Destroy (col.gameObject);
		}
	}
}
