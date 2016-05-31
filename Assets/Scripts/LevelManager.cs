using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject player;
	public CheckpointController checkpointController;
	public PlayerController playerController;
	private Health health;
	public GameObject respawnParticle;
	//public float initialLevelGravity;
	public CameraController cameraController;

	public float respawnDelay;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		//initialLevelGravity = player.GetComponent<Rigidbody2D>().gravityScale;
		health = player.GetComponent<Health>(); 
		playerController = player.GetComponent<PlayerController>();
		checkpointController = FindObjectOfType<CheckpointController>();
		cameraController = FindObjectOfType<CameraController>();
	}

	public void RespawnPlayer() {
		//playerController.GetComponent<SpriteRenderer>().enabled = false;
		//playerController.enabled = false;
		player.SetActive(false);
		StartCoroutine("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo() {
		yield return new WaitForSeconds(respawnDelay);
		player.SetActive(true);
		cameraController.isFollowing = false;
		Debug.Log("Player Respawn");
		health.ResetHealth();
		//player.GetComponent<Rigidbody2D>().gravityScale = initialLevelGravity;
		playerController.transform.position = checkpointController.GetCurrentCheckpoint().transform.position;
		cameraController.isFollowing = true;
		Instantiate(respawnParticle, playerController.transform.position, playerController.transform.rotation); 
		playerController.GetComponent<SpriteRenderer>().enabled = true;
		playerController.enabled = true;
	}
}
