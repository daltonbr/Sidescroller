using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb;
	public GameObject enemyDeathParticle;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Enemy") {
			Destroy(this.gameObject);
			Instantiate (enemyDeathParticle, other.transform.position, other.transform.rotation);
			Destroy(other.gameObject);
		}
		if (other.tag == "Ground") {
			Destroy(this.gameObject);
		}
	}
}
			  