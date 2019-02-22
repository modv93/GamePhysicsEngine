using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour {
	public Vector3 velocityVector;
	public Vector3 netForceVector;

	private List<Vector3> forceVectorList = new List<Vector3>();
	public float mass  = 10.0f;
	// Use this for initialization
	void Start () {
		SetupThrustTrails();

	}
	
	// Update is called once per frame
	void Update () {
	}
	void FixedUpdate() {
		RenderTrails ();
		UpdatePosition ();
	}
	public void AddForces (Vector3 forceVector) {
		forceVectorList.Add (forceVector);
	}
	void UpdatePosition() {
		// Summing the forces
		netForceVector = Vector3.zero;
		foreach (Vector3 forceVector in forceVectorList) {
			netForceVector += forceVector;
		}
		forceVectorList = new List<Vector3> (); // Clear the list

		// Calculate position change due to net force
		Vector3 accelarationVector = netForceVector / mass;
		velocityVector += accelarationVector * Time.deltaTime;
		//Position is getting updated FixedUpdate (delta time multiplied by the accelaration)
		gameObject.transform.position = gameObject.transform.position + (velocityVector * Time.deltaTime);
	}
	public bool showTrails = true;
	private LineRenderer lineRenderer;
	private int numberOfForces;

	// Use this for initialization
	void SetupThrustTrails () {
		forceVectorList = GetComponent<PhysicsEngine>().forceVectorList;

		lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
		lineRenderer.startColor = Color.yellow;
		lineRenderer.startWidth = 0.2F;
		lineRenderer.useWorldSpace = false;
	}

	// Update is called once per frame
	void RenderTrails () {
		if (showTrails) {
			lineRenderer.enabled = true;
			numberOfForces = forceVectorList.Count;
			lineRenderer.positionCount = (numberOfForces * 2);
			int i = 0;
			foreach (Vector3 forceVector in forceVectorList) {
				lineRenderer.SetPosition(i, Vector3.zero);
				lineRenderer.SetPosition(i+1, -forceVector);
				i = i + 2;
			}
		} else {
			lineRenderer.enabled = false;
		}
	}
}
