using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {

	public float maxLaunchSpeed;
	public AudioClip windUpSound, launchSound;
	public PhysicsEngine ballToLaunch;

	private float launchSpeed, extraSpeedPerFrame;
	private AudioSource audioSource;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		audioSource.clip = windUpSound; // So we know the length of the clip
		extraSpeedPerFrame = ( maxLaunchSpeed * Time.fixedDeltaTime / audioSource.clip.length );

		audioSource.Stop ();
		if (ballToLaunch == null) {
			Debug.LogError ("No ball assigned");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		// Increase ball speed to max over the time of button down
		launchSpeed = 0;
		audioSource.clip = windUpSound;
		audioSource.Play ();

		InvokeRepeating("IncreaseLaunchSpeed", 1f, Time.fixedDeltaTime);
	}

	void OnMouseUp() {
		// Release the ball
		CancelInvoke();

		audioSource.Stop ();
		audioSource.clip = launchSound;
		audioSource.Play ();

		PhysicsEngine newBall = Instantiate (ballToLaunch) as PhysicsEngine;
		newBall.transform.parent = GameObject.Find ("Launched Balls").transform;
		Vector3 launchVector = new Vector3 (1, 1, 0).normalized;
		newBall.velocityVector = launchVector * launchSpeed;
	}
		
	void IncreaseLaunchSpeed() {
		if (launchSpeed < maxLaunchSpeed) {
			launchSpeed += extraSpeedPerFrame;
		} else {
			launchSpeed = maxLaunchSpeed;
		}
	}
}
