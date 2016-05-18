using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public PlayerController player;

	void Start () {
		player = FindObjectOfType<PlayerController>();
	}

	void FixedUpdate () {
		// we use the players x and y coordinates and the z coordinate of the camera
		Vector3 newCamPosition = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
		this.transform.position =  (newCamPosition);
	}
}
