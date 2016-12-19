using UnityEngine;
using System.Collections;
using Assets.Scripts.Behaviour.Movement;
using Assets.Scripts;

public class Bullet : MonoBehaviour {

    public float damage = 1f;

    public bool is_friendly = false;
    public bool IsFriendly { get { return is_friendly; } }

	void Start () {

	}

    void Update() {

    }
}
