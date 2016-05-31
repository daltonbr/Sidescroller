 using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public PlayerController player;
	public bool isFollowing;
	public float xOffset;
	public float yOffset;

	void Start () {
		player = FindObjectOfType<PlayerController>();
		isFollowing = true;
	}

	void FixedUpdate () {
		if (isFollowing) {
			// we use the players x and y coordinates and the z coordinate of the camera
			Vector3 newCamPosition = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, this.transform.position.z);
			this.transform.position =  (newCamPosition);	
		}
	}
}
