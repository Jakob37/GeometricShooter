using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Behaviour.Movement {
    class StraightLine : Movement {

        public float max_speed = 0.1f;

        public override void Update() {

            this.speed = max_speed;
            this.direction = new Vector2(0, 1);
            base.Update();
        }
    }
}
