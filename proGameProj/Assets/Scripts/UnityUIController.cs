using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UnityUIController : MonoBehaviour {
	public static int score;
	public static int lives = 3;
	public bool displayDebugWindow = true;
	public Text scoreText;
	public Text debugText;
	private string scoreFMT;
	private static Vector3 playerPos;
	private static float camPosY;

	// Use this for initialization
	void Start () {
		scoreFMT = "0000000000";
		string fullScore = score.ToString (scoreFMT);
		string fullScoreToText = "Score: " + fullScore;
		scoreText.text = fullScoreToText;
		playerPos = new Vector3 (0, 0, 0);

		if (displayDebugWindow) {
			string debugWindowText = "DebugWindow\n";
			int aproxPosX = (int)playerPos.x;
			int aproxPosY = (int)playerPos.y;
			debugWindowText = debugWindowText + "Player Position: (" + aproxPosX + " , " + aproxPosY + ")\n";
			debugWindowText = debugWindowText + "Camera Y Position: " + (int)camPosY;
			debugWindowText = debugWindowText + "\nNumber of lives: " + lives;
			debugText.text = debugWindowText;
		}
	}
	
	// Update is called once per frame
	void Update () {
		string fullScore = score.ToString (scoreFMT);
		string fullScoreToText = "Score: " + fullScore;
		scoreText.text = fullScoreToText;
		
		if (displayDebugWindow) {
			string debugWindowText = "DebugWindow\n";
			int aproxPosX = (int)playerPos.x;
			int aproxPosY = (int)playerPos.y;
			debugWindowText = debugWindowText + "Player Position: (" + aproxPosX + " , " + aproxPosY + ")\n";
			debugWindowText = debugWindowText + "Camera Y Position: " + (int)camPosY;
			debugWindowText = debugWindowText + "\nNumber of lives: " + lives;
			debugText.text = debugWindowText;
		}
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
		print (added);
		lives += added;
	}


	/// <summary>
	/// Updates the cam Y position.
	/// </summary>
	/// <param name="posY">Position y.</param>
	public void UpdateCamPos(float posY) {
		camPosY = posY;
	}
	
	/// <summary>
	/// Updates the current instance of the player position to the 
	/// given Vector3.
	/// </summary>
	/// <param name="newPos">New position.</param>
	public void DebugUpdatePlayerPos(Vector3 newPos) {
		playerPos = newPos;
	}
}
