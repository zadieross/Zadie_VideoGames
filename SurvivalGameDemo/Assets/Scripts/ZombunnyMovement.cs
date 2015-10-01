using UnityEngine;
using System.Collections;

public class ZombunnyMovement : MonoBehaviour {

	Rigidbody bunnyRigidBody;
	Animator bunnyAnimator;
	public GameObject player;
	public float movementSpeed = 4f;
	NavMeshAgent nav;

	// Use this for initialization
	void Awake () {
		player = gameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <NavMeshAgent> ();
	}

	// Update is called once per frame
	void Update () {
		nav.SetDestination (player.position);
	}
}
