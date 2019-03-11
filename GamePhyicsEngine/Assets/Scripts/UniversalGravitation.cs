using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalGravitation : MonoBehaviour {

	private const float gravitationConstant = 6.674e-11f; // [m^3 Kg^-1 ms^-2]
	private PhysicsEngine[] physicsEngineArray;

	void Start () {
		physicsEngineArray = FindObjectsOfType<PhysicsEngine> ();
	}


	void FixedUpdate () {
		CalculateGravity ();
	}

	void CalculateGravity() {
		foreach (PhysicsEngine physicsEngineA in physicsEngineArray) {
			foreach (PhysicsEngine physicsEngineB in physicsEngineArray) {
				if (physicsEngineA != physicsEngineB && physicsEngineA != this) {
					Vector3 distance = physicsEngineA.transform.position - physicsEngineB.transform.position;
					float rSquared = Mathf.Pow (distance.magnitude, 2f);
					float gravityMagnitude = gravitationConstant * physicsEngineA.mass * physicsEngineB.mass / rSquared;
					Vector3 gravityFeltVector = gravityMagnitude * distance.normalized;
					physicsEngineA.AddForces (-gravityFeltVector);
				}
			}
		}
	}
}
