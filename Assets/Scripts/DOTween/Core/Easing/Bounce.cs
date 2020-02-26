using System;

namespace DG.Tweening.Core.Easing
{
	// Token: 0x02000054 RID: 84
	public static class Bounce
	{
		// Token: 0x06000297 RID: 663 RVA: 0x0000EFC0 File Offset: 0x0000D1C0
		public static float EaseIn(float time, float duration, float unusedOvershootOrAmplitude, float unusedPeriod)
		{
			return 1f - Bounce.EaseOut(duration - time, duration, -1f, -1f);
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0000EFDC File Offset: 0x0000D1DC
		public static float EaseOut(float time, float duration, float unusedOvershootOrAmplitude, float unusedPeriod)
		{
			if ((time /= duration) < 0.363636374f)
			{
				return 7.5625f * time * time;
			}
			if (time < 0.727272749f)
			{
				return 7.5625f * (time -= 0.545454562f) * time + 0.75f;
			}
			if (time < 0.909090936f)
			{
				return 7.5625f * (time -= 0.8181818f) * time + 0.9375f;
			}
			return 7.5625f * (time -= 0.954545438f) * time + 0.984375f;
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0000F05C File Offset: 0x0000D25C
		public static float EaseInOut(float time, float duration, float unusedOvershootOrAmplitude, float unusedPeriod)
		{
			if (time < duration * 0.5f)
			{
				return Bounce.EaseIn(time * 2f, duration, -1f, -1f) * 0.5f;
			}
			return Bounce.EaseOut(time * 2f - duration, duration, -1f, -1f) * 0.5f + 0.5f;
		}
	}
}
