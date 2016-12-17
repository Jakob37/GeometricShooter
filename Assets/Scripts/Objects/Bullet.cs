using UnityEngine;
using System.Collections;
using Assets.Scripts.Behaviour.Movement;
using Assets.Scripts;

public class Bullet : MonoBehaviour {

    public float damage = 1f;

    public GameObject explosion;

	void Start () {

	}

    void Update() {

    }

    public void Explode() {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
