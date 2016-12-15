using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Levels {
    class Spawn {

        // public bool IsReady { get { return !is_used; } }
        public bool IsReady { get { return Time.time > spawn_time && !is_used; } }

        public GameObject GetSpawn() {
            if (IsReady) {
                is_used = true;
                return enemy_object;
            }
            else {
                throw new Exception("Not ready to be retrieved");
            }
        }

        private float spawn_time;
        private GameObject enemy_object;
        private bool is_used;

        private Vector3 spawn_position;

        public Spawn(GameObject enemy_object, float time) {
        
            this.enemy_object = enemy_object.gameObject;
            spawn_time = Time.time + time;

            Console.WriteLine("Spawn time: " + spawn_time);

            var range_width = 5;
            var random_x = UnityEngine.Random.Range(-range_width / 2, range_width / 2);

            spawn_position = new Vector3(random_x, 0, 0);

            this.enemy_object.transform.position = spawn_position;

            is_used = false;
        }

        public Spawn() {
        }
    }
}
