using UnityEngine;
using System.Collections;
using Assets.Scripts.Levels;
using System.Collections.Generic;

public class Level1 : MonoBehaviour {

    public GameObject enemy_prefab;

    private List<Spawn> spawns;

    private GameObjects game_objects;

	void Start () {
        spawns = new List<Spawn>();
        game_objects = GetComponent<GameObjects>();

        for (var i = 0; i < 30; i++) {
            var spawn_time = Random.Range(0, 30);
            Spawn spawn = new Spawn(enemy_prefab, spawn_time);
            spawns.Add(spawn);

            print("Added spawn at time " + spawn_time);
        }
    }
	
	void Update () {
	    foreach (Spawn spawn in spawns) {
            if (spawn.IsReady) {
                print("Instantiating");
                GameObject spawn_object = spawn.GetSpawn();
                Instantiate(spawn_object);
            }
        }

        // print("Current time: " + Time.time);
	}
}
