using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add : MonoBehaviour {
	public GameObject prefab;
	public GameObject playerPosition;
	public Vector3 playerDirection;

	public KeyCode key;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (key)) {
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

		// Select the tree mesh from the list of possibles and place it
		TreeData treeData = prefab.GetComponent(typeof(TreeData)) as TreeData;
		GameObject tree = Instantiate(treeData.GetRandomTree(), spawnPosition, rotation);
		tree.transform.localScale = new Vector3(20, 20, 20);
		tree.AddComponent<DeleteGameObject>();

		// Add an Id to the tree and register the tree with the tracker
		tree.AddComponent<TreeId>();
		TreeId treeId = tree.GetComponent(typeof(TreeId)) as TreeId;
		treeId.id = RegisterTree(treeData);
	}

	// Registers the tree with the tracker so metrics can be updated
	private int RegisterTree(TreeData tree) {
		GameObject trackerHolder = GameObject.FindGameObjectWithTag("TreeTracker");

		TreeTracker treeTracker = trackerHolder.GetComponent(typeof(TreeTracker)) as TreeTracker;

		return treeTracker.AddTree(tree);
	}
}
