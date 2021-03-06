using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private void Start () {
		Destroy (gameObject, 5);
	}

	public void Init (Vector2 velocity) {
		//Physics2D.IgnoreCollision (GetComponent<Collider2D> (), col);
		transform.right = velocity;
		GetComponent<Rigidbody2D> ().velocity = velocity;
	}	
	
    
	private void OnCollisionEnter2D (Collision2D collision) {
        
		//if (collision.gameObject.layer == LayerMask.NameToLayer ("Player"))
		//print (collision.gameObject.name);
		collision.gameObject.GetComponent<IDamageable> ()?.TakeDamage (10);
		Destroy (gameObject);
	}



}

public interface IDamageable {

	void TakeDamage (int damage);

}
