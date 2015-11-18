using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	
	/// <summary>
	/// The note prefab to spawn.
	/// </summary>
	public GameObject notePrefab1;
	public GameObject notePrefab2;
	public GameObject notePrefab3;
	public GameObject notePrefab4;
	
	void Start () {
		StartCoroutine ("StartSpawning1");
		StartCoroutine ("StartSpawning2");
		StartCoroutine ("StartSpawning3");
		StartCoroutine ("StartSpawning4");
	}
	/// <summary>
	/// 
	/// Spawns an note.
	/// </summary>
	GameObject SpawnNote1(){
	
		return Instantiate (notePrefab1);

	}
	GameObject SpawnNote2(){

		return Instantiate (notePrefab2);
		
	}
	GameObject SpawnNote3(){

		return Instantiate (notePrefab3);
		
	}
	GameObject SpawnNote4(){

		return Instantiate (notePrefab4);
		
	}
	/// <summary>
	/// A coroutine that spawns notes randomly between .75 seconds and 5 seconds.
	/// </summary>
	IEnumerator StartSpawning1(){
		while(true){

			SpawnNote1();
			yield return new WaitForSeconds(Random.Range(.75f,5f));
		}

	}
	IEnumerator StartSpawning2(){
		while(true){
			
			SpawnNote2();
			yield return new WaitForSeconds(Random.Range(.75f,5f));
		}
		
	}
	IEnumerator StartSpawning3(){
		while(true){
			
			SpawnNote3();
			yield return new WaitForSeconds(Random.Range(.75f,5f));
		}
		
	}
	IEnumerator StartSpawning4(){
		while(true){
			
			SpawnNote4();
			yield return new WaitForSeconds(Random.Range(.75f,5f));
		}
		
	}
	
}
