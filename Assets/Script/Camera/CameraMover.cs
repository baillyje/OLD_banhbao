using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {

	//public Transform target;

	public float dampTime = 0.3f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;
	public Transform area;

	TileCreater tileCreater;

	// Use this for initialization
	void Start () {
		tileCreater = area.GetComponent<TileCreater> ();
		//this.transform.LookAt(target);


		Debug.Log ("Screen width >> " + Screen.width);
		Debug.Log ("Screen height >> " + Screen.height);
	}

	// Update is called once per frame
	void Update () {
		//this.transform.position = new Vector3(target.position.x, target.position.y, this.transform.position.z);

		Vector3 worldPoint = GetComponent<Camera>().WorldToViewportPoint(target.position);
		Vector3 localPoint = new Vector3 (target.position.x, target.position.y, target.position.z);

	//	Debug.Log (localPoint.ToString());
	//	Debug.Log (Screen.width + "x" + Screen.height);

		if (localPoint.x < 12.8f)
			localPoint.x = 12.8f;

		if (localPoint.y < 9.5f)
			localPoint.y = 9.5f;
		/*
		if (localPoint.y < Screen.height / 200)
			localPoint.y = Screen.height / 200;

		if (localPoint.y < Screen.height / 200)
			localPoint.y = Screen.height / 200;
		*/
		Vector3 delta = localPoint - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, worldPoint.z)); //(new Vector3(0.5, 0.5, point.z));
		Vector3 destination = transform.position + delta;
		transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);

		//TODO: Modify this in order to limit camara move to feet the area limits.



		//Debug.Log(tileCreater.upLimit + " " + tileCreater.downLimit + " " + tileCreater.leftLimit + " " + tileCreater.rightLimit);

	}
}
