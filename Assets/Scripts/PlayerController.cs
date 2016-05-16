using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpHeight;

	void Update () {
		Vector2 velocity = this.GetComponent<Rigidbody2D>().velocity;
		if (Input.GetButtonDown("Jump")){
			GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x, jumpHeight);
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight);
			Debug.Log("My jump velocity when I jump is: " + jumpHeight);
		}

		float inputX = (Input.GetAxisRaw("Horizontal"));
		GetComponent<Rigidbody2D>().velocity = new Vector2(inputX * moveSpeed, velocity.y);

	}
}
