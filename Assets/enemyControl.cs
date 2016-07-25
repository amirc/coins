using UnityEngine;
using System.Collections;

public class enemyControl : MonoBehaviour {
	public GameObject target;
	public float speed = 10;
	public float attackRange = 0;
	public float aimTime = 0.5f;

	private Rigidbody rb;
	private float nextAttack;

	private Vector3 nextAttackDirc;
	private bool aimed;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		nextAttack = Time.time + Random.value * attackRange;
		aimed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!aimed && nextAttack - aimTime < Time.time) {
			nextAttackDirc = target.transform.position - transform.position;
			nextAttackDirc.Normalize ();
			aimed = true;
		}

		if (nextAttack < Time.time && aimed) {
			print("Attak!!");
			rb.AddForce (nextAttackDirc.normalized * speed);

			// Setting next attack:
			nextAttack = Time.time + Random.value * attackRange + 1;
			aimed = false;
		}
	}
}
