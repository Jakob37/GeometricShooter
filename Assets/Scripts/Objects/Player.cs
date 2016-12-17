using UnityEngine;
using System.Collections;
using Assets.Scripts.Behaviour.Movement;
using Assets.Scripts;

public class Player : MonoBehaviour {

    public float speed = 0.1f;

    public Bullet bulletPrefab;

    private Movement movement;
    private LifetimeLogic lifetime_logic;

    void Start() {
        lifetime_logic = gameObject.GetComponent<LifetimeLogic>();
    }

    public void Update() {

        if (Input.GetKeyDown(KeyCode.Space)) {
            ShootBullet();
        }
	}

    private void ShootBullet() {
        Bullet bullet = (Bullet)Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D collider) {

        GameObject other_obj = collider.gameObject;

        if (other_obj.GetComponent<Enemy>()) {
            lifetime_logic.Destroy();
        }
    }
}
