using System;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	// Token: 0x020001CD RID: 461
	public class WaypointCircuit : MonoBehaviour
	{
		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000C0C RID: 3084 RVA: 0x0004C2EA File Offset: 0x0004A6EA
		// (set) Token: 0x06000C0D RID: 3085 RVA: 0x0004C2F2 File Offset: 0x0004A6F2
		public float Length { get; private set; }

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000C0E RID: 3086 RVA: 0x0004C2FB File Offset: 0x0004A6FB
		public Transform[] Waypoints
		{
			get
			{
				return this.waypointList.items;
			}
		}

		// Token: 0x06000C0F RID: 3087 RVA: 0x0004C308 File Offset: 0x0004A708
		private void Awake()
		{
			if (this.Waypoints.Length > 1)
			{
				this.CachePositionsAndDistances();
			}
			this.numPoints = this.Waypoints.Length;
		}

		// Token: 0x06000C10 RID: 3088 RVA: 0x0004C32C File Offset: 0x0004A72C
		public WaypointCircuit.RoutePoint GetRoutePoint(float dist)
		{
			Vector3 routePosition = this.GetRoutePosition(dist);
			Vector3 routePosition2 = this.GetRoutePosition(dist + 0.1f);
			return new WaypointCircuit.RoutePoint(routePosition, (routePosition2 - routePosition).normalized);
		}

		// Token: 0x06000C11 RID: 3089 RVA: 0x0004C364 File Offset: 0x0004A764
		public Vector3 GetRoutePosition(float dist)
		{
			int num = 0;
			if (this.Length == 0f)
			{
				this.Length = this.distances[this.distances.Length - 1];
			}
			dist = Mathf.Repeat(dist, this.Length);
			while (this.distances[num] < dist)
			{
				num++;
			}
			this.p1n = (num - 1 + this.numPoints) % this.numPoints;
			this.p2n = num;
			this.i = Mathf.InverseLerp(this.distances[this.p1n], this.distances[this.p2n], dist);
			if (this.smoothRoute)
			{
				this.p0n = (num - 2 + this.numPoints) % this.numPoints;
				this.p3n = (num + 1) % this.numPoints;
				this.p2n %= this.numPoints;
				this.P0 = this.points[this.p0n];
				this.P1 = this.points[this.p1n];
				this.P2 = this.points[this.p2n];
				this.P3 = this.points[this.p3n];
				return this.CatmullRom(this.P0, this.P1, this.P2, this.P3, this.i);
			}
			this.p1n = (num - 1 + this.numPoints) % this.numPoints;
			this.p2n = num;
			return Vector3.Lerp(this.points[this.p1n], this.points[this.p2n], this.i);
		}

		// Token: 0x06000C12 RID: 3090 RVA: 0x0004C534 File Offset: 0x0004A934
		private Vector3 CatmullRom(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float i)
		{
			return 0.5f * (2f * p1 + (-p0 + p2) * i + (2f * p0 - 5f * p1 + 4f * p2 - p3) * i * i + (-p0 + 3f * p1 - 3f * p2 + p3) * i * i * i);
		}

		// Token: 0x06000C13 RID: 3091 RVA: 0x0004C5FC File Offset: 0x0004A9FC
		private void CachePositionsAndDistances()
		{
			this.points = new Vector3[this.Waypoints.Length + 1];
			this.distances = new float[this.Waypoints.Length + 1];
			float num = 0f;
			for (int i = 0; i < this.points.Length; i++)
			{
				Transform transform = this.Waypoints[i % this.Waypoints.Length];
				Transform transform2 = this.Waypoints[(i + 1) % this.Waypoints.Length];
				if (transform != null && transform2 != null)
				{
					Vector3 position = transform.position;
					Vector3 position2 = transform2.position;
					this.points[i] = this.Waypoints[i % this.Waypoints.Length].position;
					this.distances[i] = num;
					num += (position - position2).magnitude;
				}
			}
		}

		// Token: 0x06000C14 RID: 3092 RVA: 0x0004C6E5 File Offset: 0x0004AAE5
		private void OnDrawGizmos()
		{
			this.DrawGizmos(false);
		}

		// Token: 0x06000C15 RID: 3093 RVA: 0x0004C6EE File Offset: 0x0004AAEE
		private void OnDrawGizmosSelected()
		{
			this.DrawGizmos(true);
		}

		// Token: 0x06000C16 RID: 3094 RVA: 0x0004C6F8 File Offset: 0x0004AAF8
		private void DrawGizmos(bool selected)
		{
			this.waypointList.circuit = this;
			if (this.Waypoints.Length > 1)
			{
				this.numPoints = this.Waypoints.Length;
				this.CachePositionsAndDistances();
				this.Length = this.distances[this.distances.Length - 1];
				Gizmos.color = ((!selected) ? new Color(1f, 1f, 0f, 0.5f) : Color.yellow);
				Vector3 from = this.Waypoints[0].position;
				if (this.smoothRoute)
				{
					for (float num = 0f; num < this.Length; num += this.Length / this.editorVisualisationSubsteps)
					{
						Vector3 routePosition = this.GetRoutePosition(num + 1f);
						Gizmos.DrawLine(from, routePosition);
						from = routePosition;
					}
					Gizmos.DrawLine(from, this.Waypoints[0].position);
				}
				else
				{
					for (int i = 0; i < this.Waypoints.Length; i++)
					{
						Vector3 position = this.Waypoints[(i + 1) % this.Waypoints.Length].position;
						Gizmos.DrawLine(from, position);
						from = position;
					}
				}
			}
		}

		// Token: 0x04000C63 RID: 3171
		public WaypointCircuit.WaypointList waypointList = new WaypointCircuit.WaypointList();

		// Token: 0x04000C64 RID: 3172
		[SerializeField]
		private bool smoothRoute = true;

		// Token: 0x04000C65 RID: 3173
		private int numPoints;

		// Token: 0x04000C66 RID: 3174
		private Vector3[] points;

		// Token: 0x04000C67 RID: 3175
		private float[] distances;

		// Token: 0x04000C68 RID: 3176
		public float editorVisualisationSubsteps = 100f;

		// Token: 0x04000C6A RID: 3178
		private int p0n;

		// Token: 0x04000C6B RID: 3179
		private int p1n;

		// Token: 0x04000C6C RID: 3180
		private int p2n;

		// Token: 0x04000C6D RID: 3181
		private int p3n;

		// Token: 0x04000C6E RID: 3182
		private float i;

		// Token: 0x04000C6F RID: 3183
		private Vector3 P0;

		// Token: 0x04000C70 RID: 3184
		private Vector3 P1;

		// Token: 0x04000C71 RID: 3185
		private Vector3 P2;

		// Token: 0x04000C72 RID: 3186
		private Vector3 P3;

		// Token: 0x020001CE RID: 462
		[Serializable]
		public class WaypointList
		{
			// Token: 0x04000C73 RID: 3187
			public WaypointCircuit circuit;

			// Token: 0x04000C74 RID: 3188
			public Transform[] items = new Transform[0];
		}

		// Token: 0x020001CF RID: 463
		public struct RoutePoint
		{
			// Token: 0x06000C18 RID: 3096 RVA: 0x0004C839 File Offset: 0x0004AC39
			public RoutePoint(Vector3 position, Vector3 direction)
			{
				this.position = position;
				this.direction = direction;
			}

			// Token: 0x04000C75 RID: 3189
			public Vector3 position;

			// Token: 0x04000C76 RID: 3190
			public Vector3 direction;
		}
	}
}
