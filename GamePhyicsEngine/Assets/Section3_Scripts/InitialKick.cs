using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class InitialKick : MonoBehaviour {
	private Rigidbody rigidBody;

	public Vector3 initialKick = new Vector3 (4f, 0, 0);
	// Use this for initialization
	void OnEnable () {
		rigidBody = GetComponent<Rigidbody> ();
		rigidBody.angularVelocity = initialKick;
	}

}
