using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	//Changes the scene when you hit the "play" button. Pass a string to determine the scene.
	public void ChangeToScene (string sceneToChangeTo) {
		Application.LoadLevel (sceneToChangeTo);
	}
}
