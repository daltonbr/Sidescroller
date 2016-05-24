using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	public int points;
	private ScoreManager scoreManager;

	void Start () {
		scoreManager = FindObjectOfType<ScoreManager>();
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			Debug.Log("Player pickup something");
			scoreManager.AddPoints(points);
			Debug.Log(this.name + " earns " + points + " points");
			Destroy(this.gameObject);  // maybe pooling Coins?
		}
	}
}
