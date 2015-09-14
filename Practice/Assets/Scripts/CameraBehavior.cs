using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {

	public GameObject player;
	private Vector3 translationOffset;

	// Use this for initialization
	void Start () {
		translationOffset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position + translationOffset;
	}
}
