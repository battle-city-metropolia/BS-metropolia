using UnityEngine;
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
	public GameObject gameObject;

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.name == "Ball") {
			DestroyObject (this.gameObject);
			Debug.Log ("Collided with an object.");
		}
	}

}
