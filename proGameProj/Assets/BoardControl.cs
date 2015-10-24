using UnityEngine;
using System.Collections;

public class BoardControl : MonoBehaviour {
	public int score;
	public int lives = 3;
	public bool displayDebugWindow = true;
	private static Vector3 playerPos;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	/// <summary>
	/// Updates score.
	/// </summary>
	/// <param name="added">Score to Add.</param>
	public void UpdateScore(int added) {
		score += added;
	}

	/// <summary>
	/// Updates the lives.
	/// </summary>
	/// <param name="added">Lives to Add.</param>
	public void UpdateLives(int added) {
		lives += lives;
	}

	/// <summary>
	/// Updates the current instance of the player position to the 
	/// given Vector3.
	/// </summary>
	/// <param name="newPos">New position.</param>
	public void DebugUpdatePlayerPos(Vector3 newPos) {
		playerPos = newPos;
	}

	/// <summary>
	/// Raises the GUI event.
	/// </summary>
	void OnGUI() {

		// Make scorefield at top left
		Rect scoreField = new Rect (10, 10, 150, 20);
		string fmt = "0000000000";
		string fullScore = score.ToString (fmt);
		string scoreText = "Score: " + fullScore;
		GUI.Box(scoreField, scoreText);

		//Make lives and status at top right
		Rect gameStateInfoField = new Rect (700, 10, 125, 100);
		GUI.Box(gameStateInfoField, "State and Lives");

		//Draws debug window if displayDebugWindow is true
		if (displayDebugWindow) {
			Rect debugWindow = new Rect (10, 400, 200, 100);
			GUI.Box (debugWindow,"Debug Window");
			Rect debugContents = new Rect (15, 420, 190, 75); 
			string playerPosX = string.Format("{0:#,###.##}", playerPos.x);
			string playerPosY = string.Format("{0:#,###.##}", playerPos.y);

			string posText = "Player Position: (" + playerPosX + " , " + playerPosY + ")";

			GUI.TextField (debugContents, posText);
		}

	}
}
