using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public Transform platformGenerator;
	private Vector3 platformStartPoint;
	
	public PlayerControl thePlayer;
	private Vector3 playerStartPoint;
	
	private PlatformDestroyer[] platformlist;
	public ScoreManager myScoreManager;

	public DeathMenu DeathScreen;
	
	// Use this for initialization
	void Start () {
		
		platformStartPoint=platformGenerator.position;
		playerStartPoint = thePlayer.transform.position;
		myScoreManager = FindObjectOfType<ScoreManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	public void RestartGame(){
		myScoreManager.scoreIncrease = false;
		thePlayer.gameObject.SetActive (false);
		DeathScreen.gameObject.SetActive (true);

		//StartCoroutine("RestartGameCo");
		
	}


	public void Reset(){
		DeathScreen.gameObject.SetActive (false);
		platformlist = FindObjectsOfType<PlatformDestroyer> ();
		for (int i=0; i<platformlist.Length; i++) {
			platformlist [i].gameObject.SetActive (false);
		}
		thePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive (true);
		
		myScoreManager.scoreCount = 0;
		myScoreManager.scoreIncrease = true;
	}



	/*public IEnumerator RestartGameCo(){
		//myScoreManager.scoreIncrease = false;

		//thePlayer.gameObject.SetActive (false);
		yield return new WaitForSeconds (0.5f);
		platformlist = FindObjectsOfType<PlatformDestroyer> ();
		for (int i=0; i<platformlist.Length; i++) {
			platformlist [i].gameObject.SetActive (false);
		}
		thePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive (true);

		myScoreManager.scoreCount = 0;
		myScoreManager.scoreIncrease = true;
	}*/
	
}
