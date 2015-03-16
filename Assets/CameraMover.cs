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
	}
	
	// Update is called once per frame
	void Update () {
		//this.transform.position = new Vector3(target.position.x, target.position.y, this.transform.position.z);

		Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
		Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
		Vector3 destination = transform.position + delta;
		transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);

		//TODO: Modify this in order to limit camara move to feet the area limits.

		//Debug.Log(tileCreater.upLimit + " " + tileCreater.downLimit + " " + tileCreater.leftLimit + " " + tileCreater.rightLimit);

	}
}
