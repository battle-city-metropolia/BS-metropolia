using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
	public GameObject enemy;                		// The enemy prefab to be spawned.
	public float spawnTime = 8f;            		// How long between each spawn. In seconds
	public Transform[] spawnPoints;         		// An array of the spawn points this enemy can spawn from.
	public float delta = 0.5f;
	float minX, maxX, minY, maxY;
	int spawnCheckPositionsMaxTries = 50; 			// Max tries to check for spawn position

    private PlayerHealth playerHealth;              // Reference to the player's heatlh.

    void Start ()
	{
		this.GetMinMaxWallsPositions ();
		playerHealth = GameObject.Find(GlobalVars.playerTankName).GetComponent<PlayerHealth> ();
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	
	
	void Spawn ()
	{
		//Debug.Log(spawnPoints.Length);

		// If the player has no health left...
		if (playerHealth.currentHealth <= 0f)
		{
			Debug.Log("Stopping spawning because oma_tankki is dead");
			// Stop invoking and exit the function.
			CancelInvoke("Spawn"); 
			return;
		}

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemy, GetSpawnPointVector(), new Quaternion(0, 0, 0, 1.0f));
	}

	Vector3 GetSpawnPointVector() 
	{
		int currentTry = 0;

		while(currentTry != spawnCheckPositionsMaxTries) 
		{
			currentTry++;
			float x = Random.Range (minX, maxX);
			float y = Random.Range (minY, maxY);
			Vector3 temp = new Vector3(x, y, 0);

			Collider[] hitColliders = Physics.OverlapSphere(temp, 2);
			if (hitColliders.Length == 0) // Something on the way
			{
				return temp;
			}
		}

		// Return current position if max tries exceeded
		return new Vector3 (this.transform.position.x, this.transform.position.y, 0);
	}

	void GetMinMaxWallsPositions() 
	{
		GameObject[] metallWallObjects = GameObject.FindGameObjectsWithTag ("MetalWall");
		foreach (GameObject mw in metallWallObjects)
		{
			float x = mw.transform.position.x;
			float y = mw.transform.position.y;

			if (x > maxX)
				maxX = x;
			if (x < minX)
				minX = x;
			if (y > maxY)
				maxY = y;
			if (y < minY)
				minY = y;
		}
	}

}
