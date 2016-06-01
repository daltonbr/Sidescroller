using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Collider2D))]
public class AttackPlayer : MonoBehaviour {

	public int damage = 10;
	private HealthManager healthManager;

	void Start() {
		healthManager = FindObjectOfType<HealthManager>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			other.gameObject.SendMessage("ApplyDamage", damage);
			//healthManager.UpdateGUI();
			healthManager.ChangeHealth(- damage);
			Debug.Log(this.name + " applies " + damage + " damage to Player");
		}
	}
}