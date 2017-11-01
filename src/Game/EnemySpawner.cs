using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	float spawnTime = 2f;
	public GameObject Obstacle;
	Vector3 spawnPos;

	void Update(){
		SpawnObstacles ();
	}

	void SpawnObstacles(){
		spawnTime -= Time.deltaTime;
		if (spawnTime <= 0) {
			spawnPos = new Vector3 (transform.position.x, transform.position.y + Random.Range (-0.40f, 1.90f), transform.position.z);
			Instantiate (Obstacle, spawnPos, transform.rotation);
			spawnTime = Random.Range (0.75f, 1.35f);
		}
	}
}
