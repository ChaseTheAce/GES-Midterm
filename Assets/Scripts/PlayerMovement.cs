using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    float jumpStrength = 10f;
    [SerializeField]
    float movementSpeed = 1f;
    [SerializeField]
    float groundDetectRadius = 0.2f;
    [SerializeField]
    LayerMask whatCountsAsGround;

    [SerializeField]
    Transform GroundDetectPiont;

    [SerializeField]
    LayerMask whatCountsAsLadder;

    [SerializeField]
    Transform LadderDetectPoint;

    private bool isOnGround;
    private bool shouldJump = false;

    Rigidbody2D myRigidbody;

    float horizontalInput;
    bool isFacingRight;
    private Vector2 jumpForce;

    private AudioSource audioSource;

    Animator anim;



    // Use this for initialization
    void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        jumpForce = new Vector2(0, jumpStrength);
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetMovementInput();
        GetJumpInput();
        UpdateIsOnGround();
        

    }

    private void GetJumpInput()
    {
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            shouldJump = true;
        }
    }
    private void GetMovementInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Move();
        Jump();

        if (horizontalInput > 0 && isFacingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && !isFacingRight)
        {
            Flip();
        }
        anim.SetFloat("Speed", Mathf.Abs(horizontalInput));
        anim.SetBool("Jump", !isOnGround);

        Debug.Log(isOnGround);
    }

    private void UpdateIsOnGround()
    {
        Collider2D[] groundObjects = Physics2D.OverlapCircleAll(GroundDetectPiont.position, groundDetectRadius, whatCountsAsGround);
        isOnGround = groundObjects.Length > 0;
    }

    private void UpdateIsOnLadder()
    {
        Collider2D[] ladderObjects = Physics2D.OverlapCircleAll(LadderDetectPoint.position, groundDetectRadius, whatCountsAsLadder);
        isOnGround = ladderObjects.Length > 0;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    isOnGround = true;
    //}

    private void Jump()
    {
        if (shouldJump)
        {
            myRigidbody.AddForce(jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
            shouldJump = false;
            audioSource.Play();
            
        }


    }

    
        
    private void Move()
    { 
        myRigidbody.velocity = new Vector2(horizontalInput * movementSpeed, myRigidbody.velocity.y);

        
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
}
