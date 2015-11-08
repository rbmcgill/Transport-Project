using UnityEngine;
using System.Collections;

public class CubeArrays : MonoBehaviour {
	public GameObject whiteCube;

	// Use this for initialization
	void Start () {
		Instantiate (whiteCube, new Vector2 (0,0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
