using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baillyje.Land
{
	public class EdgeData {

		public string name;
		public List<Vector2> points;

		public bool isCameraBlocker;

		private bool isExit;
		private Level levelDestination;
		private Vector2 levelDestinationCoordinate;
		private Vector2 heroDestinationCoordinate;

		public EdgeData(string pName, List<Vector2> pPoints, bool pIsCameraBlocker)
        {
			name = pName;
			points = pPoints;
			isCameraBlocker = pIsCameraBlocker;
        }

	}

	public class Edge : MonoBehaviour {

		private EdgeData data;
		private Transform parent;

		public Edge(EdgeData pData, Transform pParent) 
		{
			data = pData;
			parent = pParent;
		}

		void Initialize()
		{
			EdgeCollider2D edgeCollider = this.gameObject.AddComponent<EdgeCollider2D>() as EdgeCollider2D;

			this.gameObject.name = data.name;

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
