using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour {

    public float jumpForce = 300f;
    public Vector2 initialJumpDirection;
    public float timeBetweenJumps = 2f;   // in seconds
    public float timeBetweenJumpsDelta = 0.5f;

    private Vector2 jumpDirection;
    private Rigidbody2D rb;
    private Rigidbody2D playerRb;

    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask whatIsGround;
    private bool grounded;

    private Animator anim;
    //private bool facingRight = true;

    void Awake()
    {
        initialJumpDirection = jumpDirection = new Vector2(-1f, 3f);     // at first this must be a vector with negative X value (jumping to the left)
        rb = this.GetComponent<Rigidbody2D>();
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        if (!playerRb) Debug.LogError("Player not found!");
        anim = this.GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine("FrogLoop");
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        anim.SetBool("Grounded", grounded);
    }

    public void Jump()
    {
        rb.AddForce(jumpDirection.normalized * jumpForce);
    }

    IEnumerator FrogLoop()
    {
        while (true)    //the frog must stop jumping?
        {
            // if difference is positive, the frog is at the right side of the player
            // else (negative) it is at his left
            Vector2 difference = rb.position - playerRb.position;

            if (difference.x > 0)
            {
                // must jump to the left
                jumpDirection = initialJumpDirection;
                rb.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                // must jump to the right
                jumpDirection = new Vector2(initialJumpDirection.x * -1, initialJumpDirection.y);
                rb.GetComponent<SpriteRenderer>().flipX = true;
            }

            Jump();
            yield return new WaitForSeconds(Random.Range(timeBetweenJumps - timeBetweenJumpsDelta, timeBetweenJumps + timeBetweenJumpsDelta));
        }
    }


}
