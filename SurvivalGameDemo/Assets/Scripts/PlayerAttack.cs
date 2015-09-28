using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public float timeBetweenBullets = 0.15f;
	public int gunDamage = 10;

	LineRenderer bulletLine;
	Ray shootRay;
	float timer;
	AudioSource gunSound;

	// Use this for initialization
	void Start () {
		bulletLine = GetComponent<LineRenderer> ();
		timer = 0f;
		gunSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (Input.GetButton ("Fire") && timer >= timeBetweenBullets) {
			Shoot ();
		} else {
			DisableEffects();
		}
	}

	void DisableEffects (){
		bulletLine.enabled = false;
	}
	void Shoot (){
		gunSound.Play ();
		timer = 0;
		bulletLine.enabled = true;

		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;

		RaycastHit shootHit;

		bulletLine.SetPosition (0, transform.position);

		if (Physics.Raycast (shootRay, out shootHit)) {
			shootHit.collider.GetComponent<EnemyHealth>();
			if (EnemyHealth!= null ){
				EnemyHealth.TakeDamage(gunDamage);
			}
			bulletLine.SetPosition (1, shootHit.point);
		} else {
			bulletLine.SetPosition (1, shootRay.origin + shootRay.direction * 100);
		}
	}
}
