using UnityEngine;
using System.Collections;

public class CheckpointController : MonoBehaviour {

	public GameObject initialCheckpoint;
	public GameObject finalCheckpoint;
	public GameObject[] checkpoints;
	private GameObject currentCheckpoint;

	void Start() {
		if (checkpoints.Length < 2) {
			Debug.LogError("Set a minimum of 2 Checkpoints in the scene!", transform);
		}
			
		initialCheckpoint = checkpoints[0];
		currentCheckpoint = initialCheckpoint;
		finalCheckpoint = checkpoints[checkpoints.Length-1];
	}

	void DisableAllCheckpointsAnim() {
		foreach(GameObject temp in checkpoints) {
			temp.SendMessage("DisableCheckpointAnim"); 
		}
	}

	public void SetCurrentCheckpoint(GameObject gameObject) {
		DisableAllCheckpointsAnim();
		currentCheckpoint = gameObject;
	}

	public GameObject GetCurrentCheckpoint() {
		return this.currentCheckpoint;
	}
}
