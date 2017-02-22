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


	// is trigguer for object in collision with Player
	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log("OH LALALALALA");
	}

	// is trigger for player if the object have "is trigger enabled"
	void OnTriggerEnter2D(Collider2D coll) {
		Debug.Log ("LandAmbassador >> OnTriggerEnter2D >> " + coll.gameObject.name + " / " + coll.gameObject.tag);

		if (coll.gameObject.tag == "Wall")
			playerMover.isBlocked = true;
	}

	void OnTriggerExit2D(Collider2D coll) {

		Debug.Log ("LandAmbassador >> OnTriggerExit2D >> " + coll.gameObject.name + " / " + coll.gameObject.tag);

		if (coll.gameObject.tag == "Wall")
			playerMover.isBlocked = false;
	}
}
