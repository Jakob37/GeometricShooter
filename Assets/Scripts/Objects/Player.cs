using UnityEngine;
using System.Collections;
using Assets.Scripts.Behaviour.Movement;
using Assets.Scripts;

public class Player : MonoBehaviour {

    public float speed = 0.1f;

    private BeamWeapon beam_weapon;

    private Movement movement;
    private LifetimeLogic lifetime_logic;

    void Start() {
        lifetime_logic = gameObject.GetComponent<LifetimeLogic>();

        beam_weapon = gameObject.GetComponentInChildren<BeamWeapon>();
    }

    public void Update() {

        if (Input.GetKeyDown(KeyCode.Space)) {
            beam_weapon.ShootBullet();
        }
	}

    void OnTriggerEnter2D(Collider2D collider) {

        GameObject other_obj = collider.gameObject;

        if (other_obj.GetComponent<Enemy>()) {
            lifetime_logic.Destroy();
        }
    }
}
