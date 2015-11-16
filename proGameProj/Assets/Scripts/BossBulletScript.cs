using UnityEngine;
using System.Collections;

public class BossBulletScript : MonoBehaviour {
	public float bulletSpeed = 2f;
	private float iniPosY;
	private float maxY;
	
	// Use this for initialization
	void Start () {
		iniPosY = transform.position.y;
		maxY = iniPosY - 25;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, -bulletSpeed, 0);
		if (transform.position.y < maxY) {
			DestroyObject (gameObject);
		}
		
	}
	
	/// <summary>
	/// Raises the trigger enter event.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerEnter(Collider col) {
		if (col.GetComponent<PlayerScript>() != null) {
			col.GetComponent<PlayerScript>().OnHitP();
			DestroyObject (gameObject);
		}
	}
}
