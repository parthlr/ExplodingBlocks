using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlockPlacer : MonoBehaviour {
	
	static BlockPlacer obj;
	public GameObject blockPrefab;
	ArrayList blocks;
	public float range = 7f;

	void Start () {
		blocks = new ArrayList();
		BlockPlacer.obj = this;
	}

	void Update () {			
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitInfo = new RaycastHit ();
		bool hit = Physics.Raycast (ray, out hitInfo, range);

		if (hit) {
			Vector3 backup = ray.GetPoint (hitInfo.distance - 0.2f);

			Vector3 blockLocation = new Vector3 (Mathf.RoundToInt (backup.x), Mathf.RoundToInt(backup.y), Mathf.RoundToInt (backup.z));

			if (Input.GetMouseButtonDown (0)) {
				GameObject block = (GameObject)GameObject.Instantiate (blockPrefab, blockLocation, blockPrefab.transform.rotation);
				block.GetComponent<FixedJoint> ().connectedBody = hitInfo.rigidbody;
				Block addBlock = new Block (block, block.transform.position, "Instantiated");
				blocks.Add (addBlock);
			}
			if (Input.GetMouseButtonDown (1)) {
				GameObject block = hitInfo.transform.gameObject;
				if (block.tag.Equals ("Block")) {
					findBlock(block).setTag("Removed");
					GameObject.Destroy (block);
				}
			}
		}

		if (Input.GetKey (KeyCode.Space)) {
			uncheckKinematic ();
		}
	}

	Block findBlock(GameObject currentBlock) {
		for (int i = 0; i < blocks.Count; i++) {
			Block block = (Block)blocks [i];
			if (block.getBlock () == currentBlock) {
				return block;
			}
		}
		return null;
	}

	public void uncheckKinematic() {
		for (int i = 0; i < blocks.Count; i++) {
			Block block = (Block)blocks [i];
			if (block.getTag().Equals("Instantiated")) {
				block.getBlock ().GetComponent<Rigidbody> ().isKinematic = false;
			}
		}
	}
}