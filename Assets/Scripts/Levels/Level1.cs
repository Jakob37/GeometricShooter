﻿using UnityEngine;
using Assets.Scripts.Levels;
using System.Collections.Generic;

public class Level1 : MonoBehaviour {

    public GameObject enemy_prefab;
    public bool is_active = true;

    private List<Spawn> spawns;

	void Start () {
        spawns = new List<Spawn>();

        for (var i = 0; i < 30; i++) {
            var spawn_time = Random.Range(0, 30);

            Spawn spawn = new Spawn(enemy_prefab, spawn_time);
            spawns.Add(spawn);
        }
    }
	
	void Update () {

        if (!is_active) {
            return;
        }

	    foreach (Spawn spawn in spawns) {
            if (spawn.IsReady) {
                CreateSpawn(spawn);
            }
        }
	}

    private void CreateSpawn(Spawn spawn) {

        float screen_size = 5f;

        GameObject spawn_object = spawn.GetSpawn();
        var obj = Instantiate(spawn_object);
        var spawn_pos_x = Random.Range(-screen_size, screen_size);

        var new_pos = new Vector3(spawn_pos_x, screen_size, 0);

        obj.transform.position = new_pos;
    }
}
