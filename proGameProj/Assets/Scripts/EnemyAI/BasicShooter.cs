using UnityEngine;
using System.Collections;

/// <summary>
/// Class for the movement and behavior that fires a bullet
/// every few seconds
/// </summary>
public class BasicShooter : MonoBehaviour, IKillable {
	
	private Vector3 originalPos;
	public float speed = 0.1f;
	public int hp = 1;
	private float movementX;
	private float movementY;
	private float targetPosY;
	public float frequency = 1f;
	private float startTime;
	private float prevTime = 0.0f;
	private float timedFire;
	public GameObject UI;
	public GameObject control;
	public GameObject player;
	public GameObject EnemBullet;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		movementX = 0;
		movementY = 0;
		originalPos = transform.position;
		targetPosY = originalPos.y - 10f;
	}
	
	// Update is called once per frame
	void Update () {
		timedFire = Time.time - startTime - prevTime;
		Rect activeRect = control.GetComponent<CameraAndBoardControl> ().GetCamView ();
		Vector2 currentPos = new Vector2 (transform.position.x, transform.position.y);
		if (activeRect.Contains (currentPos)) {
			Movement();
			if (timedFire > frequency) {
				Instantiate (EnemBullet, transform.position, transform.rotation);
				prevTime = Time.time;
				timedFire = 0;
			}
		}
	}

	/// <summary>
	/// Movement change for a unit. Called each frame.
	/// </summary>
	public void Movement(){
		if (transform.position.y > targetPosY) {
			movementX = 0;
			movementY = -0.1f;
		} else {
			Vector3 playerPos = player.GetComponent<PlayerScript>().GetPosition();
			movementY = control.GetComponent<CameraAndBoardControl>().GetCamSpeed();
			movementX = (transform.position.x > playerPos.x) ? -1 : 1;
		}
		transform.Translate (movementX * speed, movementY, 0);
	}

	/// <summary>
	/// Executed when unit is hit.
	/// </summary>
	public void OnHit() {
		DestroyObject (gameObject);
		UI.GetComponent<UnityUIController> ().UpdateScore (200);
	}

	/// <summary>
	/// Executed when unit is killed
	/// </summary>
	public void OnKill() {
		hp--;
		if (hp <= 0)
			OnKill ();
	}
}
