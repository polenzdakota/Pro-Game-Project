using UnityEngine;
using System.Collections;

/// <summary>
/// Basic movement for an enemy that moves in one direction.
/// Direction determined by xDirection and yDirection variables.
/// </summary>
public class OneDirectionEnemy : MonoBehaviour, IKillable {

	public int hp = 1;
	public int xDirection = 0;
	public int yDirection = -1;
	public float speed = 0.1f;
	public GameObject control;
	public GameObject UI;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//Unit only moves if it is located within the given camView
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
		transform.Translate (xDirection * speed, yDirection * speed, 0);
	}

	/// <summary>
	/// Executed when unit is killed
	/// </summary>
	public void OnKill() {
		DestroyObject (gameObject);
		UI.GetComponent<UnityUIController> ().UpdateScore (100);
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
