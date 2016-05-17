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

	void FixedUpdate() {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround); 

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
		//float inputX = (Input.GetAxisRaw("Horizontal"));
		//Move(inputX);
	}

	void Awake() {
		rigidbody = this.GetComponent<Rigidbody2D>();
		velocity = rigidbody.velocity;
	}

	void Update () {
		
	}

	void Move(float inputX) {
		rigidbody.velocity = new Vector2(inputX * moveSpeed, velocity.y);
		Debug.Log(rigidbody.velocity);
	}

	void Jump() {
		Vector2 input = new Vector2(velocity.x, jumpHeight);
		//rigidbody.velocity = new Vector2(velocity.x, jumpHeight);
		//rigidbody.velocity += new Vector2(0,jumpHeight);
		rigidbody.AddForce(Vector2.up * jumpHeight);
		Debug.Log(rigidbody.velocity);
	}
}
