using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 20.0f;

	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < 0) {
			transform.position = new Vector3 (0, 0.06f, 0);
		}
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		print (h + v);
		Vector3 movment = new Vector3 (h, 0, v);
		rb.AddForce (movment.normalized * speed);
	}
}
