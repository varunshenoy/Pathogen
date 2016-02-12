using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class starScript : MonoBehaviour {

	public string levelID;
	public Image LivesStar;
	public Image GoalStar;
	public Image QuizStar;
	public Sprite completeStar;
	// Use this for initialization
	void Start () {
		//if the stored level's goals were beaten, add stars. Uses "Y" and "N" as booleans for the possible cases.
		if (PlayerPrefs.GetString (levelID + "Quiz") == "Y") {
			QuizStar.sprite = completeStar;
		}

		if (PlayerPrefs.GetString (levelID + "Target") == "Y") {
			GoalStar.sprite = completeStar;
		}

		if (PlayerPrefs.GetString (levelID + "LifeGoal") == "Y") {
			LivesStar.sprite = completeStar;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
