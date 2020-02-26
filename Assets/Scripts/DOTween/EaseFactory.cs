using System;
using DG.Tweening.Core.Easing;
using UnityEngine;

namespace DG.Tweening
{
	// Token: 0x0200000B RID: 11
	public class EaseFactory
	{
		// Token: 0x06000061 RID: 97 RVA: 0x00002DAC File Offset: 0x00000FAC
		public static EaseFunction StopMotion(int motionFps, Ease? ease = null)
		{
			EaseFunction customEase = EaseManager.ToEaseFunction((ease == null) ? DOTween.defaultEaseType : ease.Value);
			return EaseFactory.StopMotion(motionFps, customEase);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00002DDD File Offset: 0x00000FDD
		public static EaseFunction StopMotion(int motionFps, AnimationCurve animCurve)
		{
			return EaseFactory.StopMotion(motionFps, new EaseFunction(new EaseCurve(animCurve).Evaluate));
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00002DF6 File Offset: 0x00000FF6
		public static EaseFunction StopMotion(int motionFps, EaseFunction customEase)
		{
			float motionDelay = 1f / (float)motionFps;
			return delegate(float time, float duration, float overshootOrAmplitude, float period)
			{
				float time2 = (time < duration) ? (time - time % motionDelay) : time;
				return customEase(time2, duration, overshootOrAmplitude, period);
			};
		}
	}
}
