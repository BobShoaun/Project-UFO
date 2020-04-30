using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cop : MonoBehaviour, IDamageable {

	public Transform gun;
	public Transform target;

	public float fireRate = 1;
	private float nextFireTime = 2;
	public Bullet bulletPrefab;
	public int health = 30;

    [SerializeField] private float speed = 0.5f;

    public Vector2 targetPosition;

    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Move());

	}

    IEnumerator Move()
    {
        Vector2 initPos = transform.position;
        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            rb.MovePosition(Vector2.Lerp(initPos, targetPosition, i * speed));
            yield return null;
        }
    }

    void FixedUpdate()
    {
        
        //rb.MovePosition(targetPosition * Time.fixedDeltaTime);
        
    }
	
	// Update is called once per frame
	void Update () {
		//head.LookAt (ufo.position, -head.forward);
		//head.rotation = Quaternion.Euler(new Vector3 (0, 0, Quaternion.LookRotation (ufo.position).eulerAngles.x));
		//head.rotation = Quaternion.LookRotation (ufo.position, Vector3.up);

		var dir = (Vector2) (target.position -  gun.position).normalized;
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
			//print (GetComponent<Rigidbody2D> ().velocity.sqrMagnitude);
		}

	}

	public void TakeDamage (int damage) {
		health -= damage;
        if (health <= 0)
            Die();
	}

    public void Die ()
    {
        Destroy(gameObject);
        Player.Instance.Score += 10;
    }

}
