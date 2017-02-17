using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandAmbassador : MonoBehaviour {

	private Mover playerMover;

	// Use this for initialization
	void Start () {
		playerMover = GetComponent<Mover>();
	}

	// Update is called once per frame
	void Update () {


	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Wall")
			playerMover.isBlocked = true;
	}

	void OnCollisionExit2D(Collision2D coll) {
		if (coll.gameObject.tag == "Wall")
			playerMover.isBlocked = false;
	}
}
