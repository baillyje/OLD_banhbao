using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGenerator : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Spawn (new Vector2(20, 50));

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Spawn (Vector2 pos) {
		this.transform.position = new Vector3 (pos.x, pos.y, 0);
	}
}
