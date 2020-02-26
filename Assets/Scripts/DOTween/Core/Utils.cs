using System;
using UnityEngine;

namespace DG.Tweening.Core
{
	// Token: 0x0200004D RID: 77
	internal static class Utils
	{
		// Token: 0x0600028A RID: 650 RVA: 0x0000EB88 File Offset: 0x0000CD88
		internal static Vector3 Vector3FromAngle(float degrees, float magnitude)
		{
			float f = degrees * 0.0174532924f;
			return new Vector3(magnitude * Mathf.Cos(f), magnitude * Mathf.Sin(f), 0f);
		}

		// Token: 0x0600028B RID: 651 RVA: 0x0000EBB8 File Offset: 0x0000CDB8
		internal static float Angle2D(Vector3 from, Vector3 to)
		{
			Vector2 right = Vector2.right;
			to -= from;
			float num = Vector2.Angle(right, to);
			if (Vector3.Cross(right, to).z > 0f)
			{
				num = 360f - num;
			}
			return num * -1f;
		}
	}
}
