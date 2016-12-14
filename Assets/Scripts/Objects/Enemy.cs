using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private Health health;

	void Start () {
        health = gameObject.GetComponent<Health>();
	}
	
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider) {
        GameObject other_obj = collider.gameObject;

        if (other_obj.GetComponent<Bullet>()) {

            Bullet bullet = other_obj.GetComponent<Bullet>();
            health.InflictDamage(bullet.damage);
            Destroy(bullet.gameObject);
        }
    }
}
