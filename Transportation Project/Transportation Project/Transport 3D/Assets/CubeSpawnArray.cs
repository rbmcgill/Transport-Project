using UnityEngine;
using System.Collections;

public class CubeSpawnArray : MonoBehaviour {

	public GameObject[,] allCubes;
	public GameObject Cube;
	public Aiplane airplane;
	public GUIText cargo = airplane.cargo;
	//shoe cargo value on screen

	int turnTime = 1.5f; 
	//turn takes 1.5 seconds, at this time airplane moves

	int gridWidth = 16;
	int gridHeight = 9;

	public void ProcessClickedCube (GameObject clickedCube, int x, int y) {
		print (x + ", " + y);

		if (x == airplane.x && y == airplane.y && airplane.activeAirplane == false) {
			airplane.activeAirplane = true;
			allCubes [8, 0].GetComponent<Renderer> ().material.color = Color.black;
			clickedCube.GetComponent<Renderer> ().material.color = Color.yellow;
			print ("Active Airplane");
		} //activate airplane

		else if (x == airplane.x && y == airplane.y && airplane.activeAirplane) {
			airplane.activeAirplane = false;
			allCubes [8, 0].GetComponent<Renderer> ().material.color = Color.black;
			clickedCube.GetComponent<Renderer> ().material.color = Color.red;
			print ("Inactive airplane");
		}//deactivate airplane

		/*else if (airplane.activeAirplane && (x != airplane.x || y != airplane.y)) {
			allCubes[airplane.x, airplane.y].GetComponent<Renderer>().material.color = Color.white;
			allCubes[8,0].GetComponent<Renderer>().material.color = Color.black;
			allCubes[x,y].GetComponent<Renderer>().material.color = Color.yellow;
			airplane.x = x;
			airplane.y = y;
			print ("Teleport!")
		}*/
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
			print ("Cubes spawned");
			//reaching into CubeBehavior script, which is tracking the plane position
			//uses those coordinates in cubes spawned here (in allCubes)
		}
	
		airplane = new Aiplane ();

		airplane.x = 0;
		airplane.y = 8; 
		if(airplane.x == 0 && airplane.y == 8){
			allCubes[airplane.x,airplane.y].GetComponent<Renderer>().material.color = Color.red;
		}

		print ("load airplane");



	}

	// Update is called once per frame
	void Update () {

		//make one cube, the depot, black (bottom right corner)
			//store what key was pressed most recently
			
		if (Input.GetKey(KeyCode.DownArrow)) {
			airplane.y--;
		}//still have to figure out how to track time/turns
		else if (Input.GetKey(KeyCode.UpArrow)) {
			airplane.y++;
		}//still have to figure out how to track time/turns
		else if (Input.GetKey(KeyCode.RightArrow)) {
			airplane.x++;
		}//sti;; have to figure out how to track time/turns
		else if (Input.GetKey(KeyCode.LeftArrow)) {
			airplane.x--;
		}//still have to figure out how to track time/turns
		//move in that direction if it is time to move (turnTime)


		if (airplane.x == 0 && airplane.y == 8 && airplane.cargo < airplane.cargoCapacity){
			airplane.cargo = airplane.cargo + 10;
		}//add 10 cargo if the airplane is on the starting location

		else if (airplane.x == 0 && airplane.y == 8 && airplane.cargo == airplane.cargoCapacity){
			airplane.cargo = airplane.cargoCapacity;
			//don't accept more cargo
			print ("You can't accept additional pylons! Bring these to the base!");
		}



	}
}
