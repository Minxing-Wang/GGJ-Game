using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float speed;

	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		rb.constraints = RigidbodyConstraints.FreezeRotation;
	}

	void Update ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal")  * Time.deltaTime * speed;
		float moveVertical = Input.GetAxis ("Vertical") * Time.deltaTime * speed;

		transform.Translate (0, 0, moveVertical);
		transform.Translate (moveHorizontal, 0, 0 );
	}
}
