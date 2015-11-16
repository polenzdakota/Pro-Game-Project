using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExitScript : MonoBehaviour {

	public Text scoreText;
	public int score;
	private string scoreFMT;

	void Start() {
		score = PlayerPrefs.GetInt ("Player Score");
		scoreFMT = "0000000000";
		string fullScore = score.ToString (scoreFMT);
		string fullScoreToText = "Final Score: " + fullScore;
		scoreText.text = fullScoreToText;
	}

	void Update() {
		score = PlayerPrefs.GetInt ("Player Score");
		scoreFMT = "0000000000";
		string fullScore = score.ToString (scoreFMT);
		string fullScoreToText = "Final Score: " + fullScore;
		scoreText.text = fullScoreToText;
	}
		
	public void ExitGame() {

		Application.Quit();
	}
}
