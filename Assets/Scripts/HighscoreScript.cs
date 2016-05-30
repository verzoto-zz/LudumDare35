using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighscoreScript : MonoBehaviour {

    public Text playerScore;
    public Text playerBestScore;
    public Text newBest;
    int score;
    int bestScore;

	// Use this for initialization
	void Start () { 
        score = PlayerPrefs.GetInt("currentScore");
        bestScore = PlayerPrefs.GetInt("bestScore");

        playerScore.text = score.ToString();
        playerBestScore.text = bestScore.ToString();

        HasBestScore();
    }
	
    
    void HasBestScore()
    {
        if (score > bestScore)
        {
            PlayerPrefs.SetInt("bestScore", score);
            newBest.enabled = true;
        }
    }

    

}
