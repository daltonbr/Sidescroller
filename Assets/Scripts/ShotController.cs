using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour {

	public float shellSpeed;
    public int shellDamage = 30;   // take this value from player later
	private Rigidbody2D projectile;
	//public GameObject enemyDeathParticle;

	// Use this for initialization
	void Start () {
		projectile = this.GetComponent<Rigidbody2D>();
	}

	void OnTriggerEnter2D(Collider2D other) {
        // Send ApplyDamage to all, but dont require and let the recipient handle according
        other.gameObject.SendMessage("ApplyDamage", shellDamage, SendMessageOptions.DontRequireReceiver);
        if (other.tag == "Enemy") {

            //other.GetComponent<Health>().ApplyDamage(shellDamage);
            //Destroy(this.gameObject);
            //Instantiate (enemyDeathParticle, other.transform.position, other.transform.rotation);
            //Destroy(other.gameObject);
        }
		if (other.tag == "Ground") {
			Destroy(this.gameObject);
		}
	}
}
			  