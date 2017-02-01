using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Baillyje.Land;

public class LevelContructor : MonoBehaviour {

	public GameObject EdgeContainer;

	private Level level;

	// Use this for initialization
	void Start () {

		List<Vector2> testA = new List<Vector2>();
		testA.Add(new Vector2(0, 100));
		testA.Add(new Vector2(200, 100));

		List<Vector2> testB = new List<Vector2>();
		testB.Add(new Vector2(0, 100));
		testB.Add(new Vector2(0, 500));

		List<Vector2> testC = new List<Vector2>();
		testC.Add(new Vector2(0, 500));
		testC.Add(new Vector2(200, 500));

		List<Vector2> testD = new List<Vector2>();
		testD.Add(new Vector2(200, 500));
		testD.Add(new Vector2(200, 100));

		level = new Level();

		List<EdgeData> testEdges = new List<EdgeData>();
		testEdges.Add(new EdgeData("A", testA, false));
		testEdges.Add(new EdgeData("B", testB, false));
		testEdges.Add(new EdgeData("C", testC, false));
		testEdges.Add(new EdgeData("D", testD, false));
		level.edges = testEdges;

		DrawLevel();
	}

	// Update is called once per frame
	void Update () {

	}

	private void DrawLevel()
	{
		DrawEdges();

	}

	private void DrawEdges()
	{
		foreach(EdgeData edgeData in level.edges)
		{
			Debug.Log ("LevelContructor >> DrawEdge >> " + edgeData.name);

			new Edge (edgeData, EdgeContainer.transform);
		}
	}
}
