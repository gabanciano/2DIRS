using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {
	
	float spawnTime = 12f;
	public GameObject[] PowerUps;
	Vector3 spawnPos;

	void Update(){
		SpawnObstacles ();
	}

	void SpawnObstacles(){
		spawnTime -= Time.deltaTime;
		if (spawnTime <= 0) {
			spawnPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
			Instantiate (PowerUps[Random.Range(0,2)], spawnPos, transform.rotation);
			spawnTime = Random.Range (8f, 15f);
		}
	}
}
