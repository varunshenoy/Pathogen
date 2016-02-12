using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {

	public int hp = 20;
	public bool isEnemy = true;
	public ParticleSystem smokeEffect;
	public Text currentAntibodyType;
	public bool typeMatters;
	public string type = "yellow";

	// Use this for initialization
	void Start () {
		//grap current antibody type
		currentAntibodyType = GameObject.Find ("Typing").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Damage(int damageCount)
	{
		//subtract damage
		hp -= damageCount;
		//animate hurt animation
		gameObject.GetComponent<Animation>().Play();

		//if health is less than 0, destroy the object
		if (hp <= 0)
		{
			Destroy(gameObject);
			print("HP: " + hp);
			SpecialEffectsHelper.Instance.Explosion(transform.position);
			//SpecialEffectsHelper.Instance.KillSound();
		}
	}

	void OnTriggerEnter2D(Collider2D obj) {  
		var name = obj.gameObject.name;
		
		// If it collided with a bullet
		if (name == "BulletTrailPrefab(Clone)") {
			if (typeMatters == false) {
				Damage(10);
				Destroy(obj.gameObject);
			} else if ((type == "yellow" && currentAntibodyType.text == "TYPE Y") || (type == "green" && currentAntibodyType.text == "TYPE G")) {
				Damage(10);
				Destroy(obj.gameObject);
			}
		}

	}
}
