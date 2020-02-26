using System;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening
{
	// Token: 0x02000009 RID: 9
	public static class DOVirtual
	{
		// Token: 0x0600005B RID: 91 RVA: 0x00002CB4 File Offset: 0x00000EB4
		public static Tweener Float(float from, float to, float duration, TweenCallback<float> onVirtualUpdate)
		{
			return DOTween.To(() => from, delegate(float x)
			{
				from = x;
			}, to, duration).OnUpdate(delegate
			{
				onVirtualUpdate(from);
			});
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00002D05 File Offset: 0x00000F05
		public static float EasedValue(float from, float to, float lifetimePercentage, Ease easeType)
		{
			return from + (to - from) * EaseManager.Evaluate(easeType, null, lifetimePercentage, 1f, DOTween.defaultEaseOvershootOrAmplitude, DOTween.defaultEasePeriod);
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00002D24 File Offset: 0x00000F24
		public static float EasedValue(float from, float to, float lifetimePercentage, Ease easeType, float overshoot)
		{
			return from + (to - from) * EaseManager.Evaluate(easeType, null, lifetimePercentage, 1f, overshoot, DOTween.defaultEasePeriod);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00002D40 File Offset: 0x00000F40
		public static float EasedValue(float from, float to, float lifetimePercentage, Ease easeType, float amplitude, float period)
		{
			return from + (to - from) * EaseManager.Evaluate(easeType, null, lifetimePercentage, 1f, amplitude, period);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00002D59 File Offset: 0x00000F59
		public static float EasedValue(float from, float to, float lifetimePercentage, AnimationCurve easeCurve)
		{
			return from + (to - from) * EaseManager.Evaluate(Ease.INTERNAL_Custom, new EaseFunction(new EaseCurve(easeCurve).Evaluate), lifetimePercentage, 1f, DOTween.defaultEaseOvershootOrAmplitude, DOTween.defaultEasePeriod);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00002D89 File Offset: 0x00000F89
		public static Tween DelayedCall(float delay, TweenCallback callback, bool ignoreTimeScale = true)
		{
			return DOTween.Sequence().AppendInterval(delay).OnStepComplete(callback).SetUpdate(UpdateType.Normal, ignoreTimeScale).SetAutoKill(true);
		}
	}
}
