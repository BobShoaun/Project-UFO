using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public Bullet bulletPrefab;
	public float fireRate = 2;
	private float nextFireTime;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 point = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 dir = (point - (Vector2) transform.position).normalized;
		transform.right = dir;
		//gun.LookAt ();

		// fire
		if (Input.GetMouseButton (0) && Time.time >= nextFireTime)
			Fire (dir);

	}

	public void Fire(Vector2 dir) {
		nextFireTime = Time.time + 1 / fireRate;
		Bullet bullet = Instantiate (bulletPrefab, transform.position, transform.rotation);
		bullet.gameObject.layer = gameObject.layer;
		bullet.Init (dir * 20);
	}

}
