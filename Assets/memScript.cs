using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class memScript : MonoBehaviour {

	public GameObject InfoUI;
	public GameObject QuizUI;
	public GameObject EndLevelUI;
	public Text youHave;
	public string levelID;
	public Text lives;
	public string nextlvl;

	// Use this for initialization
	void Start () {
		//simple UI setup
		InfoUI.SetActive(false);
		QuizUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RightAnswer() {
		//If you pick the right answer, set localstorage variables for stars
		EndLevelUI.SetActive (true);
		youHave.text = "You have passed the quiz!";
		PlayerPrefs.SetString (levelID + "Quiz", "Y");
		PlayerPrefs.SetString (levelID + "Target", "Y");
		PlayerPrefs.SetString (levelID + "Beaten", "Y");
		var lifeCount = int.Parse(lives.text.Substring (0, 1));
		if (lifeCount == 3) {
			print (lifeCount);
			PlayerPrefs.SetString (levelID + "LifeGoal", "Y");
		}
	}

	public void WrongAnswer() {
		//If you pick the wrong answer, set localstorage variables for stars
		EndLevelUI.SetActive (true);
		youHave.text = "You did not pass the quiz.";
		PlayerPrefs.SetString (levelID + "Target", "Y");
		PlayerPrefs.SetString (levelID + "Beaten", "Y");
		var lifeCount = int.Parse(lives.text.Substring (0, 1));
		if (lifeCount == 3) {
			PlayerPrefs.SetString (levelID + "LifeGoal", "Y");
		}
	}

	void OnTriggerEnter2D(Collider2D obj) {  
		var name = obj.gameObject.name;
		
		// If it collided with the player, start the quiz section
		if (name == "Player") {
			InfoUI.SetActive (true);
		}
	}

	public void toQuiz() {
		//simple UI setup for the quiz
		InfoUI.SetActive (false);
		QuizUI.SetActive (true);
	}

	public void nextLevel() {
		//load next nevel, if chosen
		Application.LoadLevel (nextlvl);
	}
}
