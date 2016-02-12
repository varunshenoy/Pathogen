using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class levelSelect : MonoBehaviour {
	public string level1;
	public string level2;
	public string level3;
	public string level4;
	public Image lvl2button;
	public Image lvl3button;
	public Image lvl4button;
	public GameObject lvl2lock;
	public GameObject lvl3lock;
	public GameObject lvl4lock;
	public Sprite unlocked;

	// Use this for initialization
	void Start () {
		//Check if levels are beaten, and if so, set up UI
		var lvl1beat = PlayerPrefs.GetString("lvl1Beaten");
		var lvl2beat = PlayerPrefs.GetString("lvl2Beaten");
		var lvl3beat = PlayerPrefs.GetString("lvl3Beaten");

		if (lvl1beat == "Y") {
			lvl2button.sprite = unlocked;
			lvl2lock.SetActive(false);

		}

		if (lvl2beat == "Y") {
			lvl3button.sprite = unlocked;
			lvl3lock.SetActive(false);
		}

		if (lvl3beat == "Y") {
			lvl4button.sprite = unlocked;
			lvl4lock.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadLevel1() {
		Application.LoadLevel (level1);
		//load level 1
	}

	public void LoadTutorial() {
		Application.LoadLevel ("tutorial");
		//load tutorial
	}

	public void LoadLevel2() {
		var lvl1beat = PlayerPrefs.GetString("lvl1Beaten");
		if (lvl1beat == "Y") {
			Application.LoadLevel (level2);
		}
		//load level 2 if level 1 is beaten
	}

	public void LoadLevel3() {
		var lvl2beat = PlayerPrefs.GetString("lvl2Beaten");
		if (lvl2beat == "Y") {
			Application.LoadLevel (level3);
		}
		//load level 3 if level 2 is beaten
	}

	public void LoadLevel4() {
		var lvl3beat = PlayerPrefs.GetString("lvl3Beaten");
		if (lvl3beat == "Y") {
			Application.LoadLevel (level4);
		}
		//load level 4 if level 3 is beaten
	}
}
