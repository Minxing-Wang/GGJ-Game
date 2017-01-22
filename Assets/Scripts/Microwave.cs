using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microwave : MonoBehaviour {

	bool hasCollided = false;
	string labelText = "";
	int fontSize = 20;


	void OnTriggerEnter(Collider c){
		if (c.gameObject.tag == "Player") {
			Debug.Log("Player is here");
			hasCollided = true;
			labelText = "Hit E to use microwave!";
		}
	}

	void OnGUI(){
		GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = fontSize;
		if (hasCollided == true) {
			GUI.Box(new Rect(140,Screen.height-50,Screen.width-300,120), labelText);
		}
	}

	void OnTriggerExit(Collider other){
		Debug.Log ("Player has exit the trigger");
		hasCollided = false;
	}
}
