using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public float HealthBar;
	public float Damage;

	float delayTime;
	bool Delay;

	public float Change;

	public GameObject myHealthBar;
	public GameObject myPivot;
	public GameObject myHitIndicator;
	public Image healthBarImage;

	// Use this for initialization
	void Start () {
		Delay = false;
		delayTime = 1;

		Image healthBarImage = GameObject.FindWithTag("HealthBar").GetComponent<Image>();

		myHitIndicator = GameObject.FindGameObjectWithTag ("hitIndicator");
		hitMarkerScript hitMarker = myHitIndicator.GetComponent<hitMarkerScript> ();

		myHealthBar = GameObject.FindGameObjectWithTag ("HealthBar");
		myPivot = GameObject.FindGameObjectWithTag ("pivot");

		hitMarker.gotHit = true;
	}
	
	// Update is called once per frame
	void Update () {

		hitMarkerScript hitMarker = myHitIndicator.GetComponent<hitMarkerScript> ();

		if (HealthBar <= 0) {
			Application.LoadLevel ("GameOver");
		}


		if (HealthBar == 25) {
			healthBarImage.color = UnityEngine.Color.red;
		}
		else if (HealthBar > 25)
		{
			healthBarImage.color = UnityEngine.Color.white;
		}


		Change = (HealthBar * 0.01f) * 0.6784276f;
		//myHealthBar.transform.localScale = new Vector3 (Change, 0.3234372f, 1f);


		ScaleAround (myHealthBar.transform, myPivot.transform, new Vector3 (Change, 0.3234372f, 1f));

		if (Delay == true) {
			delayTime = delayTime -= 0.1f;
			hitMarker.gotHit = true;
			myHitIndicator.SetActive (true);
			
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
