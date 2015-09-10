using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {
	private Rigidbody BallBody;

	// Use this for initialization
	void Start () {
		BallBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float BallHorizontal = Input.GetAxis ("Horizontal");
		float BallVertical = Input.GetAxis ("Vertical");

		Vector3 move = new Vector3 (BallHorizontal, 0, BallVertical);

		BallBody.AddForce (move);
	}
}
