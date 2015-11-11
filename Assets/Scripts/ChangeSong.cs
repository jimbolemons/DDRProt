using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangeSong : MonoBehaviour {

	public GameObject circle;
	public GameObject[] songPrefabs = new GameObject[]{};
	public float rotSpeedConstant;
	public float rotDurationConstant;
	public Transform songSpawnLeft;
	public Transform songSpawnRight;
	public Transform songSpawnBottom;
	public List<GameObject> clones;
	GameObject clone;
	float rotSpeed;
	float rotDuration;
	int songNumber;
	int posOrNeg;
	bool nextOrPrev;
	bool onCooldown;
	MonoBehaviour thisScript;
	CanvasRenderer circleColor;



	void Start(){

		/* These are only ran once at the very start of the game. This starts this script
		 as disabled. */
		thisScript = GetComponent<ChangeSong> ();
		thisScript.enabled = false;

		circleColor = circle.GetComponent<CanvasRenderer> (); // This is only here to change circle color

		/* This creates the very first song name in the middle. The rest are
		 * created off the top or bottom of the screen */
		clone = Instantiate(songPrefabs[0]) as GameObject;
		clone.transform.SetParent(circle.transform);
		clones.Add (clone);
		clone.transform.position = songSpawnRight.transform.position;
		clone.transform.rotation = songSpawnRight.transform.rotation;
		
	}

	public void Update () {

		/* The following if statement make sure these variables are only
		 * run once every time our Next/Previous buttons are clicked. */
		if (thisScript.enabled == false) {
			thisScript.enabled = true;
			rotSpeed = rotSpeedConstant;
			rotDuration = rotDurationConstant;
			NextOrPrev(0); //This 0 is placeholder. It gets overwritten.
			SongActions(); //Calls the Song Actions function
		}
		CircleSpinner(); //calls the Circle Spinning function
	}

	/* This is where you calculate the speed of the circle rotating and apply it forwards
	 * or backwards. */
	void CircleSpinner(){
		rotSpeed -= rotSpeedConstant/rotDurationConstant * Time.deltaTime;
		rotDuration -= Time.deltaTime;
		circle.transform.Rotate(Vector3.forward * -rotSpeed * posOrNeg);
		if (rotDuration <= 0) {

			/* Destroys the song name clones when they're off the screen */
			if (clone != null) {
				Destroy(clones[0]);
				clones.Remove(clones[0]);
			}

			/* Ends this script when the rotator comes to a halt */
			onCooldown = false;
			thisScript.enabled = false;
		}
	}

	/* Gets a +1 or -1 whenever you hit the Next/Prev buttons and uses them
	 * to determine what song you're on. Also gave it a cooldown so 
	 * it can't be spammed. */
	public void NextOrPrev(int value){
		if (onCooldown == false) {
			onCooldown = true;
			posOrNeg = value;
			songNumber += posOrNeg;
			if (songNumber >= songPrefabs.Length) {
				songNumber = 0;
			}
			if (songNumber < 0) {
				songNumber = songPrefabs.Length - 1;
			}
		}
	}

	/* This is where you can do specific things for each song at the
	 * menu screen (i.e., change your circles color and give it a new song title) */
	void SongActions(){

		switch (songNumber) {

			// If you have more songs, just add more cases to the switch.
		case 0:
			//Do Song 0 stuff here
			circleColor.SetColor(Color.white);
			break;
		case 1:
			//Do Song 1 stuff here
			circleColor.SetColor(Color.blue);
			break;
		case 2:
			//Do Song 2 stuff here
			circleColor.SetColor(Color.red);
			break;
		case 3:
			//Do Song 3 stuff here
			circleColor.SetColor(Color.green);
			break;
		case 4:
			//Do Song 4 stuff here
			circleColor.SetColor(Color.yellow);
			break;
		case 5:
			//Do Song 5 stuff here
			circleColor.SetColor(Color.cyan);
			break;
		case 6:
			//Do Song 6 stuff here
			circleColor.SetColor(Color.magenta);
			break;
		}

		/*Spawns the new Song text or w.e(could be an image) to the top or bottom
		 * depending on if you hit "next" or "previous" */
		clone = Instantiate(songPrefabs[songNumber]) as GameObject;
		clone.transform.SetParent(circle.transform);
		clones.Add (clone);
		if (posOrNeg > 0){
			clone.transform.position = songSpawnLeft.transform.position;
			clone.transform.rotation = songSpawnLeft.transform.rotation;
		} else {
			clone.transform.position = songSpawnBottom.transform.position;
			clone.transform.rotation = songSpawnBottom.transform.rotation;
		}
	}
}
