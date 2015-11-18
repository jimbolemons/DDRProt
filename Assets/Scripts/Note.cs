using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {
	public float speed = 3;

	// Use this for initialization
	void Start () {

		Vector3 pos = transform.position;
		pos.y = 6.2f;
		transform.position = pos;
	}
	
	/// <summary>
	/// this section moves the notes down every frame and destrys them if they get tofar off screen
	/// </summary>
	void Update () {
		Vector3 pos = transform.position;
		pos.y -= speed * Time.deltaTime;
		transform.position = pos;

		//////////// If off the bottom of the screen, destroy this object:
		if (pos.y < -8) Destroy (gameObject);

	}
	/// <summary>
	/// this section checks for a colition and if one is detected it checks for a button press and if that is detected it checks for a tag
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerStay2D(Collider2D col)
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			if (col.gameObject.tag == "Yellow") 
			{
				Destroy (gameObject);
			}
		}
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			if (col.gameObject.tag == "Red")
			{
				Destroy (gameObject);				
			}
		}
		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			if (col.gameObject.tag == "Blue")
			{
				Destroy (gameObject);				
			}
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			if (col.gameObject.tag == "Green")
			{
				Destroy (gameObject);				
			}
		}
	}
}
