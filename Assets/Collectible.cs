using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

	private void Start () {
		Destroy (gameObject, 10);
	}

	private void OnCollisionEnter2D (Collision2D collision) {
		UFO ufo = collision.gameObject.GetComponent<UFO> ();
		if (ufo) {
			Destroy (gameObject);
		}

	}

}
