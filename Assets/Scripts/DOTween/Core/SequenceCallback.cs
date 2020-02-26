using System;

namespace DG.Tweening.Core
{
	// Token: 0x0200004B RID: 75
	internal class SequenceCallback : ABSSequentiable
	{
		// Token: 0x06000263 RID: 611 RVA: 0x0000D4CA File Offset: 0x0000B6CA
		public SequenceCallback(float sequencedPosition, TweenCallback callback)
		{
			this.tweenType = TweenType.Callback;
			this.sequencedPosition = sequencedPosition;
			this.onStart = callback;
		}
	}
}
