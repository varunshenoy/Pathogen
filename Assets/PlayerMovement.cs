using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	//Set default variables
	Rigidbody2D rbody;
	Animator anim;
	Animation hurt;
	public LayerMask whatToHit;
	public Transform BulletTrailPrefab;
	public Transform FirePoint;
	public Slider healthSlider;
	public int Ammo = 25;
	public Text text;
	public Text perc;
	public int curHealth;
	public int maxHealth = 100;
	public int atp = 0;
	public Text numAtp;
	public Image Fill;
	public Color MaxHealthColor = Color.green;
	public Color MinHealthColor = Color.red;
	public GameObject life1;
	public GameObject life2;
	public int lives = 3;
	public Text livescounter;
	public Text atpcouter;
	public GameObject DeadUI;
	public Text antibodyType;

	// Use this for initialization
	void Start () {
		//grab necessary variables and set up UI
		DeadUI.SetActive (false);
		rbody = GetComponent<Rigidbody2D> ();
		//anim = GetComponent<Animator> ();
		hurt = GetComponent<Animation> ();
		curHealth = maxHealth;

		text.text = "Antibodies Left: " + Ammo;
	}

	void Update () {

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			//Switch to Green Antibodies
			antibodyType.text = "TYPE G";
		}

		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			//Switch to Yellow Antibodies
			antibodyType.text = "TYPE Y";
			print ("Blood Type B");
		}

		//grab movement data from keys on axis
		Vector2 movement_vector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		if (Input.GetMouseButtonDown (0)) {
			//grab mouse variables for firing mechanism
			var mousePos = Input.mousePosition;
			mousePos.x -= Screen.width/2;
			mousePos.y -= Screen.height/2;

			if (Ammo > 0) {
				shoot();
			}



		
		}

		//movement triggered by movement_vector
		rbody.MovePosition (rbody.position + movement_vector * Time.deltaTime);

		if (curHealth <= 0) {

			Die (); 

		}


	}

	void OnTriggerEnter2D(Collider2D obj) {  
		var name = obj.gameObject.name;
		
		// If it collided with bacteria
		if (name == "Bacteria(Clone)" || name == "YellowBacteria(Clone)") {
			//damage and UI updating
			if (curHealth <= 3) {
				curHealth = 0;
			} else {
				curHealth = curHealth - 3;
			}
			healthSlider.value = curHealth;
			perc.text = curHealth + "%";
			hurt.Play("hurt");
			Fill.color = Color.Lerp (MinHealthColor, MaxHealthColor, (float)curHealth / maxHealth);
			//Destroy(obj.gameObject);
		}

		if (name == "virus(Clone)") {
			if (curHealth <= 1) {
				curHealth = 0;
			} else {
				curHealth = curHealth - 3;
			}
			healthSlider.value = curHealth;
			perc.text = curHealth + "%";
			hurt.Play("hurt");
			Fill.color = Color.Lerp (MinHealthColor, MaxHealthColor, (float)curHealth / maxHealth);
			//Destroy(obj.gameObject);
		}

		if (name == "atp(Clone)") {
			atp++;
			numAtp.text = atp.ToString();
			Destroy(obj.gameObject);
		}
		/*if (name == "Collider") {
			Damage(10);
		}*/
	}

	void Effect () {

		//Create antibodies
		Instantiate (BulletTrailPrefab, FirePoint.position, FirePoint.rotation);
			
	}
	

	void shoot() {

		//raycasting physics to determine the position of the mouse and shoot an antibody and update UI
		Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
		Ammo = Ammo - 1;
		RaycastHit2D hit = Physics2D.Raycast (rbody.position, mousePosition - rbody.position, 100, whatToHit);
		Effect ();
		Debug.DrawLine (rbody.position, (mousePosition - rbody.position) * 100, Color.cyan);
		
		if (hit.collider != null) {
			
			Debug.DrawLine (rbody.position, hit.point, Color.red);
			
		}

		text.text = "Antibodies Left: " + Ammo;
	
	}

	public void buyAntibodies() {
		//Simple math for the purchase of antibodies
		if (atp >= 5) {
			Ammo += 10;
			text.text = "Antibodies Left: " + Ammo;
			atp -= 5;
			atpcouter.text = atp.ToString ();
		}
	}

	void Die() {
		//Use special effects helper for death
		SpecialEffectsHelper.Instance.blowUpPlayer (rbody.transform.position);
		lives--;
		if (lives > 0) {
			//check if lives are left, if so continue with certain variables
			if (lives == 1) {
				life1.SetActive (true);
				life2.SetActive (false);
				livescounter.text = lives + " life left\n +20% bonus \nimmunity!";
			} else if (lives == 2) {
				life2.SetActive (true);
				livescounter.text = lives + " lives left\n +20% bonus \nimmunity!";
			}
			curHealth = maxHealth + 20;
			healthSlider.value = curHealth;
			perc.text = curHealth + "%";
			Fill.color = Color.Lerp (MinHealthColor, MaxHealthColor, (float)curHealth / maxHealth);
			Ammo += 25;
			text.text = "Antibodies Left: " + Ammo;
		} else {
			//otherwise, destroy the object, show the death UI
			Destroy (rbody.gameObject);
			DeadUI.SetActive (true);
		}

		//Destroy (rbody.gameObject);
		//restart
		//Application.LoadLevel (Application.loadedLevel);
	
	}
}
