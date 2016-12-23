using UnityEngine;
using System.Collections;
using Assets.Scripts.Behaviour.Movement;
using Assets.Scripts.Behaviour.ai;
using System.Collections.Generic;

public enum AIState {
    rest,
    follow,
    fire
}

public enum AIRepelState {
    active,
    inactive
}

public class AIModule : Movement {


    public float SPEED = 0.1f;
    public float braking_speed = 0.001f;
    public float accelerate_speed = 0.001f;

    public float close_threshold = 3f;
    public float y_shoot_offset = 2f;
    public float point_reach_dist = 0.5f;
    public float point_leave_dist = 1f;

    public float repel_distance = 1f;

    private AIState current_state;
    public AIState CurrentAIState { get { return current_state; } }

    private AIRepelState current_ai_repel_state;
    public AIRepelState CurrentAIRepelState { get { return current_ai_repel_state; } }

    private AITarget ai_object;
    private Enemy closest_enemy;

    void Start () {
        this.current_state = AIState.rest;

        Player player = GameObject.FindObjectOfType<Player>();
        ai_object = new AITarget(gameObject, player.gameObject, 
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
                // print("rest call");
                StateMovementRest();
                break;
            case AIState.follow:
                // print("movement call");
                StateMovementFollow();
                break;
            case AIState.fire:
                // print("fire call");
                StateMovementFire();
                break;
            default:
                break;
        }

        UpdateCloseRepel();

        if (current_ai_repel_state == AIRepelState.active) {
            Repel();
        }

        base.Update();
	}

    private void UpdateCloseRepel() {
        Enemy[] other_enemy_ships = GameObject.FindObjectsOfType<Enemy>();

        closest_enemy = ai_object.ClosestEnemy(other_enemy_ships);


        float closest_enemy_dist = Vector3.Distance(gameObject.transform.position, closest_enemy.gameObject.transform.position);

        print(closest_enemy_dist);

        if (closest_enemy != null && closest_enemy_dist < repel_distance) {
            current_ai_repel_state = AIRepelState.active;
            print("Repelling!");
        }
        else {
            current_ai_repel_state = AIRepelState.inactive;
        }
    }

    private void Repel() {
        print("Repel called!");
        Vector3 repel_direction = -(ai_object.AiPos - closest_enemy.transform.position);
        Vector3 repel_dir = repel_direction.normalized;
        this.direction = repel_dir;
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

        Vector3 new_direction = ai_object.Delta.normalized;

        this.direction = new_direction;

        if (this.speed + accelerate_speed > SPEED) {
            this.speed = SPEED;
        }
        else {
            this.speed += accelerate_speed;
        }
    }

    private void StateMovementFire() {

        if (this.speed < braking_speed) {
            this.speed = 0;
        }
        else {
            this.speed -= braking_speed;
        }
    }

    private AIState GetRelevantAIState() {

        Vector3 player_pos = ai_object.GetTargetPos();
        Vector3 my_pos = gameObject.transform.position;

        if (current_state == AIState.rest) {
            if (ai_object.IsCloseToTarget()) {
                return AIState.follow;
            }
            return AIState.rest;
        }
        else if (current_state == AIState.follow) {
            if (!ai_object.IsCloseToTarget()) {
                return AIState.rest;
            }
            else if (ai_object.IsFirePointReached()) {
                return AIState.fire;
            }
            return AIState.follow;
        }
        else if (current_state == AIState.fire) {
            if (ai_object.IsLeaveFirePointReached()) {
                return AIState.follow;
            }
            return AIState.fire;
        }
        else {
            throw new System.Exception("Invalid AI state reached: " + current_state);
        }
    }
}
