using UnityEngine;
using System.Collections;

public class CubeBehavior : MonoBehaviour {

	public CubeSpawnArray aGameController;
	


	void OnMouseDown (){
		aGameController.ProcessClickedCube (this.gameObject);
		print ("Do the thing!");
	
	}

	// Use this for initialization
	void Start () {
		aGameController = GameObject.Find ("GameControllerObject").GetComponent<CubeSpawnArray> ();


	}
	
	// Update is called once per frame
	void Update () {
	foreach (GameObject oneCube in aGameController.allCubes) {
			oneCube.GetComponent<Renderer>().material.color = Color.white;
		}

	}
}
