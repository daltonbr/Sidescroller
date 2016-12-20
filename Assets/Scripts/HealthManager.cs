using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	private int health;
	public Text healthText;

	void Start () {
		//healthText = GetComponent<Text>();
		if (healthText == null) Debug.LogError("scoreText not founded! Please refer a text object to ScoreManager Script!");
		health = 100;
	}

	void FixedUpdate () {
		if (health < 0) {health = 0;}
		UpdateHealth();
	}

	public void ChangeHealth(int pointsToChange) {
		health += pointsToChange;
		UpdateHealth();
	}

	public void SetHealth(int valueToSet) {
		health = valueToSet;
	}

	public void UpdateHealth() {
		healthText.text = "" + health;
	}

//	public void UpdateGUI() {
//	}
}
