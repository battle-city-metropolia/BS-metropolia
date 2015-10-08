using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveSceneTImer : MonoBehaviour {

	public float timer = 10;
	Text text;

	void Awake (){

		text = GetComponent <Text> ();

	}
	void  Update (){
		timer -= Time.deltaTime;
		
		if (timer <= 0){
			Application.LoadLevel("TestiScene");
		}

		text.text = "Score: " + Mathf.Round(timer);
	}
}
