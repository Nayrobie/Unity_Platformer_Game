using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance; // Static instances always go with Awake function below

    public float moveSpeed; // Public to be able to change the value in Unity
    public Rigidbody2D theRB; // Calls the component in Unity
    public float jumpForce;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    private bool canDoubleJump;

    private Animator anim;
    private SpriteRenderer theSR; 

    public float knockBackLenght, knockBackForce;
    private float knockBackCounter;

    private void Awake() 
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(knockBackCounter <=0) 
        {
            theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);
            
            // So you can only jump from the ground (not in the air)
            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);
            // Check if double jump is allowed
            if(isGrounded) {
                canDoubleJump = true;
            }

            if(Input.GetButtonDown("Jump"))
            {
                if(isGrounded) 
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                }
                else // Else do the double jump if space is clicked again
                { 
                    if(canDoubleJump)
                    {
                        theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                        canDoubleJump = false; 
                    }
                }
            }

            if(theRB.velocity.x < 0) // If moving to the left
            { 
                theSR.flipX = true;
            } else if(theRB.velocity.x > 0)
            {
                theSR.flipX = false;
            }
        } else 
        {
            knockBackCounter -= Time.deltaTime;
            // Add getting push back on damage impact
            // if (theSR.flipX == false) 
            if(!theSR.flipX) // When false: we are facing to the right
            {
                theRB.velocity = new Vector2(-knockBackForce, theRB.velocity.y); // If facing right, push player to the left
            } else 
            {
                theRB.velocity = new Vector2(knockBackForce, theRB.velocity.y); // If facing left, push player to the right
            }
        }

        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x)); // Run
        anim.SetBool("isGrounded", isGrounded); // Jump
    }

    public void knockBack()
    {
        knockBackCounter = knockBackLenght;
        theRB.velocity = new Vector2(0, knockBackForce); // Little jump on damage impact

        anim.SetTrigger("hurt"); // "hurt" is a trigger in Animator/Parameters
    }
}
