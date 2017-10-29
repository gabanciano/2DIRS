using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawner : MonoBehaviour {

	float spawnTime = 0.3f;
	public GameObject Grass;
	Vector3 spawnPos;

	void Update(){
		SpawnObstacles ();
	}

	void SpawnObstacles(){
		spawnTime -= Time.deltaTime;
		if (spawnTime <= 0) {
			spawnPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
			Instantiate (Grass, spawnPos, transform.rotation);
			spawnTime = Random.Range (0.2f, 0.5f);
		}
	}
}
