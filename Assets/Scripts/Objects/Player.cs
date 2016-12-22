using UnityEngine;
using System.Collections;
using Assets.Scripts.Behaviour.Movement;
using Assets.Scripts;

public class Player : MonoBehaviour {

    public float speed = 0.1f;
    public float fire_charge_time = 0.2f;

    public Vector3 Position { get { return gameObject.transform.position; } }

    private BeamWeapon beam_weapon;

    private Movement movement;
    private LifetimeLogic lifetime_logic;
    private Health health;

    private float current_weapon_charge;

    void Start() {
        lifetime_logic = gameObject.GetComponent<LifetimeLogic>();
        beam_weapon = gameObject.GetComponentInChildren<BeamWeapon>();
        health = gameObject.GetComponent<Health>();

        current_weapon_charge = 0;
    }

    public void Update() {

        if (Input.GetKey(KeyCode.Space)) {
            current_weapon_charge += Time.deltaTime;
        }
        else {
            current_weapon_charge = 0;
        }

        if (current_weapon_charge > fire_charge_time) {
            beam_weapon.ShootBullet();
            current_weapon_charge = 0;
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
