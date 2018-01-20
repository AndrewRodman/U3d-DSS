using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteOnClick : MonoBehaviour {
	public static bool deleteBtnClicked = false;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Y)) {
			OnClick ();
		}
	}

	public void OnClick(){
		if (deleteBtnClicked == false) {
			deleteBtnClicked = true;
			GetComponent<UnityEngine.UI.Image>().color = Color.red; // chnage button to red
			Debug.Log ("Yes");
		}
		else if (deleteBtnClicked == true){
			deleteBtnClicked = false;
			GetComponent<UnityEngine.UI.Image>().color = Color.white; // chnage button to white
			Debug.Log ("No");
		}
	}
}
