using UnityEngine;
using System.Collections;
using Assets.Scripts.Behaviour.Movement;

public enum AIState {
    rest,
    follow,
    fire
}

public class AIModule : Movement {


    public float CLOSE_THRESHOLD = 2f;
    public float SPEED = 0.1f;
    public float braking_speed = 0.001f;
    public float accelerate_speed = 0.001f;

    public float y_shoot_offset = 2f;
    public float point_reach_dist = 0.5f;
    public float point_leave_dist = 1f;

    private AIState current_state;
    public AIState CurrentAIState { get { return current_state; } }

    private Player target_player;

    public Vector3 GetTargetPos() {
        return target_player.transform.position + new Vector3(0, y_shoot_offset, 0);
    }

    public float DistanceToTarget() {
        return Vector3.Distance(transform.position, GetTargetPos());
    }

    public bool IsCloseToTarget() {
        return DistanceToTarget() < CLOSE_THRESHOLD;
    }

    public bool IsFirePointReached() {
        return DistanceToTarget() < point_reach_dist;
    }

    public bool IsLeaveFirePointReached() {
        return DistanceToTarget() > point_leave_dist;
    }

    void Start () {
        this.current_state = AIState.rest;

        target_player = GameObject.FindObjectOfType<Player>();
	}
	
	public override void Update () {

        var new_state = GetRelevantAIState();

        if (new_state != current_state) {
            print("Switching state to: " + new_state);
            current_state = new_state;
        }

        switch (current_state) {
            case AIState.rest:
                StateMovementRest();
                break;
            case AIState.follow:
                StateMovementFollow();
                break;
            case AIState.fire:
                StateMovementFire();
                break;
            default:
                break;
        }

        base.Update();
	}

    private void StateMovementRest() {

        if (this.speed < braking_speed) {
            this.speed = 0;
        }
        else {
            this.speed -= braking_speed;
        }
    }

    private void StateMovementFollow() {

        Vector3 my_pos = gameObject.transform.position;
        Vector3 player_pos = target_player.Position;
        Vector3 offset = new Vector3(0, y_shoot_offset, 0);

        Vector3 delta_vector = player_pos + offset - my_pos;
        Vector3 new_direction = delta_vector.normalized;

        this.direction = new_direction;

        if (this.speed + accelerate_speed > SPEED) {
            this.speed = SPEED;
        }
        else {
            this.speed += accelerate_speed;
        }
    }

    private void StateMovementFire() {

        print("In fire mode");

        if (this.speed < braking_speed) {
            print("Speed set to zero");
            this.speed = 0;
        }
        else {
            this.speed -= braking_speed;
        }
    }

    private AIState GetRelevantAIState() {

        Vector3 player_pos = target_player.gameObject.transform.position;
        Vector3 my_pos = gameObject.transform.position;

        if (current_state == AIState.rest) {
            if (IsCloseToTarget()) {
                return AIState.follow;
            }
            return AIState.rest;
        }
        else if (current_state == AIState.follow) {
            if (!IsCloseToTarget()) {
                return AIState.rest;
            }
            else if (IsFirePointReached()) {
                return AIState.fire;
            }
            return AIState.follow;
        }
        else if (current_state == AIState.fire) {
            if (IsLeaveFirePointReached()) {
                return AIState.follow;
            }
            return AIState.fire;
        }
        else {
            throw new System.Exception("Invalid AI state reached: " + current_state);
        }
    }
}
