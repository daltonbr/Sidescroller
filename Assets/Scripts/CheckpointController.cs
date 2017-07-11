using UnityEngine;
using System.Collections;

public class CheckpointController : MonoBehaviour {

	public GameObject initialCheckpoint;
	public GameObject finalCheckpoint;
	public GameObject[] checkpoints;
	private GameObject currentCheckpoint;

	void Start() {
		if (checkpoints.Length < 2) {
			Debug.LogWarning("Set a minimum of 2 Checkpoints in the scene!", transform);
		}
			
		initialCheckpoint = checkpoints[0];
		currentCheckpoint = initialCheckpoint;
		currentCheckpoint.GetComponent<Checkpoint>().EnableCheckpoint();
		finalCheckpoint = checkpoints[checkpoints.Length-1];
	}

	public void SetCurrentCheckpoint(GameObject gameObject) {
		// disable previous current checkpoint
		currentCheckpoint.GetComponent<Checkpoint>().DisableCheckpoint();

		// set a new current checkpoint
		currentCheckpoint = gameObject;	
		currentCheckpoint.GetComponent<Checkpoint>().EnableCheckpoint();
	}

	public GameObject GetCurrentCheckpoint() {
		return this.currentCheckpoint;
	}
}
