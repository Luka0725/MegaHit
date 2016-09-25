﻿using UnityEngine;
using System.Collections;

public class AIShip : MonoBehaviour {

    public float speed = 1f;
    public float degrees = 100f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.x += speed * transform.up.x * Time.deltaTime;
        pos.y += speed * transform.up.y * Time.deltaTime;
        transform.position = pos;
	}

    void OnTriggerStay2D(Collider2D other){
        if (other.tag == "left_boundary") {
            transform.Rotate(0, 0, -degrees * Time.deltaTime);
        }
        else if (other.tag == "right_boundary")
        {
            transform.Rotate(0, 0, degrees * Time.deltaTime);
        }
    }
}