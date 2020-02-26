using System;
using UnityEngine;

namespace DG.Tweening.Core.Easing
{
	// Token: 0x02000056 RID: 86
	public class EaseCurve
	{
		// Token: 0x0600029D RID: 669 RVA: 0x0000FD25 File Offset: 0x0000DF25
		public EaseCurve(AnimationCurve animCurve)
		{
			this._animCurve = animCurve;
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0000FD34 File Offset: 0x0000DF34
		public float Evaluate(float time, float duration, float unusedOvershoot, float unusedPeriod)
		{
			float time2 = this._animCurve[this._animCurve.length - 1].time;
			float num = time / duration;
			return this._animCurve.Evaluate(num * time2);
		}

		// Token: 0x04000176 RID: 374
		private readonly AnimationCurve _animCurve;
	}
}
