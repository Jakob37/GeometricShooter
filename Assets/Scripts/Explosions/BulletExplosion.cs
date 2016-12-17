using UnityEngine;
using System.Collections;

public class BulletExplosion : MonoBehaviour {

    private ParticleSystem particle_system;

	void Start () {
        particle_system = gameObject.GetComponent<ParticleSystem>();
        particle_system.Play();
	}
	
	void Update () {
	    if (!particle_system.IsAlive()) {
            Destroy(gameObject);
        }
	}
}
