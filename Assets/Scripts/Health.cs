using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	private int health;
	public int healthStartValue;
	private LevelManager levelManager;
	public GameObject dieParticle;
    public GameObject loots;

	void Start() {
		levelManager = FindObjectOfType<LevelManager>();
        if (!levelManager) Debug.LogError("levelManager was not found by health script in " + this.gameObject.name);
		ResetHealth();
	}

	public void ApplyDamage(int damage) {
        if (damage <= 0)  // maybe throw an error
        {
            Debug.Log("damage must be a positive value");
            return;
        }
		health -= damage;
		if (health <= 0 )
        {
            health = 0;
            //Debug.Log("damage was applied to " + this.gameObject.name + " health: " + health.ToString());
            Die();
        }
	}

	void Die() {
		Instantiate(dieParticle, this.transform.position, this.transform.rotation);
		if (this.gameObject.tag == ("Player")) {
			levelManager.RespawnPlayer();
		}
		else {
			if (loots)
            {
                Instantiate(loots, this.transform.position, this.transform.rotation);
            }
            Destroy(this.gameObject);
        }
	}

	public void ResetHealth() {
		health = healthStartValue;
	}
}
