using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
	public PlayerHealth playerHealth;       		// Reference to the player's heatlh.
	public string playerObjectName = "oma_tankki";

	public GameObject enemy;                		// The enemy prefab to be spawned.
	public float spawnTime = 8f;            		// How long between each spawn. In seconds
	public Transform[] spawnPoints;         		// An array of the spawn points this enemy can spawn from.
	
	
	void Start ()
	{
		playerHealth = GameObject.Find(playerObjectName).GetComponent<PlayerHealth> ();

		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	
	
	void Spawn ()
	{
		Debug.Log(spawnPoints.Length);

		// If the player has no health left...
		if (playerHealth.currentHealth <= 0f)
		{
			Debug.Log("Stopping spawning because oma_tankki is dead");
			// Stop invoking and exit the function.
			CancelInvoke("Spawn"); 
			return;
		}
		
		// Find a random index between zero and one less than the number of spawn points.
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		
		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}