using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	static int score = 0;
	static int highScore = 0;

    private int pointModifier = 0;

	static Score instance;
    
	static public void AddPoint() {
		if(instance.bird.dead)
			return;

		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		PigMovement go = player_go.GetComponent<PigMovement> ();

		if(go.flapOnce == false ) {
			Debug.LogError("Could not find an object with tag 'Player'.");
		}
		else{
		score++;
			}

		if(score > highScore) {
			highScore = score;
		}
	}

	PigMovement bird;

	void Start() {
		instance = this;
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		if(player_go == null ) {
			Debug.LogError("Could not find an object with tag 'Player'.");
		}

		bird = player_go.GetComponent<PigMovement>();
		score = 0;
		highScore = PlayerPrefs.GetInt("highScore", 0);
	}

	void OnDestroy() {
		instance = null;
		PlayerPrefs.SetInt("highScore", highScore);
	}

	void Update () {
        //Only add point every 10th frame
        if(pointModifier % 10 == 0)
        {
            AddPoint();
        }

        pointModifier++;

		GetComponent<GUIText>().text = "Score: " + score + "\nHigh Score: " + highScore;
	}
}
