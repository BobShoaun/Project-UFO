using System.Collections;
using Doxel.Utility;
using UnityEngine;

public class Cop : MonoBehaviour, IDamageable {

	[SerializeField] private Collectible coinPrefab;

	public Transform gun;
	public Transform target;

	public float fireRate = 1;
	private float nextFireTime = 2;
	public Bullet bulletPrefab;
	public int health = 30;

    [SerializeField] private float speed = 0.5f;
	[SerializeField] private float invulnerabilityCooldown = 3;
 
    public Vector2 targetPosition;

    private Rigidbody2D rb;

	private void Start () {

		nextFireTime = Time.time + invulnerabilityCooldown;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Move());

	}

    private IEnumerator Move()
    {
       // Vector2 initPos = transform.position;
    //    for (float i = 0; i < 1; i += Time.deltaTime) {
      //      rb.MovePosition(Vector2.Lerp(initPos, targetPosition, i * speed));
     //       yield return null;
     //   }
		yield return Utility.Transition (result => transform.position = result, 3, transform.position, targetPosition);
    }

	private void Update () {
		//head.LookAt (ufo.position, -head.forward);
		//head.rotation = Quaternion.Euler(new Vector3 (0, 0, Quaternion.LookRotation (ufo.position).eulerAngles.x));
		//head.rotation = Quaternion.LookRotation (ufo.position, Vector3.up);

		var dir = (Vector2) (target.position -  gun.position).normalized;
		gun.right = dir;

		if (Time.time >= nextFireTime)
			Fire (dir);
	
		
		if (rb.velocity.sqrMagnitude > 100)
			TakeDamage (20);

	}

	public void TakeDamage (int damage) {
		health -= damage;
        if (health <= 0)
            Die();
	}

    public void Die () {
        Destroy(gameObject);
        Player.Instance.Score += 10;
		Instantiate (coinPrefab, transform.position, Quaternion.identity);
	}

	public void Fire (Vector2 dir) {
		nextFireTime = Time.time + 1 / fireRate;
		Bullet bullet = Instantiate (bulletPrefab, gun.position, gun.rotation);
		bullet.gameObject.layer = gameObject.layer;
		bullet.Init (dir * 5);
	}

}
