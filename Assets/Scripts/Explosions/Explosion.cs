using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    private ParticleSystem particle_system;
    private AudioSource audio_source;

	void Start () {
        particle_system = gameObject.GetComponent<ParticleSystem>();
        audio_source = gameObject.GetComponent<AudioSource>();

        particle_system.Play();
	}
	
	void Update () {
	    if (!particle_system.IsAlive() && !audio_source.isPlaying) {
            Destroy(gameObject);
        }
	}
}
