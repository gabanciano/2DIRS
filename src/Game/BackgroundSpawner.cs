using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour {

	public GameObject Hill;
	float spawnTime = 1f;

	void Update(){
		SpawnObstacle ();
	}

	void SpawnObstacle(){
		spawnTime -= Time.deltaTime;
		if (spawnTime <= 0) {
			Instantiate (Hill, transform.position, transform.rotation);
			spawnTime = Random.Range (0.40f, 1.50f);
		}
	}
}
