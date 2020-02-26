using System;
using System.Collections.Generic;
using DG.Tweening.Core.Enums;
using UnityEngine;

namespace DG.Tweening.Core
{
	// Token: 0x0200004C RID: 76
	internal static class TweenManager
	{
		// Token: 0x06000264 RID: 612 RVA: 0x0000D4E8 File Offset: 0x0000B6E8
		internal static TweenerCore<T1, T2, TPlugOptions> GetTweener<T1, T2, TPlugOptions>() where TPlugOptions : struct
		{
			if (TweenManager.totPooledTweeners > 0)
			{
				Type typeFromHandle = typeof(T1);
				Type typeFromHandle2 = typeof(T2);
				Type typeFromHandle3 = typeof(TPlugOptions);
				for (int i = TweenManager._maxPooledTweenerId; i > TweenManager._minPooledTweenerId - 1; i--)
				{
					Tween tween = TweenManager._pooledTweeners[i];
					if (tween != null && tween.typeofT1 == typeFromHandle && tween.typeofT2 == typeFromHandle2 && tween.typeofTPlugOptions == typeFromHandle3)
					{
						TweenerCore<T1, T2, TPlugOptions> tweenerCore = (TweenerCore<T1, T2, TPlugOptions>)tween;
						TweenManager.AddActiveTween(tweenerCore);
						TweenManager._pooledTweeners[i] = null;
						if (TweenManager._maxPooledTweenerId != TweenManager._minPooledTweenerId)
						{
							if (i == TweenManager._maxPooledTweenerId)
							{
								TweenManager._maxPooledTweenerId--;
							}
							else if (i == TweenManager._minPooledTweenerId)
							{
								TweenManager._minPooledTweenerId++;
							}
						}
						TweenManager.totPooledTweeners--;
						return tweenerCore;
					}
				}
				if (TweenManager.totTweeners >= TweenManager.maxTweeners)
				{
					TweenManager._pooledTweeners[TweenManager._maxPooledTweenerId] = null;
					TweenManager._maxPooledTweenerId--;
					TweenManager.totPooledTweeners--;
					TweenManager.totTweeners--;
				}
			}
			else if (TweenManager.totTweeners >= TweenManager.maxTweeners - 1)
			{
				int num = TweenManager.maxTweeners;
				int num2 = TweenManager.maxSequences;
				TweenManager.IncreaseCapacities(TweenManager.CapacityIncreaseMode.TweenersOnly);
				if (Debugger.logPriority >= 1)
				{
					Debugger.LogWarning("Max Tweens reached: capacity has automatically been increased from #0 to #1. Use DOTween.SetTweensCapacity to set it manually at startup".Replace("#0", num + "/" + num2).Replace("#1", TweenManager.maxTweeners + "/" + TweenManager.maxSequences));
				}
			}
			TweenerCore<T1, T2, TPlugOptions> tweenerCore2 = new TweenerCore<T1, T2, TPlugOptions>();
			TweenManager.totTweeners++;
			TweenManager.AddActiveTween(tweenerCore2);
			return tweenerCore2;
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0000D698 File Offset: 0x0000B898
		internal static Sequence GetSequence()
		{
			if (TweenManager.totPooledSequences > 0)
			{
				Sequence sequence = (Sequence)TweenManager._PooledSequences.Pop();
				TweenManager.AddActiveTween(sequence);
				TweenManager.totPooledSequences--;
				return sequence;
			}
			if (TweenManager.totSequences >= TweenManager.maxSequences - 1)
			{
				int num = TweenManager.maxTweeners;
				int num2 = TweenManager.maxSequences;
				TweenManager.IncreaseCapacities(TweenManager.CapacityIncreaseMode.SequencesOnly);
				if (Debugger.logPriority >= 1)
				{
					Debugger.LogWarning("Max Tweens reached: capacity has automatically been increased from #0 to #1. Use DOTween.SetTweensCapacity to set it manually at startup".Replace("#0", num + "/" + num2).Replace("#1", TweenManager.maxTweeners + "/" + TweenManager.maxSequences));
				}
			}
			Sequence sequence2 = new Sequence();
			TweenManager.totSequences++;
			TweenManager.AddActiveTween(sequence2);
			return sequence2;
		}

		// Token: 0x06000266 RID: 614 RVA: 0x0000D760 File Offset: 0x0000B960
		internal static void SetUpdateType(Tween t, UpdateType updateType, bool isIndependentUpdate)
		{
			if (!t.active || t.updateType == updateType)
			{
				t.updateType = updateType;
				t.isIndependentUpdate = isIndependentUpdate;
				return;
			}
			if (t.updateType == UpdateType.Normal)
			{
				TweenManager.totActiveDefaultTweens--;
				TweenManager.hasActiveDefaultTweens = (TweenManager.totActiveDefaultTweens > 0);
			}
			else if (t.updateType == UpdateType.Fixed)
			{
				TweenManager.totActiveFixedTweens--;
				TweenManager.hasActiveFixedTweens = (TweenManager.totActiveFixedTweens > 0);
			}
			else
			{
				TweenManager.totActiveLateTweens--;
				TweenManager.hasActiveLateTweens = (TweenManager.totActiveLateTweens > 0);
			}
			t.updateType = updateType;
			t.isIndependentUpdate = isIndependentUpdate;
			if (updateType == UpdateType.Normal)
			{
				TweenManager.totActiveDefaultTweens++;
				TweenManager.hasActiveDefaultTweens = true;
				return;
			}
			if (updateType == UpdateType.Fixed)
			{
				TweenManager.totActiveFixedTweens++;
				TweenManager.hasActiveFixedTweens = true;
				return;
			}
			TweenManager.totActiveLateTweens++;
			TweenManager.hasActiveLateTweens = true;
		}

		// Token: 0x06000267 RID: 615 RVA: 0x0000D83A File Offset: 0x0000BA3A
		internal static void AddActiveTweenToSequence(Tween t)
		{
			TweenManager.RemoveActiveTween(t);
		}

		// Token: 0x06000268 RID: 616 RVA: 0x0000D844 File Offset: 0x0000BA44
		internal static int DespawnAll()
		{
			int result = TweenManager.totActiveTweens;
			for (int i = 0; i < TweenManager._maxActiveLookupId + 1; i++)
			{
				Tween tween = TweenManager._activeTweens[i];
				if (tween != null)
				{
					TweenManager.Despawn(tween, false);
				}
			}
			TweenManager.ClearTweenArray(TweenManager._activeTweens);
			TweenManager.hasActiveTweens = (TweenManager.hasActiveDefaultTweens = (TweenManager.hasActiveLateTweens = (TweenManager.hasActiveFixedTweens = false)));
			TweenManager.totActiveTweens = (TweenManager.totActiveDefaultTweens = (TweenManager.totActiveLateTweens = (TweenManager.totActiveFixedTweens = 0)));
			TweenManager.totActiveTweeners = (TweenManager.totActiveSequences = 0);
			TweenManager._maxActiveLookupId = (TweenManager._reorganizeFromId = -1);
			TweenManager._requiresActiveReorganization = false;
			return result;
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0000D8D4 File Offset: 0x0000BAD4
		internal static void Despawn(Tween t, bool modifyActiveLists = true)
		{
			if (t.onKill != null)
			{
				Tween.OnTweenCallback(t.onKill);
			}
			if (modifyActiveLists)
			{
				TweenManager.RemoveActiveTween(t);
			}
			if (t.isRecyclable)
			{
				TweenType tweenType = t.tweenType;
				if (tweenType != TweenType.Tweener)
				{
					if (tweenType == TweenType.Sequence)
					{
						TweenManager._PooledSequences.Push(t);
						TweenManager.totPooledSequences++;
						Sequence sequence = (Sequence)t;
						int count = sequence.sequencedTweens.Count;
						for (int i = 0; i < count; i++)
						{
							TweenManager.Despawn(sequence.sequencedTweens[i], false);
						}
					}
				}
				else
				{
					if (TweenManager._maxPooledTweenerId == -1)
					{
						TweenManager._maxPooledTweenerId = TweenManager.maxTweeners - 1;
						TweenManager._minPooledTweenerId = TweenManager.maxTweeners - 1;
					}
					if (TweenManager._maxPooledTweenerId < TweenManager.maxTweeners - 1)
					{
						TweenManager._pooledTweeners[TweenManager._maxPooledTweenerId + 1] = t;
						TweenManager._maxPooledTweenerId++;
						if (TweenManager._minPooledTweenerId > TweenManager._maxPooledTweenerId)
						{
							TweenManager._minPooledTweenerId = TweenManager._maxPooledTweenerId;
						}
					}
					else
					{
						int j = TweenManager._maxPooledTweenerId;
						while (j > -1)
						{
							if (TweenManager._pooledTweeners[j] == null)
							{
								TweenManager._pooledTweeners[j] = t;
								if (j < TweenManager._minPooledTweenerId)
								{
									TweenManager._minPooledTweenerId = j;
								}
								if (TweenManager._maxPooledTweenerId < TweenManager._minPooledTweenerId)
								{
									TweenManager._maxPooledTweenerId = TweenManager._minPooledTweenerId;
									break;
								}
								break;
							}
							else
							{
								j--;
							}
						}
					}
					TweenManager.totPooledTweeners++;
				}
			}
			else
			{
				TweenType tweenType = t.tweenType;
				if (tweenType != TweenType.Tweener)
				{
					if (tweenType == TweenType.Sequence)
					{
						TweenManager.totSequences--;
						Sequence sequence2 = (Sequence)t;
						int count2 = sequence2.sequencedTweens.Count;
						for (int k = 0; k < count2; k++)
						{
							TweenManager.Despawn(sequence2.sequencedTweens[k], false);
						}
					}
				}
				else
				{
					TweenManager.totTweeners--;
				}
			}
			t.active = false;
			t.Reset();
		}

		// Token: 0x0600026A RID: 618 RVA: 0x0000DA94 File Offset: 0x0000BC94
		internal static void PurgeAll()
		{
			for (int i = 0; i < TweenManager.totActiveTweens; i++)
			{
				Tween tween = TweenManager._activeTweens[i];
				if (tween != null && tween.onKill != null)
				{
					Tween.OnTweenCallback(tween.onKill);
				}
			}
			TweenManager.ClearTweenArray(TweenManager._activeTweens);
			TweenManager.hasActiveTweens = (TweenManager.hasActiveDefaultTweens = (TweenManager.hasActiveLateTweens = (TweenManager.hasActiveFixedTweens = false)));
			TweenManager.totActiveTweens = (TweenManager.totActiveDefaultTweens = (TweenManager.totActiveLateTweens = (TweenManager.totActiveFixedTweens = 0)));
			TweenManager.totActiveTweeners = (TweenManager.totActiveSequences = 0);
			TweenManager._maxActiveLookupId = (TweenManager._reorganizeFromId = -1);
			TweenManager._requiresActiveReorganization = false;
			TweenManager.PurgePools();
			TweenManager.ResetCapacities();
			TweenManager.totTweeners = (TweenManager.totSequences = 0);
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0000DB40 File Offset: 0x0000BD40
		internal static void PurgePools()
		{
			TweenManager.totTweeners -= TweenManager.totPooledTweeners;
			TweenManager.totSequences -= TweenManager.totPooledSequences;
			TweenManager.ClearTweenArray(TweenManager._pooledTweeners);
			TweenManager._PooledSequences.Clear();
			TweenManager.totPooledTweeners = (TweenManager.totPooledSequences = 0);
			TweenManager._minPooledTweenerId = (TweenManager._maxPooledTweenerId = -1);
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0000DB99 File Offset: 0x0000BD99
		internal static void ResetCapacities()
		{
			TweenManager.SetCapacities(200, 50);
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000DBA8 File Offset: 0x0000BDA8
		internal static void SetCapacities(int tweenersCapacity, int sequencesCapacity)
		{
			if (tweenersCapacity < sequencesCapacity)
			{
				tweenersCapacity = sequencesCapacity;
			}
			TweenManager.maxActive = tweenersCapacity + sequencesCapacity;
			TweenManager.maxTweeners = tweenersCapacity;
			TweenManager.maxSequences = sequencesCapacity;
			Array.Resize<Tween>(ref TweenManager._activeTweens, TweenManager.maxActive);
			Array.Resize<Tween>(ref TweenManager._pooledTweeners, tweenersCapacity);
			TweenManager._KillList.Capacity = TweenManager.maxActive;
		}

		// Token: 0x0600026E RID: 622 RVA: 0x0000DBFC File Offset: 0x0000BDFC
		internal static int Validate()
		{
			if (TweenManager._requiresActiveReorganization)
			{
				TweenManager.ReorganizeActiveTweens();
			}
			int num = 0;
			for (int i = 0; i < TweenManager._maxActiveLookupId + 1; i++)
			{
				Tween tween = TweenManager._activeTweens[i];
				if (!tween.Validate())
				{
					num++;
					TweenManager.MarkForKilling(tween);
				}
			}
			if (num > 0)
			{
				TweenManager.DespawnTweens(TweenManager._KillList, false);
				for (int j = TweenManager._KillList.Count - 1; j > -1; j--)
				{
					TweenManager.RemoveActiveTween(TweenManager._KillList[j]);
				}
				TweenManager._KillList.Clear();
			}
			return num;
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0000DC84 File Offset: 0x0000BE84
		internal static void Update(UpdateType updateType, float deltaTime, float independentTime)
		{
			if (TweenManager._requiresActiveReorganization)
			{
				TweenManager.ReorganizeActiveTweens();
			}
			TweenManager.isUpdateLoop = true;
			bool flag = false;
			int num = TweenManager._maxActiveLookupId + 1;
			for (int i = 0; i < num; i++)
			{
				Tween tween = TweenManager._activeTweens[i];
				if (tween != null && tween.updateType == updateType)
				{
					if (!tween.active)
					{
						flag = true;
						TweenManager.MarkForKilling(tween);
					}
					else if (tween.isPlaying)
					{
						tween.creationLocked = true;
						float num2 = (tween.isIndependentUpdate ? independentTime : deltaTime) * tween.timeScale;
						if (!tween.delayComplete)
						{
							Tween tween2 = tween;
							num2 = tween2.UpdateDelay(tween2.elapsedDelay + num2);
							if (num2 <= -1f)
							{
								flag = true;
								TweenManager.MarkForKilling(tween);
								goto IL_1C7;
							}
							if (num2 <= 0f)
							{
								goto IL_1C7;
							}
						}
						if (!tween.startupDone && !tween.Startup())
						{
							flag = true;
							TweenManager.MarkForKilling(tween);
						}
						else
						{
							float num3 = tween.position;
							bool flag2 = num3 >= tween.duration;
							int num4 = tween.completedLoops;
							if (tween.duration <= 0f)
							{
								num3 = 0f;
								num4 = ((tween.loops == -1) ? (tween.completedLoops + 1) : tween.loops);
							}
							else
							{
								if (tween.isBackwards)
								{
									num3 -= num2;
									while (num3 < 0f)
									{
										if (num4 <= 0)
										{
											break;
										}
										num3 += tween.duration;
										num4--;
									}
								}
								else
								{
									num3 += num2;
									while (num3 >= tween.duration && (tween.loops == -1 || num4 < tween.loops))
									{
										num3 -= tween.duration;
										num4++;
									}
								}
								if (flag2)
								{
									num4--;
								}
								if (tween.loops != -1 && num4 >= tween.loops)
								{
									num3 = tween.duration;
								}
							}
							if (Tween.DoGoto(tween, num3, num4, UpdateMode.Update))
							{
								flag = true;
								TweenManager.MarkForKilling(tween);
							}
						}
					}
				}
				IL_1C7:;
			}
			if (flag)
			{
				TweenManager.DespawnTweens(TweenManager._KillList, false);
				for (int j = TweenManager._KillList.Count - 1; j > -1; j--)
				{
					TweenManager.RemoveActiveTween(TweenManager._KillList[j]);
				}
				TweenManager._KillList.Clear();
			}
			TweenManager.isUpdateLoop = false;
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0000DEB0 File Offset: 0x0000C0B0
		internal static int FilteredOperation(OperationType operationType, FilterType filterType, object id, bool optionalBool, float optionalFloat, object optionalObj = null, object[] optionalArray = null)
		{
			int num = 0;
			bool flag = false;
			int num2 = (optionalArray == null) ? 0 : optionalArray.Length;
			for (int i = TweenManager._maxActiveLookupId; i > -1; i--)
			{
				Tween tween = TweenManager._activeTweens[i];
				if (tween != null && tween.active)
				{
					bool flag2 = false;
					switch (filterType)
					{
					case FilterType.All:
						flag2 = true;
						break;
					case FilterType.TargetOrId:
						flag2 = (id.Equals(tween.id) || id.Equals(tween.target));
						break;
					case FilterType.TargetAndId:
						flag2 = (id.Equals(tween.id) && optionalObj != null && optionalObj.Equals(tween.target));
						break;
					case FilterType.AllExceptTargetsOrIds:
						flag2 = true;
						for (int j = 0; j < num2; j++)
						{
							object obj = optionalArray[j];
							if (obj.Equals(tween.id) || obj.Equals(tween.target))
							{
								flag2 = false;
								break;
							}
						}
						break;
					}
					if (flag2)
					{
						switch (operationType)
						{
						case OperationType.Complete:
						{
							bool autoKill = tween.autoKill;
							if (TweenManager.Complete(tween, false, (optionalFloat > 0f) ? UpdateMode.Update : UpdateMode.Goto))
							{
								num += ((!optionalBool) ? 1 : (autoKill ? 1 : 0));
								if (autoKill)
								{
									if (TweenManager.isUpdateLoop)
									{
										tween.active = false;
									}
									else
									{
										flag = true;
										TweenManager._KillList.Add(tween);
									}
								}
							}
							break;
						}
						case OperationType.Despawn:
							num++;
							if (TweenManager.isUpdateLoop)
							{
								tween.active = false;
							}
							else
							{
								TweenManager.Despawn(tween, false);
								flag = true;
								TweenManager._KillList.Add(tween);
							}
							break;
						case OperationType.Flip:
							if (TweenManager.Flip(tween))
							{
								num++;
							}
							break;
						case OperationType.Goto:
							TweenManager.Goto(tween, optionalFloat, optionalBool, UpdateMode.Goto);
							num++;
							break;
						case OperationType.Pause:
							if (TweenManager.Pause(tween))
							{
								num++;
							}
							break;
						case OperationType.Play:
							if (TweenManager.Play(tween))
							{
								num++;
							}
							break;
						case OperationType.PlayForward:
							if (TweenManager.PlayForward(tween))
							{
								num++;
							}
							break;
						case OperationType.PlayBackwards:
							if (TweenManager.PlayBackwards(tween))
							{
								num++;
							}
							break;
						case OperationType.Rewind:
							if (TweenManager.Rewind(tween, optionalBool))
							{
								num++;
							}
							break;
						case OperationType.SmoothRewind:
							if (TweenManager.SmoothRewind(tween))
							{
								num++;
							}
							break;
						case OperationType.Restart:
							if (TweenManager.Restart(tween, optionalBool))
							{
								num++;
							}
							break;
						case OperationType.TogglePause:
							if (TweenManager.TogglePause(tween))
							{
								num++;
							}
							break;
						case OperationType.IsTweening:
							if (!tween.isComplete || !tween.autoKill)
							{
								num++;
							}
							break;
						}
					}
				}
			}
			if (flag)
			{
				for (int k = TweenManager._KillList.Count - 1; k > -1; k--)
				{
					TweenManager.RemoveActiveTween(TweenManager._KillList[k]);
				}
				TweenManager._KillList.Clear();
			}
			return num;
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0000E184 File Offset: 0x0000C384
		internal static bool Complete(Tween t, bool modifyActiveLists = true, UpdateMode updateMode = UpdateMode.Goto)
		{
			if (t.loops == -1)
			{
				return false;
			}
			if (!t.isComplete)
			{
				Tween.DoGoto(t, t.duration, t.loops, updateMode);
				t.isPlaying = false;
				if (t.autoKill)
				{
					if (TweenManager.isUpdateLoop)
					{
						t.active = false;
					}
					else
					{
						TweenManager.Despawn(t, modifyActiveLists);
					}
				}
				return true;
			}
			return false;
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0000E1E1 File Offset: 0x0000C3E1
		internal static bool Flip(Tween t)
		{
			t.isBackwards = !t.isBackwards;
			return true;
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000E1F3 File Offset: 0x0000C3F3
		internal static void ForceInit(Tween t)
		{
			if (t.startupDone)
			{
				return;
			}
			if (!t.Startup())
			{
				if (TweenManager.isUpdateLoop)
				{
					t.active = false;
					return;
				}
				TweenManager.RemoveActiveTween(t);
			}
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0000E21C File Offset: 0x0000C41C
		internal static bool Goto(Tween t, float to, bool andPlay = false, UpdateMode updateMode = UpdateMode.Goto)
		{
			bool isPlaying = t.isPlaying;
			t.isPlaying = andPlay;
			t.delayComplete = true;
			t.elapsedDelay = t.delay;
			int num = Mathf.FloorToInt(to / t.duration);
			float num2 = to % t.duration;
			if (t.loops != -1 && num >= t.loops)
			{
				num = t.loops;
				num2 = t.duration;
			}
			else if (num2 >= t.duration)
			{
				num2 = 0f;
			}
			bool flag = Tween.DoGoto(t, num2, num, updateMode);
			if (!andPlay && isPlaying && !flag && t.onPause != null)
			{
				Tween.OnTweenCallback(t.onPause);
			}
			return flag;
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0000E2BC File Offset: 0x0000C4BC
		internal static bool Pause(Tween t)
		{
			if (t.isPlaying)
			{
				t.isPlaying = false;
				if (t.onPause != null)
				{
					Tween.OnTweenCallback(t.onPause);
				}
				return true;
			}
			return false;
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0000E2E4 File Offset: 0x0000C4E4
		internal static bool Play(Tween t)
		{
			if (!t.isPlaying && ((!t.isBackwards && !t.isComplete) || (t.isBackwards && (t.completedLoops > 0 || t.position > 0f))))
			{
				t.isPlaying = true;
				if (t.playedOnce && t.onPlay != null)
				{
					Tween.OnTweenCallback(t.onPlay);
				}
				return true;
			}
			return false;
		}

		// Token: 0x06000277 RID: 631 RVA: 0x0000E34D File Offset: 0x0000C54D
		internal static bool PlayBackwards(Tween t)
		{
			if (!t.isBackwards)
			{
				t.isBackwards = true;
				TweenManager.Play(t);
				return true;
			}
			return TweenManager.Play(t);
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0000E36D File Offset: 0x0000C56D
		internal static bool PlayForward(Tween t)
		{
			if (t.isBackwards)
			{
				t.isBackwards = false;
				TweenManager.Play(t);
				return true;
			}
			return TweenManager.Play(t);
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0000E38D File Offset: 0x0000C58D
		internal static bool Restart(Tween t, bool includeDelay = true)
		{
			bool flag = !t.isPlaying;
			t.isBackwards = false;
			TweenManager.Rewind(t, includeDelay);
			t.isPlaying = true;
			if (flag && t.playedOnce && t.onPlay != null)
			{
				Tween.OnTweenCallback(t.onPlay);
			}
			return true;
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0000E3D0 File Offset: 0x0000C5D0
		internal static bool Rewind(Tween t, bool includeDelay = true)
		{
			bool isPlaying = t.isPlaying;
			t.isPlaying = false;
			bool result = false;
			if (t.delay > 0f)
			{
				if (includeDelay)
				{
					result = (t.delay > 0f && t.elapsedDelay > 0f);
					t.elapsedDelay = 0f;
					t.delayComplete = false;
				}
				else
				{
					result = (t.elapsedDelay < t.delay);
					t.elapsedDelay = t.delay;
					t.delayComplete = true;
				}
			}
			if (t.position > 0f || t.completedLoops > 0 || !t.startupDone)
			{
				result = true;
				if (!Tween.DoGoto(t, 0f, 0, UpdateMode.Goto) && isPlaying && t.onPause != null)
				{
					Tween.OnTweenCallback(t.onPause);
				}
			}
			return result;
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0000E49C File Offset: 0x0000C69C
		internal static bool SmoothRewind(Tween t)
		{
			bool result = false;
			if (t.delay > 0f)
			{
				result = (t.elapsedDelay < t.delay);
				t.elapsedDelay = t.delay;
				t.delayComplete = true;
			}
			if (t.position > 0f || t.completedLoops > 0 || !t.startupDone)
			{
				result = true;
				if (t.loopType == LoopType.Incremental)
				{
					t.PlayBackwards();
				}
				else
				{
					t.Goto(t.ElapsedDirectionalPercentage() * t.duration, false);
					t.PlayBackwards();
				}
			}
			else
			{
				t.isPlaying = false;
			}
			return result;
		}

		// Token: 0x0600027C RID: 636 RVA: 0x0000E52F File Offset: 0x0000C72F
		internal static bool TogglePause(Tween t)
		{
			if (t.isPlaying)
			{
				return TweenManager.Pause(t);
			}
			return TweenManager.Play(t);
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0000E546 File Offset: 0x0000C746
		internal static int TotalPooledTweens()
		{
			return TweenManager.totPooledTweeners + TweenManager.totPooledSequences;
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0000E554 File Offset: 0x0000C754
		internal static int TotalPlayingTweens()
		{
			if (!TweenManager.hasActiveTweens)
			{
				return 0;
			}
			if (TweenManager._requiresActiveReorganization)
			{
				TweenManager.ReorganizeActiveTweens();
			}
			int num = 0;
			for (int i = 0; i < TweenManager._maxActiveLookupId + 1; i++)
			{
				Tween tween = TweenManager._activeTweens[i];
				if (tween != null && tween.isPlaying)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0000E5A4 File Offset: 0x0000C7A4
		internal static List<Tween> GetActiveTweens(bool playing)
		{
			if (TweenManager._requiresActiveReorganization)
			{
				TweenManager.ReorganizeActiveTweens();
			}
			if (TweenManager.totActiveTweens <= 0)
			{
				return null;
			}
			int num = TweenManager.totActiveTweens;
			List<Tween> list = new List<Tween>(num);
			for (int i = 0; i < num; i++)
			{
				Tween tween = TweenManager._activeTweens[i];
				if (tween.isPlaying == playing)
				{
					list.Add(tween);
				}
			}
			if (list.Count > 0)
			{
				return list;
			}
			return null;
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0000E604 File Offset: 0x0000C804
		internal static List<Tween> GetTweensById(object id, bool playingOnly)
		{
			if (TweenManager._requiresActiveReorganization)
			{
				TweenManager.ReorganizeActiveTweens();
			}
			if (TweenManager.totActiveTweens <= 0)
			{
				return null;
			}
			int num = TweenManager.totActiveTweens;
			List<Tween> list = new List<Tween>(num);
			for (int i = 0; i < num; i++)
			{
				Tween tween = TweenManager._activeTweens[i];
				if (tween != null && object.Equals(id, tween.id) && (!playingOnly || tween.isPlaying))
				{
					list.Add(tween);
				}
			}
			if (list.Count > 0)
			{
				return list;
			}
			return null;
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0000E678 File Offset: 0x0000C878
		internal static List<Tween> GetTweensByTarget(object target, bool playingOnly)
		{
			if (TweenManager._requiresActiveReorganization)
			{
				TweenManager.ReorganizeActiveTweens();
			}
			if (TweenManager.totActiveTweens <= 0)
			{
				return null;
			}
			int num = TweenManager.totActiveTweens;
			List<Tween> list = new List<Tween>(num);
			for (int i = 0; i < num; i++)
			{
				Tween tween = TweenManager._activeTweens[i];
				if (tween.target == target && (!playingOnly || tween.isPlaying))
				{
					list.Add(tween);
				}
			}
			if (list.Count > 0)
			{
				return list;
			}
			return null;
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0000E6E3 File Offset: 0x0000C8E3
		private static void MarkForKilling(Tween t)
		{
			t.active = false;
			TweenManager._KillList.Add(t);
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0000E6F8 File Offset: 0x0000C8F8
		private static void AddActiveTween(Tween t)
		{
			if (TweenManager._requiresActiveReorganization)
			{
				TweenManager.ReorganizeActiveTweens();
			}
			t.active = true;
			t.updateType = DOTween.defaultUpdateType;
			t.isIndependentUpdate = DOTween.defaultTimeScaleIndependent;
			t.activeId = (TweenManager._maxActiveLookupId = TweenManager.totActiveTweens);
			TweenManager._activeTweens[TweenManager.totActiveTweens] = t;
			if (t.updateType == UpdateType.Normal)
			{
				TweenManager.totActiveDefaultTweens++;
				TweenManager.hasActiveDefaultTweens = true;
			}
			else if (t.updateType == UpdateType.Fixed)
			{
				TweenManager.totActiveFixedTweens++;
				TweenManager.hasActiveFixedTweens = true;
			}
			else
			{
				TweenManager.totActiveLateTweens++;
				TweenManager.hasActiveLateTweens = true;
			}
			TweenManager.totActiveTweens++;
			if (t.tweenType == TweenType.Tweener)
			{
				TweenManager.totActiveTweeners++;
			}
			else
			{
				TweenManager.totActiveSequences++;
			}
			TweenManager.hasActiveTweens = true;
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0000E7CC File Offset: 0x0000C9CC
		private static void ReorganizeActiveTweens()
		{
			if (TweenManager.totActiveTweens <= 0)
			{
				TweenManager._maxActiveLookupId = -1;
				TweenManager._requiresActiveReorganization = false;
				TweenManager._reorganizeFromId = -1;
				return;
			}
			if (TweenManager._reorganizeFromId == TweenManager._maxActiveLookupId)
			{
				TweenManager._maxActiveLookupId--;
				TweenManager._requiresActiveReorganization = false;
				TweenManager._reorganizeFromId = -1;
				return;
			}
			int num = 1;
			int num2 = TweenManager._maxActiveLookupId + 1;
			TweenManager._maxActiveLookupId = TweenManager._reorganizeFromId - 1;
			for (int i = TweenManager._reorganizeFromId + 1; i < num2; i++)
			{
				Tween tween = TweenManager._activeTweens[i];
				if (tween == null)
				{
					num++;
				}
				else
				{
					tween.activeId = (TweenManager._maxActiveLookupId = i - num);
					TweenManager._activeTweens[i - num] = tween;
					TweenManager._activeTweens[i] = null;
				}
			}
			TweenManager._requiresActiveReorganization = false;
			TweenManager._reorganizeFromId = -1;
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0000E880 File Offset: 0x0000CA80
		private static void DespawnTweens(List<Tween> tweens, bool modifyActiveLists = true)
		{
			int count = tweens.Count;
			for (int i = 0; i < count; i++)
			{
				TweenManager.Despawn(tweens[i], modifyActiveLists);
			}
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0000E8B0 File Offset: 0x0000CAB0
		private static void RemoveActiveTween(Tween t)
		{
			int activeId = t.activeId;
			t.activeId = -1;
			TweenManager._requiresActiveReorganization = true;
			if (TweenManager._reorganizeFromId == -1 || TweenManager._reorganizeFromId > activeId)
			{
				TweenManager._reorganizeFromId = activeId;
			}
			TweenManager._activeTweens[activeId] = null;
			if (t.updateType == UpdateType.Normal)
			{
				if (TweenManager.totActiveDefaultTweens > 0)
				{
					TweenManager.totActiveDefaultTweens--;
					TweenManager.hasActiveDefaultTweens = (TweenManager.totActiveDefaultTweens > 0);
				}
				else
				{
					Debugger.LogRemoveActiveTweenError("totActiveDefaultTweens");
				}
			}
			else if (t.updateType == UpdateType.Fixed)
			{
				if (TweenManager.totActiveFixedTweens > 0)
				{
					TweenManager.totActiveFixedTweens--;
					TweenManager.hasActiveFixedTweens = (TweenManager.totActiveFixedTweens > 0);
				}
				else
				{
					Debugger.LogRemoveActiveTweenError("totActiveFixedTweens");
				}
			}
			else if (TweenManager.totActiveLateTweens > 0)
			{
				TweenManager.totActiveLateTweens--;
				TweenManager.hasActiveLateTweens = (TweenManager.totActiveLateTweens > 0);
			}
			else
			{
				Debugger.LogRemoveActiveTweenError("totActiveLateTweens");
			}
			TweenManager.totActiveTweens--;
			TweenManager.hasActiveTweens = (TweenManager.totActiveTweens > 0);
			if (t.tweenType == TweenType.Tweener)
			{
				TweenManager.totActiveTweeners--;
			}
			else
			{
				TweenManager.totActiveSequences--;
			}
			if (TweenManager.totActiveTweens < 0)
			{
				TweenManager.totActiveTweens = 0;
				Debugger.LogRemoveActiveTweenError("totActiveTweens");
			}
			if (TweenManager.totActiveTweeners < 0)
			{
				TweenManager.totActiveTweeners = 0;
				Debugger.LogRemoveActiveTweenError("totActiveTweeners");
			}
			if (TweenManager.totActiveSequences < 0)
			{
				TweenManager.totActiveSequences = 0;
				Debugger.LogRemoveActiveTweenError("totActiveSequences");
			}
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0000EA10 File Offset: 0x0000CC10
		private static void ClearTweenArray(Tween[] tweens)
		{
			int num = tweens.Length;
			for (int i = 0; i < num; i++)
			{
				tweens[i] = null;
			}
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0000EA34 File Offset: 0x0000CC34
		private static void IncreaseCapacities(TweenManager.CapacityIncreaseMode increaseMode)
		{
			int num = 0;
			int num2 = Mathf.Max((int)((float)TweenManager.maxTweeners * 1.5f), 200);
			int num3 = Mathf.Max((int)((float)TweenManager.maxSequences * 1.5f), 50);
			if (increaseMode != TweenManager.CapacityIncreaseMode.TweenersOnly)
			{
				if (increaseMode != TweenManager.CapacityIncreaseMode.SequencesOnly)
				{
					num += num2;
					TweenManager.maxTweeners += num2;
					TweenManager.maxSequences += num3;
					Array.Resize<Tween>(ref TweenManager._pooledTweeners, TweenManager.maxTweeners);
				}
				else
				{
					num += num3;
					TweenManager.maxSequences += num3;
				}
			}
			else
			{
				num += num2;
				TweenManager.maxTweeners += num2;
				Array.Resize<Tween>(ref TweenManager._pooledTweeners, TweenManager.maxTweeners);
			}
			TweenManager.maxActive = TweenManager.maxTweeners + TweenManager.maxSequences;
			Array.Resize<Tween>(ref TweenManager._activeTweens, TweenManager.maxActive);
			if (num > 0)
			{
				TweenManager._KillList.Capacity += num;
			}
		}

		// Token: 0x0400012D RID: 301
		private const int _DefaultMaxTweeners = 200;

		// Token: 0x0400012E RID: 302
		private const int _DefaultMaxSequences = 50;

		// Token: 0x0400012F RID: 303
		private const string _MaxTweensReached = "Max Tweens reached: capacity has automatically been increased from #0 to #1. Use DOTween.SetTweensCapacity to set it manually at startup";

		// Token: 0x04000130 RID: 304
		internal static int maxActive = 200;

		// Token: 0x04000131 RID: 305
		internal static int maxTweeners = 200;

		// Token: 0x04000132 RID: 306
		internal static int maxSequences = 50;

		// Token: 0x04000133 RID: 307
		internal static bool hasActiveTweens;

		// Token: 0x04000134 RID: 308
		internal static bool hasActiveDefaultTweens;

		// Token: 0x04000135 RID: 309
		internal static bool hasActiveLateTweens;

		// Token: 0x04000136 RID: 310
		internal static bool hasActiveFixedTweens;

		// Token: 0x04000137 RID: 311
		internal static int totActiveTweens;

		// Token: 0x04000138 RID: 312
		internal static int totActiveDefaultTweens;

		// Token: 0x04000139 RID: 313
		internal static int totActiveLateTweens;

		// Token: 0x0400013A RID: 314
		internal static int totActiveFixedTweens;

		// Token: 0x0400013B RID: 315
		internal static int totActiveTweeners;

		// Token: 0x0400013C RID: 316
		internal static int totActiveSequences;

		// Token: 0x0400013D RID: 317
		internal static int totPooledTweeners;

		// Token: 0x0400013E RID: 318
		internal static int totPooledSequences;

		// Token: 0x0400013F RID: 319
		internal static int totTweeners;

		// Token: 0x04000140 RID: 320
		internal static int totSequences;

		// Token: 0x04000141 RID: 321
		internal static bool isUpdateLoop;

		// Token: 0x04000142 RID: 322
		internal static Tween[] _activeTweens = new Tween[200];

		// Token: 0x04000143 RID: 323
		private static Tween[] _pooledTweeners = new Tween[200];

		// Token: 0x04000144 RID: 324
		private static readonly Stack<Tween> _PooledSequences = new Stack<Tween>();

		// Token: 0x04000145 RID: 325
		private static readonly List<Tween> _KillList = new List<Tween>(200);

		// Token: 0x04000146 RID: 326
		private static int _maxActiveLookupId = -1;

		// Token: 0x04000147 RID: 327
		private static bool _requiresActiveReorganization;

		// Token: 0x04000148 RID: 328
		private static int _reorganizeFromId = -1;

		// Token: 0x04000149 RID: 329
		private static int _minPooledTweenerId = -1;

		// Token: 0x0400014A RID: 330
		private static int _maxPooledTweenerId = -1;

		// Token: 0x020000B1 RID: 177
		internal enum CapacityIncreaseMode
		{
			// Token: 0x04000207 RID: 519
			TweenersAndSequences,
			// Token: 0x04000208 RID: 520
			TweenersOnly,
			// Token: 0x04000209 RID: 521
			SequencesOnly
		}
	}
}
