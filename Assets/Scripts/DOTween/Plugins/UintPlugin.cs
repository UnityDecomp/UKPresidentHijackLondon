using System;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Options;

namespace DG.Tweening.Plugins
{
	// Token: 0x02000027 RID: 39
	public class UintPlugin : ABSTweenPlugin<uint, uint, NoOptions>
	{
		// Token: 0x060001C9 RID: 457 RVA: 0x00007FEC File Offset: 0x000061EC
		public override void Reset(TweenerCore<uint, uint, NoOptions> t)
		{
		}

		// Token: 0x060001CA RID: 458 RVA: 0x0000A46C File Offset: 0x0000866C
		public override void SetFrom(TweenerCore<uint, uint, NoOptions> t, bool isRelative)
		{
			uint endValue = t.endValue;
			t.endValue = t.getter();
			t.startValue = (isRelative ? (t.endValue + endValue) : endValue);
			t.setter(t.startValue);
		}

		// Token: 0x060001CB RID: 459 RVA: 0x000080C9 File Offset: 0x000062C9
		public override uint ConvertToStartValue(TweenerCore<uint, uint, NoOptions> t, uint value)
		{
			return value;
		}

		// Token: 0x060001CC RID: 460 RVA: 0x0000A4B6 File Offset: 0x000086B6
		public override void SetRelativeEndValue(TweenerCore<uint, uint, NoOptions> t)
		{
			t.endValue += t.startValue;
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0000A4CB File Offset: 0x000086CB
		public override void SetChangeValue(TweenerCore<uint, uint, NoOptions> t)
		{
			t.changeValue = t.endValue - t.startValue;
		}

		// Token: 0x060001CE RID: 462 RVA: 0x0000A4E0 File Offset: 0x000086E0
		public override float GetSpeedBasedDuration(NoOptions options, float unitsXSecond, uint changeValue)
		{
			float num = changeValue / unitsXSecond;
			if (num < 0f)
			{
				num = -num;
			}
			return num;
		}

		// Token: 0x060001CF RID: 463 RVA: 0x0000A500 File Offset: 0x00008700
		public override void EvaluateAndApply(NoOptions options, Tween t, bool isRelative, DOGetter<uint> getter, DOSetter<uint> setter, float elapsed, uint startValue, uint changeValue, float duration, bool usingInversePosition, UpdateNotice updateNotice)
		{
			if (t.loopType == LoopType.Incremental)
			{
				startValue += (uint)((ulong)changeValue * (ulong)((long)(t.isComplete ? (t.completedLoops - 1) : t.completedLoops)));
			}
			if (t.isSequenced && t.sequenceParent.loopType == LoopType.Incremental)
			{
				startValue += (uint)((ulong)changeValue * (ulong)((long)((t.loopType == LoopType.Incremental) ? t.loops : 1)) * (ulong)((long)(t.sequenceParent.isComplete ? (t.sequenceParent.completedLoops - 1) : t.sequenceParent.completedLoops)));
			}
			setter((uint)Math.Round((double)(startValue + changeValue * EaseManager.Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod))));
		}
	}
}
