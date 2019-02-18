using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour {
	public Vector3 velocityVector;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate() {
		gameObject.transform.position = gameObject.transform.position + (velocityVector * Time.deltaTime);
	}

}
