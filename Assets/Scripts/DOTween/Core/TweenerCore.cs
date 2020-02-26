using System;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;

namespace DG.Tweening.Core
{
	// Token: 0x0200004E RID: 78
	public class TweenerCore<T1, T2, TPlugOptions> : Tweener where TPlugOptions : struct
	{
		// Token: 0x0600028C RID: 652 RVA: 0x0000EC08 File Offset: 0x0000CE08
		internal TweenerCore()
		{
			this.typeofT1 = typeof(T1);
			this.typeofT2 = typeof(T2);
			this.typeofTPlugOptions = typeof(TPlugOptions);
			this.tweenType = TweenType.Tweener;
			this.Reset();
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0000EC58 File Offset: 0x0000CE58
		public override Tweener ChangeStartValue(object newStartValue, float newDuration = -1f)
		{
			if (this.isSequenced)
			{
				if (Debugger.logPriority >= 1)
				{
					Debugger.LogWarning("You cannot change the values of a tween contained inside a Sequence");
				}
				return this;
			}
			Type type = newStartValue.GetType();
			if (type != this.typeofT2)
			{
				if (Debugger.logPriority >= 1)
				{
					Debugger.LogWarning(string.Concat(new object[]
					{
						"ChangeStartValue: incorrect newStartValue type (is ",
						type,
						", should be ",
						this.typeofT2,
						")"
					}));
				}
				return this;
			}
			return Tweener.DoChangeStartValue<T1, T2, TPlugOptions>(this, (T2)((object)newStartValue), newDuration);
		}

		// Token: 0x0600028E RID: 654 RVA: 0x0000ECDD File Offset: 0x0000CEDD
		public override Tweener ChangeEndValue(object newEndValue, bool snapStartValue)
		{
			return this.ChangeEndValue(newEndValue, -1f, snapStartValue);
		}

		// Token: 0x0600028F RID: 655 RVA: 0x0000ECEC File Offset: 0x0000CEEC
		public override Tweener ChangeEndValue(object newEndValue, float newDuration = -1f, bool snapStartValue = false)
		{
			if (this.isSequenced)
			{
				if (Debugger.logPriority >= 1)
				{
					Debugger.LogWarning("You cannot change the values of a tween contained inside a Sequence");
				}
				return this;
			}
			Type type = newEndValue.GetType();
			if (type != this.typeofT2)
			{
				if (Debugger.logPriority >= 1)
				{
					Debugger.LogWarning(string.Concat(new object[]
					{
						"ChangeEndValue: incorrect newEndValue type (is ",
						type,
						", should be ",
						this.typeofT2,
						")"
					}));
				}
				return this;
			}
			return Tweener.DoChangeEndValue<T1, T2, TPlugOptions>(this, (T2)((object)newEndValue), newDuration, snapStartValue);
		}

		// Token: 0x06000290 RID: 656 RVA: 0x0000ED74 File Offset: 0x0000CF74
		public override Tweener ChangeValues(object newStartValue, object newEndValue, float newDuration = -1f)
		{
			if (this.isSequenced)
			{
				if (Debugger.logPriority >= 1)
				{
					Debugger.LogWarning("You cannot change the values of a tween contained inside a Sequence");
				}
				return this;
			}
			Type type = newStartValue.GetType();
			Type type2 = newEndValue.GetType();
			if (type != this.typeofT2)
			{
				if (Debugger.logPriority >= 1)
				{
					Debugger.LogWarning(string.Concat(new object[]
					{
						"ChangeValues: incorrect value type (is ",
						type,
						", should be ",
						this.typeofT2,
						")"
					}));
				}
				return this;
			}
			if (type2 != this.typeofT2)
			{
				if (Debugger.logPriority >= 1)
				{
					Debugger.LogWarning(string.Concat(new object[]
					{
						"ChangeValues: incorrect value type (is ",
						type2,
						", should be ",
						this.typeofT2,
						")"
					}));
				}
				return this;
			}
			return Tweener.DoChangeValues<T1, T2, TPlugOptions>(this, (T2)((object)newStartValue), (T2)((object)newEndValue), newDuration);
		}

		// Token: 0x06000291 RID: 657 RVA: 0x0000EE4E File Offset: 0x0000D04E
		internal override Tweener SetFrom(bool relative)
		{
			this.tweenPlugin.SetFrom(this, relative);
			this.hasManuallySetStartValue = true;
			return this;
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0000EE68 File Offset: 0x0000D068
		internal sealed override void Reset()
		{
			base.Reset();
			if (this.tweenPlugin != null)
			{
				this.tweenPlugin.Reset(this);
			}
			this.plugOptions = Activator.CreateInstance<TPlugOptions>();
			this.getter = null;
			this.setter = null;
			this.hasManuallySetStartValue = false;
			this.isFromAllowed = true;
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0000EEB8 File Offset: 0x0000D0B8
		internal override bool Validate()
		{
			try
			{
				this.getter();
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x06000294 RID: 660 RVA: 0x0000EEEC File Offset: 0x0000D0EC
		internal override float UpdateDelay(float elapsed)
		{
			return Tweener.DoUpdateDelay<T1, T2, TPlugOptions>(this, elapsed);
		}

		// Token: 0x06000295 RID: 661 RVA: 0x0000EEF5 File Offset: 0x0000D0F5
		internal override bool Startup()
		{
			return Tweener.DoStartup<T1, T2, TPlugOptions>(this);
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0000EF00 File Offset: 0x0000D100
		internal override bool ApplyTween(float prevPosition, int prevCompletedLoops, int newCompletedSteps, bool useInversePosition, UpdateMode updateMode, UpdateNotice updateNotice)
		{
			float elapsed = useInversePosition ? (this.duration - this.position) : this.position;
			if (DOTween.useSafeMode)
			{
				try
				{
					this.tweenPlugin.EvaluateAndApply(this.plugOptions, this, this.isRelative, this.getter, this.setter, elapsed, this.startValue, this.changeValue, this.duration, useInversePosition, updateNotice);
					return false;
				}
				catch
				{
					return true;
				}
			}
			this.tweenPlugin.EvaluateAndApply(this.plugOptions, this, this.isRelative, this.getter, this.setter, elapsed, this.startValue, this.changeValue, this.duration, useInversePosition, updateNotice);
			return false;
		}

		// Token: 0x0400014B RID: 331
		public T2 startValue;

		// Token: 0x0400014C RID: 332
		public T2 endValue;

		// Token: 0x0400014D RID: 333
		public T2 changeValue;

		// Token: 0x0400014E RID: 334
		public TPlugOptions plugOptions;

		// Token: 0x0400014F RID: 335
		public DOGetter<T1> getter;

		// Token: 0x04000150 RID: 336
		public DOSetter<T1> setter;

		// Token: 0x04000151 RID: 337
		internal ABSTweenPlugin<T1, T2, TPlugOptions> tweenPlugin;

		// Token: 0x04000152 RID: 338
		private const string _TxtCantChangeSequencedValues = "You cannot change the values of a tween contained inside a Sequence";
	}
}
