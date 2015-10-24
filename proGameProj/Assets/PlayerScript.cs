using UnityEngine;
using System.Collections;


/// <summary>
/// Class holds all player script.
/// </summary>
public class PlayerScript : MonoBehaviour, IKillable {
	public float speed = 2f;
	public GameObject bullet;
	public int topLeftPlayFieldX = -20;
	public int topLeftPlayFieldY = 10;
	public int playFieldWidth = 40;
	public int playFieldHeight = 20;
	public GameObject UI;


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

		if (IsWithinBounds (movementX, movementY, speed)) {
			transform.Translate (speed * movementX, speed * movementY, 0);
			UI.GetComponent<BoardControl>().DebugUpdatePlayerPos(transform.position);
		}


		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			Fire ();
		}
	}

	/// <summary>
	/// Fires a bullet object at the current position 
	/// </summary>
	void Fire() {
		float heightDivTwo = transform.localScale.y / 2;
		Vector3 instPosition = 
			new Vector3 (transform.position.x, transform.position.y + heightDivTwo, transform.position.z);

		Instantiate (bullet, instPosition, transform.rotation);
	}

	/// <summary>
	/// Returns true if the next point is within the playfield.
	/// </summary>
	/// <returns><c>true</c>, if within bounds <c>false</c> otherwise.</returns>
	/// <param name="xMovement">X movement direction and degree</param>
	/// <param name="yMovement">Y movement direction and degree</param>
	/// <param name="speed">Speed of the player unit</param>
	bool IsWithinBounds(float xMovement, float yMovement, float speed) {
		float xPos = transform.position.x + (xMovement * speed);
		float yPos = transform.position.y + (yMovement * speed);
		return ((xPos > topLeftPlayFieldX && xPos < topLeftPlayFieldX + playFieldWidth) &&
			    (yPos < topLeftPlayFieldY && yPos > topLeftPlayFieldY - playFieldHeight));
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
