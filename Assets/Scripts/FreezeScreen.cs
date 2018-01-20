using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeScreen : MonoBehaviour {

	public static bool freezeScreen=false;
	bool isOpen;
	// Use this for initialization
	void Start () {

		isOpen = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (isOpen == false) {
				freezeScreen = true;
				Debug.Log (freezeScreen);
				//Screen.lockCursor = false;
				//Cursor.visible = true; 
				isOpen = true;

			} else {
				isOpen = false;
				freezeScreen = false;
				Debug.Log (freezeScreen);
			}

		}


	}
}
