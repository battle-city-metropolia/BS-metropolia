using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour
{
	
	// 1 - Designer variables
	
	/// <summary>
	/// Object speed
	/// </summary>
	public Vector2 speed = new Vector2(10, 10);
	
	/// <summary>
	/// Moving direction
	/// </summary>
	public Vector2 direction = new Vector2(-1, 0);
	
	private Vector2 movement;
	private Vector3 rotationVector;
	
	void Update()
	{
		if (direction.x != 0)
		{
			movement = new Vector2(speed.x * direction.x, 0);
		}
		else
		{
			movement = new Vector2(0, speed.y * direction.y);
		}
		Rotate(direction.x, direction.y);
		transform.eulerAngles = rotationVector; // Apply rotation

		// 2 - Movement
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
	}
	
	void FixedUpdate()
	{
		// Apply movement to the rigidbody
		GetComponent<Rigidbody2D>().velocity = movement;
	}

	void Rotate(float inputX, float inputY)
	{
		float x = rotationVector.x,
		y = rotationVector.y,
		z = rotationVector.z;
		
		// Looking right
		if (inputX > 0)
		{
			x = 0;
			y = 0;
			z = -90;
		}
		// Looking left
		else if (inputX < 0)
		{
			x = 0;
			y = 0;
			z = 90;
		}
		
		// Looking up
		else if (inputY > 0)
		{
			x = 0;
			y = 0;
			z = 0;
		}
		// Looking down
		else if (inputY < 0)
		{
			x = 0;
			y = 0;
			z = 180;
		}
		
		rotationVector = new Vector3(x, y, z);
	}

}
