using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SWS
{
	// Token: 0x02000106 RID: 262
	public class BezierPathManager : PathManager
	{
		// Token: 0x0600071C RID: 1820 RVA: 0x0002EFE5 File Offset: 0x0002D3E5
		private void Awake()
		{
			this.CalculatePath();
		}

		// Token: 0x0600071D RID: 1821 RVA: 0x0002EFF0 File Offset: 0x0002D3F0
		private void OnDrawGizmos()
		{
			if (this.bPoints.Count <= 0)
			{
				return;
			}
			Vector3 position = this.bPoints[0].wp.position;
			Vector3 position2 = this.bPoints[this.bPoints.Count - 1].wp.position;
			Gizmos.color = this.color1;
			Gizmos.DrawWireCube(position, this.size * this.GetHandleSize(position) * 1.5f);
			Gizmos.DrawWireCube(position2, this.size * this.GetHandleSize(position2) * 1.5f);
			Gizmos.color = this.color2;
			for (int i = 1; i < this.bPoints.Count - 1; i++)
			{
				Gizmos.DrawWireSphere(this.bPoints[i].wp.position, this.radius * this.GetHandleSize(this.bPoints[i].wp.position));
			}
			if (this.drawCurved && this.bPoints.Count >= 2)
			{
				WaypointManager.DrawCurved(this.pathPoints);
			}
			else
			{
				WaypointManager.DrawStraight(this.pathPoints);
			}
		}

		// Token: 0x0600071E RID: 1822 RVA: 0x0002F138 File Offset: 0x0002D538
		public override Vector3[] GetPathPoints(bool local = false)
		{
			if (local)
			{
				Vector3[] array = new Vector3[this.pathPoints.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = base.transform.InverseTransformPoint(this.pathPoints[i]);
				}
				return array;
			}
			return this.pathPoints;
		}

		// Token: 0x0600071F RID: 1823 RVA: 0x0002F19D File Offset: 0x0002D59D
		public override int GetEventsCount()
		{
			return this.bPoints.Count;
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x0002F1AC File Offset: 0x0002D5AC
		public override int GetWaypointIndex(int point)
		{
			int result = -1;
			int num = 0;
			int num2 = 10;
			for (int i = 0; i < this.segmentDetail.Count; i++)
			{
				if (point == num)
				{
					result = i;
					break;
				}
				if (this.customDetail)
				{
					num += Mathf.CeilToInt(this.segmentDetail[i] * (float)num2);
				}
				else
				{
					num += Mathf.CeilToInt(this.pathDetail * (float)num2);
				}
			}
			return result;
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x0002F224 File Offset: 0x0002D624
		public void CalculatePath()
		{
			List<Vector3> list = new List<Vector3>();
			for (int i = 0; i < this.bPoints.Count - 1; i++)
			{
				BezierPoint bezierPoint = this.bPoints[i];
				float detail = this.pathDetail;
				if (this.customDetail)
				{
					detail = this.segmentDetail[i];
				}
				list.AddRange(this.GetPoints(bezierPoint.wp.position, bezierPoint.cp[1].position, this.bPoints[i + 1].cp[0].position, this.bPoints[i + 1].wp.position, detail));
			}
			this.pathPoints = list.Distinct<Vector3>().ToArray<Vector3>();
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x0002F2EC File Offset: 0x0002D6EC
		private List<Vector3> GetPoints(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float detail)
		{
			List<Vector3> list = new List<Vector3>();
			float num = detail * 10f;
			int num2 = 0;
			while ((float)num2 <= num)
			{
				float num3 = (float)num2 / num;
				float d = 1f - num3;
				Vector3 vector = Vector3.zero;
				vector += p0 * d * d * d;
				vector += p1 * num3 * 3f * d * d;
				vector += p2 * 3f * num3 * num3 * d;
				vector += p3 * num3 * num3 * num3;
				list.Add(vector);
				num2++;
			}
			return list;
		}

		// Token: 0x0400061E RID: 1566
		public Vector3[] pathPoints = new Vector3[0];

		// Token: 0x0400061F RID: 1567
		public List<BezierPoint> bPoints = new List<BezierPoint>();

		// Token: 0x04000620 RID: 1568
		public bool showHandles = true;

		// Token: 0x04000621 RID: 1569
		public bool connectHandles = true;

		// Token: 0x04000622 RID: 1570
		public Color color3 = new Color(0.423529416f, 0.5921569f, 1f, 1f);

		// Token: 0x04000623 RID: 1571
		public float pathDetail = 1f;

		// Token: 0x04000624 RID: 1572
		public bool customDetail;

		// Token: 0x04000625 RID: 1573
		public List<float> segmentDetail = new List<float>();
	}
}
