using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCannonBall : MonoBehaviour {

	public GameObject cannonBall;
	public ParticleSystem[] particles;
	public float force;

	void Start () {
		for (int i = 0; i < particles.Length; i++) {
			particles [i].Stop ();
		}
	}

	void Update () {
		if (Input.GetKeyUp (KeyCode.Space)) {
			Fire ();
		}
	}

	public void Fire() {
		for (int i = 0; i < particles.Length; i++) {
			particles [i].Play ();
		}
		GameObject ball = Instantiate (cannonBall, cannonBall.transform.position, Quaternion.identity, transform);
		ball.GetComponent<MeshRenderer> ().enabled = true;
		ball.GetComponent<Rigidbody> ().isKinematic = false;
		ball.GetComponent<Rigidbody>().velocity = transform.up * force;
	}
}
