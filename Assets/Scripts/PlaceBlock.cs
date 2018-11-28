using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBlock : MonoBehaviour {

	public GameObject meshObject;
	RaycastHit hit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector3 blockPosition = new Vector3 (Mathf.Ceil (hit.point.x), Mathf.Ceil (hit.point.y), Mathf.Ceil (hit.point.z));
			Instantiate (meshObject, blockPosition + transform.position, Quaternion.identity);
		}
	}
}
