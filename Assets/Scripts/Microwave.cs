using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microwave : MonoBehaviour {

	bool hasCollided = false;
	string labelText = "";

	void onGUI(){
		if (hasCollided == true) {
			GUI.Box (new Rect (140, Screen.height - 50, Screen.width - 300, 120), (labelText));
		}
	}

	void OnTriggerEnter(Collider c){
		Debug.Log ("Player has entered the trigger");
		if (c.gameObject.tag == "FPSController" || c.gameObject.tag == "FirstPersonCharacter") {
			hasCollided = true;
			labelText = "Hit E to use microwave!";
		}
	}

	void OnTriggerExit(Collider other){
		Debug.Log ("Player has exit the trigger");
		hasCollided = false;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
