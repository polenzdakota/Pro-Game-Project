using UnityEngine;
using System.Collections;

/// <summary>
/// Class holds all bullet script.
/// </summary>
public class BulletScript : MonoBehaviour {
	public float bulletSpeed = 2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, bulletSpeed, 0);
		if (transform.position.y > 50) {
			DestroyObject (gameObject);
		}
	
	}

	/// <summary>
	/// Raises the trigger enter event.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerEnter(Collider col) {
		//TODO
	}
}
