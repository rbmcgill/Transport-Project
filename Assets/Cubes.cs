using UnityEngine;
using System.Collections;

public class Cubes : MonoBehaviour {

	public GameObject cubes;
	int totalNumberCubes = 16;

	// Use this for initialization
	void Start () {
		for(int cubesSpawned = 0; cubesSpawned < totalNumberCubes; cubesSpawned++){
			Instantiate (cubes, new Vector2(1, 0), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
