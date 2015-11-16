using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {

	public float scrollSpeed;
	public float tileSizeZ;
	public GameObject camera;
	private Vector3 startPosition;

	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float newPositionDY = camera.GetComponent<CameraAndBoardControl> ().GetCamSpeed();
		transform.Translate (0, newPositionDY, 0);
	}
}
