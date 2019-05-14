using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenMove : MonoBehaviour {

   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject myPlayer = GameObject.FindGameObjectWithTag("player");
        this.transform.position = new Vector3(this.transform.position.x + 0.05f, myPlayer.transform.position.y, this.transform.position.z);
	}
}
