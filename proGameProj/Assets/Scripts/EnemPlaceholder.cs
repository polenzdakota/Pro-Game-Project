using UnityEngine;
using System.Collections;

public class EnemPlaceholder : MonoBehaviour, IKillable {
	public GameObject UI;
	public int hp = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Movement change for a unit. Called each frame.
	/// </summary>
	public void Movement(){
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
	public void OnHit() {
		hp--;

		if (hp <= 0)
			OnKill ();
	}

}
