using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds (3);
		 RaycastHit[] hits = null;
	//	if (Physics2D.CircleCast (transform.position, 3, Vector2.left, 3, 0, hits) > 0) {

	//	}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
