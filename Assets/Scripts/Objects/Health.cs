using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float max_health = 10f;

    private float current_health;

	void Start () {
        current_health = max_health;
	}
	
	void Update () {
	    if (current_health < 0) {
            Destroy(gameObject);
        }
	}

    public void InflictDamage(float damage) {
        current_health -= damage;
    }
}
