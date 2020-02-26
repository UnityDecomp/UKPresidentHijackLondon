using System;
using UnityEngine;

namespace DG.Tweening.Core.Easing
{
	// Token: 0x02000057 RID: 87
	public static class Flash
	{
		// Token: 0x0600029F RID: 671 RVA: 0x0000FD74 File Offset: 0x0000DF74
		public static float Ease(float time, float duration, float overshootOrAmplitude, float period)
		{
			int num = Mathf.CeilToInt(time / duration * overshootOrAmplitude);
			float num2 = duration / overshootOrAmplitude;
			time -= num2 * (float)(num - 1);
			float num3 = (float)((num % 2 != 0) ? 1 : -1);
			if (num3 < 0f)
			{
				time -= num2;
			}
			float res = time * num3 / num2;
			return Flash.WeightedEase(overshootOrAmplitude, period, num, num2, num3, res);
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x0000FDC4 File Offset: 0x0000DFC4
		public static float EaseIn(float time, float duration, float overshootOrAmplitude, float period)
		{
			int num = Mathf.CeilToInt(time / duration * overshootOrAmplitude);
			float num2 = duration / overshootOrAmplitude;
			time -= num2 * (float)(num - 1);
			float num3 = (float)((num % 2 != 0) ? 1 : -1);
			if (num3 < 0f)
			{
				time -= num2;
			}
			time *= num3;
			float res = (time /= num2) * time;
			return Flash.WeightedEase(overshootOrAmplitude, period, num, num2, num3, res);
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0000FE1C File Offset: 0x0000E01C
		public static float EaseOut(float time, float duration, float overshootOrAmplitude, float period)
		{
			int num = Mathf.CeilToInt(time / duration * overshootOrAmplitude);
			float num2 = duration / overshootOrAmplitude;
			time -= num2 * (float)(num - 1);
			float num3 = (float)((num % 2 != 0) ? 1 : -1);
			if (num3 < 0f)
			{
				time -= num2;
			}
			time *= num3;
			float res = -(time /= num2) * (time - 2f);
			return Flash.WeightedEase(overshootOrAmplitude, period, num, num2, num3, res);
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x0000FE7C File Offset: 0x0000E07C
		public static float EaseInOut(float time, float duration, float overshootOrAmplitude, float period)
		{
			int num = Mathf.CeilToInt(time / duration * overshootOrAmplitude);
			float num2 = duration / overshootOrAmplitude;
			time -= num2 * (float)(num - 1);
			float num3 = (float)((num % 2 != 0) ? 1 : -1);
			if (num3 < 0f)
			{
				time -= num2;
			}
			time *= num3;
			float res = ((time /= num2 * 0.5f) < 1f) ? (0.5f * time * time) : (-0.5f * ((time -= 1f) * (time - 2f) - 1f));
			return Flash.WeightedEase(overshootOrAmplitude, period, num, num2, num3, res);
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x0000FF08 File Offset: 0x0000E108
		private static float WeightedEase(float overshootOrAmplitude, float period, int stepIndex, float stepDuration, float dir, float res)
		{
			float num = 0f;
			float num2 = 0f;
			if (period > 0f)
			{
				float num3 = (float)Math.Truncate((double)overshootOrAmplitude);
				num2 = overshootOrAmplitude - num3;
				if (num3 % 2f > 0f)
				{
					num2 = 1f - num2;
				}
				num2 = num2 * (float)stepIndex / overshootOrAmplitude;
				num = res * (overshootOrAmplitude - (float)stepIndex) / overshootOrAmplitude;
			}
			else if (period < 0f)
			{
				period = -period;
				num = res * (float)stepIndex / overshootOrAmplitude;
			}
			float num4 = num - res;
			res += num4 * period + num2;
			if (res > 1f)
			{
				res = 1f;
			}
			return res;
		}
	}
}
