using Assets.Scripts.Behaviour.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts {

    public class ScriptGameObject : MonoBehaviour {

        public float max_speed = 1f;

        private Vector3 speed;

        protected void Initialize() {

        }

        public void Update() {
            // speed = movement.UpdateSpeed();

            // var new_pos = transform.position + new Vector3(speed.x, speed.y, 0);

            // print("called");

            // transform.position = new_pos;

        }
    }
}
