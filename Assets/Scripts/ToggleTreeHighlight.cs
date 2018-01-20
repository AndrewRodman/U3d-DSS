using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTreeHighlight : MonoBehaviour {

	public static bool isON=true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.H)) {
			OnClick ();
		}
	}

	public void OnClick(){

		if (isON == true) {
			isON = false;
		} else if(isON == false)
			isON = true;
	}
}
