using UnityEngine;
using System.Collections;

public class TileCreater : MonoBehaviour {

	public Transform spriteA;
	public Transform spriteB; 

	public int mapWidth;
	public int mapHeight;

	public float upLimit;
	public float downLimit;
	public float rightLimit;
	public float leftLimit;

	// Use this for initialization
	void Start () {
		float wOrig = 0;
		float hOrig = 0;

		upLimit = float.NaN;
		downLimit = float.NaN;
		leftLimit = float.NaN;
		rightLimit = float.NaN;

		for (int w = 0; w <= mapWidth; w++) {
			for (int h = 0; h <= mapHeight; h++) {

				Transform test;

				if((w+h)%2 == 0)
					test = Instantiate(spriteA.transform) as Transform;
				else
					test = Instantiate(spriteB.transform) as Transform;

				SpriteRenderer sr = test.GetComponent<SpriteRenderer>();

				// spawn level at the middle...
				if(wOrig == 0)
					wOrig = - (sr.bounds.size.y*mapWidth/2);
				if(hOrig == 0)
					hOrig = - (sr.bounds.size.x*mapHeight)/2;

				test.position = new Vector3((sr.bounds.size.y*w) + wOrig, (sr.bounds.size.x*h) + hOrig, 1f);

				if(float.IsNaN(upLimit) && h == 0) {
					upLimit = hOrig;
				}

				if(float.IsNaN(downLimit) && h == mapHeight) {
					downLimit = (sr.bounds.size.x*(h+1)) + hOrig ;
				}

				if(float.IsNaN(leftLimit) && w == 0) {
					leftLimit = wOrig;
				}

				if(float.IsNaN(rightLimit) && w == mapWidth) {
					rightLimit = (sr.bounds.size.y*(w+1)) + wOrig;
				}

			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
