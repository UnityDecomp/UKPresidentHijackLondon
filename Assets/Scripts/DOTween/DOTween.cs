using System;
using System.Collections.Generic;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening
{
	// Token: 0x02000008 RID: 8
	public class DOTween
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000011 RID: 17 RVA: 0x000020D1 File Offset: 0x000002D1
		// (set) Token: 0x06000012 RID: 18 RVA: 0x000020D8 File Offset: 0x000002D8
		public static LogBehaviour logBehaviour
		{
			get
			{
				return DOTween._logBehaviour;
			}
			set
			{
				DOTween._logBehaviour = value;
				Debugger.SetLogPriority(DOTween._logBehaviour);
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000020EC File Offset: 0x000002EC
		static DOTween()
		{
			DOTween.isUnityEditor = Application.isEditor;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002171 File Offset: 0x00000371
		public static IDOTweenInit Init(bool? recycleAllByDefault = null, bool? useSafeMode = null, LogBehaviour? logBehaviour = null)
		{
			if (DOTween.initialized)
			{
				return DOTween.instance;
			}
			if (!Application.isPlaying || DOTween.isQuitting)
			{
				return null;
			}
			return DOTween.Init(Resources.Load("DOTweenSettings") as DOTweenSettings, recycleAllByDefault, useSafeMode, logBehaviour);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000021A8 File Offset: 0x000003A8
		private static void AutoInit()
		{
			DOTween.Init(Resources.Load("DOTweenSettings") as DOTweenSettings, null, null, null);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000021E8 File Offset: 0x000003E8
		private static IDOTweenInit Init(DOTweenSettings settings, bool? recycleAllByDefault, bool? useSafeMode, LogBehaviour? logBehaviour)
		{
			DOTween.initialized = true;
			if (recycleAllByDefault != null)
			{
				DOTween.defaultRecyclable = recycleAllByDefault.Value;
			}
			if (useSafeMode != null)
			{
				DOTween.useSafeMode = useSafeMode.Value;
			}
			if (logBehaviour != null)
			{
				DOTween.logBehaviour = logBehaviour.Value;
			}
			DOTweenComponent.Create();
			if (settings != null)
			{
				if (useSafeMode == null)
				{
					DOTween.useSafeMode = settings.useSafeMode;
				}
				if (logBehaviour == null)
				{
					DOTween.logBehaviour = settings.logBehaviour;
				}
				if (recycleAllByDefault == null)
				{
					DOTween.defaultRecyclable = settings.defaultRecyclable;
				}
				DOTween.timeScale = settings.timeScale;
				DOTween.useSmoothDeltaTime = settings.useSmoothDeltaTime;
				DOTween.defaultRecyclable = ((recycleAllByDefault == null) ? settings.defaultRecyclable : recycleAllByDefault.Value);
				DOTween.showUnityEditorReport = settings.showUnityEditorReport;
				DOTween.drawGizmos = settings.drawGizmos;
				DOTween.defaultAutoPlay = settings.defaultAutoPlay;
				DOTween.defaultUpdateType = settings.defaultUpdateType;
				DOTween.defaultTimeScaleIndependent = settings.defaultTimeScaleIndependent;
				DOTween.defaultEaseType = settings.defaultEaseType;
				DOTween.defaultEaseOvershootOrAmplitude = settings.defaultEaseOvershootOrAmplitude;
				DOTween.defaultEasePeriod = settings.defaultEasePeriod;
				DOTween.defaultAutoKill = settings.defaultAutoKill;
				DOTween.defaultLoopType = settings.defaultLoopType;
			}
			if (Debugger.logPriority >= 2)
			{
				Debugger.Log(string.Concat(new object[]
				{
					"DOTween initialization (useSafeMode: ",
					DOTween.useSafeMode.ToString(),
					", recycling: ",
					DOTween.defaultRecyclable ? "ON" : "OFF",
					", logBehaviour: ",
					DOTween.logBehaviour,
					")"
				}));
			}
			return DOTween.instance;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x0000239B File Offset: 0x0000059B
		public static void SetTweensCapacity(int tweenersCapacity, int sequencesCapacity)
		{
			TweenManager.SetCapacities(tweenersCapacity, sequencesCapacity);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000023A4 File Offset: 0x000005A4
		public static void Clear(bool destroy = false)
		{
			TweenManager.PurgeAll();
			PluginsManager.PurgeAll();
			if (!destroy)
			{
				return;
			}
			DOTween.initialized = false;
			DOTween.useSafeMode = false;
			DOTween.showUnityEditorReport = false;
			DOTween.drawGizmos = true;
			DOTween.timeScale = 1f;
			DOTween.useSmoothDeltaTime = false;
			DOTween.logBehaviour = LogBehaviour.ErrorsOnly;
			DOTween.defaultEaseType = Ease.OutQuad;
			DOTween.defaultEaseOvershootOrAmplitude = 1.70158f;
			DOTween.defaultEasePeriod = 0f;
			DOTween.defaultUpdateType = UpdateType.Normal;
			DOTween.defaultTimeScaleIndependent = false;
			DOTween.defaultAutoPlay = AutoPlay.All;
			DOTween.defaultLoopType = LoopType.Restart;
			DOTween.defaultAutoKill = true;
			DOTween.defaultRecyclable = false;
			DOTween.maxActiveTweenersReached = (DOTween.maxActiveSequencesReached = 0);
			DOTweenComponent.DestroyInstance();
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000243C File Offset: 0x0000063C
		public static void ClearCachedTweens()
		{
			TweenManager.PurgePools();
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002443 File Offset: 0x00000643
		public static int Validate()
		{
			return TweenManager.Validate();
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0000244A File Offset: 0x0000064A
		public static TweenerCore<float, float, FloatOptions> To(DOGetter<float> getter, DOSetter<float> setter, float endValue, float duration)
		{
			return DOTween.ApplyTo<float, float, FloatOptions>(getter, setter, endValue, duration, null);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002456 File Offset: 0x00000656
		public static TweenerCore<double, double, NoOptions> To(DOGetter<double> getter, DOSetter<double> setter, double endValue, float duration)
		{
			return DOTween.ApplyTo<double, double, NoOptions>(getter, setter, endValue, duration, null);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002462 File Offset: 0x00000662
		public static Tweener To(DOGetter<int> getter, DOSetter<int> setter, int endValue, float duration)
		{
			return DOTween.ApplyTo<int, int, NoOptions>(getter, setter, endValue, duration, null);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000246E File Offset: 0x0000066E
		public static Tweener To(DOGetter<uint> getter, DOSetter<uint> setter, uint endValue, float duration)
		{
			return DOTween.ApplyTo<uint, uint, NoOptions>(getter, setter, endValue, duration, null);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000247A File Offset: 0x0000067A
		public static Tweener To(DOGetter<long> getter, DOSetter<long> setter, long endValue, float duration)
		{
			return DOTween.ApplyTo<long, long, NoOptions>(getter, setter, endValue, duration, null);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002486 File Offset: 0x00000686
		public static Tweener To(DOGetter<ulong> getter, DOSetter<ulong> setter, ulong endValue, float duration)
		{
			return DOTween.ApplyTo<ulong, ulong, NoOptions>(getter, setter, endValue, duration, null);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002492 File Offset: 0x00000692
		public static TweenerCore<string, string, StringOptions> To(DOGetter<string> getter, DOSetter<string> setter, string endValue, float duration)
		{
			return DOTween.ApplyTo<string, string, StringOptions>(getter, setter, endValue, duration, null);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000249E File Offset: 0x0000069E
		public static TweenerCore<Vector2, Vector2, VectorOptions> To(DOGetter<Vector2> getter, DOSetter<Vector2> setter, Vector2 endValue, float duration)
		{
			return DOTween.ApplyTo<Vector2, Vector2, VectorOptions>(getter, setter, endValue, duration, null);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000024AA File Offset: 0x000006AA
		public static TweenerCore<Vector3, Vector3, VectorOptions> To(DOGetter<Vector3> getter, DOSetter<Vector3> setter, Vector3 endValue, float duration)
		{
			return DOTween.ApplyTo<Vector3, Vector3, VectorOptions>(getter, setter, endValue, duration, null);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000024B6 File Offset: 0x000006B6
		public static TweenerCore<Vector4, Vector4, VectorOptions> To(DOGetter<Vector4> getter, DOSetter<Vector4> setter, Vector4 endValue, float duration)
		{
			return DOTween.ApplyTo<Vector4, Vector4, VectorOptions>(getter, setter, endValue, duration, null);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000024C2 File Offset: 0x000006C2
		public static TweenerCore<Quaternion, Vector3, QuaternionOptions> To(DOGetter<Quaternion> getter, DOSetter<Quaternion> setter, Vector3 endValue, float duration)
		{
			return DOTween.ApplyTo<Quaternion, Vector3, QuaternionOptions>(getter, setter, endValue, duration, null);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000024CE File Offset: 0x000006CE
		public static TweenerCore<Color, Color, ColorOptions> To(DOGetter<Color> getter, DOSetter<Color> setter, Color endValue, float duration)
		{
			return DOTween.ApplyTo<Color, Color, ColorOptions>(getter, setter, endValue, duration, null);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000024DA File Offset: 0x000006DA
		public static TweenerCore<Rect, Rect, RectOptions> To(DOGetter<Rect> getter, DOSetter<Rect> setter, Rect endValue, float duration)
		{
			return DOTween.ApplyTo<Rect, Rect, RectOptions>(getter, setter, endValue, duration, null);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000024E6 File Offset: 0x000006E6
		public static Tweener To(DOGetter<RectOffset> getter, DOSetter<RectOffset> setter, RectOffset endValue, float duration)
		{
			return DOTween.ApplyTo<RectOffset, RectOffset, NoOptions>(getter, setter, endValue, duration, null);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000024F2 File Offset: 0x000006F2
		public static TweenerCore<T1, T2, TPlugOptions> To<T1, T2, TPlugOptions>(ABSTweenPlugin<T1, T2, TPlugOptions> plugin, DOGetter<T1> getter, DOSetter<T1> setter, T2 endValue, float duration) where TPlugOptions : struct
		{
			return DOTween.ApplyTo<T1, T2, TPlugOptions>(getter, setter, endValue, duration, plugin);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000024FF File Offset: 0x000006FF
		public static TweenerCore<Vector3, Vector3, VectorOptions> ToAxis(DOGetter<Vector3> getter, DOSetter<Vector3> setter, float endValue, float duration, AxisConstraint axisConstraint = AxisConstraint.X)
		{
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.ApplyTo<Vector3, Vector3, VectorOptions>(getter, setter, new Vector3(endValue, endValue, endValue), duration, null);
			tweenerCore.plugOptions.axisConstraint = axisConstraint;
			return tweenerCore;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x0000251F File Offset: 0x0000071F
		public static Tweener ToAlpha(DOGetter<Color> getter, DOSetter<Color> setter, float endValue, float duration)
		{
			return DOTween.ApplyTo<Color, Color, ColorOptions>(getter, setter, new Color(0f, 0f, 0f, endValue), duration, null).SetOptions(true);
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002548 File Offset: 0x00000748
		public static Tweener To(DOSetter<float> setter, float startValue, float endValue, float duration)
		{
			return DOTween.To(() => startValue, delegate(float x)
			{
				startValue = x;
				setter(startValue);
			}, endValue, duration).NoFrom<float, float, FloatOptions>();
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002590 File Offset: 0x00000790
		public static TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> Punch(DOGetter<Vector3> getter, DOSetter<Vector3> setter, Vector3 direction, float duration, int vibrato = 10, float elasticity = 1f)
		{
			if (elasticity > 1f)
			{
				elasticity = 1f;
			}
			else if (elasticity < 0f)
			{
				elasticity = 0f;
			}
			float num = direction.magnitude;
			int num2 = (int)((float)vibrato * duration);
			if (num2 < 2)
			{
				num2 = 2;
			}
			float num3 = num / (float)num2;
			float[] array = new float[num2];
			float num4 = 0f;
			for (int i = 0; i < num2; i++)
			{
				float num5 = (float)(i + 1) / (float)num2;
				float num6 = duration * num5;
				num4 += num6;
				array[i] = num6;
			}
			float num7 = duration / num4;
			for (int j = 0; j < num2; j++)
			{
				array[j] *= num7;
			}
			Vector3[] array2 = new Vector3[num2];
			for (int k = 0; k < num2; k++)
			{
				if (k < num2 - 1)
				{
					if (k == 0)
					{
						array2[k] = direction;
					}
					else if (k % 2 != 0)
					{
						array2[k] = -Vector3.ClampMagnitude(direction, num * elasticity);
					}
					else
					{
						array2[k] = Vector3.ClampMagnitude(direction, num);
					}
					num -= num3;
				}
				else
				{
					array2[k] = Vector3.zero;
				}
			}
			return DOTween.ToArray(getter, setter, array2, array).NoFrom<Vector3, Vector3[], Vector3ArrayOptions>().SetSpecialStartupMode(SpecialStartupMode.SetPunch);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000026BD File Offset: 0x000008BD
		public static TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> Shake(DOGetter<Vector3> getter, DOSetter<Vector3> setter, float duration, float strength = 3f, int vibrato = 10, float randomness = 90f, bool ignoreZAxis = true)
		{
			return DOTween.Shake(getter, setter, duration, new Vector3(strength, strength, strength), vibrato, randomness, ignoreZAxis, false);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000026D6 File Offset: 0x000008D6
		public static TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> Shake(DOGetter<Vector3> getter, DOSetter<Vector3> setter, float duration, Vector3 strength, int vibrato = 10, float randomness = 90f)
		{
			return DOTween.Shake(getter, setter, duration, strength, vibrato, randomness, false, true);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000026E8 File Offset: 0x000008E8
		private static TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> Shake(DOGetter<Vector3> getter, DOSetter<Vector3> setter, float duration, Vector3 strength, int vibrato, float randomness, bool ignoreZAxis, bool vectorBased)
		{
			float num = vectorBased ? strength.magnitude : strength.x;
			int num2 = (int)((float)vibrato * duration);
			if (num2 < 2)
			{
				num2 = 2;
			}
			float num3 = num / (float)num2;
			float[] array = new float[num2];
			float num4 = 0f;
			for (int i = 0; i < num2; i++)
			{
				float num5 = (float)(i + 1) / (float)num2;
				float num6 = duration * num5;
				num4 += num6;
				array[i] = num6;
			}
			float num7 = duration / num4;
			for (int j = 0; j < num2; j++)
			{
				array[j] *= num7;
			}
			float num8 = UnityEngine.Random.Range(0f, 360f);
			Vector3[] array2 = new Vector3[num2];
			for (int k = 0; k < num2; k++)
			{
				if (k < num2 - 1)
				{
					if (k > 0)
					{
						num8 = num8 - 180f + UnityEngine.Random.Range(-randomness, randomness);
					}
					if (vectorBased)
					{
						Vector3 vector = Quaternion.AngleAxis(UnityEngine.Random.Range(-randomness, randomness), Vector3.up) * Utils.Vector3FromAngle(num8, num);
						vector.x = Vector3.ClampMagnitude(vector, strength.x).x;
						vector.y = Vector3.ClampMagnitude(vector, strength.y).y;
						vector.z = Vector3.ClampMagnitude(vector, strength.z).z;
						array2[k] = vector;
						num -= num3;
						strength = Vector3.ClampMagnitude(strength, num);
					}
					else
					{
						if (ignoreZAxis)
						{
							array2[k] = Utils.Vector3FromAngle(num8, num);
						}
						else
						{
							Quaternion rotation = Quaternion.AngleAxis(UnityEngine.Random.Range(-randomness, randomness), Vector3.up);
							array2[k] = rotation * Utils.Vector3FromAngle(num8, num);
						}
						num -= num3;
					}
				}
				else
				{
					array2[k] = Vector3.zero;
				}
			}
			return DOTween.ToArray(getter, setter, array2, array).NoFrom<Vector3, Vector3[], Vector3ArrayOptions>().SetSpecialStartupMode(SpecialStartupMode.SetShake);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000028C8 File Offset: 0x00000AC8
		public static TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> ToArray(DOGetter<Vector3> getter, DOSetter<Vector3> setter, Vector3[] endValues, float[] durations)
		{
			int num = durations.Length;
			if (num != endValues.Length)
			{
				Debugger.LogError("To Vector3 array tween: endValues and durations arrays must have the same length");
				return null;
			}
			Vector3[] array = new Vector3[num];
			float[] array2 = new float[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = endValues[i];
				array2[i] = durations[i];
			}
			float num2 = 0f;
			for (int j = 0; j < num; j++)
			{
				num2 += array2[j];
			}
			TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> tweenerCore = DOTween.ApplyTo<Vector3, Vector3[], Vector3ArrayOptions>(getter, setter, array, num2, null).NoFrom<Vector3, Vector3[], Vector3ArrayOptions>();
			tweenerCore.plugOptions.durations = array2;
			return tweenerCore;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002959 File Offset: 0x00000B59
		internal static TweenerCore<Color2, Color2, ColorOptions> To(DOGetter<Color2> getter, DOSetter<Color2> setter, Color2 endValue, float duration)
		{
			return DOTween.ApplyTo<Color2, Color2, ColorOptions>(getter, setter, endValue, duration, null);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002965 File Offset: 0x00000B65
		public static Sequence Sequence()
		{
			DOTween.InitCheck();
			Sequence sequence = TweenManager.GetSequence();
			DG.Tweening.Sequence.Setup(sequence);
			return sequence;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002977 File Offset: 0x00000B77
		public static int CompleteAll(bool withCallbacks = false)
		{
			return TweenManager.FilteredOperation(OperationType.Complete, FilterType.All, null, false, (float)(withCallbacks ? 1 : 0), null, null);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x0000298C File Offset: 0x00000B8C
		public static int Complete(object targetOrId, bool withCallbacks = false)
		{
			if (targetOrId == null)
			{
				return 0;
			}
			return TweenManager.FilteredOperation(OperationType.Complete, FilterType.TargetOrId, targetOrId, false, (float)(withCallbacks ? 1 : 0), null, null);
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000029A6 File Offset: 0x00000BA6
		internal static int CompleteAndReturnKilledTot()
		{
			return TweenManager.FilteredOperation(OperationType.Complete, FilterType.All, null, true, 0f, null, null);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000029B8 File Offset: 0x00000BB8
		internal static int CompleteAndReturnKilledTot(object targetOrId)
		{
			if (targetOrId == null)
			{
				return 0;
			}
			return TweenManager.FilteredOperation(OperationType.Complete, FilterType.TargetOrId, targetOrId, true, 0f, null, null);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000029CF File Offset: 0x00000BCF
		internal static int CompleteAndReturnKilledTotExceptFor(params object[] excludeTargetsOrIds)
		{
			return TweenManager.FilteredOperation(OperationType.Complete, FilterType.AllExceptTargetsOrIds, null, true, 0f, null, excludeTargetsOrIds);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000029E1 File Offset: 0x00000BE1
		public static int FlipAll()
		{
			return TweenManager.FilteredOperation(OperationType.Flip, FilterType.All, null, false, 0f, null, null);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000029F3 File Offset: 0x00000BF3
		public static int Flip(object targetOrId)
		{
			if (targetOrId == null)
			{
				return 0;
			}
			return TweenManager.FilteredOperation(OperationType.Flip, FilterType.TargetOrId, targetOrId, false, 0f, null, null);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002A0A File Offset: 0x00000C0A
		public static int GotoAll(float to, bool andPlay = false)
		{
			return TweenManager.FilteredOperation(OperationType.Goto, FilterType.All, null, andPlay, to, null, null);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002A18 File Offset: 0x00000C18
		public static int Goto(object targetOrId, float to, bool andPlay = false)
		{
			if (targetOrId == null)
			{
				return 0;
			}
			return TweenManager.FilteredOperation(OperationType.Goto, FilterType.TargetOrId, targetOrId, andPlay, to, null, null);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002A2B File Offset: 0x00000C2B
		public static int KillAll(bool complete = false)
		{
			return (complete ? DOTween.CompleteAndReturnKilledTot() : 0) + TweenManager.DespawnAll();
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002A3E File Offset: 0x00000C3E
		public static int KillAll(bool complete, params object[] idsOrTargetsToExclude)
		{
			if (idsOrTargetsToExclude == null)
			{
				return (complete ? DOTween.CompleteAndReturnKilledTot() : 0) + TweenManager.DespawnAll();
			}
			return (complete ? DOTween.CompleteAndReturnKilledTotExceptFor(idsOrTargetsToExclude) : 0) + TweenManager.FilteredOperation(OperationType.Despawn, FilterType.AllExceptTargetsOrIds, null, false, 0f, null, idsOrTargetsToExclude);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002A72 File Offset: 0x00000C72
		public static int Kill(object targetOrId, bool complete = false)
		{
			if (targetOrId == null)
			{
				return 0;
			}
			return (complete ? DOTween.CompleteAndReturnKilledTot(targetOrId) : 0) + TweenManager.FilteredOperation(OperationType.Despawn, FilterType.TargetOrId, targetOrId, false, 0f, null, null);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002A96 File Offset: 0x00000C96
		public static int PauseAll()
		{
			return TweenManager.FilteredOperation(OperationType.Pause, FilterType.All, null, false, 0f, null, null);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002AA8 File Offset: 0x00000CA8
		public static int Pause(object targetOrId)
		{
			if (targetOrId == null)
			{
				return 0;
			}
			return TweenManager.FilteredOperation(OperationType.Pause, FilterType.TargetOrId, targetOrId, false, 0f, null, null);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002ABF File Offset: 0x00000CBF
		public static int PlayAll()
		{
			return TweenManager.FilteredOperation(OperationType.Play, FilterType.All, null, false, 0f, null, null);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002AD1 File Offset: 0x00000CD1
		public static int Play(object targetOrId)
		{
			if (targetOrId == null)
			{
				return 0;
			}
			return TweenManager.FilteredOperation(OperationType.Play, FilterType.TargetOrId, targetOrId, false, 0f, null, null);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002AE8 File Offset: 0x00000CE8
		public static int Play(object target, object id)
		{
			if (target == null || id == null)
			{
				return 0;
			}
			return TweenManager.FilteredOperation(OperationType.Play, FilterType.TargetAndId, id, false, 0f, target, null);
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002B02 File Offset: 0x00000D02
		public static int PlayBackwardsAll()
		{
			return TweenManager.FilteredOperation(OperationType.PlayBackwards, FilterType.All, null, false, 0f, null, null);
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002B14 File Offset: 0x00000D14
		public static int PlayBackwards(object targetOrId)
		{
			if (targetOrId == null)
			{
				return 0;
			}
			return TweenManager.FilteredOperation(OperationType.PlayBackwards, FilterType.TargetOrId, targetOrId, false, 0f, null, null);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002B2B File Offset: 0x00000D2B
		public static int PlayForwardAll()
		{
			return TweenManager.FilteredOperation(OperationType.PlayForward, FilterType.All, null, false, 0f, null, null);
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002B3D File Offset: 0x00000D3D
		public static int PlayForward(object targetOrId)
		{
			if (targetOrId == null)
			{
				return 0;
			}
			return TweenManager.FilteredOperation(OperationType.PlayForward, FilterType.TargetOrId, targetOrId, false, 0f, null, null);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002B54 File Offset: 0x00000D54
		public static int RestartAll(bool includeDelay = true)
		{
			return TweenManager.FilteredOperation(OperationType.Restart, FilterType.All, null, includeDelay, 0f, null, null);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002B67 File Offset: 0x00000D67
		public static int Restart(object targetOrId, bool includeDelay = true)
		{
			if (targetOrId == null)
			{
				return 0;
			}
			return TweenManager.FilteredOperation(OperationType.Restart, FilterType.TargetOrId, targetOrId, includeDelay, 0f, null, null);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002B7F File Offset: 0x00000D7F
		public static int Restart(object target, object id, bool includeDelay = true)
		{
			if (target == null || id == null)
			{
				return 0;
			}
			return TweenManager.FilteredOperation(OperationType.Restart, FilterType.TargetAndId, id, includeDelay, 0f, target, null);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002B9A File Offset: 0x00000D9A
		public static int RewindAll(bool includeDelay = true)
		{
			return TweenManager.FilteredOperation(OperationType.Rewind, FilterType.All, null, includeDelay, 0f, null, null);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002BAC File Offset: 0x00000DAC
		public static int Rewind(object targetOrId, bool includeDelay = true)
		{
			if (targetOrId == null)
			{
				return 0;
			}
			return TweenManager.FilteredOperation(OperationType.Rewind, FilterType.TargetOrId, targetOrId, includeDelay, 0f, null, null);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002BC3 File Offset: 0x00000DC3
		public static int SmoothRewindAll()
		{
			return TweenManager.FilteredOperation(OperationType.SmoothRewind, FilterType.All, null, false, 0f, null, null);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002BD6 File Offset: 0x00000DD6
		public static int SmoothRewind(object targetOrId)
		{
			if (targetOrId == null)
			{
				return 0;
			}
			return TweenManager.FilteredOperation(OperationType.SmoothRewind, FilterType.TargetOrId, targetOrId, false, 0f, null, null);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002BEE File Offset: 0x00000DEE
		public static int TogglePauseAll()
		{
			return TweenManager.FilteredOperation(OperationType.TogglePause, FilterType.All, null, false, 0f, null, null);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002C01 File Offset: 0x00000E01
		public static int TogglePause(object targetOrId)
		{
			if (targetOrId == null)
			{
				return 0;
			}
			return TweenManager.FilteredOperation(OperationType.TogglePause, FilterType.TargetOrId, targetOrId, false, 0f, null, null);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002C19 File Offset: 0x00000E19
		public static bool IsTweening(object targetOrId)
		{
			return TweenManager.FilteredOperation(OperationType.IsTweening, FilterType.TargetOrId, targetOrId, false, 0f, null, null) > 0;
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002C2F File Offset: 0x00000E2F
		public static int TotalPlayingTweens()
		{
			return TweenManager.TotalPlayingTweens();
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002C36 File Offset: 0x00000E36
		public static List<Tween> PlayingTweens()
		{
			return TweenManager.GetActiveTweens(true);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002C3E File Offset: 0x00000E3E
		public static List<Tween> PausedTweens()
		{
			return TweenManager.GetActiveTweens(false);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002C46 File Offset: 0x00000E46
		public static List<Tween> TweensById(object id, bool playingOnly = false)
		{
			if (id == null)
			{
				return null;
			}
			return TweenManager.GetTweensById(id, playingOnly);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00002C54 File Offset: 0x00000E54
		public static List<Tween> TweensByTarget(object target, bool playingOnly = false)
		{
			return TweenManager.GetTweensByTarget(target, playingOnly);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00002C5D File Offset: 0x00000E5D
		private static void InitCheck()
		{
			if (DOTween.initialized || !Application.isPlaying || DOTween.isQuitting)
			{
				return;
			}
			DOTween.AutoInit();
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00002C7C File Offset: 0x00000E7C
		private static TweenerCore<T1, T2, TPlugOptions> ApplyTo<T1, T2, TPlugOptions>(DOGetter<T1> getter, DOSetter<T1> setter, T2 endValue, float duration, ABSTweenPlugin<T1, T2, TPlugOptions> plugin = null) where TPlugOptions : struct
		{
			DOTween.InitCheck();
			TweenerCore<T1, T2, TPlugOptions> tweener = TweenManager.GetTweener<T1, T2, TPlugOptions>();
			if (!Tweener.Setup<T1, T2, TPlugOptions>(tweener, getter, setter, endValue, duration, plugin))
			{
				TweenManager.Despawn(tweener, true);
				return null;
			}
			return tweener;
		}

		// Token: 0x0400000E RID: 14
		public static readonly string Version = "1.1.135";

		// Token: 0x0400000F RID: 15
		public static bool useSafeMode = true;

		// Token: 0x04000010 RID: 16
		public static bool showUnityEditorReport = false;

		// Token: 0x04000011 RID: 17
		public static float timeScale = 1f;

		// Token: 0x04000012 RID: 18
		public static bool useSmoothDeltaTime;

		// Token: 0x04000013 RID: 19
		private static LogBehaviour _logBehaviour = LogBehaviour.ErrorsOnly;

		// Token: 0x04000014 RID: 20
		public static bool drawGizmos = true;

		// Token: 0x04000015 RID: 21
		public static UpdateType defaultUpdateType = UpdateType.Normal;

		// Token: 0x04000016 RID: 22
		public static bool defaultTimeScaleIndependent = false;

		// Token: 0x04000017 RID: 23
		public static AutoPlay defaultAutoPlay = AutoPlay.All;

		// Token: 0x04000018 RID: 24
		public static bool defaultAutoKill = true;

		// Token: 0x04000019 RID: 25
		public static LoopType defaultLoopType = LoopType.Restart;

		// Token: 0x0400001A RID: 26
		public static bool defaultRecyclable;

		// Token: 0x0400001B RID: 27
		public static Ease defaultEaseType = Ease.OutQuad;

		// Token: 0x0400001C RID: 28
		public static float defaultEaseOvershootOrAmplitude = 1.70158f;

		// Token: 0x0400001D RID: 29
		public static float defaultEasePeriod = 0f;

		// Token: 0x0400001E RID: 30
		internal static DOTweenComponent instance;

		// Token: 0x0400001F RID: 31
		internal static bool isUnityEditor;

		// Token: 0x04000020 RID: 32
		internal static bool isDebugBuild;

		// Token: 0x04000021 RID: 33
		internal static int maxActiveTweenersReached;

		// Token: 0x04000022 RID: 34
		internal static int maxActiveSequencesReached;

		// Token: 0x04000023 RID: 35
		internal static readonly List<TweenCallback> GizmosDelegates = new List<TweenCallback>();

		// Token: 0x04000024 RID: 36
		internal static bool initialized;

		// Token: 0x04000025 RID: 37
		internal static bool isQuitting;
	}
}
