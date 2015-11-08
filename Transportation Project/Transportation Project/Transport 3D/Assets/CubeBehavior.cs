using UnityEngine;
using System.Collections;

public class CubeBehavior : MonoBehaviour {

	public CubeSpawnArray aGameController;

	public int x,y;

	void OnMouseDown (){
		aGameController.ProcessClickedCube (this.gameObject, x, y);
		//when player clicks on plane, make the color change/have airplane glow to show it's activated
		//if player clicks active plane it deactivates (changes back to red/stop glowing)

	
		}
		//if plane is active and player clicks on a white cube, make that one red (teleport airplane there) and the other cubes white
		//but, if the airplane is not active, don't make any other cubes change color

	//if the player presses an arrow key, and the plane is active, it moves in that direction 


	// Use this for initialization
	void Start () {
		aGameController = GameObject.Find ("GameControllerObject").GetComponent<CubeSpawnArray> ();


	}
	
	// Update is called once per frame
	void Update () {
	

	}
}
