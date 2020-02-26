using System;
using UnityEngine;

namespace DG.Tweening.Core
{
	// Token: 0x02000049 RID: 73
	public class _DOTweenSettings : ScriptableObject
	{
		// Token: 0x0400011C RID: 284
		public const string AssetName = "DOTweenSettings";

		// Token: 0x0400011D RID: 285
		public bool useSafeMode = true;

		// Token: 0x0400011E RID: 286
		public float timeScale = 1f;

		// Token: 0x0400011F RID: 287
		public bool useSmoothDeltaTime;

		// Token: 0x04000120 RID: 288
		public bool showUnityEditorReport;

		// Token: 0x04000121 RID: 289
		public LogBehaviour logBehaviour = LogBehaviour.ErrorsOnly;

		// Token: 0x04000122 RID: 290
		public bool drawGizmos = true;

		// Token: 0x04000123 RID: 291
		public bool defaultRecyclable;

		// Token: 0x04000124 RID: 292
		public AutoPlay defaultAutoPlay = AutoPlay.All;

		// Token: 0x04000125 RID: 293
		public UpdateType defaultUpdateType;

		// Token: 0x04000126 RID: 294
		public bool defaultTimeScaleIndependent;

		// Token: 0x04000127 RID: 295
		public Ease defaultEaseType = Ease.OutQuad;

		// Token: 0x04000128 RID: 296
		public float defaultEaseOvershootOrAmplitude = 1.70158f;

		// Token: 0x04000129 RID: 297
		public float defaultEasePeriod;

		// Token: 0x0400012A RID: 298
		public bool defaultAutoKill = true;

		// Token: 0x0400012B RID: 299
		public LoopType defaultLoopType;

		// Token: 0x0400012C RID: 300
		public DOTweenSettings.SettingsLocation storeSettingsLocation;

		// Token: 0x020000B0 RID: 176
		public enum SettingsLocation
		{
			// Token: 0x04000203 RID: 515
			AssetsDirectory,
			// Token: 0x04000204 RID: 516
			DOTweenDirectory,
			// Token: 0x04000205 RID: 517
			DemigiantDirectory
		}
	}
}
