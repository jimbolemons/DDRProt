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
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.y -= speed * Time.deltaTime;
		transform.position = pos;

		//////////// If off the bottom of the screen, destroy this object:
		if (pos.y < -8) Destroy (gameObject);

	}
	void OnTriggerStay2D(Collider2D col)
	{
		if (Input.GetKeyDown(KeyCode.A)) {
			if (col.gameObject.tag == "Yellow") 
			{
				Destroy (gameObject);
			}
		}
		if (Input.GetKeyDown(KeyCode.S)) {
			if (col.gameObject.tag == "Red")
			{
				Destroy (gameObject);				
			}
		}
		if (Input.GetKeyDown(KeyCode.D)) {
			if (col.gameObject.tag == "Blue")
			{
				Destroy (gameObject);				
			}
		}
		if (Input.GetKeyDown(KeyCode.F)) {
			if (col.gameObject.tag == "Green")
			{
				Destroy (gameObject);				
			}
		}
	}
}
