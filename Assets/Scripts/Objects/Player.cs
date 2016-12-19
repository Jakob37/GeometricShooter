using UnityEngine;
using System.Collections;
using Assets.Scripts.Behaviour.Movement;
using Assets.Scripts;

public class Player : MonoBehaviour {

    public float speed = 0.1f;

    public Vector3 Position { get { return gameObject.transform.position; } }

    private BeamWeapon beam_weapon;

    private Movement movement;
    private LifetimeLogic lifetime_logic;
    private Health health;

    void Start() {
        lifetime_logic = gameObject.GetComponent<LifetimeLogic>();
        beam_weapon = gameObject.GetComponentInChildren<BeamWeapon>();
        health = gameObject.GetComponent<Health>();
    }

    public void Update() {

        if (Input.GetKeyDown(KeyCode.Space)) {
            beam_weapon.ShootBullet();
        }
	}

    void OnTriggerEnter2D(Collider2D collider) {

        GameObject other_obj = collider.gameObject;
        Bullet bullet = other_obj.GetComponent<Bullet>();

        if (bullet && !bullet.is_friendly) {
            LifetimeLogic bullet_lifetime = other_obj.GetComponent<LifetimeLogic>();

            health.InflictDamage(bullet.damage);
            bullet_lifetime.Destroy();
        }
        else if (other_obj.GetComponent<Enemy>()) {
            lifetime_logic.Destroy();
        }
    }
}
