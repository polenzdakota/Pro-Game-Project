using UnityEngine;
using System.Collections;


/// <summary>
/// Class holds all player script.
/// </summary>
public class PlayerScript : MonoBehaviour {
	public float speed = 2f;
	public GameObject bullet;
	public static float topLeftPlayFieldX = -20f;
	public static float topLeftPlayFieldY = 10f;
	public static float playFieldWidth = 40f;
	public static float playFieldHeight = 20f;
	public static float camSpeed = 0.1f;
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

		//Kind of weird code. Should update.
		float displacementY = camSpeed;
		float displacementX = 0f;
		if (IsWithinBounds (movementX, movementY, speed)) {
			displacementY = displacementY + (speed * movementY);
			displacementX = speed * movementX;
		}

		transform.Translate (displacementX, displacementY, 0);
		UI.GetComponent<UnityUIController>().DebugUpdatePlayerPos(transform.position);


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
	/// Moves the current playfield by the given offset in the Y direction.
	/// </summary>
	/// <param name="offset">Offset.</param>
	public void AddCamOffset(float offset) {
		topLeftPlayFieldY += offset;
	}

	public void OnHitP() {
		//TODO
	}

	/// <summary>
	/// Gets the position.
	/// </summary>
	/// <returns>The position.</returns>
	public Vector3 GetPosition() {
		return transform.position;
	}

}
