using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Collider2D))]
public class AttackPlayer : MonoBehaviour {

	public int damage = 10;
	private Health health;

	//void Start() {
 //       health = FindObjectOfType<HealthManager>();
	//}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player")
        {
            other.gameObject.SendMessage("ApplyDamage", damage);
            Debug.Log(this.name + " applies " + damage + " damage to Player");
		}
	}
}