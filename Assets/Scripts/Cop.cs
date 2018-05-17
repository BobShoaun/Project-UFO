using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cop : MonoBehaviour {

	public Transform head;
	public Transform ufo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//head.LookAt (ufo.position, -head.forward);
		head.rotation = Quaternion.Euler(new Vector3 (0, 0, Quaternion.LookRotation (ufo.position).eulerAngles.x));
		//head.rotation = Quaternion.LookRotation (ufo.position, Vector3.up);
	}

}
