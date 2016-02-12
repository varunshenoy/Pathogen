using UnityEngine;
using UnityEngine.UI;

public class SpecialEffectsHelper : MonoBehaviour
{
	//public Text anotherLife;
	public ParticleSystem smokeEffect;
	public ParticleSystem blowUp;
	public static SpecialEffectsHelper Instance;
	public GameObject atp;
	public int target;
	int currentKilled;
	public Text targetComp;
	public GameObject MemCell;
	public AudioSource sound;
	public AudioClip kill;

	void Awake()
	{
		//memory cell hidden
		//set up target number of enemies
		MemCell.SetActive (false);
		targetComp.text = "0/" + target;
		if (Instance != null)
		{
			//simple debugging
			Debug.LogError("Multiple instances of SpecialEffectsHelper!");
		}
		currentKilled = 0;
		Instance = this;
		sound = GetComponent<AudioSource> ();
	}

	void Update() {

		//make the memory cell appear if the player makes it to the target amount of enemies
		if (currentKilled >= target) {
			MemCell.SetActive (true);
		}

	}
	
	/*public void KillSound () {

		sound.PlayOneShot(enemy_death);

	}

	public void ImpDead (Vector3 position) {
		
		sound.PlayOneShot(Imp_Death);
		instantiate(time, position);
	}

	public void FinalBoss (Vector3 position) {
		
		sound.PlayOneShot(Imp_Death);
		instantiate(head, position);
	}

	public void BossDead (Vector3 position) {
		
		sound.PlayOneShot(Imp_Death);
		instantiate(time2, position);
	}

	public void Explosion(Vector3 position)
	{

		instantiate(smokeEffect, position);
		instantiate(coin, position);

	}*/

	public void blowUpPlayer(Vector3 position)
	{
		//destruction animation of player
		instantiate(blowUp, position);

	}

	public void Explosion(Vector3 position)
	{
		//death of enemy sound + particle effect
		sound.PlayOneShot (kill);
		instantiate(smokeEffect, position);
		//random atp spawning
		var number = Random.Range(0,2);
		if (number == 1) {
			instantiate (atp, position);
		} else if (number == 2) {
			instantiate (atp, position);
			instantiate (atp, position);
		}
		//increase and change ui of current enemies slain
		currentKilled++;
		targetComp.text = currentKilled + "/" + target;
		if (currentKilled >= target) {
			MemCell.SetActive (true);
		}
	}

	private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
	{
		ParticleSystem newParticleSystem = Instantiate (
			prefab,
			position,
			Quaternion.identity
		) as ParticleSystem;
		

		Destroy (
			newParticleSystem.gameObject,
			newParticleSystem.startLifetime
		);
		
		return newParticleSystem;
	}

	private GameObject instantiate(GameObject prefab, Vector3 position)
	{
		GameObject newCoin = Instantiate(
			prefab,
			position,
			Quaternion.identity
			) as GameObject;
		
		return newCoin;
	}
}
