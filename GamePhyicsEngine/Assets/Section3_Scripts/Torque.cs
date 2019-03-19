﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torque : MonoBehaviour {
	
	public Vector3 torque;
	public float torqueTime;
	private Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(torqueTime >= 0) {
			rigidBody.AddTorque (torque);
			torqueTime -= Time.fixedDeltaTime;
		}
	}
}
