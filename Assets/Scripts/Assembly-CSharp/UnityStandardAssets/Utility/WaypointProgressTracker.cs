using System;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	// Token: 0x020001D0 RID: 464
	public class WaypointProgressTracker : MonoBehaviour
	{
		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000C1A RID: 3098 RVA: 0x0004C888 File Offset: 0x0004AC88
		// (set) Token: 0x06000C1B RID: 3099 RVA: 0x0004C890 File Offset: 0x0004AC90
		public WaypointCircuit.RoutePoint targetPoint { get; private set; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000C1C RID: 3100 RVA: 0x0004C899 File Offset: 0x0004AC99
		// (set) Token: 0x06000C1D RID: 3101 RVA: 0x0004C8A1 File Offset: 0x0004ACA1
		public WaypointCircuit.RoutePoint speedPoint { get; private set; }

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000C1E RID: 3102 RVA: 0x0004C8AA File Offset: 0x0004ACAA
		// (set) Token: 0x06000C1F RID: 3103 RVA: 0x0004C8B2 File Offset: 0x0004ACB2
		public WaypointCircuit.RoutePoint progressPoint { get; private set; }

		// Token: 0x06000C20 RID: 3104 RVA: 0x0004C8BB File Offset: 0x0004ACBB
		private void Start()
		{
			if (this.target == null)
			{
				this.target = new GameObject(base.name + " Waypoint Target").transform;
			}
			this.Reset();
		}

		// Token: 0x06000C21 RID: 3105 RVA: 0x0004C8F4 File Offset: 0x0004ACF4
		public void Reset()
		{
			this.progressDistance = 0f;
			this.progressNum = 0;
			if (this.progressStyle == WaypointProgressTracker.ProgressStyle.PointToPoint)
			{
				this.target.position = this.circuit.Waypoints[this.progressNum].position;
				this.target.rotation = this.circuit.Waypoints[this.progressNum].rotation;
			}
		}

		// Token: 0x06000C22 RID: 3106 RVA: 0x0004C964 File Offset: 0x0004AD64
		private void Update()
		{
			if (this.progressStyle == WaypointProgressTracker.ProgressStyle.SmoothAlongRoute)
			{
				if (Time.deltaTime > 0f)
				{
					this.speed = Mathf.Lerp(this.speed, (this.lastPosition - base.transform.position).magnitude / Time.deltaTime, Time.deltaTime);
				}
				this.target.position = this.circuit.GetRoutePoint(this.progressDistance + this.lookAheadForTargetOffset + this.lookAheadForTargetFactor * this.speed).position;
				this.target.rotation = Quaternion.LookRotation(this.circuit.GetRoutePoint(this.progressDistance + this.lookAheadForSpeedOffset + this.lookAheadForSpeedFactor * this.speed).direction);
				this.progressPoint = this.circuit.GetRoutePoint(this.progressDistance);
				Vector3 lhs = this.progressPoint.position - base.transform.position;
				if (Vector3.Dot(lhs, this.progressPoint.direction) < 0f)
				{
					this.progressDistance += lhs.magnitude * 0.5f;
				}
				this.lastPosition = base.transform.position;
			}
			else
			{
				if ((this.target.position - base.transform.position).magnitude < this.pointToPointThreshold)
				{
					this.progressNum = (this.progressNum + 1) % this.circuit.Waypoints.Length;
				}
				this.target.position = this.circuit.Waypoints[this.progressNum].position;
				this.target.rotation = this.circuit.Waypoints[this.progressNum].rotation;
				this.progressPoint = this.circuit.GetRoutePoint(this.progressDistance);
				Vector3 lhs2 = this.progressPoint.position - base.transform.position;
				if (Vector3.Dot(lhs2, this.progressPoint.direction) < 0f)
				{
					this.progressDistance += lhs2.magnitude;
				}
				this.lastPosition = base.transform.position;
			}
		}

		// Token: 0x06000C23 RID: 3107 RVA: 0x0004CBD0 File Offset: 0x0004AFD0
		private void OnDrawGizmos()
		{
			if (Application.isPlaying)
			{
				Gizmos.color = Color.green;
				Gizmos.DrawLine(base.transform.position, this.target.position);
				Gizmos.DrawWireSphere(this.circuit.GetRoutePosition(this.progressDistance), 1f);
				Gizmos.color = Color.yellow;
				Gizmos.DrawLine(this.target.position, this.target.position + this.target.forward);
			}
		}

		// Token: 0x04000C77 RID: 3191
		[SerializeField]
		private WaypointCircuit circuit;

		// Token: 0x04000C78 RID: 3192
		[SerializeField]
		private float lookAheadForTargetOffset = 5f;

		// Token: 0x04000C79 RID: 3193
		[SerializeField]
		private float lookAheadForTargetFactor = 0.1f;

		// Token: 0x04000C7A RID: 3194
		[SerializeField]
		private float lookAheadForSpeedOffset = 10f;

		// Token: 0x04000C7B RID: 3195
		[SerializeField]
		private float lookAheadForSpeedFactor = 0.2f;

		// Token: 0x04000C7C RID: 3196
		[SerializeField]
		private WaypointProgressTracker.ProgressStyle progressStyle;

		// Token: 0x04000C7D RID: 3197
		[SerializeField]
		private float pointToPointThreshold = 4f;

		// Token: 0x04000C81 RID: 3201
		public Transform target;

		// Token: 0x04000C82 RID: 3202
		private float progressDistance;

		// Token: 0x04000C83 RID: 3203
		private int progressNum;

		// Token: 0x04000C84 RID: 3204
		private Vector3 lastPosition;

		// Token: 0x04000C85 RID: 3205
		private float speed;

		// Token: 0x020001D1 RID: 465
		public enum ProgressStyle
		{
			// Token: 0x04000C87 RID: 3207
			SmoothAlongRoute,
			// Token: 0x04000C88 RID: 3208
			PointToPoint
		}
	}
}
