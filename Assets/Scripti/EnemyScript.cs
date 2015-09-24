using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
	System.Random random = new System.Random();

	public float changeDirectionTime = 5f; // Time in seconds
	public float stayingCheckTime = 2f; // Time in seconds

    private WeaponScript weapon;
	private Vector3 enemyPosition;
	private int sightCheckError = 2;

	void Start ()
	{
		enemyPosition = transform.position;
		ChangeMoveDirectionRandom(); // Change direction 
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating("CheckForStaying", stayingCheckTime, stayingCheckTime);
	}

    void Awake()
    {
        // Retrieve the weapon only once
        weapon = GetComponentInChildren<WeaponScript>();
    }

    void Update()
    {
        // Auto-fire
        if (weapon != null && weapon.CanAttack && this.PlayerOnSight())
        {
            weapon.Attack(true);
        }
    }

	bool PlayerOnSight() 
	{
		Vector3 playerPosition = GameObject.Find(GlobalVars.playerTankName).transform.position;
		Vector3 ownPosition = transform.position;
		return true;
	}

	// Collision Trigger
	void OnCollisionEnter2D(Collision2D collision)
	{
		this.ChangeMoveDirectionRandom();
	}

	// Trigger
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		Debug.Log("ENEMY OnTriggerEnter2D");
	}

	void ChangeMoveDirectionRandom()
	{
		int directionX = random.Next(0, 2);
		int directionY = random.Next(0, 2);

		if (directionX == 1 && random.Next(0, 2) == 1)
			directionX = -1;
		if (directionY == 1 && random.Next(0, 2) == 1)
			directionY = -1;

		GetComponent<MoveScript>().direction = new Vector2(directionX, directionY);
	}

	private void CheckForStaying() 
	{
		Vector3 newPosition = transform.position;

		if (enemyPosition == newPosition)
			ChangeMoveDirectionRandom ();

		enemyPosition = newPosition;
	}

}
