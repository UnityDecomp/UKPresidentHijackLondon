using System;
using UnityEngine;

namespace DG.Tweening.Plugins.Core.PathCore
{
	// Token: 0x02000041 RID: 65
	internal class LinearDecoder : ABSPathDecoder
	{
		// Token: 0x0600021C RID: 540 RVA: 0x0000C51A File Offset: 0x0000A71A
		internal override void FinalizePath(Path p, Vector3[] wps, bool isClosedPath)
		{
			p.controlPoints = null;
			p.subdivisions = wps.Length * p.subdivisionsXSegment;
			this.SetTimeToLengthTables(p, p.subdivisions);
		}

		// Token: 0x0600021D RID: 541 RVA: 0x0000C540 File Offset: 0x0000A740
		internal override Vector3 GetPoint(float perc, Vector3[] wps, Path p, ControlPoint[] controlPoints)
		{
			if (perc <= 0f)
			{
				p.linearWPIndex = 1;
				return wps[0];
			}
			int num = 0;
			int num2 = 0;
			int num3 = p.timesTable.Length;
			for (int i = 1; i < num3; i++)
			{
				if (p.timesTable[i] >= perc)
				{
					num = i - 1;
					num2 = i;
					break;
				}
			}
			float num4 = p.timesTable[num];
			float num5 = perc - num4;
			float maxLength = p.length * num5;
			Vector3 vector = wps[num];
			Vector3 a = wps[num2];
			p.linearWPIndex = num2;
			return vector + Vector3.ClampMagnitude(a - vector, maxLength);
		}

		// Token: 0x0600021E RID: 542 RVA: 0x0000C5E0 File Offset: 0x0000A7E0
		internal void SetTimeToLengthTables(Path p, int subdivisions)
		{
			float num = 0f;
			int num2 = p.wps.Length;
			float[] array = new float[num2];
			Vector3 b = p.wps[0];
			for (int i = 0; i < num2; i++)
			{
				Vector3 vector = p.wps[i];
				float num3 = Vector3.Distance(vector, b);
				num += num3;
				b = vector;
				array[i] = num3;
			}
			float[] array2 = new float[num2];
			float num4 = 0f;
			for (int j = 1; j < num2; j++)
			{
				num4 += array[j];
				array2[j] = num4 / num;
			}
			p.length = num;
			p.wpLengths = array;
			p.timesTable = array2;
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00007FEC File Offset: 0x000061EC
		internal void SetWaypointsLengths(Path p, int subdivisions)
		{
		}
	}
}
