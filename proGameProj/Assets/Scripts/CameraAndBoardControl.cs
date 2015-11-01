using UnityEngine;
using System.Collections;

/// <summary>
/// Camera and board control.
/// </summary>
public class CameraAndBoardControl : MonoBehaviour {
	private float camPosY;
	public float camSpeed = 0.1f;
	public static float camViewTopLeftX;
	public static float camViewTopLeftY;
	public static float camViewHeight;
	public static float camViewWidth;
	public GameObject player;
	public GameObject UI;
	public static bool camMoves = true;

	// Use this for initialization
	void Start () {
		camViewTopLeftY = 20;
		camViewTopLeftX = -30;
		camViewHeight = 40;
		camViewWidth = 60;
		camPosY = transform.position.z;
	}

	// Update is called once per frame
	void Update () {
		if (camMoves) {
			transform.Translate (0, camSpeed, 0);
			camPosY = transform.position.y;
			camViewTopLeftY += camSpeed;
			//AddCamOffset needs to be called to update playfield
			player.GetComponent<PlayerScript>().AddCamOffset(camSpeed);
			UI.GetComponent<UnityUIController>().UpdateCamPos(camPosY);
		}
	}

	/// <summary>
	/// Gets the current boders of the camera.
	/// </summary>
	/// <returns>The cam view.</returns>
	public Rect GetCamView() {
		Rect camView = new Rect (camViewTopLeftX, camViewTopLeftY, camViewWidth, camViewHeight);
		return camView;
	}

	/// <summary>
	/// Sets camMoves which determines if the camera is moving
	/// </summary>
	/// <param name="moves">If set to <c>true</c> moves.</param>
	public void setCamMoves(bool moves) {
		camMoves = moves;
	}
}
