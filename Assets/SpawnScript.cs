using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	// Variable to store the enemy prefab
	public GameObject enemy;
	public float spawnTime = 2;
	public int max = 0;
	public int start = 0;
	
	void Start() {  
		// Call the 'addEnemy' function every 'spawnTime' seconds
		InvokeRepeating("addEnemy", spawnTime, spawnTime);
	}
	
	// New function to spawn an enemy
	void addEnemy() {  
		if (max < start) {
			// Variables to store the X position of the spawn object
			// See image below
			var x1 = transform.position.x - GetComponent<Renderer> ().bounds.size.x / 2;
			var x2 = transform.position.x + GetComponent<Renderer> ().bounds.size.x / 2;
		
			// Randomly pick a point within the spawn object
			var spawnPoint = new Vector2 (Random.Range (x1, x2), transform.position.y);
		
			// Create an enemy at the 'spawnPoint' position
			Instantiate (enemy, spawnPoint, Quaternion.identity);
			max += 1;
		}
	}
}
