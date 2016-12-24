using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Behaviour.ai {
    class AITarget {

        private float close_threshold;
        private float y_shoot_offset;
        private float point_reach_dist;
        private float point_leave_dist;

        private GameObject ai_obj;
        private GameObject target_obj;

        public AITarget(GameObject ai_obj, GameObject target_obj,
            float close_threshold=3f, float y_shoot_offset=2f,
            float point_reach_dist=0.5f, float point_leave_dist=1f) {

            this.ai_obj = ai_obj;
            this.target_obj = target_obj;

            this.close_threshold = close_threshold;
            this.y_shoot_offset = y_shoot_offset;
            this.point_reach_dist = point_reach_dist;
            this.point_leave_dist = point_leave_dist;
        }

        public Vector3 AiPos { get { return this.ai_obj.transform.position; } }
        public Vector3 TargetPos { get { return this.target_obj.transform.position; } }
        public Vector3 Offset { get { return new Vector3(0, y_shoot_offset, 0); } }
        public Vector3 Delta { get { return TargetPos + Offset - AiPos; } }
        public bool TargetAlive { get { return target_obj != null; } }

        public Vector3 GetTargetPos() {
            return target_obj.transform.position + new Vector3(0, y_shoot_offset, 0);
        }

        public float DistanceToTarget() {
            return Vector3.Distance(ai_obj.transform.position, GetTargetPos());
        }

        public bool IsCloseToTarget() {
            return DistanceToTarget() < close_threshold;
        }

        public bool IsFirePointReached() {
            return DistanceToTarget() < point_reach_dist;
        }

        public bool IsLeaveFirePointReached() {
            return DistanceToTarget() > point_leave_dist;
        }

        public Enemy ClosestEnemy(Enemy[] objs) {

            float closest_dist = float.MaxValue;
            Enemy closest_enemy = null;

            foreach (Enemy enemy in objs) {

                var obj = enemy.gameObject;

                var dist_to_obj = Vector3.Distance(AiPos, obj.transform.position);
                if (dist_to_obj < closest_dist && dist_to_obj > 0) {
                    closest_dist = dist_to_obj;
                    closest_enemy = enemy;
                }
            }
            return closest_enemy;
        }

        public float DistToObj(GameObject obj) {
            return Vector3.Distance(this.ai_obj.transform.position, obj.transform.position);
        }
    }
}
