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
    public float y_shoot_offset = 2f;
    public float point_reach_dist = 0.5f;

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

    public bool IsAtFirePoint() {
        return DistanceToTarget() < point_reach_dist;
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
            default:
                break;
        }

        base.Update();
	}

    private void StateMovementRest() {
        this.speed = 0f;
    }

    private void StateMovementFollow() {

        Vector3 my_pos = gameObject.transform.position;
        Vector3 player_pos = target_player.Position;
        Vector3 offset = new Vector3(0, y_shoot_offset, 0);

        print(offset);

        Vector3 delta_vector = player_pos + offset - my_pos;
        Vector3 new_direction = delta_vector.normalized;

        this.direction = new_direction;
        this.speed = SPEED;
    }

    private AIState GetRelevantAIState() {

        Vector3 player_pos = target_player.gameObject.transform.position;
        Vector3 my_pos = gameObject.transform.position;

        var current_distance = Vector3.Distance(my_pos, player_pos);

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
            else if (IsAtFirePoint()) {
                print("Fire!");
                return AIState.fire;
            }
            return AIState.follow;
        }
        else if (current_state == AIState.fire) {
            if (!IsAtFirePoint()) {
                return AIState.follow;
            }
            return AIState.fire;
        }
        else {
            throw new System.Exception("Invalid AI state reached: " + current_state);
        }
    }
}
