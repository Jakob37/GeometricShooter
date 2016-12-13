using UnityEngine;
using System.Collections;
using Assets.Scripts.Behaviour.Movement;
using Assets.Scripts;

public class Bullet : ScriptGameObject {

	void Start () {
        //movement = new StraightLine(this);
	}

    void Update() {

        print("Bullet base");

        base.Update();
    }
}
