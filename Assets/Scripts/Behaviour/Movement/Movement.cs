using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Behaviour.Movement {
    public abstract class Movement : MonoBehaviour {

        protected Vector2 direction;
        protected float speed;

        public virtual void Update() {

            var delta_pos = new Vector3(speed * direction.x, speed * direction.y, 0);
            var new_pos = transform.position + delta_pos;
            transform.position = new_pos;

            DestroyOutside();
        }

        private void DestroyOutside() {

            var out_distance = 10;

            if (transform.position.x < -out_distance ||
                transform.position.x > out_distance ||
                transform.position.y < -out_distance ||
                transform.position.y > out_distance) {

                DestroyObject(this.gameObject);
            }
        }
    }
}
