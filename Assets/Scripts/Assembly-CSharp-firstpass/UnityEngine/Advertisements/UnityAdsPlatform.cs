using System;

namespace UnityEngine.Advertisements
{
	// Token: 0x02000031 RID: 49
	internal abstract class UnityAdsPlatform
	{
		// Token: 0x06000192 RID: 402
		public abstract void init(string gameId, bool testModeEnabled, string gameObjectName, string unityVersion);

		// Token: 0x06000193 RID: 403
		public abstract bool show(string zoneId, string rewardItemKey, string options);

		// Token: 0x06000194 RID: 404
		public abstract void hide();

		// Token: 0x06000195 RID: 405
		public abstract bool isSupported();

		// Token: 0x06000196 RID: 406
		public abstract string getSDKVersion();

		// Token: 0x06000197 RID: 407
		public abstract bool canShowZone(string zone);

		// Token: 0x06000198 RID: 408
		public abstract bool hasMultipleRewardItems();

		// Token: 0x06000199 RID: 409
		public abstract string getRewardItemKeys();

		// Token: 0x0600019A RID: 410
		public abstract string getDefaultRewardItemKey();

		// Token: 0x0600019B RID: 411
		public abstract string getCurrentRewardItemKey();

		// Token: 0x0600019C RID: 412
		public abstract bool setRewardItemKey(string rewardItemKey);

		// Token: 0x0600019D RID: 413
		public abstract void setDefaultRewardItemAsRewardItem();

		// Token: 0x0600019E RID: 414
		public abstract string getRewardItemDetailsWithKey(string rewardItemKey);

		// Token: 0x0600019F RID: 415
		public abstract string getRewardItemDetailsKeys();

		// Token: 0x060001A0 RID: 416
		public abstract void setLogLevel(Advertisement.DebugLevel logLevel);
	}
}
