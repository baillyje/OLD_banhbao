using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baillyje.Land
{
	public class Edge {

		public List<Vector2> points;

		public bool isCameraBlocker;

		private bool isExit;
		private Level levelDestination;
		private Vector2 levelDestinationCoordinate;
		private Vector2 heroDestinationCoordinate;

		public Edge(List<Vector2> pPoints, bool pIsCameraBlocker)
        {
			points = pPoints;
			isCameraBlocker = pIsCameraBlocker;
        }

	}
}
