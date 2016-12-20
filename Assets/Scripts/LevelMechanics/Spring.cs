using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour {

	public AudioSource springSound;
	public float springPower = 1000f;
	private Animator springAnimator;

	void Awake()
	{
		springAnimator = this.GetComponent<Animator>();
		if (!springAnimator) Debug.LogError("An Animator was not founded on " + this.gameObject.name);
		springSound = this.GetComponent<AudioSource>();
		if (!springSound) Debug.LogError("An AudioSource was not founded on " + this.gameObject.name);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player")
			springAnimator.SetTrigger("released");
			//Debug.Log(coll.gameObject.name + " has collided with " + this.gameObject.name);
			coll.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * springPower);
			springSound.Play();
	}
}
