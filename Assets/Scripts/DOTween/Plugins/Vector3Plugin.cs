﻿using System;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening.Plugins
{
	// Token: 0x0200002D RID: 45
	public class Vector3Plugin : ABSTweenPlugin<Vector3, Vector3, VectorOptions>
	{
		// Token: 0x060001F7 RID: 503 RVA: 0x00007FEC File Offset: 0x000061EC
		public override void Reset(TweenerCore<Vector3, Vector3, VectorOptions> t)
		{
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x0000B724 File Offset: 0x00009924
		public override void SetFrom(TweenerCore<Vector3, Vector3, VectorOptions> t, bool isRelative)
		{
			Vector3 endValue = t.endValue;
			t.endValue = t.getter();
			t.startValue = (isRelative ? (t.endValue + endValue) : endValue);
			Vector3 vector = t.endValue;
			AxisConstraint axisConstraint = t.plugOptions.axisConstraint;
			if (axisConstraint != AxisConstraint.X)
			{
				if (axisConstraint != AxisConstraint.Y)
				{
					if (axisConstraint != AxisConstraint.Z)
					{
						vector = t.startValue;
					}
					else
					{
						vector.z = t.startValue.z;
					}
				}
				else
				{
					vector.y = t.startValue.y;
				}
			}
			else
			{
				vector.x = t.startValue.x;
			}
			if (t.plugOptions.snapping)
			{
				vector.x = (float)Math.Round((double)vector.x);
				vector.y = (float)Math.Round((double)vector.y);
				vector.z = (float)Math.Round((double)vector.z);
			}
			t.setter(vector);
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x000080C9 File Offset: 0x000062C9
		public override Vector3 ConvertToStartValue(TweenerCore<Vector3, Vector3, VectorOptions> t, Vector3 value)
		{
			return value;
		}

		// Token: 0x060001FA RID: 506 RVA: 0x0000B81C File Offset: 0x00009A1C
		public override void SetRelativeEndValue(TweenerCore<Vector3, Vector3, VectorOptions> t)
		{
			t.endValue += t.startValue;
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0000B844 File Offset: 0x00009A44
		public override void SetChangeValue(TweenerCore<Vector3, Vector3, VectorOptions> t)
		{
			AxisConstraint axisConstraint = t.plugOptions.axisConstraint;
			if (axisConstraint == AxisConstraint.X)
			{
				t.changeValue = new Vector3(t.endValue.x - t.startValue.x, 0f, 0f);
				return;
			}
			if (axisConstraint == AxisConstraint.Y)
			{
				t.changeValue = new Vector3(0f, t.endValue.y - t.startValue.y, 0f);
				return;
			}
			if (axisConstraint != AxisConstraint.Z)
			{
				t.changeValue = t.endValue - t.startValue;
				return;
			}
			t.changeValue = new Vector3(0f, 0f, t.endValue.z - t.startValue.z);
		}

		// Token: 0x060001FC RID: 508 RVA: 0x000099C4 File Offset: 0x00007BC4
		public override float GetSpeedBasedDuration(VectorOptions options, float unitsXSecond, Vector3 changeValue)
		{
			return changeValue.magnitude / unitsXSecond;
		}

		// Token: 0x060001FD RID: 509 RVA: 0x0000B90C File Offset: 0x00009B0C
		public override void EvaluateAndApply(VectorOptions options, Tween t, bool isRelative, DOGetter<Vector3> getter, DOSetter<Vector3> setter, float elapsed, Vector3 startValue, Vector3 changeValue, float duration, bool usingInversePosition, UpdateNotice updateNotice)
		{
			if (t.loopType == LoopType.Incremental)
			{
				startValue += changeValue * (float)(t.isComplete ? (t.completedLoops - 1) : t.completedLoops);
			}
			if (t.isSequenced && t.sequenceParent.loopType == LoopType.Incremental)
			{
				startValue += changeValue * (float)((t.loopType == LoopType.Incremental) ? t.loops : 1) * (float)(t.sequenceParent.isComplete ? (t.sequenceParent.completedLoops - 1) : t.sequenceParent.completedLoops);
			}
			float num = EaseManager.Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);
			AxisConstraint axisConstraint = options.axisConstraint;
			if (axisConstraint == AxisConstraint.X)
			{
				Vector3 vector = getter();
				vector.x = startValue.x + changeValue.x * num;
				if (options.snapping)
				{
					vector.x = (float)Math.Round((double)vector.x);
				}
				setter(vector);
				return;
			}
			if (axisConstraint == AxisConstraint.Y)
			{
				Vector3 vector2 = getter();
				vector2.y = startValue.y + changeValue.y * num;
				if (options.snapping)
				{
					vector2.y = (float)Math.Round((double)vector2.y);
				}
				setter(vector2);
				return;
			}
			if (axisConstraint != AxisConstraint.Z)
			{
				startValue.x += changeValue.x * num;
				startValue.y += changeValue.y * num;
				startValue.z += changeValue.z * num;
				if (options.snapping)
				{
					startValue.x = (float)Math.Round((double)startValue.x);
					startValue.y = (float)Math.Round((double)startValue.y);
					startValue.z = (float)Math.Round((double)startValue.z);
				}
				setter(startValue);
				return;
			}
			Vector3 vector3 = getter();
			vector3.z = startValue.z + changeValue.z * num;
			if (options.snapping)
			{
				vector3.z = (float)Math.Round((double)vector3.z);
			}
			setter(vector3);
		}
	}
}
