using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeDifficulty : MonoBehaviour {

	public GameObject myCamera;

	// Use this for initialization
	void Start () {
		myCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		Mover movingScript = myCamera.GetComponent<Mover> ();
		movingScript.speed = 6f;
	}
	/*	public void changeSpeed ( GameObject myCamera, Mover movingScript )
	{
		movingScript.speed = 6f;
	}
	*/
}
