using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Behaviour.Movement {
    public abstract class Movement : MonoBehaviour {

        protected Vector2 speed;

        public virtual void Update() {
            var new_pos = transform.position + new Vector3(speed.x, speed.y, 0);
            transform.position = new_pos;
        }
    }
}
