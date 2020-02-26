using System;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening.Plugins
{
	// Token: 0x02000026 RID: 38
	public class RectPlugin : ABSTweenPlugin<Rect, Rect, RectOptions>
	{
		// Token: 0x060001C1 RID: 449 RVA: 0x00007FEC File Offset: 0x000061EC
		public override void Reset(TweenerCore<Rect, Rect, RectOptions> t)
		{
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x00009FFC File Offset: 0x000081FC
		public override void SetFrom(TweenerCore<Rect, Rect, RectOptions> t, bool isRelative)
		{
			Rect endValue = t.endValue;
			t.endValue = t.getter();
			t.startValue = endValue;
			if (isRelative)
			{
				t.startValue.x = t.startValue.x + t.endValue.x;
				t.startValue.y = t.startValue.y + t.endValue.y;
				t.startValue.width = t.startValue.width + t.endValue.width;
				t.startValue.height = t.startValue.height + t.endValue.height;
			}
			Rect startValue = t.startValue;
			if (t.plugOptions.snapping)
			{
				startValue.x = (float)Math.Round((double)startValue.x);
				startValue.y = (float)Math.Round((double)startValue.y);
				startValue.width = (float)Math.Round((double)startValue.width);
				startValue.height = (float)Math.Round((double)startValue.height);
			}
			t.setter(startValue);
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x000080C9 File Offset: 0x000062C9
		public override Rect ConvertToStartValue(TweenerCore<Rect, Rect, RectOptions> t, Rect value)
		{
			return value;
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x0000A114 File Offset: 0x00008314
		public override void SetRelativeEndValue(TweenerCore<Rect, Rect, RectOptions> t)
		{
			t.endValue.x = t.endValue.x + t.startValue.x;
			t.endValue.y = t.endValue.y + t.startValue.y;
			t.endValue.width = t.endValue.width + t.startValue.width;
			t.endValue.height = t.endValue.height + t.startValue.height;
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x0000A198 File Offset: 0x00008398
		public override void SetChangeValue(TweenerCore<Rect, Rect, RectOptions> t)
		{
			t.changeValue = new Rect(t.endValue.x - t.startValue.x, t.endValue.y - t.startValue.y, t.endValue.width - t.startValue.width, t.endValue.height - t.startValue.height);
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x0000A20C File Offset: 0x0000840C
		public override float GetSpeedBasedDuration(RectOptions options, float unitsXSecond, Rect changeValue)
		{
			float width = changeValue.width;
			float height = changeValue.height;
			double num = (double)(width * width);
			float num2 = height;
			return (float)Math.Sqrt(num + (double)(num2 * num2)) / unitsXSecond;
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x0000A238 File Offset: 0x00008438
		public override void EvaluateAndApply(RectOptions options, Tween t, bool isRelative, DOGetter<Rect> getter, DOSetter<Rect> setter, float elapsed, Rect startValue, Rect changeValue, float duration, bool usingInversePosition, UpdateNotice updateNotice)
		{
			if (t.loopType == LoopType.Incremental)
			{
				int num = t.isComplete ? (t.completedLoops - 1) : t.completedLoops;
				startValue.x += changeValue.x * (float)num;
				startValue.y += changeValue.y * (float)num;
				startValue.width += changeValue.width * (float)num;
				startValue.height += changeValue.height * (float)num;
			}
			if (t.isSequenced && t.sequenceParent.loopType == LoopType.Incremental)
			{
				int num2 = ((t.loopType == LoopType.Incremental) ? t.loops : 1) * (t.sequenceParent.isComplete ? (t.sequenceParent.completedLoops - 1) : t.sequenceParent.completedLoops);
				startValue.x += changeValue.x * (float)num2;
				startValue.y += changeValue.y * (float)num2;
				startValue.width += changeValue.width * (float)num2;
				startValue.height += changeValue.height * (float)num2;
			}
			float num3 = EaseManager.Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);
			startValue.x += changeValue.x * num3;
			startValue.y += changeValue.y * num3;
			startValue.width += changeValue.width * num3;
			startValue.height += changeValue.height * num3;
			if (options.snapping)
			{
				startValue.x = (float)Math.Round((double)startValue.x);
				startValue.y = (float)Math.Round((double)startValue.y);
				startValue.width = (float)Math.Round((double)startValue.width);
				startValue.height = (float)Math.Round((double)startValue.height);
			}
			setter(startValue);
		}
	}
}
