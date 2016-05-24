using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public CheckpointController checkpointController;
	public PlayerController playerController;
	//public GameObject player;
	private Health health;
	public GameObject respawnParticle;

	public float respawnDelay;

	void Start () {
		health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>(); 
		playerController = FindObjectOfType<PlayerController>();
		checkpointController = FindObjectOfType<CheckpointController>();
	}

	public void RespawnPlayer() {
		playerController.GetComponent<SpriteRenderer>().enabled = false;
		playerController.enabled = false;
		StartCoroutine("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo() {
		
		yield return new WaitForSeconds(respawnDelay);
		Debug.Log("Player Respawn");
		health.ResetHealth();
		playerController.transform.position = checkpointController.GetCurrentCheckpoint().transform.position;
		Instantiate(respawnParticle, playerController.transform.position, playerController.transform.rotation); 
		playerController.GetComponent<SpriteRenderer>().enabled = true;
		playerController.enabled = true;
	}
}
