using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public void Init (Collider2D col, Vector2 velocity) {
		Physics2D.IgnoreCollision (GetComponent<Collider2D> (), col);
		transform.right = velocity;
		GetComponent<Rigidbody2D> ().velocity = velocity;
	}	
	
	private void OnCollisionEnter2D (Collision2D collision) {
		//if (collision.gameObject.layer == LayerMask.NameToLayer ("Player"))
		print (collision.gameObject.name);
		if (collision.gameObject.GetComponent<IDamageable> () != null)
			collision.gameObject.GetComponent<IDamageable> ().TakeDamage (10);
		Destroy (gameObject);
	}

}

public interface IDamageable {

	void TakeDamage (int damage);

}
