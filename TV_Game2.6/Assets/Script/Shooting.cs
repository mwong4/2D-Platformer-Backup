using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	public GameObject bullet;

	public Vector2 mycurr3DPos;

	public Transform firePoint;

	public GameObject myCharacter;
	//public float myHealth;
	// Use this for initialization
	void Start () {
		mycurr3DPos = this.transform.position;

		Vector2 mycurr2DPos = new Vector2 (mycurr3DPos.x, mycurr3DPos.y);

		myCharacter = GameObject.FindGameObjectWithTag ("player");
		Health healthScript = myCharacter.GetComponent<Health> ();


	}


	// Update is called once per frame
	void Update () {

		myCharacter = GameObject.FindGameObjectWithTag ("player");
		Health healthScript = myCharacter.GetComponent<Health> ();

		if (Input.GetKeyDown ("space")) {
			Instantiate (bullet, firePoint.position, firePoint.rotation);
			healthScript.HealthBar -= 5f;
		}

	}

}
