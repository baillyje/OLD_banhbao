using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baillyje.Land
{
	public class Edge {

		public Vector2 point1;
		public Vector2 point2;

		public bool isCameraBlocker;

		private bool isExit;
		private Level levelDestination;
		private Vector2 levelDestinationCoordinate;
		private Vector2 heroDestinationCoordinate;

		public Edge(Vector2 pPoint1, Vector2 pPoint2, bool pIsCameraBlocker)
        {
			point1 = pPoint1;
			point2 = pPoint2;
			isCameraBlocker = pIsCameraBlocker;
        }

	}
}
