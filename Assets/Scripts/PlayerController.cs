using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class PlayerController : MonoBehaviour {

	public int playerNumber = 1;
	public float baseSpeed;
	public float jumpForce;
	public float sprintFactor = 0.3f;
	private float moveSpeed;	// speed * sprintFactor (if used)
	
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	private bool doubleJump;
	private bool sprint;
	private Vector2 velocity;
	private Rigidbody2D rb;

	private Animator anim;
	private bool facingRight = true;

	// Fire
	public Transform firePoint;
	public Rigidbody2D projectile;
	public float minLaunchForce = 15f;
	public float maxLaunchForce = 30f;
	public float maxChargeTime = 0.75f;  // 3/4 of seconds
    public float firePitchDelta = 0.2f;  // oscilation in pitch when firing
    public AudioSource chargingClip;
    public AudioSource fireClip;

    private string fireButton;
	private string sprintButton;
	private string horizontalAxis;
	private string verticalAxis;
	private string jumpButton;
	public float shellLifetime = 5f;
	private float currentLaunchForce;
	private float chargeSpeed;
	private bool fired;

	private void OnEnable()	{
		currentLaunchForce = minLaunchForce;
	}

	void Start() {
		rb = this.GetComponent<Rigidbody2D>();
		velocity = rb.velocity;
		anim = GetComponent<Animator>();

		// mapping buttons
		fireButton      = "Fire" + playerNumber;
		sprintButton    = "Sprint" + playerNumber;
		horizontalAxis  = "Horizontal" + playerNumber;
		verticalAxis    = "Vertical" + playerNumber;
		jumpButton      = "Jump" + playerNumber;

		//fire
		chargeSpeed     = (maxLaunchForce - minLaunchForce) / maxChargeTime;
	}

	void Update() {

		// sprint
		if (Input.GetButton(sprintButton)) {
			sprint = true;
		} else {
			sprint = false;
		}
			
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
			//shootingAudioClip.clip = chargingClip;
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
        fireClip.pitch = Random.Range(1-firePitchDelta, 1+firePitchDelta);
        fireClip.Play();
      
		currentLaunchForce = minLaunchForce;
	}

	void FixedUpdate() {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround); 
		anim.SetBool("Grounded", grounded);
		velocity = rb.velocity;

		if (grounded) { doubleJump = false; }
		if (Input.GetButtonDown(jumpButton)){
			if (grounded) {
				Jump();
			}
			else if (!doubleJump) {
				Jump();
				doubleJump = true;
			}
		}

		if (sprint)
			moveSpeed = baseSpeed * (1+sprintFactor) ;	// account for sprintFactor;
		else
			moveSpeed = baseSpeed;
		
		rb.velocity = new Vector2 (Input.GetAxisRaw(horizontalAxis) * baseSpeed, velocity.y);
		anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

		if (rb.velocity.x > 0) {
			this.transform.localScale = new Vector3 (1f,1f,1f);
			facingRight = true;
		} else if (rb.velocity.x < 0) {
			this.transform.localScale = new Vector3 (-1f,1f,1f);
			facingRight = false;
		}
	}

	void Move(float inputX) {
		rb.velocity = new Vector2(inputX * moveSpeed, velocity.y);
	}

	void Jump() {
		//Vector2 input = new Vector2(velocity.x, jumpHeight);
		rb.AddForce(Vector2.up * jumpForce);
	}
		
}
