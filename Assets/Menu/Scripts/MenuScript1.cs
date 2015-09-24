using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript1 : MonoBehaviour {

	public Canvas helpMenu;
	public Canvas exitMenu;
	public Button startText;
	public Button helpText;
	public Button exitText;
	
	void Start () {
		helpMenu = helpMenu.GetComponent<Canvas> ();
		exitMenu = exitMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		helpText = helpText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		helpMenu.enabled = false;
		exitMenu.enabled = false;
	}

	public void HelpPress(){	//kun painetaan Help-painiketta,alkuvalikon painikkeet eivät toimi
		helpMenu.enabled = true;
		exitMenu.enabled = false;
		startText.enabled = false;
		helpText.enabled = false;
		exitText.enabled = false;
	}

	public void BackAndNoPress(){	//palataan takaisin alkuvalikkoon, help-valikko menee pois
		helpMenu.enabled = false;
		exitMenu.enabled = false;
		startText.enabled = true;
		helpText.enabled = true;
		exitText.enabled = true;
	}

	public void ExitPress(){
		helpMenu.enabled = false;
		exitMenu.enabled = true;
		startText.enabled = false;
		helpText.enabled = false;
		exitText.enabled = false;
	}

	public void StartLevel(){	//kun painetaan play-painiketta
		Application.LoadLevel (1);
	}

	public void ExitGame(){		//kun painetaan exit-painiketta
		Application.Quit ();
	}

	void Update () {
	
	}
}
