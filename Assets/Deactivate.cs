using UnityEngine;
using System.Collections;

public class Deactivate : MonoBehaviour {

    public bool deactivate = false;

	// Use this for initialization
	void Start () {
	    if (deactivate) {
            gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
