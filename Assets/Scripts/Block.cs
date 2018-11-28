using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block {

	Vector3 pos;
	GameObject gameBlock;
	string blockTag;

	public Block (GameObject block, Vector3 position, string tag) {
		gameBlock = block;
		pos = position;
		blockTag = tag;
	}

	public Vector3 getPosition() {
		return pos;
	}

	public string getTag() {
		return blockTag;
	}

	public void setTag(string newTag) {
		blockTag = newTag;
	}

	public GameObject getBlock() {
		return gameBlock;
	}
}
