using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public Transform leftPoint, rightPoint;

    private bool movingRight;
    
    private Rigidbody2D theRB;
    public SpriteRenderer theSR; // can't do private sprite renderer here as it's attach to the parent no the child for going left and right
    private Animator anim;

    public float moveTime, waitTime;
    private float moveCount, waitCount;

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // Child objects keep the same distance at all time from the parent, to make the points static we need to make them non-chil when the game starts
        leftPoint.parent = null;
        rightPoint.parent = null;

        movingRight = true; // because false by defautl

        moveCount = moveTime; 
    }

    // Update is called once per frame 
    void Update()
    {
        if(moveCount >0)
        {

            moveCount -= Time.deltaTime;

            if(movingRight)
            {
                theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);

                theSR.flipX = true;

                if(transform.position.x > rightPoint.position.x)
                {
                    movingRight = false;

                }
            } else 
            {
                theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);

                theSR.flipX = false;

                if(transform.position.x < leftPoint.position.x)
                {
                    movingRight = true;

                }
            }

            if(moveCount <= 0)
            {
                // waitCount = waitTime;
                // Let's make it a bit less obvious when the enemy stops
                waitCount = Random.Range(waitTime* .75f, waitTime* 1.25f); // small range for variety
            }

            anim.SetBool("isMoving", true);

        } else if(waitCount > 0)
        {
            waitCount -= Time.deltaTime;
            theRB.velocity = new Vector2(0f, theRB.velocity.y); // Stand still

            if(waitCount <= 0)
            {
                // moveCount = moveTime;
                moveCount = Random.Range(moveTime* .75f, moveTime* 1.25f);
            }

            anim.SetBool("isMoving", false); // Frog only jumps when moving

        }
    }
}
