﻿using UnityEngine;
using System.Collections;

public class DestructibleWall : MonoBehaviour {

	/*
	public Sprite dmgSprite; //vahingoittunut seinä
	public int hp = 4;

	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Awake () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	public void DamageWall(int loss){
		spriteRenderer.sprite = dmgSprite;
		hp -= loss;
		if (hp <= 0) {
			gameObject.SetActive(false);
		}
	}
	*/

	public GameObject otherGameObject;
	public GameObject rajahdysAnimation;

	void OnCollisionEnter2D(Collision2D collision)
	{
		//Debug.Log("Entered OnCollisionEnter2D");

		/*if (collision.gameObject.name == "Ball") {
			DestroyObject (this.gameObject);
			Debug.Log ("Collided with an object.");
		}*/
	}


	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		//Debug.Log("Entered OnTriggerEnter2D");

		// Is it a shot?
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
		if (shot != null)
		{
			PlayExplosion();
			Destroy(gameObject); // Destroy this wall
		}
	}
	void PlayExplosion(){
		GameObject explosion = (GameObject)Instantiate (rajahdysAnimation);
		explosion.transform.position = transform.position;
	}

			Destroy(gameObject); // Destroy this wall
		}
	}


}