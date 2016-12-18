using UnityEngine;
using System.Collections;
using Assets.Scripts.Behaviour.Movement;

public class ai_module : Movement {

    public enum ai_state {
        rest,
        follow
    }

    public float CLOSE_THRESHOLD = 2f;
    public float SPEED = 0.1f;

    private ai_state current_state;
    private Player target_player;

	void Start () {
        this.current_state = ai_state.rest;

        target_player = GameObject.FindObjectOfType<Player>();
	}
	
	public override void Update () {

        var new_state = GetRelevantAIState();

        if (new_state != current_state) {
            print("Switching state to: " + new_state);
            current_state = new_state;
        }

        switch (current_state) {
            case ai_state.rest:
                StateMovementRest();
                break;
            case ai_state.follow:
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

        Vector3 my_position = gameObject.transform.position;
        Vector3 delta_vector = target_player.Position - my_position;
        Vector3 new_direction = delta_vector.normalized;

        this.direction = new_direction;
        this.speed = SPEED;
    }

    private ai_state GetRelevantAIState() {

        Vector3 player_pos = target_player.gameObject.transform.position;
        Vector3 my_pos = gameObject.transform.position;

        var current_distance = Vector3.Distance(my_pos, player_pos);

        if (current_distance < CLOSE_THRESHOLD) {
            return ai_state.follow;
        }
        else {
            return ai_state.rest;
        }
    }
}
