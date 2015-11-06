using UnityEngine;
using System.Collections;

public class VeerTowardsPlayer : MonoBehaviour, IKillable {

	public int hp = 1;
	private int xDirection;
	public int yDirection = 0;
	public float speed = 0.1f;
	private static Vector3 playerPos;
	public GameObject control;
	public GameObject UI;
	public GameObject player;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Rect activeRect = control.GetComponent<CameraAndBoardControl> ().GetCamView ();
		Vector2 currentPos = new Vector2 (transform.position.x, transform.position.y);
		if (activeRect.Contains (currentPos)) {
			Movement();
		}
	}

	/// <summary>
	/// Movement change for a unit. Called each frame.
	/// </summary>
	public void Movement() {
		playerPos = player.GetComponent<PlayerScript> ().GetPosition ();

		xDirection = (transform.position.x > playerPos.x) ? -1 : 1;
		transform.Translate (xDirection * speed, yDirection * speed, 0);
	}
	
	/// <summary>
	/// Executed when unit is killed
	/// </summary>
	public void OnKill() {
		DestroyObject (gameObject);
		UI.GetComponent<UnityUIController> ().UpdateScore (150);
	}
	
	/// <summary>
	/// Executed when unit is hit.
	/// </summary>
	public void OnHit(){
		hp--;
		if (hp <= 0)
			OnKill ();
	}
}
