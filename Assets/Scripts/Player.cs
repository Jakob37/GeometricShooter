using UnityEngine;
using System.Collections;
using Assets.Scripts.Behaviour.Movement;
using Assets.Scripts;

public class Player : ScriptGameObject {

    public float speed = 0.1f;

    //public Camera camera;

    //private float minX;
    //private float maxX;
    //private float minY;
    //private float maxY;
    //
    //private float mapX = 27f;
    //private float mapY = 20f;

    private Movement movement;

    void Start() {

        //Camera camera = Camera.main;
        //
        //float vertExtent = camera.orthographicSize;
        //float horzExtent = (float)(vertExtent * Screen.width / Screen.height);
        //
        //// Calculations assume map is position at the origin
        //minX = horzExtent - mapX / 2f;
        //maxX = mapX / 2f - horzExtent;
        //minY = vertExtent - mapY / 2f;
        //maxY = mapY / 2f - vertExtent;

        //print(minX);
        //print(maxX);
        //print(minY);
        //print(maxY);
        //print(mapX);
        //print(mapY);
    }

    // Update is called once per frame
    public void Update () {

        //base.Update();

        //Movement();

        // TODO - Basic shooting

	}

    //private void Movement() {
    //
    //    var x_speed = 0f;
    //    var y_speed = 0f;
    //
    //    if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
    //        x_speed = -speed;
    //    }
    //    else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
    //        x_speed = speed;
    //    }
    //
    //    if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
    //        y_speed = speed;
    //    } 
    //    else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
    //        y_speed = -speed;
    //    }
    //
    //    var delta_pos = new Vector3(x_speed, y_speed, 0);
    //    var new_pos = transform.position + delta_pos;
    //
    //    new_pos.x = Mathf.Clamp(new_pos.x, minX, maxX);
    //    new_pos.y = Mathf.Clamp(new_pos.y, minY, maxY);
    //
    //
    //    transform.position = new_pos;
    //}
}
