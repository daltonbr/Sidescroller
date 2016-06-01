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
	private bool facingRight = true;

	// Fire
	public Transform firePoint;
	public Rigidbody2D projectile;
	public float minLaunchForce = 15f;
	public float maxLaunchForce = 30f;
	public float maxChargeTime = 0.75f;  // 3/4 of seconds

	private string fireButton;
	public float shellLifetime = 5f;
	private float currentLaunchForce;
	private float chargeSpeed;
	private bool fired;

	private void OnEnable()	{
		currentLaunchForce = minLaunchForce;
	}

	void Start() {
		rigidbody = this.GetComponent<Rigidbody2D>();
		velocity = rigidbody.velocity;
		anim = GetComponent<Animator>();

		//fire
		fireButton = "Fire1";
		chargeSpeed = (maxLaunchForce - minLaunchForce) / maxChargeTime;
	}

	void Update() {
		if (Input.GetButtonUp(fireButton) && !fired) {
			Fire ();
		} else if (currentLaunchForce >= maxLaunchForce && !fired) {
			// at max charge, but not fired
			currentLaunchForce = maxLaunchForce;
			// this line defines if the player autoshoot when maxCharged
			//Fire ();
		}
		else if (Input.GetButtonDown(fireButton)) {
			//have pressed fire for the first time?
			fired = false;
			currentLaunchForce = minLaunchForce;
			//shootingAudioClip.clip =  chargingClip;
		}
		else if (Input.GetButton(fireButton) && !fired) {
			//Holding the fire button, not fired yet
			currentLaunchForce += chargeSpeed * Time.deltaTime;
		}
//		else if (Input.GetButtonUp(fireButton) && !fired) {
//			//we release the button, having not fired yet
//			Fire ();
//		}
	}

	private void Fire () {
		fired = true;
		Rigidbody2D shellInstance = Instantiate(projectile, firePoint.position, firePoint.rotation) as Rigidbody2D;
		if (facingRight) {
			shellInstance.velocity = currentLaunchForce * firePoint.right;
		} else {
			shellInstance.velocity = currentLaunchForce * -1 * firePoint.right;
		}
		Destroy(shellInstance.gameObject, shellLifetime);
		// shootingAudio.clip = fireClip;
		// shoottingAudio.Play();
		currentLaunchForce = minLaunchForce;
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
			facingRight = true;
		} else if (rigidbody.velocity.x < 0) {
			this.transform.localScale = new Vector3 (-1f,1f,1f);
			facingRight = false;
		}
	}

	void Move(float inputX) {
		rigidbody.velocity = new Vector2(inputX * moveSpeed, velocity.y);
	}

	void Jump() {
		//Vector2 input = new Vector2(velocity.x, jumpHeight);
		rigidbody.AddForce(Vector2.up * jumpHeight);
	}
		
}
