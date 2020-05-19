using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    [SerializeField] private float timer = 3;
    [SerializeField] private float explosionRadius = 0.5f;
    [SerializeField] private int damage = 20;
    [SerializeField] private Explosion explosionPrefab;

	protected virtual IEnumerator Start () {

        if (timer < 0) // dont detonate by itself
            yield break;

		yield return new WaitForSeconds (timer);

        Explode();
	}

    public void Explode()
    {
        Explode(transform.position);
    }

    public void Explode(Vector2 point)
    {
        Destroy(gameObject);
        
        var hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (var hit in hits)
        {
            
            hit.GetComponent<IDamageable>()?.TakeDamage(damage);
        }

        Instantiate(explosionPrefab, point, Quaternion.identity);
    }

}
