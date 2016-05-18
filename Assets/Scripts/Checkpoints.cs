using UnityEngine;
using System.Collections;

public class Checkpoints : MonoBehaviour {

	Animator animator;
	public LevelManager levelManager;
	public CheckpointController checkpointController;

	void Start () {
		animator = GetComponent<Animator>();
		levelManager = FindObjectOfType<LevelManager>();
		checkpointController = FindObjectOfType<CheckpointController>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == ("Player")) {
			checkpointController.SetCurrentCheckpoint(this.gameObject);
			//SendMessageUpwards("DisableAllCheckpointsAnim");
			animator.SetBool("Active", true);
			Debug.Log("Activated Checkpoint: " + transform.name);
		}
	}

	void DisableCheckpointAnim() {
		animator.SetBool("Active", false);
	}
}
