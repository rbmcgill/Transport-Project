using UnityEngine;
using System.Collections;

public class CubeSpawnArray : MonoBehaviour {

	public GameObject[] allCubes;
	public GameObject Cube;

	int totalNumberCubes = 16;

	public void ProcessClickedCube (GameObject clickedCube) {
	//this whole script can be called by other scripts but won't return anything when completed
		foreach (GameObject oneCube in allCubes) {
			oneCube.GetComponent<Renderer>().material.color = Color.black;
		}
		clickedCube.GetComponent<Renderer>().material.color = Color.red;
		print (clickedCube.GetComponent<Renderer>().material.color);
	}


	// Use this for initialization
	void Start () {
		allCubes = new GameObject[totalNumberCubes];
		for(int cubesSpawned = 0; cubesSpawned < totalNumberCubes; cubesSpawned++) {
			allCubes[cubesSpawned] = (GameObject) Instantiate (Cube, new Vector3 (cubesSpawned*2, 0, 0), Quaternion.identity);
		
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
