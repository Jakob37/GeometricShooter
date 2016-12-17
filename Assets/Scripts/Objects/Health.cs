using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float max_health = 10f;

    private float current_health;
    private LifetimeLogic lifetime_logic;

	void Start () {
        current_health = max_health;
        lifetime_logic = gameObject.GetComponent<LifetimeLogic>();
	}
	
	void Update () {
	    if (current_health < 0) {
            lifetime_logic.Destroy();
        }
	}

    public void InflictDamage(float damage) {
        current_health -= damage;
    }
}
