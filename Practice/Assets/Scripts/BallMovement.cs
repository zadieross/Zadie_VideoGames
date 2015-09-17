using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour {
	private Rigidbody BallBody;
	private int total;
	public int speed;
	public Text Score;
	public Text WinText;

	// Use this for initialization
	void Start () {
		BallBody = GetComponent<Rigidbody> ();
		total = 0;
		SetScoreText ();
		WinText.text = "";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float BallHorizontal = Input.GetAxis ("Horizontal");
		float BallVertical = Input.GetAxis ("Vertical");

		Vector3 move = new Vector3 (BallHorizontal, 0, BallVertical);

		BallBody.AddForce (move*speed);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("TicTac")) 
		{
			other.gameObject.SetActive (false);
			total = total + 1;
			SetScoreText();
		}
	}

	void SetScoreText () {
		Score.text = "Tic Tacs eaten: " + total.ToString ();
		if (total >= 5){
			WinText.text = "You Win!";
		}
	}

}
