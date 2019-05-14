using UnityEngine;
using System.Collections;

public class CharacterAnimScript : MonoBehaviour 
{
	public float maxSpeed = 10f;
	public bool facingRight = true;

    Animator anim;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpforce = 2000f;
    bool doubleJump = false;

	public bool CheatOn = false;
	//Directional bullet
//	public bool MovingRight = true;
	public Bullet BulletMovingRight;

		//If not going right, bullet is going left

    void Start () {
        anim = GetComponent<Animator>();
	}

	void FixedUpdate () 
	{	
		//Key detection
//		if(Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)){
			
			//Debug.Log ("Right");

//			GameObject myObject = GameObject.Find ("Bullet");
//			BulletMovingRight = myObject.GetComponent<Bullet> ();

//			BulletMovingRight.MovingRight = true;





//		}
	//	if(Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)){
			
			//Debug.Log ("Left");

	//		GameObject myObject = GameObject.Find ("Bullet");
//			BulletMovingRight = myObject.GetComponent<Bullet> ();

	//		BulletMovingRight.MovingRight = false;



	//	}
			
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);

        if (grounded)
            doubleJump = false;

    
        var myRigidBody = this.GetComponent<Rigidbody2D>();
        anim.SetFloat("vSpeed", myRigidBody.velocity.y);

        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));		

        //		rigidbody2D = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D>());
        //		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
        myRigidBody.velocity = new Vector2 (move * maxSpeed, myRigidBody.velocity.y );

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
	}

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.L) && !CheatOn) {
			CheatOn = true;
		} else if (Input.GetKeyDown(KeyCode.L)) {
			CheatOn = false;
		}

		if((grounded || (!doubleJump && CheatOn == true)) && Input.GetKeyDown(KeyCode.W) || (grounded || (!doubleJump && CheatOn == true)) && Input.GetKeyDown(KeyCode.UpArrow))
        {
			Debug.Log ("Jump");
            anim.SetBool("Ground", false);
            var myRigidBody = this.GetComponent<Rigidbody2D>();
            myRigidBody.AddForce(new Vector2(0, jumpforce));

            if (!doubleJump & !grounded)
                doubleJump = true;
        }
    }

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
