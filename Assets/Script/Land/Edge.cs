using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baillyje.Land
{
	public class EdgeData {

		public string name;
		public List<Vector2> points;

		private bool isExit;
		private Level levelDestination;
		private Vector2 levelDestinationCoordinate;
		private Vector2 heroDestinationCoordinate;

		public EdgeData(string pName, List<Vector2> pPoints)
        {
			name = pName;
			points = pPoints;
        }

	}

	public class Edge : MonoBehaviour {

		private EdgeData data;
		private Transform parent;

		public void SetData(EdgeData pData, Transform pParent)
		{
			data = pData;
			parent = pParent;

			EdgeCollider2D edgeCollider = this.gameObject.AddComponent<EdgeCollider2D>() as EdgeCollider2D;

			this.gameObject.name = data.name;
			this.gameObject.tag = "Wall";

			List<Vector2> pointInGameWorld = new List<Vector2>();
			foreach(Vector2 point in data.points)
			{
				pointInGameWorld.Add (point * Common.GetTileSize());
			}

			Debug.Log (Common.GetTileSize() + " / " + pointInGameWorld.ToArray ()[0].x);
			edgeCollider.points = pointInGameWorld.ToArray();

			this.transform.parent = parent.transform;

			Debug.Log ("Edge >> Initialize >> " + data.name);
		}

	}
}
