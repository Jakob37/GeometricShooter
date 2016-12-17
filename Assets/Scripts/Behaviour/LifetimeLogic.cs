using UnityEngine;
using System.Collections;

public class LifetimeLogic : MonoBehaviour {

    public GameObject explosion;

	void Start () {
	
	}
	
	void Update () {
	
	}

    public void Destroy() {
        Explode();
    }

    private void Explode() {

        if (explosion) {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }
}
