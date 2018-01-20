using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add2 : MonoBehaviour {

	public GameObject prefab2;
	public GameObject playerPosition;
	public Vector3 playerDirection;
	public Vector3 spawnPosition;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			OnClick ();
		}
	}

	public void OnClick(){
		//Vector3 position = new Vector3(0, -40, 300);
		playerPosition = GameObject.FindGameObjectWithTag("Player");
		Vector3 position = playerPosition.transform.position;
		playerDirection = playerPosition.transform.forward;
		Vector3 spawnPosition = playerPosition.transform.position + playerDirection * 100; // spawn infront of player
		spawnPosition.y = position.y - 20; // spawns tree so it is flush with ground
		Quaternion rotation = new Quaternion(0,0,0,0);
		GameObject obj = Instantiate(prefab2, spawnPosition, rotation) as GameObject;
		obj.transform.localScale = new Vector3 (10, 10, 10);
		obj.AddComponent<DeleteGameObject> ();

	}
}
