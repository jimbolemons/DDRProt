using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
	
	bool paused = false;
	
	void Start () {
		
	}
	
	/// <summary>
	///this  script pauses and unpauses the gameplay it also alows the player to go bac to the menu  
	/// </summary>
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			paused = !paused;
			
		}
		if (paused) {
			
			Time.timeScale = 0.0f;
			if (Input.GetKeyDown (KeyCode.Backspace)) {
				Application.LoadLevel ("MenuScene");
				
			}
			
			
		} else {
			
			Time.timeScale = 1.0f;
		}
		
	}
}
