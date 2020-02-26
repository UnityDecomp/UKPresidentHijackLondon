using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace SWS
{
	// Token: 0x02000109 RID: 265
	public class WaypointManager : MonoBehaviour
	{
		// Token: 0x0600072B RID: 1835 RVA: 0x0002F3E0 File Offset: 0x0002D7E0
		private void Awake()
		{
			IEnumerator enumerator = base.transform.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Transform transform = (Transform)obj;
					WaypointManager.AddPath(transform.gameObject);
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
			DOTween.Init(null, null, null);
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x0002F46C File Offset: 0x0002D86C
		public static void AddPath(GameObject path)
		{
			if (path.name.Contains("(Clone)"))
			{
				path.name = path.name.Replace("(Clone)", string.Empty);
			}
			if (WaypointManager.Paths.ContainsKey(path.name))
			{
				Debug.LogWarning("Called AddPath() but Scene already contains Path " + path.name + ".");
				return;
			}
			PathManager componentInChildren = path.GetComponentInChildren<PathManager>();
			if (componentInChildren)
			{
				WaypointManager.Paths.Add(path.name, componentInChildren);
				return;
			}
			Debug.LogWarning("Called AddPath() but Transform " + path.name + " has no Path Component attached.");
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x0002F51C File Offset: 0x0002D91C
		private void OnDestroy()
		{
			WaypointManager.Paths.Clear();
		}

		// Token: 0x0600072E RID: 1838 RVA: 0x0002F528 File Offset: 0x0002D928
		public static void DrawStraight(Vector3[] waypoints)
		{
			for (int i = 0; i < waypoints.Length - 1; i++)
			{
				Gizmos.DrawLine(waypoints[i], waypoints[i + 1]);
			}
		}

		// Token: 0x0600072F RID: 1839 RVA: 0x0002F56C File Offset: 0x0002D96C
		public static void DrawCurved(Vector3[] waypoints)
		{
			Vector3[] array = new Vector3[waypoints.Length + 2];
			waypoints.CopyTo(array, 1);
			array[0] = waypoints[1];
			array[array.Length - 1] = array[array.Length - 2];
			int num = array.Length * 10;
			Vector3[] array2 = new Vector3[num + 1];
			for (int i = 0; i <= num; i++)
			{
				float t = (float)i / (float)num;
				Vector3 vector = WaypointManager.GetPoint(array, t);
				array2[i] = vector;
			}
			Vector3 to = array2[0];
			for (int j = 1; j < array2.Length; j++)
			{
				Vector3 vector = array2[j];
				Gizmos.DrawLine(vector, to);
				to = vector;
			}
		}

		// Token: 0x06000730 RID: 1840 RVA: 0x0002F648 File Offset: 0x0002DA48
		public static Vector3 GetPoint(Vector3[] gizmoPoints, float t)
		{
			int num = gizmoPoints.Length - 3;
			int num2 = (int)Mathf.Floor(t * (float)num);
			int num3 = num - 1;
			if (num3 > num2)
			{
				num3 = num2;
			}
			float num4 = t * (float)num - (float)num3;
			Vector3 a = gizmoPoints[num3];
			Vector3 a2 = gizmoPoints[num3 + 1];
			Vector3 vector = gizmoPoints[num3 + 2];
			Vector3 b = gizmoPoints[num3 + 3];
			return 0.5f * ((-a + 3f * a2 - 3f * vector + b) * (num4 * num4 * num4) + (2f * a - 5f * a2 + 4f * vector - b) * (num4 * num4) + (-a + vector) * num4 + 2f * a2);
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x0002F76C File Offset: 0x0002DB6C
		public static float GetPathLength(Vector3[] waypoints)
		{
			float num = 0f;
			for (int i = 0; i < waypoints.Length - 1; i++)
			{
				num += Vector3.Distance(waypoints[i], waypoints[i + 1]);
			}
			return num;
		}

		// Token: 0x06000732 RID: 1842 RVA: 0x0002F7B8 File Offset: 0x0002DBB8
		public static List<Vector3> SmoothCurve(List<Vector3> pathToCurve, int interpolations)
		{
			if (interpolations < 1)
			{
				interpolations = 1;
			}
			int count = pathToCurve.Count;
			int num = count * Mathf.RoundToInt((float)interpolations) - 1;
			List<Vector3> list = new List<Vector3>(num);
			for (int i = 0; i < num + 1; i++)
			{
				float num2 = Mathf.InverseLerp(0f, (float)num, (float)i);
				List<Vector3> list2 = new List<Vector3>(pathToCurve);
				for (int j = count - 1; j > 0; j--)
				{
					for (int k = 0; k < j; k++)
					{
						list2[k] = (1f - num2) * list2[k] + num2 * list2[k + 1];
					}
				}
				list.Add(list2[0]);
			}
			return list;
		}

		// Token: 0x04000630 RID: 1584
		public static readonly Dictionary<string, PathManager> Paths = new Dictionary<string, PathManager>();
	}
}
