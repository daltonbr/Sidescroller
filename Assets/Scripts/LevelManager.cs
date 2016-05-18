using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public CheckpointController checkpointController;
	private PlayerController player;
	private Health health;

	void Start () {
		player = FindObjectOfType<PlayerController>();
		checkpointController = FindObjectOfType<CheckpointController>();
		health = FindObjectOfType<Health>();
	}

	public void RespawnPlayer() {
		Debug.Log("Player Respawn");
		health.ResetHealth();
		player.transform.position = checkpointController.GetCurrentCheckpoint().transform.position;
	}
}
