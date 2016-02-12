using UnityEngine;
using System.Collections;

public class movementScript : MonoBehaviour {
	public float rotationSpeed;
	public float movementSpeed;
	public float rotationTime;
	
	void Start()
	{
		Invoke("ChangeRotation",rotationTime);
	}
	
	void ChangeRotation()
	{
		if(Random.value > 0.5f)
		{
			rotationSpeed = -rotationSpeed;
		}
		Invoke("ChangeRotation",rotationTime);
	}
	
	
	void Update() {
		
		transform.Rotate (new Vector3 (0, 0, rotationSpeed * Time.deltaTime));
		transform.position += transform.up*movementSpeed*Time.deltaTime;
		
	}
}
