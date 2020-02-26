using System;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Options;

namespace DG.Tweening.Plugins
{
	// Token: 0x0200001C RID: 28
	internal class Color2Plugin : ABSTweenPlugin<Color2, Color2, ColorOptions>
	{
		// Token: 0x0600016E RID: 366 RVA: 0x00007FEC File Offset: 0x000061EC
		public override void Reset(TweenerCore<Color2, Color2, ColorOptions> t)
		{
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00007FF0 File Offset: 0x000061F0
		public override void SetFrom(TweenerCore<Color2, Color2, ColorOptions> t, bool isRelative)
		{
			Color2 endValue = t.endValue;
			t.endValue = t.getter();
			if (isRelative)
			{
				t.startValue = new Color2(t.endValue.ca + endValue.ca, t.endValue.cb + endValue.cb);
			}
			else
			{
				t.startValue = new Color2(endValue.ca, endValue.cb);
			}
			Color2 pNewValue = t.endValue;
			if (!t.plugOptions.alphaOnly)
			{
				pNewValue = t.startValue;
			}
			else
			{
				pNewValue.ca.a = t.startValue.ca.a;
				pNewValue.cb.a = t.startValue.cb.a;
			}
			t.setter(pNewValue);
		}

		// Token: 0x06000170 RID: 368 RVA: 0x000080C9 File Offset: 0x000062C9
		public override Color2 ConvertToStartValue(TweenerCore<Color2, Color2, ColorOptions> t, Color2 value)
		{
			return value;
		}

		// Token: 0x06000171 RID: 369 RVA: 0x000080CC File Offset: 0x000062CC
		public override void SetRelativeEndValue(TweenerCore<Color2, Color2, ColorOptions> t)
		{
			t.endValue += t.startValue;
		}

		// Token: 0x06000172 RID: 370 RVA: 0x000080F2 File Offset: 0x000062F2
		public override void SetChangeValue(TweenerCore<Color2, Color2, ColorOptions> t)
		{
			t.changeValue = t.endValue - t.startValue;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x0000810B File Offset: 0x0000630B
		public override float GetSpeedBasedDuration(ColorOptions options, float unitsXSecond, Color2 changeValue)
		{
			return 1f / unitsXSecond;
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00008114 File Offset: 0x00006314
		public override void EvaluateAndApply(ColorOptions options, Tween t, bool isRelative, DOGetter<Color2> getter, DOSetter<Color2> setter, float elapsed, Color2 startValue, Color2 changeValue, float duration, bool usingInversePosition, UpdateNotice updateNotice)
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
			if (!options.alphaOnly)
			{
				startValue.ca.r = startValue.ca.r + changeValue.ca.r * num;
				startValue.ca.g = startValue.ca.g + changeValue.ca.g * num;
				startValue.ca.b = startValue.ca.b + changeValue.ca.b * num;
				startValue.ca.a = startValue.ca.a + changeValue.ca.a * num;
				startValue.cb.r = startValue.cb.r + changeValue.cb.r * num;
				startValue.cb.g = startValue.cb.g + changeValue.cb.g * num;
				startValue.cb.b = startValue.cb.b + changeValue.cb.b * num;
				startValue.cb.a = startValue.cb.a + changeValue.cb.a * num;
				setter(startValue);
				return;
			}
			Color2 pNewValue = getter();
			pNewValue.ca.a = startValue.ca.a + changeValue.ca.a * num;
			pNewValue.cb.a = startValue.cb.a + changeValue.cb.a * num;
			setter(pNewValue);
		}
	}
}
