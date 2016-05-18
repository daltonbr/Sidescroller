using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpHeight;
	//public int energy;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	private bool doubleJump;
	private Vector2 velocity;
	private Rigidbody2D rigidbody;

	private Animator anim;
	private bool facingRight;

	void Start() {
		rigidbody = this.GetComponent<Rigidbody2D>();
		velocity = rigidbody.velocity;
		anim = GetComponent<Animator>();
	}

	void FixedUpdate() {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround); 
		anim.SetBool("Grounded", grounded);
		velocity = rigidbody.velocity;

		if (grounded) { doubleJump = false; }
		if (Input.GetButtonDown("Jump")){
			if (grounded) {
				Jump();
			}
			else if (!doubleJump) {
				Jump();
				doubleJump = true;
			}
		}
		rigidbody.velocity = new Vector2 (Input.GetAxisRaw("Horizontal") * moveSpeed, velocity.y);
		anim.SetFloat("Speed", Mathf.Abs(rigidbody.velocity.x));

		if (rigidbody.velocity.x > 0) {
			this.transform.localScale = new Vector3 (1f,1f,1f);
		} else if (rigidbody.velocity.x < 0) {
			this.transform.localScale = new Vector3 (-1f,1f,1f);
		}
	}

	void Move(float inputX) {
		rigidbody.velocity = new Vector2(inputX * moveSpeed, velocity.y);
	}

	void Jump() {
		Vector2 input = new Vector2(velocity.x, jumpHeight);
		rigidbody.AddForce(Vector2.up * jumpHeight);
	}
		
}
