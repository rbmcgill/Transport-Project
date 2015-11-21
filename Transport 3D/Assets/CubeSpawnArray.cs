using UnityEngine;
using System.Collections;

public class CubeSpawnArray : MonoBehaviour {

	public GameObject[,] allCubes;
	public GameObject Cube;
	public Airplane airplane;
	void OnGUI () {
		GUI.Box (new Rect ((Screen.width/2)-(Screen.width/20), 0, Screen.width/10, 25), airplane.cargo.ToString());
	}
	//show cargo value on screen


	float timeToDoTheThing;
	float turnTime = 1.5f; 
	//turn takes 1.5 seconds, at this time airplane moves

	int gridWidth = 16;
	int gridHeight = 9;
	int score = 0;
	int depotX = 15;
	int depotY = 0;
	int airplaneStartX = 0;
	int airplaneStartY = 8;

	public void ProcessClickedCube (GameObject clickedCube, int x, int y) {
		print (x + ", " + y);
		//if the airplane is in the depot, that square is black, for anything else the airplane cube is white for some reason
		if (airplane.x == depotX && airplane.y == depotY) {
			allCubes [airplane.x, airplane.y].GetComponent<Renderer> ().material.color = Color.black;
		} 
		else {
			allCubes [airplane.x, airplane.y].GetComponent<Renderer>().material.color = Color.white;
		}//this  doesn't make sense to ma as to why I could make the airplane cube white (see below script)
	

		if (x == airplane.x && y == airplane.y && airplane.activeAirplane == false) {
			airplane.activeAirplane = true;
			clickedCube.GetComponent<Renderer> ().material.color = Color.yellow;
			print ("Active Airplane");
		} //activate airplane

		else if (x == airplane.x && y == airplane.y && airplane.activeAirplane) {
			airplane.activeAirplane = false;
			clickedCube.GetComponent<Renderer> ().material.color = Color.red;
			print ("Inactive airplane");
		}//deactivate airplane


	}




	//when player clicks on plane, make the color change/have airplane glow to show it's activated
	//if player clicks active plane it deactivates (changes back to red/stop glowing)


	//if there is no active airplane, don't do anything, no teleportation, nothing




	// Use this for initialization
	void Start () {
		timeToDoTheThing = turnTime;
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
		allCubes [depotX,depotY].GetComponent<Renderer>().material.color = Color.black;
	
		airplane = new Airplane ();

		airplane.x = airplaneStartX;
		airplane.y = airplaneStartY; 
		if(airplane.x == airplaneStartX && airplane.y == airplaneStartY){
			allCubes[airplane.x,airplane.y].GetComponent<Renderer>().material.color = Color.red;
			allCubes [depotX,depotY].GetComponent<Renderer> ().material.color = Color.black;
		}


		print ("load airplane");
	}

	// Update is called once per frame
	void Update () {
		if (airplane.activeAirplane == true) {
			AirplaneMovement();
		}

		if (airplane.x == depotX && airplane.y == depotY) {
			score += airplane.cargo;
			airplane.cargo = 0;
			print ("Score:" + score);
		}

		if (Time.time >= timeToDoTheThing) {


			//color changing stuff
			if (airplane.x == depotX && airplane.y == depotY){
				allCubes[airplane.x, airplane.y].GetComponent<Renderer>().material.color = Color.black;
			}
			else {
				allCubes[airplane.x, airplane.y].GetComponent<Renderer>().material.color = Color.white;
			}
			//move
			airplane.MoveAirplane();

			//new colors after movement
			if (airplane.activeAirplane){
				allCubes[airplane.x, airplane.y].GetComponent<Renderer>().material.color = Color.yellow;
			}
			else {
				allCubes[airplane.x, airplane.y].GetComponent<Renderer>().material.color = Color.red;
			}

			//cargo stuff
			if (airplane.x == airplaneStartX && airplane.y == airplaneStartY && airplane.cargo < airplane.cargoCapacity){
				airplane.cargo = airplane.cargo + 10;
				print ("Cargo:" + airplane.cargo);
			}//add 10 cargo if the airplane is on the starting location
			else if (airplane.x == airplaneStartX && airplane.y == airplaneStartY && airplane.cargo == airplane.cargoCapacity){
				airplane.cargo = airplane.cargoCapacity;
			//don't accept more cargo

			}
			timeToDoTheThing += turnTime;

		}

	}

	void AirplaneMovement () {
			if (Input.GetKey(KeyCode.DownArrow)) {
				airplane.SetMoveDirection(0,-1);
			}

			else if (Input.GetKey(KeyCode.UpArrow)) {
				airplane.SetMoveDirection(0,1);
			}

			else if (Input.GetKey(KeyCode.RightArrow)) {
				airplane.SetMoveDirection(1,0);
			}

			else if (Input.GetKey(KeyCode.LeftArrow)) {
				airplane.SetMoveDirection(-1,0);
			}

	}




}
