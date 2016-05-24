using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	private int score;
	public Text scoreText;

	void Start () {
		//scoreText = GetComponent<Text>();
		if (scoreText == null) Debug.LogError("scoreText not founded! Please refer a text object to ScoreManager Script!");
		score = 0;
	}

	void Update () {
		if (score < 0) {score = 0;}

		scoreText.text = "" + score;
	}

	public void AddPoints(int pointsToAdd) {
		score += pointsToAdd;
		UpdateScore();
	}

	public void UpdateScore() {
		scoreText.text = "" + score;
	}

	public void ResetPoints() {
		score = 0;
	}
}
