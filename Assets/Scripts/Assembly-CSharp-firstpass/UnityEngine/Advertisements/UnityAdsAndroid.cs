using System;

namespace UnityEngine.Advertisements
{
	// Token: 0x0200002F RID: 47
	internal class UnityAdsAndroid : UnityAdsPlatform
	{
		// Token: 0x0600016F RID: 367 RVA: 0x0000542E File Offset: 0x0000362E
		private AndroidJavaObject getAndroidWrapper()
		{
			if (!UnityAdsAndroid.wrapperInitialized)
			{
				UnityAdsAndroid.wrapperInitialized = true;
				UnityAdsAndroid.unityAdsUnity = new AndroidJavaObject("com.unity3d.ads.android.unity3d.UnityAdsUnityWrapper", new object[0]);
			}
			return UnityAdsAndroid.unityAdsUnity;
		}

		// Token: 0x06000170 RID: 368 RVA: 0x0000545C File Offset: 0x0000365C
		public override void init(string gameId, bool testModeEnabled, string gameObjectName, string unityVersion)
		{
			Utils.LogDebug(string.Concat(new object[]
			{
				"UnityAndroid: init(), gameId=",
				gameId,
				", testModeEnabled=",
				testModeEnabled,
				", gameObjectName=",
				gameObjectName
			}));
			if (Advertisement.UnityDeveloperInternalTestMode)
			{
				this.getAndroidWrapper().Call("enableUnityDeveloperInternalTestMode", new object[0]);
			}
			UnityAdsAndroid.currentActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
			this.getAndroidWrapper().Call("init", new object[]
			{
				gameId,
				UnityAdsAndroid.currentActivity,
				testModeEnabled,
				(int)Advertisement.debugLevel,
				gameObjectName,
				unityVersion
			});
		}

		// Token: 0x06000171 RID: 369 RVA: 0x0000551C File Offset: 0x0000371C
		public override bool show(string zoneId, string rewardItemKey, string options)
		{
			Utils.LogDebug("UnityAndroid: show()");
			return this.getAndroidWrapper().Call<bool>("show", new object[]
			{
				zoneId,
				rewardItemKey,
				options
			});
		}

		// Token: 0x06000172 RID: 370 RVA: 0x0000554A File Offset: 0x0000374A
		public override void hide()
		{
			Utils.LogDebug("UnityAndroid: hide()");
			this.getAndroidWrapper().Call("hide", new object[0]);
		}

		// Token: 0x06000173 RID: 371 RVA: 0x0000556C File Offset: 0x0000376C
		public override bool isSupported()
		{
			Utils.LogDebug("UnityAndroid: isSupported()");
			return this.getAndroidWrapper().Call<bool>("isSupported", new object[0]);
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0000558E File Offset: 0x0000378E
		public override string getSDKVersion()
		{
			Utils.LogDebug("UnityAndroid: getSDKVersion()");
			return this.getAndroidWrapper().Call<string>("getSDKVersion", new object[0]);
		}

		// Token: 0x06000175 RID: 373 RVA: 0x000055B0 File Offset: 0x000037B0
		public override bool canShowZone(string zone)
		{
			return this.getAndroidWrapper().Call<bool>("canShowZone", new object[]
			{
				zone
			});
		}

		// Token: 0x06000176 RID: 374 RVA: 0x000055CC File Offset: 0x000037CC
		public override bool hasMultipleRewardItems()
		{
			Utils.LogDebug("UnityAndroid: hasMultipleRewardItems()");
			return this.getAndroidWrapper().Call<bool>("hasMultipleRewardItems", new object[0]);
		}

		// Token: 0x06000177 RID: 375 RVA: 0x000055EE File Offset: 0x000037EE
		public override string getRewardItemKeys()
		{
			Utils.LogDebug("UnityAndroid: getRewardItemKeys()");
			return this.getAndroidWrapper().Call<string>("getRewardItemKeys", new object[0]);
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00005610 File Offset: 0x00003810
		public override string getDefaultRewardItemKey()
		{
			Utils.LogDebug("UnityAndroid: getDefaultRewardItemKey()");
			return this.getAndroidWrapper().Call<string>("getDefaultRewardItemKey", new object[0]);
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00005632 File Offset: 0x00003832
		public override string getCurrentRewardItemKey()
		{
			Utils.LogDebug("UnityAndroid: getCurrentRewardItemKey()");
			return this.getAndroidWrapper().Call<string>("getCurrentRewardItemKey", new object[0]);
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00005654 File Offset: 0x00003854
		public override bool setRewardItemKey(string rewardItemKey)
		{
			Utils.LogDebug("UnityAndroid: setRewardItemKey() rewardItemKey=" + rewardItemKey);
			return this.getAndroidWrapper().Call<bool>("setRewardItemKey", new object[]
			{
				rewardItemKey
			});
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00005680 File Offset: 0x00003880
		public override void setDefaultRewardItemAsRewardItem()
		{
			Utils.LogDebug("UnityAndroid: setDefaultRewardItemAsRewardItem()");
			this.getAndroidWrapper().Call("setDefaultRewardItemAsRewardItem", new object[0]);
		}

		// Token: 0x0600017C RID: 380 RVA: 0x000056A2 File Offset: 0x000038A2
		public override string getRewardItemDetailsWithKey(string rewardItemKey)
		{
			Utils.LogDebug("UnityAndroid: getRewardItemDetailsWithKey() rewardItemKey=" + rewardItemKey);
			return this.getAndroidWrapper().Call<string>("getRewardItemDetailsWithKey", new object[]
			{
				rewardItemKey
			});
		}

		// Token: 0x0600017D RID: 381 RVA: 0x000056CE File Offset: 0x000038CE
		public override string getRewardItemDetailsKeys()
		{
			Utils.LogDebug("UnityAndroid: getRewardItemDetailsKeys()");
			return this.getAndroidWrapper().Call<string>("getRewardItemDetailsKeys", new object[0]);
		}

		// Token: 0x0600017E RID: 382 RVA: 0x000056F0 File Offset: 0x000038F0
		public override void setLogLevel(Advertisement.DebugLevel logLevel)
		{
			Utils.LogDebug("UnityAndroid: setLogLevel()");
			this.getAndroidWrapper().Call("setLogLevel", new object[]
			{
				(int)logLevel
			});
		}

		// Token: 0x040000BF RID: 191
		private static AndroidJavaObject unityAds;

		// Token: 0x040000C0 RID: 192
		private static AndroidJavaObject unityAdsUnity;

		// Token: 0x040000C1 RID: 193
		private static AndroidJavaObject currentActivity;

		// Token: 0x040000C2 RID: 194
		private static bool wrapperInitialized;
	}
}
