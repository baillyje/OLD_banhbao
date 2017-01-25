using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Baillyje.Land;

public class LevelContructor : MonoBehaviour {

	public int tileSize = 10;

	private Level level;

	// Use this for initialization
	void Start () {

		level = new Level();
		level.edges = new Edge[] {
			new Edge(new Vector2(4, 2), new Vector2(6, 2), false)
		};

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
			edge_go.transform.position = new Vector3(edge.point1.x * tileSize, edge.point1.y * tileSize, 10);
			LineRenderer edgeRenderer = edge_go.AddComponent<LineRenderer>() as LineRenderer;
			edgeRenderer.SetPositions(new Vector3[] {
				new Vector3(edge.point1.x * tileSize, edge.point1.y * tileSize, 10),
				new Vector3(edge.point2.x * tileSize, edge.point2.y * tileSize, 10)
			});

			edge_go.transform.parent = this.transform;

		}


	}
}
