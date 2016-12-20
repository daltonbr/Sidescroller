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

	// Fix some unexpect behaviors of Particle Effects
	void OnBecameInvisible() {
//		Debug.Log("Activating OnBecameInvisible on Particles");
		Destroy(this.gameObject);
	}
}
