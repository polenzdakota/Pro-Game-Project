using UnityEngine;
using System.Collections;

/// <summary>
/// Interface for killable units
/// </summary>
public interface IKillable {

	/// <summary>
	/// Movement change for a unit. Called each frame.
	/// </summary>
	void Movement();

	/// <summary>
	/// Executed when unit is killed
	/// </summary>
	void OnKill();

	/// <summary>
	/// Executed when unit is hit.
	/// </summary>
	void OnHit();

}
