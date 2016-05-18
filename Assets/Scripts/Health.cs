using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	private int health;
	public int healthStartValue;
	private LevelManager levelManager;

	void Start() {
		levelManager = FindObjectOfType<LevelManager>();
		ResetHealth();
	}

	void ApplyDamage(int damage) {
		health -= damage;
		if (health <= 0 ) { Die(); }
	}

	void Die() {
		if (this.gameObject.tag == ("Player")) {
			levelManager.RespawnPlayer();
		}
		else {
			Destroy(this);
		}
	}

	public void ResetHealth() {
		health = healthStartValue;
	}
}
