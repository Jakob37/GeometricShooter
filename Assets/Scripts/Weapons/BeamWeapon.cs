using UnityEngine;
using System.Collections;

public class BeamWeapon : MonoBehaviour {

    public Bullet bullet_prefab;

    private AudioSource audio_source;

	void Start () {
        audio_source = gameObject.GetComponent<AudioSource>();
	}
	
	void Update () {
	
	}

    public void ShootBullet() {
        Instantiate(bullet_prefab, transform.position, transform.rotation);
        audio_source.Play();
    }
}
