using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int maxHeath = 30;

	int currHealth;

	// Use this for initialization
	void Start () {
		currHealth = maxHeath;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TakeDamage(int damage){
		currHealth = currHealth - damage;
	}
}
