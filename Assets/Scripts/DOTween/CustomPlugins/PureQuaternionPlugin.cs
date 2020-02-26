using System;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening.CustomPlugins
{
	// Token: 0x02000043 RID: 67
	public class PureQuaternionPlugin : ABSTweenPlugin<Quaternion, Quaternion, NoOptions>
	{
		// Token: 0x0600022F RID: 559 RVA: 0x0000CEAD File Offset: 0x0000B0AD
		public static PureQuaternionPlugin Plug()
		{
			if (PureQuaternionPlugin._plug == null)
			{
				PureQuaternionPlugin._plug = new PureQuaternionPlugin();
			}
			return PureQuaternionPlugin._plug;
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00007FEC File Offset: 0x000061EC
		public override void Reset(TweenerCore<Quaternion, Quaternion, NoOptions> t)
		{
		}

		// Token: 0x06000231 RID: 561 RVA: 0x0000CEC8 File Offset: 0x0000B0C8
		public override void SetFrom(TweenerCore<Quaternion, Quaternion, NoOptions> t, bool isRelative)
		{
			Quaternion endValue = t.endValue;
			t.endValue = t.getter();
			t.startValue = (isRelative ? (t.endValue * endValue) : endValue);
			t.setter(t.startValue);
		}

		// Token: 0x06000232 RID: 562 RVA: 0x000080C9 File Offset: 0x000062C9
		public override Quaternion ConvertToStartValue(TweenerCore<Quaternion, Quaternion, NoOptions> t, Quaternion value)
		{
			return value;
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0000CF18 File Offset: 0x0000B118
		public override void SetRelativeEndValue(TweenerCore<Quaternion, Quaternion, NoOptions> t)
		{
			t.endValue *= t.startValue;
		}

		// Token: 0x06000234 RID: 564 RVA: 0x0000CF40 File Offset: 0x0000B140
		public override void SetChangeValue(TweenerCore<Quaternion, Quaternion, NoOptions> t)
		{
			t.changeValue.x = t.endValue.x - t.startValue.x;
			t.changeValue.y = t.endValue.y - t.startValue.y;
			t.changeValue.z = t.endValue.z - t.startValue.z;
			t.changeValue.w = t.endValue.w - t.startValue.w;
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0000CFD8 File Offset: 0x0000B1D8
		public override float GetSpeedBasedDuration(NoOptions options, float unitsXSecond, Quaternion changeValue)
		{
			return changeValue.eulerAngles.magnitude / unitsXSecond;
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0000CFF8 File Offset: 0x0000B1F8
		public override void EvaluateAndApply(NoOptions options, Tween t, bool isRelative, DOGetter<Quaternion> getter, DOSetter<Quaternion> setter, float elapsed, Quaternion startValue, Quaternion changeValue, float duration, bool usingInversePosition, UpdateNotice updateNotice)
		{
			float num = EaseManager.Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);
			startValue.x += changeValue.x * num;
			startValue.y += changeValue.y * num;
			startValue.z += changeValue.z * num;
			startValue.w += changeValue.w * num;
			setter(startValue);
		}

		// Token: 0x04000112 RID: 274
		private static PureQuaternionPlugin _plug;
	}
}
