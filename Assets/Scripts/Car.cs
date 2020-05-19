using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Bomb, IDamageable
{

	[SerializeField] private Collectible coinPrefab;
    [SerializeField] private float speed;
    [SerializeField] private float stoppingThreshold = 0.01f;
    [SerializeField] private Transform explosionPoint;

    private int health = 200;

    public Vector2 targetPosition;

    private IEnumerator Start2()
    {
        
        var direction = targetPosition - (Vector2) transform.position;
        direction.Normalize();

        while ((targetPosition - (Vector2)transform.position).sqrMagnitude > stoppingThreshold)
        {
            
            transform.Translate(direction * speed * Time.deltaTime);
            yield return null;
        }
        print("STOP");
    }

    protected override IEnumerator Start()
    {
        print("tEts)");

        var rb = GetComponent<Rigidbody2D>();

        FlipSprite();

        Vector2 initPos = transform.position;
        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            rb.MovePosition(Vector2.Lerp(initPos, targetPosition, i * speed));
            yield return null;
        }
    }

    private void FlipSprite()
    {
        if (targetPosition.x > transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void Update()
    {
        
    }

    public void TakeDamage(int damage) {
        health -= damage;
		if (health <= 0) {
			Explode (explosionPoint.position);
			Instantiate (coinPrefab, transform.position, Quaternion.identity);
			Instantiate (coinPrefab, transform.position, Quaternion.identity);
		}
    }


}
