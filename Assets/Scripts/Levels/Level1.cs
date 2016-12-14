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

        Spawn spawn = new Spawn(enemy_prefab, 1);

        spawns.Add(spawn);
	}
	
	void Update () {
	    foreach (Spawn spawn in spawns) {
            spawn.MyUpdate();
        }
	}
}
