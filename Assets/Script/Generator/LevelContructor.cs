﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Baillyje.Land;

public class LevelContructor : MonoBehaviour {

	public GameObject EdgeContainer;
	public GameObject TileContainer;

	public Sprite ed_tileSprite;

	private Level level;

	// Use this for initialization
	void Start () {

		List<Vector2> testA = new List<Vector2>();
		testA.Add(new Vector2(10, 0));
		testA.Add(new Vector2(50, 0));
		testA.Add(new Vector2(50, 10));

		List<Vector2> testB = new List<Vector2>();
		testB.Add(new Vector2(50, 10));
		testB.Add(new Vector2(40, 10));
		testB.Add(new Vector2(40, 20));
		testB.Add(new Vector2(50, 20));

		List<Vector2> testC = new List<Vector2>();
		testC.Add(new Vector2(50, 20));
		testC.Add(new Vector2(50, 60));
		testC.Add(new Vector2(40, 60));
		testC.Add(new Vector2(40, 30));

		List<Vector2> testD = new List<Vector2>();
		testD.Add(new Vector2(40, 30));
		testD.Add(new Vector2(30, 30));
		testD.Add(new Vector2(30, 60));

		List<Vector2> testE = new List<Vector2>();
		testE.Add(new Vector2(30, 60));
		testE.Add(new Vector2(10, 60));
		testE.Add(new Vector2(10, 30));
		testE.Add(new Vector2(0, 30));
		testE.Add(new Vector2(0, 10));

		List<Vector2> testF = new List<Vector2>();
		testF.Add(new Vector2(0, 10));
		testF.Add(new Vector2(10, 10));
		testF.Add(new Vector2(10, 0));

		level = new Level();

		List<EdgeData> testEdges = new List<EdgeData>();
		testEdges.Add(new EdgeData("A", testA));
		testEdges.Add(new EdgeData("B", testB));
		testEdges.Add(new EdgeData("C", testC));
		testEdges.Add(new EdgeData("D", testD));
		testEdges.Add(new EdgeData("E", testE));
		testEdges.Add(new EdgeData("F", testF));
		level.edges = testEdges;

		DrawLevel();
	}

	// Update is called once per frame
	void Update () {

	}

	private void DrawLevel()
	{
		DrawEdges();

		DrawTiles ();
	}

	private void DrawEdges()
	{
		foreach(EdgeData edgeData in level.edges)
		{
			Debug.Log ("LevelContructor >> DrawEdge >> " + edgeData.name);

			GameObject edge_go = new GameObject();
			edge_go.name = edgeData.name;
			Edge edge = edge_go.AddComponent<Edge> ();
			edge.SetData(edgeData, EdgeContainer.transform);
		}
	}

	private void DrawTiles()
	{
		float minX = float.NaN;
		float minY = float.NaN;
		float maxX = float.NaN;
		float maxY = float.NaN;

		foreach(EdgeData edgeData in level.edges)
		{
			foreach (Vector2 point in edgeData.points) {

				if (float.IsNaN(minX) || minX > point.x)
					minX = point.x;

				if (float.IsNaN(maxX) || maxX < point.x)
					maxX = point.x;

				if (float.IsNaN(minY) || minY > point.y)
					minY = point.y;

				if (float.IsNaN(maxY) || maxY < point.y)
					maxY = point.y;
			}
		}

		bool pairLign = true;
		bool pairCollumn;

		for (int i = 0; i < maxX - minX; i++) {

			pairCollumn = pairLign;

			for (int j = 0; j < maxY - minY; j++) {

				GameObject tile_go = new GameObject ();

				SpriteRenderer tileSprite = tile_go.AddComponent<SpriteRenderer> ();
				if(pairCollumn)
					tileSprite.color = new Color (1f, 1f, 1f);
				else
					tileSprite.color = new Color (0f, 0f, 0f);

				tileSprite.sprite = ed_tileSprite;
				tile_go.transform.parent = TileContainer.transform;

				tile_go.transform.position = new Vector3((minX+i)*Common.GetTileSize(), (minY+j)*Common.GetTileSize(), 0);

				Vector3 scale = new Vector3( Common.GetTileSize(), Common.GetTileSize(), 1f );
				tile_go.transform.localScale = scale;

				pairCollumn = !pairCollumn;
			}

			pairLign = !pairLign;
		}

	}
}
