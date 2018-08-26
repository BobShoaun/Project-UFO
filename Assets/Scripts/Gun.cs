using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public Bullet bulletPrefab;
	public float fireRate = 2;
	private float nextFireTime;

	public Collider2D ignore;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 point = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 dir = (point - (Vector2) transform.position).normalized;
		transform.right = dir;
		//gun.LookAt ();

		// fire
		if (Input.GetMouseButton (0) && Time.time >= nextFireTime) {
			nextFireTime = Time.time + 1 / fireRate;

			Bullet bullet = Instantiate (bulletPrefab, transform.position, transform.rotation);
		//	bullet.transform.right = dir;
			bullet.Init ( ignore, dir * 20);
		//	bullet.velocity = dir * 20;
			Destroy (bullet.gameObject, 5);

		}
	}
}
