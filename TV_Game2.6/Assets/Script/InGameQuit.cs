using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameQuit : MonoBehaviour {

	public bool UIOpen;
	public GameObject myMenu;

	// Use this for initialization
	void Start () {

		UIOpen = false;
		myMenu = GameObject.FindGameObjectWithTag ("MainMenu");
		myMenu.SetActive (false);
		Time.timeScale = 1f;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape) && UIOpen == false) {
			myMenu.SetActive (true);
			UIOpen = true;
			Time.timeScale = 0f;
		}

		else if (Input.GetKeyDown (KeyCode.Escape) && UIOpen == true) {
			myMenu.SetActive (false);
			UIOpen = false;
			Time.timeScale = 1f;
		}

	}
}
