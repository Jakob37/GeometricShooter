using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public GameObject explosion;
    public float shoot_delay;

    private Health health;
    private float time_to_shot;
    private BeamWeapon beam_weapon;
    private AIModule ai_module;
    private SpriteRenderer sprite_renderer;

	void Start () {
        health = gameObject.GetComponent<Health>();
        time_to_shot = Random.Range(0, shoot_delay);
        beam_weapon = GetComponentInChildren<BeamWeapon>();
        ai_module = gameObject.GetComponent<AIModule>();
        sprite_renderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	void Update () {

        time_to_shot -= Time.deltaTime;

        if (time_to_shot <= 0 && ai_module.CurrentAIState == AIState.fire) {
            beam_weapon.ShootBullet();
            time_to_shot = shoot_delay;
        }

        sprite_renderer.color = ShotChargeColor(shoot_delay - time_to_shot, shoot_delay);
	}

    private Color ShotChargeColor(float current_charge, float fire_charge) {
        var charge_frac = time_to_shot / shoot_delay;
        return new Color(1, charge_frac, charge_frac);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        GameObject other_obj = collider.gameObject;

        Bullet bullet = other_obj.GetComponent<Bullet>();

        if (bullet && bullet.is_friendly) {
            LifetimeLogic bullet_lifetime = other_obj.GetComponent<LifetimeLogic>();
            health.InflictDamage(bullet.damage);
            bullet_lifetime.Destroy();
        }
    }
}
