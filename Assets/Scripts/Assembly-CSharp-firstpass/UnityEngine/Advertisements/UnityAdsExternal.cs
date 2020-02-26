using System;

namespace UnityEngine.Advertisements
{
	// Token: 0x02000030 RID: 48
	internal static class UnityAdsExternal
	{
		// Token: 0x06000180 RID: 384 RVA: 0x0000571D File Offset: 0x0000391D
		private static UnityAdsPlatform getImpl()
		{
			if (!UnityAdsExternal.initialized)
			{
				UnityAdsExternal.initialized = true;
				UnityAdsExternal.impl = new UnityAdsAndroid();
			}
			return UnityAdsExternal.impl;
		}

		// Token: 0x06000181 RID: 385 RVA: 0x0000573E File Offset: 0x0000393E
		public static void init(string gameId, bool testModeEnabled, string gameObjectName, string unityVersion)
		{
			UnityAdsExternal.getImpl().init(gameId, testModeEnabled, gameObjectName, unityVersion);
		}

		// Token: 0x06000182 RID: 386 RVA: 0x0000574E File Offset: 0x0000394E
		public static bool show(string zoneId, string rewardItemKey, string options)
		{
			return UnityAdsExternal.getImpl().show(zoneId, rewardItemKey, options);
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000575D File Offset: 0x0000395D
		public static void hide()
		{
			UnityAdsExternal.getImpl().hide();
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00005769 File Offset: 0x00003969
		public static bool isSupported()
		{
			return UnityAdsExternal.getImpl().isSupported();
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00005775 File Offset: 0x00003975
		public static string getSDKVersion()
		{
			return UnityAdsExternal.getImpl().getSDKVersion();
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00005781 File Offset: 0x00003981
		public static bool canShowZone(string zone)
		{
			return UnityAdsExternal.getImpl().canShowZone(zone);
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0000578E File Offset: 0x0000398E
		public static bool hasMultipleRewardItems()
		{
			return UnityAdsExternal.getImpl().hasMultipleRewardItems();
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0000579A File Offset: 0x0000399A
		public static string getRewardItemKeys()
		{
			return UnityAdsExternal.getImpl().getRewardItemKeys();
		}

		// Token: 0x06000189 RID: 393 RVA: 0x000057A6 File Offset: 0x000039A6
		public static string getDefaultRewardItemKey()
		{
			return UnityAdsExternal.getImpl().getDefaultRewardItemKey();
		}

		// Token: 0x0600018A RID: 394 RVA: 0x000057B2 File Offset: 0x000039B2
		public static string getCurrentRewardItemKey()
		{
			return UnityAdsExternal.getImpl().getCurrentRewardItemKey();
		}

		// Token: 0x0600018B RID: 395 RVA: 0x000057BE File Offset: 0x000039BE
		public static bool setRewardItemKey(string rewardItemKey)
		{
			return UnityAdsExternal.getImpl().setRewardItemKey(rewardItemKey);
		}

		// Token: 0x0600018C RID: 396 RVA: 0x000057CB File Offset: 0x000039CB
		public static void setDefaultRewardItemAsRewardItem()
		{
			UnityAdsExternal.getImpl().setDefaultRewardItemAsRewardItem();
		}

		// Token: 0x0600018D RID: 397 RVA: 0x000057D7 File Offset: 0x000039D7
		public static string getRewardItemDetailsWithKey(string rewardItemKey)
		{
			return UnityAdsExternal.getImpl().getRewardItemDetailsWithKey(rewardItemKey);
		}

		// Token: 0x0600018E RID: 398 RVA: 0x000057E4 File Offset: 0x000039E4
		public static string getRewardItemDetailsKeys()
		{
			return UnityAdsExternal.getImpl().getRewardItemDetailsKeys();
		}

		// Token: 0x0600018F RID: 399 RVA: 0x000057F0 File Offset: 0x000039F0
		public static void setLogLevel(Advertisement.DebugLevel logLevel)
		{
			UnityAdsExternal.getImpl().setLogLevel(logLevel);
		}

		// Token: 0x040000C3 RID: 195
		private static UnityAdsPlatform impl;

		// Token: 0x040000C4 RID: 196
		private static bool initialized;
	}
}
