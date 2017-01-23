using UnityEngine;
using System.Collections;

public class KeyboardController : MonoBehaviour {

	private KeyCode up = KeyCode.UpArrow;
	private KeyCode down = KeyCode.DownArrow;
	private KeyCode left = KeyCode.LeftArrow;
	private KeyCode right = KeyCode.RightArrow;

	private bool isInputUp = false;
	private bool isInputDown = false;
	private bool isInputRight = false;
	private bool isInputLeft = false;

	private Mover mover;

	// Use this for initialization
	void Start () {
		mover = this.GetComponent<Mover> ();
	}
	
	// Update is called once per frame
	void Update () {
		// re-initialisation
		isInputUp = false;
		isInputDown = false;
		isInputLeft = false;
		isInputRight = false;

		// input test
		if (!(Input.GetKey (left) && Input.GetKey (right))) {
			if (Input.GetKey (up)) {
				mover.Move("Up");
				isInputUp = true;
			}

			if (Input.GetKey (down)) {
				mover.Move("Down");
				isInputDown = true;
			}
		}
		if (!(Input.GetKey (left) && Input.GetKey (right))) {
			if (Input.GetKey (left)) {
				mover.Move("Left");
				isInputLeft = true;
			}

			if (Input.GetKey (right)) {
				mover.Move("Right");
				isInputRight = true;
			}
		}

		// Manage Multi input for direction and orientation purposes
		if (!isInputUp && !isInputDown && !isInputLeft && !isInputRight)
			mover.isAskingMoving = "";
		else if (mover.isAskingMoving == "" && isInputUp)
			mover.isAskingMoving = "Up";
		else if (mover.isAskingMoving == "" && isInputDown)
			mover.isAskingMoving = "Down";
		else if (mover.isAskingMoving == "" && isInputLeft)
			mover.isAskingMoving = "Left";
		else if (mover.isAskingMoving == "" && isInputRight)
			mover.isAskingMoving = "Right";
		else if (mover.isAskingMoving == "Up" && !isInputUp) {
			if(isInputRight && !isInputLeft)
				mover.isAskingMoving = "Right";
			else if(isInputLeft && !isInputRight)
				mover.isAskingMoving = "Left";
		}
		else if (mover.isAskingMoving == "Down" && !isInputDown) {
			if(isInputRight && !isInputLeft)
				mover.isAskingMoving = "Right";
			else if(isInputLeft && !isInputRight)
				mover.isAskingMoving = "Left";
		}
		else if (mover.isAskingMoving == "Left" && !isInputLeft) {
			if(isInputUp && !isInputDown)
				mover.isAskingMoving = "Up";
			else if(isInputDown && !isInputUp)
				mover.isAskingMoving = "Down";
		}
		else if (mover.isAskingMoving == "Right" && !isInputRight) {
			if(isInputUp && !isInputDown)
				mover.isAskingMoving = "Up";
			else if(isInputDown && !isInputUp)
				mover.isAskingMoving = "Down";
		}
	}
}
