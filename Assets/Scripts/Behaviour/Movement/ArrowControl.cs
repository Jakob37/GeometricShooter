using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Behaviour.Movement {
    class ArrowControl : Movement {

        public float max_speed = 0.1f;

        private float minX;
        private float maxX;
        private float minY;
        private float maxY;

        private float mapX = 27f;
        private float mapY = 20f;

        void Start() {
            Camera camera = Camera.main;

            float vertExtent = camera.orthographicSize;
            float horzExtent = (float)(vertExtent * Screen.width / Screen.height);

            // Calculations assume map is position at the origin
            minX = horzExtent - mapX / 2f;
            maxX = mapX / 2f - horzExtent;
            minY = vertExtent - mapY / 2f;
            maxY = mapY / 2f - vertExtent;
        }

        public override void Update() {
            UpdateMovement();

            base.Update();
        }

        private void UpdateMovement() {

            var x_speed = 0f;
            var y_speed = 0f;

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
                x_speed = -max_speed;
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
                x_speed = max_speed;
            }

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
                y_speed = max_speed;
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
                y_speed = -max_speed;
            }

            var delta_pos = new Vector3(x_speed, y_speed, 0);
            var new_pos = transform.position + delta_pos;

            new_pos.x = Mathf.Clamp(new_pos.x, minX, maxX);
            new_pos.y = Mathf.Clamp(new_pos.y, minY, maxY);


            transform.position = new_pos;
        }
    }
}
