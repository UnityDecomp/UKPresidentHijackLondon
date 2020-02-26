using System;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Plugins;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening
{
	// Token: 0x02000016 RID: 22
	public static class TweenSettingsExtensions
	{
		// Token: 0x06000117 RID: 279 RVA: 0x00006492 File Offset: 0x00004692
		public static T SetAutoKill<T>(this T t) where T : Tween
		{
			if (t == null || !t.active || t.creationLocked)
			{
				return t;
			}
			t.autoKill = true;
			return t;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x000064C5 File Offset: 0x000046C5
		public static T SetAutoKill<T>(this T t, bool autoKillOnCompletion) where T : Tween
		{
			if (t == null || !t.active || t.creationLocked)
			{
				return t;
			}
			t.autoKill = autoKillOnCompletion;
			return t;
		}

		// Token: 0x06000119 RID: 281 RVA: 0x000064F8 File Offset: 0x000046F8
		public static T SetId<T>(this T t, object id) where T : Tween
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.id = id;
			return t;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0000651E File Offset: 0x0000471E
		public static T SetTarget<T>(this T t, object target) where T : Tween
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.target = target;
			return t;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00006544 File Offset: 0x00004744
		public static T SetLoops<T>(this T t, int loops) where T : Tween
		{
			if (t == null || !t.active || t.creationLocked)
			{
				return t;
			}
			if (loops < -1)
			{
				loops = -1;
			}
			else if (loops == 0)
			{
				loops = 1;
			}
			t.loops = loops;
			if (t.tweenType == TweenType.Tweener)
			{
				if (loops > -1)
				{
					t.fullDuration = t.duration * (float)loops;
				}
				else
				{
					t.fullDuration = float.PositiveInfinity;
				}
			}
			return t;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x000065D0 File Offset: 0x000047D0
		public static T SetLoops<T>(this T t, int loops, LoopType loopType) where T : Tween
		{
			if (t == null || !t.active || t.creationLocked)
			{
				return t;
			}
			if (loops < -1)
			{
				loops = -1;
			}
			else if (loops == 0)
			{
				loops = 1;
			}
			t.loops = loops;
			t.loopType = loopType;
			if (t.tweenType == TweenType.Tweener)
			{
				if (loops > -1)
				{
					t.fullDuration = t.duration * (float)loops;
				}
				else
				{
					t.fullDuration = float.PositiveInfinity;
				}
			}
			return t;
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00006665 File Offset: 0x00004865
		public static T SetEase<T>(this T t, Ease ease) where T : Tween
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.easeType = ease;
			t.customEase = null;
			return t;
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00006697 File Offset: 0x00004897
		public static T SetEase<T>(this T t, Ease ease, float overshoot) where T : Tween
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.easeType = ease;
			t.easeOvershootOrAmplitude = overshoot;
			t.customEase = null;
			return t;
		}

		// Token: 0x0600011F RID: 287 RVA: 0x000066D8 File Offset: 0x000048D8
		public static T SetEase<T>(this T t, Ease ease, float amplitude, float period) where T : Tween
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.easeType = ease;
			t.easeOvershootOrAmplitude = amplitude;
			t.easePeriod = period;
			t.customEase = null;
			return t;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00006730 File Offset: 0x00004930
		public static T SetEase<T>(this T t, AnimationCurve animCurve) where T : Tween
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.easeType = Ease.INTERNAL_Custom;
			t.customEase = new EaseFunction(new EaseCurve(animCurve).Evaluate);
			return t;
		}

		// Token: 0x06000121 RID: 289 RVA: 0x0000677E File Offset: 0x0000497E
		public static T SetEase<T>(this T t, EaseFunction customEase) where T : Tween
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.easeType = Ease.INTERNAL_Custom;
			t.customEase = customEase;
			return t;
		}

		// Token: 0x06000122 RID: 290 RVA: 0x000067B1 File Offset: 0x000049B1
		public static T SetRecyclable<T>(this T t) where T : Tween
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.isRecyclable = true;
			return t;
		}

		// Token: 0x06000123 RID: 291 RVA: 0x000067D7 File Offset: 0x000049D7
		public static T SetRecyclable<T>(this T t, bool recyclable) where T : Tween
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.isRecyclable = recyclable;
			return t;
		}

		// Token: 0x06000124 RID: 292 RVA: 0x000067FD File Offset: 0x000049FD
		public static T SetUpdate<T>(this T t, bool isIndependentUpdate) where T : Tween
		{
			if (t == null || !t.active)
			{
				return t;
			}
			TweenManager.SetUpdateType(t, DOTween.defaultUpdateType, isIndependentUpdate);
			return t;
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00006828 File Offset: 0x00004A28
		public static T SetUpdate<T>(this T t, UpdateType updateType) where T : Tween
		{
			if (t == null || !t.active)
			{
				return t;
			}
			TweenManager.SetUpdateType(t, updateType, DOTween.defaultTimeScaleIndependent);
			return t;
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00006853 File Offset: 0x00004A53
		public static T SetUpdate<T>(this T t, UpdateType updateType, bool isIndependentUpdate) where T : Tween
		{
			if (t == null || !t.active)
			{
				return t;
			}
			TweenManager.SetUpdateType(t, updateType, isIndependentUpdate);
			return t;
		}

		// Token: 0x06000127 RID: 295 RVA: 0x0000687A File Offset: 0x00004A7A
		public static T OnStart<T>(this T t, TweenCallback action) where T : Tween
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.onStart = action;
			return t;
		}

		// Token: 0x06000128 RID: 296 RVA: 0x000068A0 File Offset: 0x00004AA0
		public static T OnPlay<T>(this T t, TweenCallback action) where T : Tween
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.onPlay = action;
			return t;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x000068C6 File Offset: 0x00004AC6
		public static T OnPause<T>(this T t, TweenCallback action) where T : Tween
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.onPause = action;
			return t;
		}

		// Token: 0x0600012A RID: 298 RVA: 0x000068EC File Offset: 0x00004AEC
		public static T OnRewind<T>(this T t, TweenCallback action) where T : Tween
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.onRewind = action;
			return t;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00006912 File Offset: 0x00004B12
		public static T OnUpdate<T>(this T t, TweenCallback action) where T : Tween
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.onUpdate = action;
			return t;
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00006938 File Offset: 0x00004B38
		public static T OnStepComplete<T>(this T t, TweenCallback action) where T : Tween
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.onStepComplete = action;
			return t;
		}

		// Token: 0x0600012D RID: 301 RVA: 0x0000695E File Offset: 0x00004B5E
		public static T OnComplete<T>(this T t, TweenCallback action) where T : Tween
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.onComplete = action;
			return t;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00006984 File Offset: 0x00004B84
		public static T OnKill<T>(this T t, TweenCallback action) where T : Tween
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.onKill = action;
			return t;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x000069AA File Offset: 0x00004BAA
		public static T OnWaypointChange<T>(this T t, TweenCallback<int> action) where T : Tween
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.onWaypointChange = action;
			return t;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x000069D0 File Offset: 0x00004BD0
		public static T SetAs<T>(this T t, Tween asTween) where T : Tween
		{
			if (t == null || !t.active || t.creationLocked)
			{
				return t;
			}
			t.timeScale = asTween.timeScale;
			t.isBackwards = asTween.isBackwards;
			TweenManager.SetUpdateType(t, asTween.updateType, asTween.isIndependentUpdate);
			t.id = asTween.id;
			t.onStart = asTween.onStart;
			t.onPlay = asTween.onPlay;
			t.onRewind = asTween.onRewind;
			t.onUpdate = asTween.onUpdate;
			t.onStepComplete = asTween.onStepComplete;
			t.onComplete = asTween.onComplete;
			t.onKill = asTween.onKill;
			t.onWaypointChange = asTween.onWaypointChange;
			t.isRecyclable = asTween.isRecyclable;
			t.isSpeedBased = asTween.isSpeedBased;
			t.autoKill = asTween.autoKill;
			t.loops = asTween.loops;
			t.loopType = asTween.loopType;
			if (t.tweenType == TweenType.Tweener)
			{
				if (t.loops > -1)
				{
					t.fullDuration = t.duration * (float)t.loops;
				}
				else
				{
					t.fullDuration = float.PositiveInfinity;
				}
			}
			t.delay = asTween.delay;
			t.delayComplete = (t.delay <= 0f);
			t.isRelative = asTween.isRelative;
			t.easeType = asTween.easeType;
			t.customEase = asTween.customEase;
			t.easeOvershootOrAmplitude = asTween.easeOvershootOrAmplitude;
			t.easePeriod = asTween.easePeriod;
			return t;
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00006C00 File Offset: 0x00004E00
		public static T SetAs<T>(this T t, TweenParams tweenParams) where T : Tween
		{
			if (t == null || !t.active || t.creationLocked)
			{
				return t;
			}
			TweenManager.SetUpdateType(t, tweenParams.updateType, tweenParams.isIndependentUpdate);
			t.id = tweenParams.id;
			t.onStart = tweenParams.onStart;
			t.onPlay = tweenParams.onPlay;
			t.onRewind = tweenParams.onRewind;
			t.onUpdate = tweenParams.onUpdate;
			t.onStepComplete = tweenParams.onStepComplete;
			t.onComplete = tweenParams.onComplete;
			t.onKill = tweenParams.onKill;
			t.onWaypointChange = tweenParams.onWaypointChange;
			t.isRecyclable = tweenParams.isRecyclable;
			t.isSpeedBased = tweenParams.isSpeedBased;
			t.autoKill = tweenParams.autoKill;
			t.loops = tweenParams.loops;
			t.loopType = tweenParams.loopType;
			if (t.tweenType == TweenType.Tweener)
			{
				if (t.loops > -1)
				{
					t.fullDuration = t.duration * (float)t.loops;
				}
				else
				{
					t.fullDuration = float.PositiveInfinity;
				}
			}
			t.delay = tweenParams.delay;
			t.delayComplete = (t.delay <= 0f);
			t.isRelative = tweenParams.isRelative;
			if (tweenParams.easeType == Ease.Unset)
			{
				if (t.tweenType == TweenType.Sequence)
				{
					t.easeType = Ease.Linear;
				}
				else
				{
					t.easeType = DOTween.defaultEaseType;
				}
			}
			else
			{
				t.easeType = tweenParams.easeType;
			}
			t.customEase = tweenParams.customEase;
			t.easeOvershootOrAmplitude = tweenParams.easeOvershootOrAmplitude;
			t.easePeriod = tweenParams.easePeriod;
			return t;
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00006E43 File Offset: 0x00005043
		public static Sequence Append(this Sequence s, Tween t)
		{
			if (s == null || !s.active || s.creationLocked)
			{
				return s;
			}
			if (t == null || !t.active || t.isSequenced)
			{
				return s;
			}
			Sequence.DoInsert(s, t, s.duration);
			return s;
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00006E7E File Offset: 0x0000507E
		public static Sequence Prepend(this Sequence s, Tween t)
		{
			if (s == null || !s.active || s.creationLocked)
			{
				return s;
			}
			if (t == null || !t.active || t.isSequenced)
			{
				return s;
			}
			Sequence.DoPrepend(s, t);
			return s;
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00006EB3 File Offset: 0x000050B3
		public static Sequence Join(this Sequence s, Tween t)
		{
			if (s == null || !s.active || s.creationLocked)
			{
				return s;
			}
			if (t == null || !t.active || t.isSequenced)
			{
				return s;
			}
			Sequence.DoInsert(s, t, s.lastTweenInsertTime);
			return s;
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00006EEE File Offset: 0x000050EE
		public static Sequence Insert(this Sequence s, float atPosition, Tween t)
		{
			if (s == null || !s.active || s.creationLocked)
			{
				return s;
			}
			if (t == null || !t.active || t.isSequenced)
			{
				return s;
			}
			Sequence.DoInsert(s, t, atPosition);
			return s;
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00006F24 File Offset: 0x00005124
		public static Sequence AppendInterval(this Sequence s, float interval)
		{
			if (s == null || !s.active || s.creationLocked)
			{
				return s;
			}
			Sequence.DoAppendInterval(s, interval);
			return s;
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00006F44 File Offset: 0x00005144
		public static Sequence PrependInterval(this Sequence s, float interval)
		{
			if (s == null || !s.active || s.creationLocked)
			{
				return s;
			}
			Sequence.DoPrependInterval(s, interval);
			return s;
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00006F64 File Offset: 0x00005164
		public static Sequence AppendCallback(this Sequence s, TweenCallback callback)
		{
			if (s == null || !s.active || s.creationLocked)
			{
				return s;
			}
			if (callback == null)
			{
				return s;
			}
			Sequence.DoInsertCallback(s, callback, s.duration);
			return s;
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00006F8F File Offset: 0x0000518F
		public static Sequence PrependCallback(this Sequence s, TweenCallback callback)
		{
			if (s == null || !s.active || s.creationLocked)
			{
				return s;
			}
			if (callback == null)
			{
				return s;
			}
			Sequence.DoInsertCallback(s, callback, 0f);
			return s;
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00006FB9 File Offset: 0x000051B9
		public static Sequence InsertCallback(this Sequence s, float atPosition, TweenCallback callback)
		{
			if (s == null || !s.active || s.creationLocked)
			{
				return s;
			}
			if (callback == null)
			{
				return s;
			}
			Sequence.DoInsertCallback(s, callback, atPosition);
			return s;
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00006FE0 File Offset: 0x000051E0
		public static T From<T>(this T t) where T : Tweener
		{
			if (t == null || !t.active || t.creationLocked || !t.isFromAllowed)
			{
				return t;
			}
			t.isFrom = true;
			t.SetFrom(false);
			return t;
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00007038 File Offset: 0x00005238
		public static T From<T>(this T t, bool isRelative) where T : Tweener
		{
			if (t == null || !t.active || t.creationLocked || !t.isFromAllowed)
			{
				return t;
			}
			t.isFrom = true;
			if (!isRelative)
			{
				t.SetFrom(false);
			}
			else
			{
				t.SetFrom(!t.isBlendable);
			}
			return t;
		}

		// Token: 0x0600013D RID: 317 RVA: 0x000070B0 File Offset: 0x000052B0
		public static T SetDelay<T>(this T t, float delay) where T : Tween
		{
			if (t == null || !t.active || t.creationLocked)
			{
				return t;
			}
			if (t.tweenType == TweenType.Sequence)
			{
				(t as Sequence).PrependInterval(delay);
			}
			else
			{
				t.delay = delay;
				t.delayComplete = (delay <= 0f);
			}
			return t;
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00007128 File Offset: 0x00005328
		public static T SetRelative<T>(this T t) where T : Tween
		{
			if (t == null || !t.active || t.creationLocked || t.isFrom || t.isBlendable)
			{
				return t;
			}
			t.isRelative = true;
			return t;
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00007180 File Offset: 0x00005380
		public static T SetRelative<T>(this T t, bool isRelative) where T : Tween
		{
			if (t == null || !t.active || t.creationLocked || t.isFrom || t.isBlendable)
			{
				return t;
			}
			t.isRelative = isRelative;
			return t;
		}

		// Token: 0x06000140 RID: 320 RVA: 0x000071D8 File Offset: 0x000053D8
		public static T SetSpeedBased<T>(this T t) where T : Tween
		{
			if (t == null || !t.active || t.creationLocked)
			{
				return t;
			}
			t.isSpeedBased = true;
			return t;
		}

		// Token: 0x06000141 RID: 321 RVA: 0x0000720B File Offset: 0x0000540B
		public static T SetSpeedBased<T>(this T t, bool isSpeedBased) where T : Tween
		{
			if (t == null || !t.active || t.creationLocked)
			{
				return t;
			}
			t.isSpeedBased = isSpeedBased;
			return t;
		}

		// Token: 0x06000142 RID: 322 RVA: 0x0000723E File Offset: 0x0000543E
		public static Tweener SetOptions(this TweenerCore<float, float, FloatOptions> t, bool snapping)
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.plugOptions.snapping = snapping;
			return t;
		}

		// Token: 0x06000143 RID: 323 RVA: 0x0000725A File Offset: 0x0000545A
		public static Tweener SetOptions(this TweenerCore<Vector2, Vector2, VectorOptions> t, bool snapping)
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.plugOptions.snapping = snapping;
			return t;
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00007276 File Offset: 0x00005476
		public static Tweener SetOptions(this TweenerCore<Vector2, Vector2, VectorOptions> t, AxisConstraint axisConstraint, bool snapping = false)
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.plugOptions.axisConstraint = axisConstraint;
			t.plugOptions.snapping = snapping;
			return t;
		}

		// Token: 0x06000145 RID: 325 RVA: 0x0000729E File Offset: 0x0000549E
		public static Tweener SetOptions(this TweenerCore<Vector3, Vector3, VectorOptions> t, bool snapping)
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.plugOptions.snapping = snapping;
			return t;
		}

		// Token: 0x06000146 RID: 326 RVA: 0x000072BA File Offset: 0x000054BA
		public static Tweener SetOptions(this TweenerCore<Vector3, Vector3, VectorOptions> t, AxisConstraint axisConstraint, bool snapping = false)
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.plugOptions.axisConstraint = axisConstraint;
			t.plugOptions.snapping = snapping;
			return t;
		}

		// Token: 0x06000147 RID: 327 RVA: 0x000072E2 File Offset: 0x000054E2
		public static Tweener SetOptions(this TweenerCore<Vector4, Vector4, VectorOptions> t, bool snapping)
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.plugOptions.snapping = snapping;
			return t;
		}

		// Token: 0x06000148 RID: 328 RVA: 0x000072FE File Offset: 0x000054FE
		public static Tweener SetOptions(this TweenerCore<Vector4, Vector4, VectorOptions> t, AxisConstraint axisConstraint, bool snapping = false)
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.plugOptions.axisConstraint = axisConstraint;
			t.plugOptions.snapping = snapping;
			return t;
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00007326 File Offset: 0x00005526
		public static Tweener SetOptions(this TweenerCore<Quaternion, Vector3, QuaternionOptions> t, bool useShortest360Route = true)
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.plugOptions.rotateMode = (useShortest360Route ? RotateMode.Fast : RotateMode.FastBeyond360);
			return t;
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00007348 File Offset: 0x00005548
		public static Tweener SetOptions(this TweenerCore<Color, Color, ColorOptions> t, bool alphaOnly)
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.plugOptions.alphaOnly = alphaOnly;
			return t;
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00007364 File Offset: 0x00005564
		public static Tweener SetOptions(this TweenerCore<Rect, Rect, RectOptions> t, bool snapping)
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.plugOptions.snapping = snapping;
			return t;
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00007380 File Offset: 0x00005580
		public static Tweener SetOptions(this TweenerCore<string, string, StringOptions> t, bool richTextEnabled, ScrambleMode scrambleMode = ScrambleMode.None, string scrambleChars = null)
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.plugOptions.richTextEnabled = richTextEnabled;
			t.plugOptions.scrambleMode = scrambleMode;
			if (!string.IsNullOrEmpty(scrambleChars))
			{
				if (scrambleChars.Length <= 1)
				{
					string text = scrambleChars;
					scrambleChars = text + text;
				}
				t.plugOptions.scrambledChars = scrambleChars.ToCharArray();
				t.plugOptions.scrambledChars.ScrambleChars();
			}
			return t;
		}

		// Token: 0x0600014D RID: 333 RVA: 0x000073EE File Offset: 0x000055EE
		public static Tweener SetOptions(this TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t, bool snapping)
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.plugOptions.snapping = snapping;
			return t;
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0000740A File Offset: 0x0000560A
		public static Tweener SetOptions(this TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t, AxisConstraint axisConstraint, bool snapping = false)
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.plugOptions.axisConstraint = axisConstraint;
			t.plugOptions.snapping = snapping;
			return t;
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00007432 File Offset: 0x00005632
		public static TweenerCore<Vector3, Path, PathOptions> SetOptions(this TweenerCore<Vector3, Path, PathOptions> t, AxisConstraint lockPosition, AxisConstraint lockRotation = AxisConstraint.None)
		{
			return t.SetOptions(false, lockPosition, lockRotation);
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0000743D File Offset: 0x0000563D
		public static TweenerCore<Vector3, Path, PathOptions> SetOptions(this TweenerCore<Vector3, Path, PathOptions> t, bool closePath, AxisConstraint lockPosition = AxisConstraint.None, AxisConstraint lockRotation = AxisConstraint.None)
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.plugOptions.isClosedPath = closePath;
			t.plugOptions.lockPositionAxis = lockPosition;
			t.plugOptions.lockRotationAxis = lockRotation;
			return t;
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00007471 File Offset: 0x00005671
		public static TweenerCore<Vector3, Path, PathOptions> SetLookAt(this TweenerCore<Vector3, Path, PathOptions> t, Vector3 lookAtPosition, Vector3? forwardDirection = null, Vector3? up = null)
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.plugOptions.orientType = OrientType.LookAtPosition;
			t.plugOptions.lookAtPosition = lookAtPosition;
			t.SetPathForwardDirection(forwardDirection, up);
			return t;
		}

		// Token: 0x06000152 RID: 338 RVA: 0x000074A1 File Offset: 0x000056A1
		public static TweenerCore<Vector3, Path, PathOptions> SetLookAt(this TweenerCore<Vector3, Path, PathOptions> t, Transform lookAtTransform, Vector3? forwardDirection = null, Vector3? up = null)
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.plugOptions.orientType = OrientType.LookAtTransform;
			t.plugOptions.lookAtTransform = lookAtTransform;
			t.SetPathForwardDirection(forwardDirection, up);
			return t;
		}

		// Token: 0x06000153 RID: 339 RVA: 0x000074D1 File Offset: 0x000056D1
		public static TweenerCore<Vector3, Path, PathOptions> SetLookAt(this TweenerCore<Vector3, Path, PathOptions> t, float lookAhead, Vector3? forwardDirection = null, Vector3? up = null)
		{
			if (t == null || !t.active)
			{
				return t;
			}
			t.plugOptions.orientType = OrientType.ToPath;
			if (lookAhead < 0.0001f)
			{
				lookAhead = 0.0001f;
			}
			t.plugOptions.lookAhead = lookAhead;
			t.SetPathForwardDirection(forwardDirection, up);
			return t;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00007510 File Offset: 0x00005710
		private static void SetPathForwardDirection(this TweenerCore<Vector3, Path, PathOptions> t, Vector3? forwardDirection = null, Vector3? up = null)
		{
			if (t == null || !t.active)
			{
				return;
			}
			bool hasCustomForwardDirection;
			if (forwardDirection != null)
			{
				Vector3? vector = forwardDirection;
				Vector3 zero = Vector3.zero;
				if (vector == null || (vector != null && vector.GetValueOrDefault() != zero))
				{
					hasCustomForwardDirection = true;
					goto IL_86;
				}
			}
			if (up != null)
			{
				Vector3? vector = up;
				Vector3 zero = Vector3.zero;
				hasCustomForwardDirection = (vector == null || (vector != null && vector.GetValueOrDefault() != zero));
			}
			else
			{
				hasCustomForwardDirection = false;
			}
			IL_86:
			t.plugOptions.hasCustomForwardDirection = hasCustomForwardDirection;
			if (t.plugOptions.hasCustomForwardDirection)
			{
				Vector3? vector = forwardDirection;
				Vector3 zero = Vector3.zero;
				if (vector != null && (vector == null || vector.GetValueOrDefault() == zero))
				{
					forwardDirection = new Vector3?(Vector3.forward);
				}
				t.plugOptions.forward = Quaternion.LookRotation((forwardDirection == null) ? Vector3.forward : forwardDirection.Value, (up == null) ? Vector3.up : up.Value);
			}
		}
	}
}
