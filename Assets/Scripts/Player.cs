using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Player : MonoBehaviour {

	public float speed;
	public int hp; 
	public Text hpText; 
	public SmoothMouseLook mouseLook;


	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		rb.constraints = RigidbodyConstraints.FreezeRotation;
		hp = 100;
		hpText.text = "Health: " + hp.ToString(); 

	}

	void Update ()
	{
		if (Input.GetAxis ("Vertical") < 0) { // moving backwards ( w button ) 
			float moveX = Mathf.Cos (mouseLook.transform.eulerAngles.y * Mathf.PI / 180) * speed * -1;
			float moveY = Mathf.Sin (mouseLook.transform.eulerAngles.y * Mathf.PI / 180) * speed * -1; 
			transform.Translate (moveY, 0, moveX);
		} else if (Input.GetAxis ("Vertical") > 0) { // moving forward ( w button ) 
			float moveX = Mathf.Cos (mouseLook.transform.eulerAngles.y * Mathf.PI / 180 * -1) * speed; 
			float moveY = Mathf.Sin (mouseLook.transform.eulerAngles.y * Mathf.PI / 180) * speed; 
			transform.Translate (moveY, 0, moveX); 
		} else if (Input.GetAxis ("Horizontal") < 0) { // moving left
			float moveX = Mathf.Cos (mouseLook.transform.eulerAngles.y * Mathf.PI / 180 - (Mathf.PI / 2)) * speed; 
			float moveY = Mathf.Sin (mouseLook.transform.eulerAngles.y * Mathf.PI / 180 - (Mathf.PI / 2)) * speed; 
			transform.Translate (moveY, 0, moveX); 
		} else if (Input.GetAxis ("Horizontal") > 0) { // moving right
			float moveX = Mathf.Cos (mouseLook.transform.eulerAngles.y * Mathf.PI / 180 + (Mathf.PI / 2)) * speed; 
			float moveY = Mathf.Sin (mouseLook.transform.eulerAngles.y * Mathf.PI / 180 + (Mathf.PI / 2)) * speed; 
			transform.Translate (moveY, 0, moveX); 
		}
			
	}
}
