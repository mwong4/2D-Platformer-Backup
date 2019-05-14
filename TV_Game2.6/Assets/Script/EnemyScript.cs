using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

//	public float CurrentX, CurrentY;

//	private SpriteRenderer mySpriteRenderer;

	public GameObject Player;
	public GameObject Enemy;

	public float PointOne, PointTwo, Speed;
	public float Direction;
	public float RotateX, RotateY;

	public Vector2 mycurr3DPos;

	// Use this for initialization
	void Start () {
		
		Direction = -1;

//		RotateY = RotateY + 180;

	
	}
	
	// Update is called once per frame
	void Update () {

		mycurr3DPos = this.transform.position;
		Vector2 mycurr2DPos = new Vector2 (mycurr3DPos.x, mycurr3DPos.y);
	


		if (mycurr2DPos.x > PointTwo) {
			Direction = -1;
			transform.Rotate (0, RotateY + 180, 0);
//warning! Use at own risk			mySpriteRenderer.flipX = true;
		} 

		else if (mycurr2DPos.x < PointOne) {
			Direction = 1;
//warning!	Use at own risk		mySpriteRenderer.flipX = false;
			transform.Rotate (0, RotateY + 180, 0);
		}


	
		mycurr3DPos.x = mycurr3DPos.x + (Direction * Speed *Time.deltaTime);
		transform.position = new Vector2 (mycurr3DPos.x, mycurr3DPos.y);
		//		transform.Rotate = (RotateX);

	}

	void OnCollisionEnter2D (Collision2D col)
	{
		
		if(col.gameObject.tag == "player") 
		{
			Destroy(Enemy);
			//Destroy(Player);
//			Debug.Log ("Destroyed");
		}

		if(col.gameObject.tag == "bullet") 
		{
			Destroy(Enemy);
//			Debug.Log ("Destroyed");
		}
	}
}

