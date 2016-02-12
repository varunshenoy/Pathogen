using UnityEngine;
using System.Collections;

public class MoveTrail : MonoBehaviour {
	// Update is called once per frame

	public float movespeed = 0.5f;

	void Update () {
	
		transform.Translate (Vector3.right * Time.deltaTime * movespeed);

	}
}
