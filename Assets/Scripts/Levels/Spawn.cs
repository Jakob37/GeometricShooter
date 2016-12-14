using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Levels {
    class Spawn : MonoBehaviour {

        private float spawn_time;
        private GameObject enemy_object;
        private bool is_used;

        public Spawn(GameObject enemy_object, float time) {

            this.enemy_object = enemy_object.gameObject;
            spawn_time = Time.time + time;

            is_used = false;

            print("Spawn at" + spawn_time);

        }

        public void MyUpdate() {

            if (spawn_time > Time.time && !is_used) {

                print(enemy_object);

                Instantiate(enemy_object);
                is_used = true;
            }
        }
    }
}
