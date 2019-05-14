using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatEnemyScript : MonoBehaviour {

	//	public float CurrentX, CurrentY;

	//	private SpriteRenderer mySpriteRenderer;

	//The delay
	public float delay;

	//explosion
	public GameObject explosionEffect;
	public float radius;
	public float force = 700f;

	float countdown;

	public bool Destroy;

	public GameObject Player;
	public GameObject Enemy;

	public float PointOne, PointTwo, Speed;
	public float Direction;
	public float RotateX, RotateY;

	public Vector2 mycurr3DPos;

	// Use this for initialization
	void Start () {

		Destroy = false;

		//countdown
		countdown = delay;

		Direction = -1;

		//		RotateY = RotateY + 180;

		mycurr3DPos = this.transform.position;

		Vector2 mycurr2DPos = new Vector2 (mycurr3DPos.x, mycurr3DPos.y);
	}

	//Collisiion detection
	void OnCollisionEnter2D (Collision2D col)
	{

		if(col.gameObject.tag == "player") 
		{
			Destroy = true;
			//Destroy(Player);
			//			Debug.Log ("Destroyed");
		}

		if (col.gameObject.tag == "bullet") {
			//	Destroy (Enemy);
			Destroy = true;
			//Explode ();
		} else {
			Destroy = false;
		}
	}

	// Update is called once per frame
	void Update () {

		//get a vector distance
		//float dist = Mathf.Abs(Enemy.transform.position.x - Player.transform.position.x);

		Vector3 heading = Enemy.transform.position - Player.transform.position;

		float distance = heading.magnitude;


	/*	if (Destroy = true) {
			countdown -= Time.deltaTime;
			if (countdown <= 0f) {
				Explode ();
			}
		} else if(Destroy = false){
			countdown = 3f;
		}

*/

		if (Destroy == true) {
			Explode (distance);
			Destroy = false;
		}




		//Debug.Log (mycurr3DPos);

		transform.position = new Vector2 (mycurr3DPos.x, mycurr3DPos.y);
		//		transform.Rotate = (RotateX);

		mycurr3DPos.x = mycurr3DPos.x + (Direction * Speed);


		if (mycurr3DPos.x > PointTwo) {
			Direction = -1;
			transform.Rotate (0, RotateY + 180, 0);
			//warning! Use at own risk			mySpriteRenderer.flipX = true;
		} 

		if (PointOne > mycurr3DPos.x) {
			Direction = 1;
			//warning!	Use at own risk		mySpriteRenderer.flipX = false;
			transform.Rotate (0, RotateY + 180, 0);
		}
	}

	void Explode (float distance){
		//explosion effect
		Instantiate (explosionEffect, transform.position, transform.rotation);
		//explosionEffect.transform.parent = gameObject.transform;

		//get nearby objects 


		if (distance < radius) {
		//	Debug.Log ("Hit");
			Application.LoadLevel("GameOver");
		}



				//.OverlapCircle(this.transform.Position, radius, Contactfilter2D ContactFilter, Collider2D[]result);

		//damage

		//destroy grendade
		Destroy(gameObject);
	}


}

