using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class okay : MonoBehaviour {
	public GameObject panel;
	// Use this for initialization
	void Start () {
		GetComponent<Button>().onClick.AddListener(() => {
			panel.SetActive (false);
		});
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
