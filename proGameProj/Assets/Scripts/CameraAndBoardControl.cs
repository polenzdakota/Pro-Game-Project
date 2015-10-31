using UnityEngine;
using System.Collections;

/// <summary>
/// Camera and board control.
/// </summary>
public class CameraAndBoardControl : MonoBehaviour {
	private float startCamPosZ;
	public float camSpeed = 0.1f;
	public GameObject player;
	public static bool camMoves = true;

	// Use this for initialization
	void Start () {
		startCamPosZ = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		if (camMoves) {
			transform.Translate (0, camSpeed, 0);
			//AddCamOffset needs to be called to update playfield
			player.GetComponent<PlayerScript>().AddCamOffset(camSpeed);
		}
	}

	/// <summary>
	/// Sets camMoves which determines if the camera is moving
	/// </summary>
	/// <param name="moves">If set to <c>true</c> moves.</param>
	public void setCamMoves(bool moves) {
		camMoves = moves;
	}
}
