using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour, IDamageable {

	public float moveSpeed;
	public float rotateSpeed;
	public float suckStrength;
    public GameObject tractorBeam;

    [SerializeField] private Transform bombDropZone;
    [SerializeField] private Bomb bombPrefab;

    public int Health = 100;

    private Rigidbody2D rb;
    private bool inputDetected;

	private void Start () {
		rb = GetComponent<Rigidbody2D> ();
		
	}

	private void Update () {
		inputDetected = Input.GetAxis ("Horizontal") > 0 ||  Input.GetAxis ("Horizontal") < 0;

		float rotation = Mathf.MoveTowards (rb.rotation, Input.GetAxis ("Horizontal") * -30, rotateSpeed * Time.deltaTime);
		rb.MoveRotation (rotation);

		if (inputDetected) {
			//transform.Translate (Vector3.right * Input.GetAxis ("Horizontal"));
			//transform.position += Vector3.right * Input.GetAxis ("Horizontal");
			//rb.MovePosition (transform.position + Vector3.right * Input.GetAxis ("Horizontal"));
			//rb.velocity = Vector3.right * Input.GetAxis ("Horizontal") * speed;
			rb.MovePosition (rb.position + Vector2.right * Input.GetAxis ("Horizontal") * moveSpeed * Time.deltaTime);

			
			//rb.MoveRotation (rb.rotation + Input.GetAxis ("Horizontal") * rotateSpeed * Time.deltaTime);
			//rb.angularVelocity = Input.GetAxis ("Horizontal") * rotateSpeed;
			//rb.AddTorque (Input.GetAxis ("Horizontal") * rotateSpeed, ForceMode2D.Force);
		} else {
			//rb.MoveRotation (0);
		}


		tractorBeam.SetActive (Input.GetKey (KeyCode.Space));

		if (Input.GetKey (KeyCode.A)) {
			//rb.AddForce (Vector2.left * speed, ForceMode2D.Force);
		}
        if (Input.GetKeyDown(KeyCode.A))
        {
            //	rb.AddTorque (-10);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
            DeployBomb();

	}

    private void DeployBomb()
    {
        Instantiate(bombPrefab, bombDropZone.position, Quaternion.identity);
    }

	private void FixedUpdate () {
		if (inputDetected) {
			//rb.AddForce (Vector2.right * Input.GetAxis("Horizontal") * speed, ForceMode2D.Force);
			//rb.AddTorque (10);
			//rb.MoveRotation (20);

		}
	}

	public void TakeDamage (int damage) {
		Health -= damage;
		if (Health <= 0)
			Destroy (gameObject);
	}

	void OnTriggerStay2D (Collider2D collider2D) {
		//Debug.Log ((transform.position - collider2D.transform.position).normalized);
		//collider2D.GetComponent<Rigidbody2D> ().AddForce ((transform.position - collider2D.transform.position) * suckStrength, ForceMode2D.Impulse);
	}

}