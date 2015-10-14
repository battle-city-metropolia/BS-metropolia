using UnityEngine;
using UnityEditor;

public class SpawnEnemy : MonoBehaviour
{
    public static int MaxEnemies = 20;

    //public GameObject enemy;                		// The enemy prefab to be spawned.
    public float spawnTime = 4.0f;            		// How long between each spawn. In seconds
	public Transform[] spawnPoints;         		// An array of the spawn points this enemy can spawn from.
	public float delta = 0.5f;
	float fieldMinX, fieldMaxX, fieldMinY, fieldMaxY;
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

        // Make spawn delay a random interval
        //spawnTime = Random.Range(2.0f, 8.0f);
        Debug.Log("spawnTime: " + spawnTime);

        // If the player has no health left...
        if (playerHealth.currentHealth <= 0f)
		{
			Debug.Log("Stopping spawning because oma_tankki is dead");
			// Stop invoking and exit the function.
			CancelInvoke("Spawn"); 
			return;
		}

        // Check if enemy tank is outside of the walls
        CheckIfEnemiesAreaOutside();

        SpawnEnemyTank();
	}

	Vector3 GetSpawnPointVector() 
	{
		int currentTry = 0;

		while(currentTry != spawnCheckPositionsMaxTries) 
		{
			currentTry++;
			float x = Random.Range (fieldMinX, fieldMaxX);
			float y = Random.Range (fieldMinY, fieldMaxY);
			Vector3 temp = new Vector3(x, y, 0);

			Collider[] hitColliders = Physics.OverlapSphere(temp, 6);
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

			if (x > fieldMaxX)
                fieldMaxX = x;
			if (x < fieldMinX)
                fieldMinX = x;
			if (y > fieldMaxY)
                fieldMaxY = y;
			if (y < fieldMinY)
                fieldMinY = y;
		}
	}

    private void SpawnEnemyTank()
    {
        Object tank = null;

        switch (Random.Range(0, 2))
        {
            case 0:    
                tank = AssetDatabase.LoadAssetAtPath("Assets/Prefabit/Enemy1.prefab", typeof(GameObject));
                break;
            case 1:
                tank = AssetDatabase.LoadAssetAtPath("Assets/Prefabit/vihollinen5.prefab", typeof(GameObject));
                break;
        }

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        if (tank != null 
                && GameObject.FindGameObjectsWithTag(GlobalVars.enemyTankTag).Length < SpawnEnemy.MaxEnemies)
        {
            Instantiate(tank, GetSpawnPointVector(), new Quaternion(0, 0, 0, 1.0f));
        }
        Debug.Log(GameObject.FindGameObjectsWithTag(GlobalVars.enemyTankTag).Length);
    }

    private void CheckIfEnemiesAreaOutside()
    {
        GameObject[] enemyTanks = GameObject.FindGameObjectsWithTag(GlobalVars.enemyTankTag);
        foreach (GameObject tank in enemyTanks)
        {
            float tankPosX = tank.transform.position.x;
            float tankPosY = tank.transform.position.y;
            if (tankPosX > fieldMaxX
                    || tankPosX < fieldMinX
                    || tankPosY > fieldMaxY
                    || tankPosY < fieldMinY)
                Destroy(tank);
        }
    }

}
