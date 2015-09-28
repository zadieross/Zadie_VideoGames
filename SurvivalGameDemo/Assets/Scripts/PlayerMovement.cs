using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float movementSpeed = 6f;
	public float turnSpeed = 100f;
	Rigidbody playerRigidBody;
	Animator playerAnimator;

	// Use this for initialization
	void Start () {
		playerRigidBody = GetComponent <Rigidbody> ();
		playerAnimator = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float forwardMovement = Input.GetAxis("Vertical");
		float turnMovement = Input.GetAxis ("Horizontal");

		if (forwardMovement == 0 && turnMovement == 0) {
			playerAnimator.SetBool ("IsWalking", false);
		} else {
			playerAnimator.SetBool ("IsWalking", true);
		}
		Vector3 movement = forwardMovement * transform.forward;
		movement = movement.normalized * Time.deltaTime;

		playerRigidBody.MovePosition (transform.position + movement);

		float currAngle = transform.rotation.eulerAngles.y;
		float targetAngle = currAngle + turnMovement * Time.deltaTime * turnSpeed;
		Quaternion newRotation = Quaternion.Euler (new Vector3 (0, targetAngle, 0));
		playerRigidBody.MoveRotation (newRotation);
	}
}
