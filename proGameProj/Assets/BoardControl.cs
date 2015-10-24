using UnityEngine;
using System.Collections;

public class BoardControl : MonoBehaviour {
	public int score;
	public string scoreText;
	public int lives = 3;

	// Use this for initialization
	void Start () {
		score = 0;
		scoreText = "" + score;
	}
	
	// Update is called once per frame
	void Update () {
	}

	/// <summary>
	/// Updates score.
	/// </summary>
	/// <param name="added">Score to Add.</param>
	void UpdateScore(int added) {
		score += added;
	}

	/// <summary>
	/// Updates the lives.
	/// </summary>
	/// <param name="added">Lives to Add.</param>
	void UpdateLives(int added) {
		lives += lives;
	}

	/// <summary>
	/// Raises the GUI event.
	/// </summary>
	void OnGUI() {

		// Make scorefield at top left
		Rect scoreField = new Rect (10, 10, 150, 20);
		GUI.Box(scoreField, "Score: ");
		scoreField.x += 100;
		scoreField.width -= 100;
		GUI.TextField (scoreField, scoreText);

		//Make lives and status at top right
		Rect gameStateInfoField = new Rect (700, 10, 125, 100);
		GUI.Box(gameStateInfoField, "State and Lives");

	}
}
