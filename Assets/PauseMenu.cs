using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public GameObject PauseUI;
	public GameObject GameUI;
	public GameObject StartUI;
	public Slider vol;
	public AudioSource aud;

	public bool paused = false;
	private bool start = true;

	void Start() {
		PauseUI.SetActive (false);
		GameUI.SetActive (true);
		StartUI.SetActive (true);
		Time.timeScale = 1;
		aud = GetComponent<AudioSource> ();
	}

	void Update() {
		aud.volume = vol.value;

		if (Input.GetKeyDown(KeyCode.Escape)) {
			
			paused = !paused;
			
		}

		if (start) {
			GameUI.SetActive(true);
			//PauseUI.SetActive(false);
			StartUI.SetActive(true);
			//Time.timeScale = 0;
		}


		if (paused) {

			//GameUI.SetActive(false);
			PauseUI.SetActive(true);
			Time.timeScale = 0;

		}

		if (!start) {
			GameUI.SetActive(true);
			//PauseUI.SetActive(false);
			StartUI.SetActive(false);
			//Time.timeScale = 0;
		}

		if (!paused) {

			//GameUI.SetActive(true);
			PauseUI.SetActive(false);
			Time.timeScale = 1;

		}


	}

	public void Resume() {
	
		paused = false;


	}

	public void startGame() {
		print ("loop");
		GameUI.SetActive (true);
		StartUI.SetActive (true);
		PauseUI.SetActive (false);
		//Time.timeScale = 0;
		
	}

	public void doneLookingAtMission() {
		start = false;
	}

	public void Restart() {

		Application.LoadLevel(Application.loadedLevel);

	}

	public void MainMenu() {

		Application.LoadLevel (0);

	}

	public void Quit() {

		Application.Quit();

	}

}
