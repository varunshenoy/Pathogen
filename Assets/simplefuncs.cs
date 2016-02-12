using UnityEngine;
using System.Collections;

public class simplefuncs : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Restart() {
		//restart current level
		Application.LoadLevel(Application.loadedLevel);
		
	}
	
	public void MainMenu() {
		//Load main menu
		Application.LoadLevel (0);
		
	}
	
	public void Quit() {
		//Quit Application
		print ("quit");
		Application.Quit();
		
	}

	public void toCredits() {
		//load credits
		Application.LoadLevel("Credits");
	}

	public void toCellBook() {
		//load cell book
		Application.LoadLevel("CellBook");
	}

	public void LoadLevel4() {
		//load 4th level
		Application.LoadLevel("Stage4");
	}

	public void toHelp() {
		//load help screen
		Application.LoadLevel("help");
	}
}
