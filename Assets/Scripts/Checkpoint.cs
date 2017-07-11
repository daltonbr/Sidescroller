using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class Checkpoint : MonoBehaviour {

	Animator animator;
	public LevelManager levelManager;
	public CheckpointController checkpointController;
	private bool active;

	void Awake () {
		animator = this.GetComponent<Animator>();
		levelManager = FindObjectOfType<LevelManager>();
		checkpointController = FindObjectOfType<CheckpointController>();
        Assert.IsNotNull(animator, "Checkpoint: Animator not found!");
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == ("Player") && !active) {
			checkpointController.SetCurrentCheckpoint(this.gameObject);
		}
	}

	public void EnableCheckpoint() {
		this.active = true;
		animator.SetBool("Active", true);
		Debug.Log("Activated Checkpoint: " + transform.name);
	}
		
	public void DisableCheckpoint() {
		this.active = false;
		animator.SetBool("Active", false);
	}
}
