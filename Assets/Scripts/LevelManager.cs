using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject player;
	public CheckpointController checkpointController;
	public PlayerController playerController;
	private Health health;
	public GameObject respawnParticle;

	public float respawnDelay;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		health = player.GetComponent<Health>(); 
		playerController = player.GetComponent<PlayerController>();
		checkpointController = FindObjectOfType<CheckpointController>();
	}

	public void RespawnPlayer() {
		playerController.GetComponent<SpriteRenderer>().enabled = false;
		playerController.enabled = false;

		StartCoroutine("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo() {
		player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		yield return new WaitForSeconds(respawnDelay);
		Debug.Log("Player Respawn");
		health.ResetHealth();
		playerController.transform.position = checkpointController.GetCurrentCheckpoint().transform.position;
		Instantiate(respawnParticle, playerController.transform.position, playerController.transform.rotation); 
		playerController.GetComponent<SpriteRenderer>().enabled = true;
		playerController.enabled = true;
	}
}
