using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour {
	private Rigidbody BallBody;
	private int total;
	public totalText;

	// Use this for initialization
	void Start () {
		BallBody = GetComponent<Rigidbody> ();
		total = 0;
		totalText.text = "TicTacs: " + total.toString ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float BallHorizontal = Input.GetAxis ("Horizontal");
		float BallVertical = Input.GetAxis ("Vertical");

		Vector3 move = new Vector3 (BallHorizontal, 0, BallVertical);

		BallBody.AddForce (move);
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("TicTac")) 
		{
			other.gameObject.SetActive (false);
			total = total + 1;
		}
	}
}
