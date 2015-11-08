using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text score;
	public Text highscore;

	public float scoreCount;
	public float highScoreCount;
	public float pointsPerSecond;
	public bool scoreIncrease;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey("Highscore")) {
			highScoreCount=PlayerPrefs.GetFloat ("Highscore");
		}
		scoreIncrease = true;
		scoreCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (scoreIncrease) {
		
			scoreCount += pointsPerSecond * Time.deltaTime ;

			if (scoreCount > highScoreCount){
				highScoreCount = Mathf.Round(scoreCount);
				PlayerPrefs.SetFloat("Highscore",highScoreCount);
			}

			score.text = "Score: " + Mathf.Round (scoreCount);
			highscore.text = "Highscore: " + highScoreCount;
		}
	
	}

	public void AddScore(float points){
		this.scoreCount += points;
	}
}
