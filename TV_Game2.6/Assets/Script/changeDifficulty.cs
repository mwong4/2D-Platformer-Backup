using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeDifficulty : MonoBehaviour {

	public GameObject myCamera;

	public GameObject[] slowPoints;
	public GameObject[] fastPoints;


	// Use this for initialization
	void Start () {
		myCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		Mover movingScript = myCamera.GetComponent<Mover> ();
		movingScript.speed = 6f;

		slowPoints = GameObject.FindGameObjectsWithTag ("slowerCameraPoints");

		foreach (GameObject x in slowPoints) {
			Waypoint waypoint = x.GetComponent<Waypoint> ();
			waypoint.speedOut = 1.5f;
		}

		fastPoints = GameObject.FindGameObjectsWithTag ("fasterCameraPoints");
		foreach (GameObject x in fastPoints) {
			Waypoint waypoint = x.GetComponent<Waypoint> ();
			waypoint.speedOut = 5;
		}
	}
	/*	public void changeSpeed ( GameObject myCamera, Mover movingScript )
	{
		movingScript.speed = 6f;
	}
	*/
}
