using System;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening.Plugins
{
	// Token: 0x02000025 RID: 37
	public class RectOffsetPlugin : ABSTweenPlugin<RectOffset, RectOffset, NoOptions>
	{
		// Token: 0x060001B8 RID: 440 RVA: 0x00009B70 File Offset: 0x00007D70
		public override void Reset(TweenerCore<RectOffset, RectOffset, NoOptions> t)
		{
			t.startValue = (t.endValue = (t.changeValue = null));
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x00009B98 File Offset: 0x00007D98
		public override void SetFrom(TweenerCore<RectOffset, RectOffset, NoOptions> t, bool isRelative)
		{
			RectOffset endValue = t.endValue;
			t.endValue = t.getter();
			t.startValue = endValue;
			if (isRelative)
			{
				t.startValue.left += t.endValue.left;
				t.startValue.right += t.endValue.right;
				t.startValue.top += t.endValue.top;
				t.startValue.bottom += t.endValue.bottom;
			}
			t.setter(t.startValue);
		}

		// Token: 0x060001BA RID: 442 RVA: 0x00009C4C File Offset: 0x00007E4C
		public override RectOffset ConvertToStartValue(TweenerCore<RectOffset, RectOffset, NoOptions> t, RectOffset value)
		{
			return new RectOffset(value.left, value.right, value.top, value.bottom);
		}

		// Token: 0x060001BB RID: 443 RVA: 0x00009C6C File Offset: 0x00007E6C
		public override void SetRelativeEndValue(TweenerCore<RectOffset, RectOffset, NoOptions> t)
		{
			t.endValue.left += t.startValue.left;
			t.endValue.right += t.startValue.right;
			t.endValue.top += t.startValue.top;
			t.endValue.bottom += t.startValue.bottom;
		}

		// Token: 0x060001BC RID: 444 RVA: 0x00009CF0 File Offset: 0x00007EF0
		public override void SetChangeValue(TweenerCore<RectOffset, RectOffset, NoOptions> t)
		{
			t.changeValue = new RectOffset(t.endValue.left - t.startValue.left, t.endValue.right - t.startValue.right, t.endValue.top - t.startValue.top, t.endValue.bottom - t.startValue.bottom);
		}

		// Token: 0x060001BD RID: 445 RVA: 0x00009D64 File Offset: 0x00007F64
		public override float GetSpeedBasedDuration(NoOptions options, float unitsXSecond, RectOffset changeValue)
		{
			float num = (float)changeValue.right;
			if (num < 0f)
			{
				num = -num;
			}
			float num2 = (float)changeValue.bottom;
			if (num2 < 0f)
			{
				num2 = -num2;
			}
			float num3 = num;
			double num4 = (double)(num3 * num3);
			float num5 = num2;
			return (float)Math.Sqrt(num4 + (double)(num5 * num5)) / unitsXSecond;
		}

		// Token: 0x060001BE RID: 446 RVA: 0x00009DA8 File Offset: 0x00007FA8
		public override void EvaluateAndApply(NoOptions options, Tween t, bool isRelative, DOGetter<RectOffset> getter, DOSetter<RectOffset> setter, float elapsed, RectOffset startValue, RectOffset changeValue, float duration, bool usingInversePosition, UpdateNotice updateNotice)
		{
			RectOffsetPlugin._r.left = startValue.left;
			RectOffsetPlugin._r.right = startValue.right;
			RectOffsetPlugin._r.top = startValue.top;
			RectOffsetPlugin._r.bottom = startValue.bottom;
			if (t.loopType == LoopType.Incremental)
			{
				int num = t.isComplete ? (t.completedLoops - 1) : t.completedLoops;
				RectOffsetPlugin._r.left += changeValue.left * num;
				RectOffsetPlugin._r.right += changeValue.right * num;
				RectOffsetPlugin._r.top += changeValue.top * num;
				RectOffsetPlugin._r.bottom += changeValue.bottom * num;
			}
			if (t.isSequenced && t.sequenceParent.loopType == LoopType.Incremental)
			{
				int num2 = ((t.loopType == LoopType.Incremental) ? t.loops : 1) * (t.sequenceParent.isComplete ? (t.sequenceParent.completedLoops - 1) : t.sequenceParent.completedLoops);
				RectOffsetPlugin._r.left += changeValue.left * num2;
				RectOffsetPlugin._r.right += changeValue.right * num2;
				RectOffsetPlugin._r.top += changeValue.top * num2;
				RectOffsetPlugin._r.bottom += changeValue.bottom * num2;
			}
			float num3 = EaseManager.Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);
			setter(new RectOffset((int)Math.Round((double)((float)RectOffsetPlugin._r.left + (float)changeValue.left * num3)), (int)Math.Round((double)((float)RectOffsetPlugin._r.right + (float)changeValue.right * num3)), (int)Math.Round((double)((float)RectOffsetPlugin._r.top + (float)changeValue.top * num3)), (int)Math.Round((double)((float)RectOffsetPlugin._r.bottom + (float)changeValue.bottom * num3))));
		}

		// Token: 0x040000BE RID: 190
		private static RectOffset _r = new RectOffset();
	}
}
