using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour, IKillable {
	public float speed = 2f; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CheckInputs ();
	}

	/// <summary>
	/// Checks the inputs each frame.
	/// </summary>
	void CheckInputs() {
		//For now check inputs will handle movement
		float movementX = Input.GetAxis ("Horizontal");
		float movementY = Input.GetAxis ("Vertical");
		transform.Translate (speed * movementX, speed * movementY, 0);

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}

	/// <summary>
	/// Handles non-player inputed movement
	/// </summary>
	public void Movement() {
		//TODO
	}

	/// <summary>
	/// Executed when unit is killed
	/// </summary>
	public void OnKill() {
		//TODO
	}

	/// <summary>
	/// Executed when unit is hit.
	/// </summary>
	public void OnHit() {
		//TODO
	}
}
