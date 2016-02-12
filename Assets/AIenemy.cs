using UnityEngine;
using System.Collections;

public class AIenemy : MonoBehaviour {

	public GameObject Player;
	public float speed = 2f;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		//Follow the player
		Player = GameObject.FindGameObjectWithTag ("Player");
		transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
		var lookPos = Player.transform.position - transform.position;
		lookPos.y = 0;
		var rotation = Quaternion.LookRotation(lookPos);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2); 

	}
}
