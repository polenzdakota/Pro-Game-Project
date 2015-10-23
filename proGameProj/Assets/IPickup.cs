using UnityEngine;
using System.Collections;

/// <summary>
/// Interface for any powerup or pickup.
/// </summary>
public interface IPickup {

	/// <summary>
	/// Movement change for a unit. Called each frame
	/// </summary>
	void Movement();

	/// <summary>
	/// Condition given to the player state when pickup is pickuped.
	/// </summary>
	void UpdateCondition();
}