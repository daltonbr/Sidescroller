using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

	public float moveSpeed;
	public bool moveRight;
	private Rigidbody2D enemyRigidbody;

	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	private bool hittingWall; 

	// TODO: implement EdgeCheck
//	private bool atEdge;
//	public Transform edgeCheck;

	void Start () {
		enemyRigidbody = this.gameObject.GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);
	
		//flip the movement 
		if (hittingWall) { moveRight = !moveRight; }

		if (moveRight) {
			enemyRigidbody.velocity = new Vector2(moveSpeed, enemyRigidbody.velocity.y);
			transform.localScale = new Vector3(-1f, 1f, 1f);
		} else {
			enemyRigidbody.velocity = new Vector2(-moveSpeed, enemyRigidbody.velocity.y);
			transform.localScale = new Vector3( 1f, 1f, 1f);
		}
	}
}
