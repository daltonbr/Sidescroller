using UnityEngine;
using System.Collections;

public class DestroyFinishParticle : MonoBehaviour {

	private ParticleSystem thisParticleSystem;

	void Start () {
		thisParticleSystem = GetComponent<ParticleSystem>();
	}

	void Update () {
		if (thisParticleSystem.isPlaying) {
			return;
		} else {
			Destroy(this.gameObject);
		}
	}
}
