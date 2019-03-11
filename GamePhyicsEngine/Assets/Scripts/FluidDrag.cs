using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidDrag : MonoBehaviour {

	[Range(1, 2f)]
	public float velocityExponent;
	public float dragConstant;

	private PhysicsEngine physicsEngine;

	void Start () {
		physicsEngine = GetComponent<PhysicsEngine> ();
	}

	void FixedUpdate(){
		Vector3 velocityVector = physicsEngine.velocityVector;
		float speed = velocityVector.magnitude;
		float dragSize = CalculateDrag(speed);
		Vector3 dragVector = dragSize * velocityVector.normalized;
		physicsEngine.AddForces (-dragVector); // dragVector is applying in the opposite direction	
	}
	float CalculateDrag(float speed) {
		return dragConstant * Mathf.Pow(speed, velocityExponent);
	}
}
