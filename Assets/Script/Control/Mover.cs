using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mover : MonoBehaviour {

	public float factor = 45;

	public string isAskingMoving = "";

	public float minAccelerationRate = 1.0f;
	public float maxAccelerationRate = 2.0f;

	public bool isBlocked;

	private List<string> directions = new List<string>();
	private Dictionary<string, float> currentAcceleration = new Dictionary<string, float>();
	private Dictionary<string, bool> isMovingThisDirection = new Dictionary<string, bool>();

	//private string orientation;

	// Use this for initialization
	void Start () {

		isBlocked = false;

		directions.Add("Left");
		directions.Add("Right");
		directions.Add("Up");
		directions.Add("Down");

		//orientation = "Up";

		foreach (string direction in directions) {
			currentAcceleration.Add (direction, minAccelerationRate);
			isMovingThisDirection.Add (direction, false);
		}
	}

	// Update is called once per frame
	void Update () {
		foreach (string direction in directions)
		{
			if(isAskingMoving == ""){
				isMovingThisDirection[direction] = false;
			}

			if(isMovingThisDirection[direction] == true){

				currentAcceleration[direction] += 0.1f;

				if( currentAcceleration[direction] > maxAccelerationRate)
					currentAcceleration[direction] = maxAccelerationRate;
			}
			else {
				currentAcceleration[direction] = minAccelerationRate;
			}
		}
	}

	public void Move(string direction) {


		if(isBlocked == false)
			switch (direction) {
				case "Up" :
					Up ();
					break;
				case "Down" :
					Down ();
					break;
				case "Left" :
					Left ();
					break;
				case "Right" :
					Right ();
					break;
			}

		Rotate (isAskingMoving);
	}

	public void Rotate(string orientation){

		switch (orientation) {
			case "Up" :
				OrientUp ();
				break;
			case "Down" :
				OrientDown ();
				break;
			case "Left" :
				OrientLeft ();
				break;
			case "Right" :
				OrientRight ();
				break;
		}
	}

	public void Up() {
		gameObject.transform.position += (Vector3.up / factor) * GetAcceleration("Up") ;
	}

	public void Down() {
		gameObject.transform.position += (Vector3.down / factor) * GetAcceleration("Down");
	}

	public void Left() {
		gameObject.transform.position += (Vector3.left / factor) * GetAcceleration("Left");
	}

	public void Right() {
		gameObject.transform.position += (Vector3.right / factor) * GetAcceleration("Right");
	}

	private float GetAcceleration(string direction){
		isMovingThisDirection [direction] = true;

		return currentAcceleration[direction];
	}

	public void OrientUp() {
		gameObject.transform.eulerAngles = Vector3.forward * 0;
	}

	public void OrientDown() {
		gameObject.transform.eulerAngles = Vector3.forward * 180;
	}

	public void OrientLeft() {
		gameObject.transform.eulerAngles = Vector3.forward * 90;
	}

	public void OrientRight() {
		gameObject.transform.eulerAngles = Vector3.forward * 270;
	}
}
