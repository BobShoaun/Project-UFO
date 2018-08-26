using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cop : MonoBehaviour, IDamageable {

	public Transform gun;
	public Transform ufo;
	public float fireRate = 2;
	private float nextFireTime;
	public Bullet bulletPrefab;
	public int health = 30;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//head.LookAt (ufo.position, -head.forward);
		//head.rotation = Quaternion.Euler(new Vector3 (0, 0, Quaternion.LookRotation (ufo.position).eulerAngles.x));
		//head.rotation = Quaternion.LookRotation (ufo.position, Vector3.up);

		Vector2 dir = (Vector2) (ufo.position -  gun.position).normalized;
		gun.right = dir;


		if (Time.time >= nextFireTime) {
			nextFireTime = Time.time + 1 / fireRate;
			Bullet bullet = Instantiate (bulletPrefab, gun.position, gun.rotation);
			bullet.Init (GetComponent<CapsuleCollider2D> (), dir * 5);
			//bullet.transform.right = dir;
			//bullet.velocity = dir * 5;
			
			Destroy (bullet.gameObject, 5);
		}

		
		if (GetComponent<Rigidbody2D> ().velocity.sqrMagnitude > 100) {
			TakeDamage (20);
			print (GetComponent<Rigidbody2D> ().velocity.sqrMagnitude);

		}

	}

	public void TakeDamage (int damage) {
		health -= damage;
		if (health <= 0)
			Destroy (gameObject);
	}

}
