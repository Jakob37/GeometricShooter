using UnityEngine;
using System.Collections;
using Assets.Scripts.Behaviour.Movement;
using Assets.Scripts.Behaviour.ai;

public enum AIState {
    rest,
    follow,
    fire
}

public class AIModule : Movement {


    public float SPEED = 0.1f;
    public float braking_speed = 0.001f;
    public float accelerate_speed = 0.001f;

    public float close_threshold = 3f;
    public float y_shoot_offset = 2f;
    public float point_reach_dist = 0.5f;
    public float point_leave_dist = 1f;

    private AIState current_state;
    public AIState CurrentAIState { get { return current_state; } }

    private AITarget target;

    void Start () {
        this.current_state = AIState.rest;

        Player player = GameObject.FindObjectOfType<Player>();
        target = new AITarget(gameObject, player.gameObject, 
            close_threshold:close_threshold,
            y_shoot_offset:y_shoot_offset,
            point_reach_dist:point_reach_dist,
            point_leave_dist:point_leave_dist);
	}
	
	public override void Update () {

        var new_state = GetRelevantAIState();

        if (new_state != current_state) {
            current_state = new_state;
        }

        switch (current_state) {
            case AIState.rest:
                print("rest call");
                StateMovementRest();
                break;
            case AIState.follow:
                print("movement call");
                StateMovementFollow();
                break;
            case AIState.fire:
                print("fire call");
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

        Vector3 new_direction = target.Delta.normalized;

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

        Vector3 player_pos = target.GetTargetPos();
        Vector3 my_pos = gameObject.transform.position;

        if (current_state == AIState.rest) {
            if (target.IsCloseToTarget()) {
                return AIState.follow;
            }
            return AIState.rest;
        }
        else if (current_state == AIState.follow) {
            if (!target.IsCloseToTarget()) {
                return AIState.rest;
            }
            else if (target.IsFirePointReached()) {
                return AIState.fire;
            }
            return AIState.follow;
        }
        else if (current_state == AIState.fire) {
            if (target.IsLeaveFirePointReached()) {
                return AIState.follow;
            }
            return AIState.fire;
        }
        else {
            throw new System.Exception("Invalid AI state reached: " + current_state);
        }
    }
}
