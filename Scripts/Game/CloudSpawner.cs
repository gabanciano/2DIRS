using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {

	float spawnTime = 5f;
	public GameObject[] Clouds;
	Vector3 spawnPos;

	void Update(){
		SpawnObstacles ();
	}

	void SpawnObstacles(){
		spawnTime -= Time.deltaTime;
		if (spawnTime <= 0) {
			spawnPos = new Vector3 (transform.position.x, transform.position.y + Random.Range (-1f, 1.25f), transform.position.z);
			Instantiate (Clouds[Random.Range(1,3)], spawnPos, transform.rotation);
			spawnTime = Random.Range (6f, 7f);
		}
	}
}
