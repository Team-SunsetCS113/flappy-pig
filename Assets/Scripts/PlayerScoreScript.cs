using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScoreScript : MonoBehaviour {

    private int score = 0;
    private static int highScore = 0;
    public Text scoreText;

	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + score + "\nHigh Score: " + highScore;
	}

    public void addPoints(int numPoints)
    {
        score += numPoints;

        if (score > highScore)
        {
            highScore = score;
        }
    }
}
