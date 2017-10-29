using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour {

	float spawnTime = 6f;
	public GameObject[] GemSets;
	Vector3 spawnPos;

	void Update(){
		SpawnObstacles ();
	}

	void SpawnObstacles(){
		spawnTime -= Time.deltaTime;
		if (spawnTime <= 0) {
			spawnPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
			Instantiate (GemSets [Random.Range (0, 7)], spawnPos, transform.rotation);
			spawnTime = Random.Range (2f, 10f);
		}
	}
}
