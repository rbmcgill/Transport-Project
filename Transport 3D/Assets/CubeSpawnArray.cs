using UnityEngine;
using System.Collections;

public class CubeSpawnArray : MonoBehaviour {

	public GameObject[,] allCubes;
	public GameObject Cube;
	public Aiplane airplane;

	int gridWidth = 16;
	int gridHeight = 9;

	public void ProcessClickedCube (GameObject clickedCube, int x, int y) {
		if (x == airplane.x && y == airplane.y && airplane.activeAirplane == false) {
			airplane.activeAirplane = true;
			clickedCube.GetComponent<Renderer> ().material.color = Color.yellow;
		} 
		else if (x == airplane.x && y == airplane.y && airplane.activeAirplane) {
			airplane.activeAirplane = false;
			clickedCube.GetComponent<Renderer> ().material.color = Color.red;
		}
		else if (airplane.activeAirplane && (x != airplane.x || y != airplane.y)) {
			allCubes[airplane.x, airplane.y].GetComponent<Renderer>().material.color = Color.white;
			allCubes[x,y].renGetComponent<Renderer>().derer.material.color = Color.yellow;
			airplane.x = x;
			airplane.y = y;
		}

	}
	//when player clicks on plane, make the color change/have airplane glow to show it's activated
	//if player clicks active plane it deactivates (changes back to red/stop glowing)


	//if there is no active airplane, don't do anything, no teleportation, nothing




	// Use this for initialization
	void Start () {
		allCubes = new GameObject[gridWidth,gridHeight];
		for(int x = 0; x < gridWidth; x++) {
			for (int y = 0; y < gridHeight; y++){
			allCubes[x,y] = (GameObject) Instantiate (Cube, new Vector3 (x*2, y*2, 0), Quaternion.identity);
			
			allCubes[x,y].GetComponent<CubeBehavior>().x = x;
			allCubes[x,y].GetComponent<CubeBehavior>().y = y;
			}
			//reaching into CubeBehavior script, which is tracking the plane position
			//uses those coordinates in cubes spawned here (in allCubes)

		}
		airplane = new Aiplane ();
		//does this take or make a new object from the type Airplane? What does that do/mean?
		airplane.x = 0;
		airplane.y = 8; 

		allCubes [airplane.x, airplane.y].GetComponents<Renderer>().material.color = Color.red;

	}

	// Update is called once per frame
	void Update () {

	}
}
