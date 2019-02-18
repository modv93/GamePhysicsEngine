using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour {
	public Vector3 velocityVector;
	public Vector3 netForceVector;
	public List<Vector3> forceVectorList = new List<Vector3>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate() {
		AddForce ();
		if (netForceVector == Vector3.zero) {
			gameObject.transform.position = gameObject.transform.position + (velocityVector * Time.deltaTime);
		} 
		else {
			Debug.LogError("Unbalanced force detected! ");
		}
			
	}
	void AddForce() {
		netForceVector = Vector3.zero;
		foreach (Vector3 forceVector in forceVectorList) {
			netForceVector += forceVector;
		}
	}
}
