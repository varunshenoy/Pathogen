using UnityEngine;
using System.Collections;

public class triggerEndTutorial : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D obj) {  
		var name = obj.gameObject.name;
		
		// If it collided with home barrier
		if (name == "Player") {
			//load main menu
			Application.LoadLevel("Home");
		}

	}
}
