using System;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening.Plugins.Core
{
	// Token: 0x02000039 RID: 57
	internal static class SpecialPluginsUtils
	{
		// Token: 0x060001FF RID: 511 RVA: 0x0000BB54 File Offset: 0x00009D54
		internal static bool SetLookAt(TweenerCore<Quaternion, Vector3, QuaternionOptions> t)
		{
			Transform transform = t.target as Transform;
			Vector3 vector = t.endValue;
			vector -= transform.position;
			AxisConstraint axisConstraint = t.plugOptions.axisConstraint;
			if (axisConstraint != AxisConstraint.X)
			{
				if (axisConstraint != AxisConstraint.Y)
				{
					if (axisConstraint == AxisConstraint.Z)
					{
						vector.z = 0f;
					}
				}
				else
				{
					vector.y = 0f;
				}
			}
			else
			{
				vector.x = 0f;
			}
			Vector3 eulerAngles = Quaternion.LookRotation(vector, t.plugOptions.up).eulerAngles;
			t.endValue = eulerAngles;
			return true;
		}

		// Token: 0x06000200 RID: 512 RVA: 0x0000BBE8 File Offset: 0x00009DE8
		internal static bool SetPunch(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t)
		{
			Vector3 b;
			try
			{
				b = t.getter();
			}
			catch
			{
				return false;
			}
			t.isRelative = (t.isSpeedBased = false);
			t.easeType = Ease.OutQuad;
			t.customEase = null;
			int num = t.endValue.Length;
			for (int i = 0; i < num; i++)
			{
				t.endValue[i] = t.endValue[i] + b;
			}
			return true;
		}

		// Token: 0x06000201 RID: 513 RVA: 0x0000BC74 File Offset: 0x00009E74
		internal static bool SetShake(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t)
		{
			if (!SpecialPluginsUtils.SetPunch(t))
			{
				return false;
			}
			t.easeType = Ease.Linear;
			return true;
		}

		// Token: 0x06000202 RID: 514 RVA: 0x0000BC88 File Offset: 0x00009E88
		internal static bool SetCameraShakePosition(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t)
		{
			if (!SpecialPluginsUtils.SetShake(t))
			{
				return false;
			}
			Camera camera = t.target as Camera;
			if (camera == null)
			{
				return false;
			}
			Vector3 b = t.getter();
			Transform transform = camera.transform;
			int num = t.endValue.Length;
			for (int i = 0; i < num; i++)
			{
				Vector3 a = t.endValue[i];
				t.endValue[i] = transform.localRotation * (a - b) + b;
			}
			return true;
		}
	}
}
