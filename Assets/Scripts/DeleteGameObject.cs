using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteGameObject : MonoBehaviour {
	


	// Use this for initialization
	// void Start () {
		
	// }
	
	// // Update is called once per frame
	// void Update () {
		
	// }

	void OnMouseDown(){
		if (DeleteOnClick.deleteBtnClicked == true) {
			Debug.Log ("Down");

			TreeId treeId = this.GetComponent(typeof(TreeId)) as TreeId;

			DeregisterTree(treeId.id);

			Destroy (this.gameObject);
		}

	}

	void DeregisterTree(int id) {
		GameObject trackerHolder = GameObject.FindGameObjectWithTag("TreeTracker");

		TreeTracker treeTracker = trackerHolder.GetComponent(typeof(TreeTracker)) as TreeTracker;

		treeTracker.RemoveTree(id);
	}


}
