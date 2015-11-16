using UnityEngine;
using System.Collections;

public class PedestalButtons : MonoBehaviour {

	public GameObject buttonPrefab;
	public GameObject door;

	// number of rows and columns in the grid of buttons
	private static int rows = 4;
	private static int columns = 4;

	public TextAsset[,] buttonImageAsset = new TextAsset[rows, columns];

	// create 2d array of button positions
	private Vector3[,] buttonPositions = new Vector3[rows, columns];
	private GameObject[,] buttonGO = new GameObject[rows, columns];
	
	// Use this for initialization
	void Start () {

		// 2d array of button labels
		// note that this is reversed from the actual order of the buttons
		// (the top row on the pedestal is S, C, X, I, ...)
		char[,] blabels = {{'e', 'z', 'm', 'h'},
						   {'f', 'u', 'o', 'q'},
						   {'a', 'n', 'b', 'l'},
						   {'s', 'c', 'x', 'i'}};

		// create grid of prefab buttons
		for (int r=0; r<rows; r++) {
			for (int c=0;c<columns;c++) {
				// create a new button at each position
				buttonPositions[r,c] = new Vector3((float)(0.2*c), 0, 
												   (float)(0.2*r));
				// instantiate the button, and add it to the game as a GameObject
				buttonGO[r,c] = (GameObject)Instantiate(buttonPrefab, 
									 buttonPositions[r,c], Quaternion.identity);
				// make the button a child of the pedestal
				buttonGO[r,c].transform.parent = GameObject.Find("Pedestal").transform;

				Vector3 translateButtons = new Vector3(-0.3f, 0.25f, -0.3f);
				buttonGO[r,c].transform.Translate(this.transform.position + 
											 translateButtons);
	
				buttonGO[r,c].GetComponent<ButtonClick>().label = blabels[r,c];
			}
		}

		// rotate the pedestal and all of its buttons
		this.transform.Rotate(315, 0, 0);
		// applying image texture ??
		for (int t; t<rows; t++) {
			for (int v; v<columns; v++;) {
				Texture2D texture = new Texture2D(250,250);
				texture.LoadImage(buttonImageAsset[t,v].bytes);
				buttonGO[t,v].GetComponent.<Renderer>().material.mainTexture = texture;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		// check if the player has hit the right buttons on the pedestal
		// and if so, unlock the door
		for (int r=0;r<rows;r++) {
			for (int c=0;c<columns;c++) {
				if (buttonGO[r,c].GetComponent<ButtonClick>().getStatus())
					door.SetActive(false);
			}
		}
	}
}
