using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public GameObject explosion;

    private Health health;

	void Start () {
        health = gameObject.GetComponent<Health>();
	}
	
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider) {
        GameObject other_obj = collider.gameObject;

        if (other_obj.GetComponent<Bullet>()) {

            LifetimeLogic bullet_lifetime = other_obj.GetComponent<LifetimeLogic>();
            Bullet bullet = other_obj.GetComponent<Bullet>();
            health.InflictDamage(bullet.damage);
            bullet_lifetime.Destroy();
        }
    }
}
