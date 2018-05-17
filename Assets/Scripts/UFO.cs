using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour {

	private Rigidbody2D rb;
	public float speed;
	public float suckStrength;
	private bool inputDetected;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		inputDetected = Input.GetAxis ("Horizontal") > 0 ||  Input.GetAxis ("Horizontal") < 0;

		if (Input.GetKey (KeyCode.A)) {
			//rb.AddForce (Vector2.left * speed, ForceMode2D.Force);
		}
		if (Input.GetKeyDown (KeyCode.A)) {
		//	rb.AddTorque (-10);
		}
		if (inputDetected) {
			//transform.Translate (Vector3.right * Input.GetAxis ("Horizontal"));
			transform.position += Vector3.right * Input.GetAxis ("Horizontal");
		}
	}

	private void FixedUpdate () {
		if (inputDetected) {
			//rb.AddForce (Vector2.right * Input.GetAxis("Horizontal") * speed, ForceMode2D.Force);
			//rb.AddTorque (10);
			//rb.MoveRotation (20);

		}
	}

	void OnTriggerStay2D (Collider2D collider2D) {
		Debug.Log ((transform.position - collider2D.transform.position).normalized);
		collider2D.GetComponent<Rigidbody2D> ().AddForce ((transform.position - collider2D.transform.position) * suckStrength, ForceMode2D.Impulse);
	}

}