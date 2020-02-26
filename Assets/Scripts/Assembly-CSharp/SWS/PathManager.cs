using System;
using UnityEngine;

namespace SWS
{
	// Token: 0x02000108 RID: 264
	public class PathManager : MonoBehaviour
	{
		// Token: 0x06000725 RID: 1829 RVA: 0x0002EDC8 File Offset: 0x0002D1C8
		private void OnDrawGizmos()
		{
			if (this.waypoints.Length <= 0)
			{
				return;
			}
			Vector3[] pathPoints = this.GetPathPoints(false);
			Vector3 vector = pathPoints[0];
			Vector3 vector2 = pathPoints[pathPoints.Length - 1];
			Gizmos.color = this.color1;
			Gizmos.DrawWireCube(vector, this.size * this.GetHandleSize(vector) * 1.5f);
			Gizmos.DrawWireCube(vector2, this.size * this.GetHandleSize(vector2) * 1.5f);
			Gizmos.color = this.color2;
			for (int i = 1; i < pathPoints.Length - 1; i++)
			{
				Gizmos.DrawWireSphere(pathPoints[i], this.radius * this.GetHandleSize(pathPoints[i]));
			}
			if (this.drawCurved && pathPoints.Length >= 2)
			{
				WaypointManager.DrawCurved(pathPoints);
			}
			else
			{
				WaypointManager.DrawStraight(pathPoints);
			}
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x0002EECC File Offset: 0x0002D2CC
		public virtual float GetHandleSize(Vector3 pos)
		{
			return 1f;
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x0002EEE0 File Offset: 0x0002D2E0
		public virtual Vector3[] GetPathPoints(bool local = false)
		{
			Vector3[] array = new Vector3[this.waypoints.Length];
			if (local)
			{
				for (int i = 0; i < this.waypoints.Length; i++)
				{
					array[i] = this.waypoints[i].localPosition;
				}
			}
			else
			{
				for (int j = 0; j < this.waypoints.Length; j++)
				{
					array[j] = this.waypoints[j].position;
				}
			}
			return array;
		}

		// Token: 0x06000728 RID: 1832 RVA: 0x0002EF6B File Offset: 0x0002D36B
		public virtual int GetWaypointIndex(int point)
		{
			return point;
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x0002EF6E File Offset: 0x0002D36E
		public virtual int GetEventsCount()
		{
			return this.waypoints.Length;
		}

		// Token: 0x04000628 RID: 1576
		public Transform[] waypoints = new Transform[0];

		// Token: 0x04000629 RID: 1577
		public bool drawCurved = true;

		// Token: 0x0400062A RID: 1578
		public Color color1 = new Color(1f, 0f, 1f, 0.5f);

		// Token: 0x0400062B RID: 1579
		public Color color2 = new Color(1f, 0.921568632f, 0.0156862754f, 0.5f);

		// Token: 0x0400062C RID: 1580
		public Vector3 size = new Vector3(0.7f, 0.7f, 0.7f);

		// Token: 0x0400062D RID: 1581
		public float radius = 0.4f;

		// Token: 0x0400062E RID: 1582
		public bool skipCustomNames = true;

		// Token: 0x0400062F RID: 1583
		public GameObject replaceObject;
	}
}
