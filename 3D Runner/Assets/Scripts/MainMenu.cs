using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public string PlayGameLevel;
	
	public void PlayGame(){
		
		Application.LoadLevel (PlayGameLevel);
	}
	
	public void QuitGame(){
		Application.Quit ();
	}
}
