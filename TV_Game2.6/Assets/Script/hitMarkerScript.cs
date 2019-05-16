using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitMarkerScript : MonoBehaviour {

	public bool gotHit;
	private float currentTime;
	public GameObject thisObject;

	// Use this for initialization
	void Start () {
		gotHit = true;
		currentTime = 99.999f;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(gotHit == true)
		{
			currentTime += Time.deltaTime;
			thisObject.SetActive (true);
		}
		if(currentTime >= 0.15)
		{
			gotHit = false;
			currentTime = 0;
			thisObject.SetActive (false);
		}
		
	}
}
