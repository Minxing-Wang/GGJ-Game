using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Player : MonoBehaviour {

	public float speed;
	public int hp; 
	public Text hpText; 

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
		float moveHorizontal = Input.GetAxis ("Horizontal")  * Time.deltaTime * speed;
		float moveVertical = Input.GetAxis ("Vertical") * Time.deltaTime * speed;

		transform.Translate (0, 0, moveVertical);
		transform.Translate (moveHorizontal, 0, 0 );
	}
}
