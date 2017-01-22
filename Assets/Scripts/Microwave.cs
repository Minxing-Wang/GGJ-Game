using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Microwave : MonoBehaviour {

	bool hasCollided = false;
	string labelText = "";
	int fontSize = 20;
	public bool state = false;
	public int hits = 0;
	public Text text;

	void Start(){
		SetCountText ();
	}

	void OnTriggerEnter(Collider c){
		if (c.gameObject.tag == "Player") {
			Debug.Log("Player is here");
			hasCollided = true;
			labelText = "Hit E to hit microwave!";
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

	void Update () {
		if (Input.GetKeyUp (KeyCode.E)) {
			state = true;
			SetCountText ();
			hits += 1;
		}
	}

	void SetCountText ()
	{
		text.text = "Hits: " + hits.ToString ();
		if (hits >= 100)
		{
			text.text= "Nice Waste of Time LOL";
		}
	}
}
