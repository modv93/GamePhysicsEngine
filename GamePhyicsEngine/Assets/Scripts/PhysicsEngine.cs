using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour {
	public Vector3 velocityVector;
	public Vector3 netForceVector;
	public List<Vector3> forceVectorList = new List<Vector3>();
	public float mass  = 10.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate() {
		AddForce ();
		UpdateVelocity ();

		//Position is getting updated FixedUpdate (delta time multiplied by the accelaration)
		gameObject.transform.position = gameObject.transform.position + (velocityVector * Time.deltaTime);
				
	}
	void AddForce() {
		netForceVector = Vector3.zero;
		foreach (Vector3 forceVector in forceVectorList) {
			netForceVector += forceVector;
		}
	}
	void UpdateVelocity() {
		Vector3 accelarationVector = netForceVector / mass;
		velocityVector += accelarationVector * Time.deltaTime;
	}

}
