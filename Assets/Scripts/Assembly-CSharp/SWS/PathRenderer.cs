using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SWS
{
	// Token: 0x02000105 RID: 261
	[RequireComponent(typeof(LineRenderer))]
	public class PathRenderer : MonoBehaviour
	{
		// Token: 0x06000716 RID: 1814 RVA: 0x0002EAB9 File Offset: 0x0002CEB9
		private void Start()
		{
			this.line = base.GetComponent<LineRenderer>();
			this.path = base.GetComponent<PathManager>();
			if (this.path)
			{
				base.StartCoroutine("StartRenderer");
			}
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x0002EAF0 File Offset: 0x0002CEF0
		private IEnumerator StartRenderer()
		{
			this.Render();
			if (!this.onUpdate)
			{
				yield break;
			}
			for (;;)
			{
				yield return null;
				this.Render();
			}
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x0002EB0C File Offset: 0x0002CF0C
		private void Render()
		{
			this.spacing = Mathf.Clamp01(this.spacing);
			if (this.spacing == 0f)
			{
				this.spacing = 0.05f;
			}
			List<Vector3> list = new List<Vector3>();
			list.AddRange(this.path.GetPathPoints(false));
			if (this.path.drawCurved)
			{
				list.Insert(0, list[0]);
				list.Add(list[list.Count - 1]);
				this.points = list.ToArray();
				this.DrawCurved();
			}
			else
			{
				this.points = list.ToArray();
				this.DrawLinear();
			}
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x0002EBB8 File Offset: 0x0002CFB8
		private void DrawCurved()
		{
			int num = Mathf.RoundToInt(1f / this.spacing) + 1;
			this.line.SetVertexCount(num);
			float num2 = 0f;
			for (int i = 0; i < num; i++)
			{
				this.line.SetPosition(i, WaypointManager.GetPoint(this.points, num2));
				num2 += this.spacing;
			}
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x0002EC20 File Offset: 0x0002D020
		private void DrawLinear()
		{
			this.line.SetVertexCount(this.points.Length);
			float num = 0f;
			for (int i = 0; i < this.points.Length; i++)
			{
				this.line.SetPosition(i, this.points[i]);
				num += this.spacing;
			}
		}

		// Token: 0x04000619 RID: 1561
		public bool onUpdate;

		// Token: 0x0400061A RID: 1562
		public float spacing = 0.05f;

		// Token: 0x0400061B RID: 1563
		private PathManager path;

		// Token: 0x0400061C RID: 1564
		private LineRenderer line;

		// Token: 0x0400061D RID: 1565
		private Vector3[] points;
	}
}
