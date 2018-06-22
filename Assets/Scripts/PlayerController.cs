using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float jumpForce;
    private bool facingRight;
    float xSpeed;
    private Rigidbody2D myRigidbody;
    Animator anim;
    private int _maxJumps = 2;
    [SerializeField]
    private int mJumpCount = 0;
	// Use this for initialization
	void Start () {
        facingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        HandleMovement(horizontal);
        Flip(horizontal);
        if(Input.GetKey(KeyCode.LeftArrow)){
            xSpeed = -5;
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            xSpeed = 5;
        }
        else {
            xSpeed = 0;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetTrigger("Active");
        }
        else 
        {
            anim.SetTrigger("Deactive");
        }
	}

    private void HandleMovement(float horizontal)
    {
        myRigidbody.velocity = new Vector2(xSpeed* movementSpeed,myRigidbody.velocity.y); // x= -1, y=0;

        if (Input.GetKey(KeyCode.Space))
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            anim.SetTrigger("ActiveJump");
           // anim.SetTrigger("Deactive");
        }
        else
        {
            anim.SetTrigger("Deactive");
        }
    /*    if (Input.GetKey(KeyCode.Space) && mJumpCount < _maxJumps)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            mJumpCount++;
        }
        updateJump(); */
    } 
    private void Flip(float horizontal)
    {
        if(horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale; 
        }
    }

 /*   private void updateJump(){
        mJumpCount = 0;
        jumpForce = 0;
    }  */
}
