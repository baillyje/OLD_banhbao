using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Baillyje.Land;

public class LevelContructor : MonoBehaviour {

	public float tileSize = 1f;

	private Level level;

	// Use this for initialization
	void Start () {

		List<Vector2> test = new List<Vector2>();
		test.Add(new Vector2(4, 2));
		test.Add(new Vector2(6, 2));

		List<Vector2> test2 = new List<Vector2>();
		test2.Add(new Vector2(4, 0));
		test2.Add(new Vector2(4, 2));

		level = new Level();

		List<Edge> testEdges = new List<Edge>();
		testEdges.Add(new Edge(test, false));
		testEdges.Add(new Edge(test2, false));
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
		foreach(Edge edge in level.edges) {

			GameObject edge_go = new GameObject();
			EdgeCollider2D edgeCollider = edge_go.AddComponent<EdgeCollider2D>() as EdgeCollider2D;

			List<Vector2> pointInGameWorld = new List<Vector2>();
			foreach(Vector2 point in edge.points)
			{
				pointInGameWorld.Add (point * tileSize);
			}

			Debug.Log (tileSize + " / " + pointInGameWorld.ToArray ()[0].x);
			edgeCollider.points = pointInGameWorld.ToArray();

			edge_go.transform.parent = this.transform;
		}


	}
}
