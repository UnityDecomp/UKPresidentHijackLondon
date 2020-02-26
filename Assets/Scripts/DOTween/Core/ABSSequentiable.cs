using System;

namespace DG.Tweening.Core
{
	// Token: 0x02000044 RID: 68
	public abstract class ABSSequentiable
	{
		// Token: 0x04000113 RID: 275
		internal TweenType tweenType;

		// Token: 0x04000114 RID: 276
		internal float sequencedPosition;

		// Token: 0x04000115 RID: 277
		internal float sequencedEndPosition;

		// Token: 0x04000116 RID: 278
		internal TweenCallback onStart;
	}
}
