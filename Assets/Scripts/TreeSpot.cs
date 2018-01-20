using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpot : MonoBehaviour {
	public GameObject treeSpot;

	public GameObject playerPosition;
	public Vector3 playerDirection;
	// Use this for initialization
	void Start () {
		treeSpot.SetActive (true);
	}

	// Update is called once per frame
	void Update () {
		if (ToggleTreeHighlight.isON == true) {
			treeSpot.SetActive (true);
		}
		else if (ToggleTreeHighlight.isON == false)
			treeSpot.SetActive (false);
		if(GameObject.FindGameObjectWithTag("Player"))
		{
		playerPosition = GameObject.FindGameObjectWithTag("Player");
		Vector3 position = playerPosition.transform.position;
		playerDirection = playerPosition.transform.forward;
		Vector3 spawnPosition = playerPosition.transform.position + playerDirection * 100; // spawn infront of player
		spawnPosition.y = position.y - 20; // spawns tree so it is flush with ground
		Quaternion rotation = new Quaternion(0,0,0,0);
		treeSpot.transform.position = new Vector3(spawnPosition.x,spawnPosition.y,spawnPosition.z);
		}
	}
}
