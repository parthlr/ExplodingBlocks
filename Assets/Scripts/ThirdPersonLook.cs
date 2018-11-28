using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonLook : MonoBehaviour {

	public float speed;
	public float zoomDistance;
	public GameObject target;

	public float flySpeed = 1f;

	public float maxToClamp;

	public GameObject referenceObject;

	public void Start() {
		transform.LookAt (target.transform);
	}

	public void Update() {
		RaycastHit hit;
		Ray forwardRay = new Ray (transform.position, transform.forward);

		if (Physics.Raycast (forwardRay, out hit, 10000f)) {
			transform.LookAt (hit.point);
		}
		zoomDistance += Input.GetAxis("Mouse ScrollWheel");
		zoomDistance = Mathf.Clamp(zoomDistance, -maxToClamp, maxToClamp);
		float translate = Mathf.Min(Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")), maxToClamp - Mathf.Abs(zoomDistance));
		transform.Translate(0,0,translate * speed * Mathf.Sign(Input.GetAxis("Mouse ScrollWheel")));
		if (Input.GetMouseButton (1)) {
			transform.RotateAround (target.transform.position, transform.right, -Input.GetAxis ("Mouse Y") * speed);
			transform.RotateAround (target.transform.position, transform.up, Input.GetAxis ("Mouse X") * speed);
		}
		transform.Translate(referenceObject.transform.forward * flySpeed * Input.GetAxis("Vertical"), Space.World);
		transform.Translate(referenceObject.transform.right * flySpeed * Input.GetAxis("Horizontal"), Space.World);
		referenceObject.transform.eulerAngles = new Vector3 (0f, transform.eulerAngles.y, 0f);
	}
}
