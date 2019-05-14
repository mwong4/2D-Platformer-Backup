using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float HealthBar;
	public float Damage;

	float delayTime;
	bool Delay;

	public float Change;

	public GameObject myHealthBar;
	public GameObject myPivot;

	// Use this for initialization
	void Start () {
		Delay = false;
		delayTime = 1;

		myHealthBar = GameObject.FindGameObjectWithTag ("HealthBar");
		myPivot = GameObject.FindGameObjectWithTag ("pivot");
	}
	
	// Update is called once per frame
	void Update () {

		if (HealthBar <= 0) {
			Application.LoadLevel ("GameOver");
		}

		Change = (HealthBar * 0.01f) * 0.6784276f;
		//myHealthBar.transform.localScale = new Vector3 (Change, 0.3234372f, 1f);


		ScaleAround (myHealthBar.transform, myPivot.transform, new Vector3 (Change, 0.3234372f, 1f));

		if (Delay == true) {
			delayTime = delayTime -= 0.1f;
		}

		if (delayTime <= 0) {
			Delay = false;
			delayTime = 1;
		}

		if (HealthBar <= 0) {
			Debug.Log ("Killed");
			//Die
			//Application.LoadLevel("GameOver");
		}

//		if (Input.GetKeyDown ("g")) {
//			HealthBar -= 10;
//		}
	}



	void OnCollisionEnter2D (Collision2D col)
	{

		if(col.gameObject.tag == "enemy" && Delay == false) {
			HealthBar = HealthBar - Damage;
			Delay = true;
			//			Debug.Log ("Destroyed");
		}

		if(col.gameObject.tag == "GiveHealth" && HealthBar <= 50) {
			HealthBar = HealthBar + 50f;

		}

		if(col.gameObject.tag == "GiveHealth" && HealthBar >= 50) {
			HealthBar = 100f;
		}

	}

	public static void ScaleAround(Transform target, Transform pivot, Vector3 scale) {
		Transform pivotParent = pivot.parent;
		Vector3 pivotPos = pivot.position;
		pivot.parent = target;      
		target.localScale = scale;
		target.position += pivotPos - pivot.position;
		pivot.parent = pivotParent;
	}
}
