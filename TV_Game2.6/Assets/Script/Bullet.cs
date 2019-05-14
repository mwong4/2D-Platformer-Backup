using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public Vector2 mycurr3DPos;

	public float speed, life;

	public bool MovingRight;

	// Use this for initialization
	void Start () {

		Vector2 mycurr2DPos = new Vector2 (mycurr3DPos.x, mycurr3DPos.y);

		mycurr3DPos = this.transform.position;

		life = 50;

		MovingRight = true;

		GameObject myPlayer = GameObject.FindGameObjectWithTag ("player");

		MovingRight = myPlayer.GetComponent<CharacterAnimScript>().facingRight;

	}

	// Update is called once per frame
	void Update () {




		life -= 1;
		if (life <= 0) {
			Destroy (this.gameObject);
		}



		transform.position = new Vector2 (mycurr3DPos.x, mycurr3DPos.y);

		if (MovingRight == true) {

			Debug.Log ("MovingRight");

			mycurr3DPos.x = mycurr3DPos.x += speed;

		}

		if (MovingRight == false) {

			Debug.Log ("MovingLeft");

			mycurr3DPos.x = mycurr3DPos.x -= speed;

		}

	}

	void OnCollisionEnter2D (Collision2D col)
	{

		if(col.gameObject.tag == "enemy") {
			Destroy(this.gameObject);
			//			Debug.Log ("Destroyed");
		}

	}
}
