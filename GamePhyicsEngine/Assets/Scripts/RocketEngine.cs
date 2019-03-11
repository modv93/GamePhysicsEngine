using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(PhysicsEngine))]
public class RocketEngine : MonoBehaviour {

	public float fuelMass;			// kg
	public float maxThrust;			// kN [kg m s^-2] 
	[Range(0, 1f)]
	public float thrustpercent; 	// to be determined in percentage [none]

	public Vector3 thrustUnitVector;	// [none]
	//public Vector3 forceVector;
	private PhysicsEngine physicsEngine;
	private float currentThrust;

	// Use this for initialization
	void Start () {
		physicsEngine = GetComponent<PhysicsEngine> ();
		physicsEngine.mass = physicsEngine.mass + fuelMass;
	}

	void FixedUpdate() {
		if (fuelMass > FuelThisUpdate ()) {
			fuelMass -= FuelThisUpdate ();
			physicsEngine.mass -= FuelThisUpdate ();
			ExertForce ();

		} else {
			Debug.LogWarning ("Out of rocket fuel");
		}

	}
	float FuelThisUpdate(){
		float exhaustMassFlow;						// [Kg]
		float effectiveExhaustVelocity = 4462f;				// [m s^-1]

		exhaustMassFlow = currentThrust / effectiveExhaustVelocity;

		return exhaustMassFlow * Time.deltaTime;	// [Kg]
	}
	void ExertForce (){
		currentThrust = thrustpercent * maxThrust * 1000f;
		Vector3 thrustVector = thrustUnitVector.normalized * currentThrust; // [N]
		physicsEngine.AddForces (thrustVector);
	}

}
