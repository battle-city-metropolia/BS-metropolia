using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
	public float changeDirectionTime = 5f; // Time in seconds
	System.Random random = new System.Random();
    private WeaponScript weapon;

	void Start ()
	{
		ChangeMoveDirectionRandom(); // Change direction 
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating("ChangeMoveDirectionRandom", changeDirectionTime, changeDirectionTime);
	}

    void Awake()
    {
        // Retrieve the weapon only once
        weapon = GetComponentInChildren<WeaponScript>();
    }

    void Update()
    {
        // Auto-fire
        if (weapon != null && weapon.CanAttack)
        {
            weapon.Attack(true);
        }
    }

	// Trigger
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		string name = otherCollider.gameObject.name.ToLower();
		if (name.Contains ("seinä") || name.Contains ("wall")) 
		{
			// Enemy hits the wall

		}
		
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

}
