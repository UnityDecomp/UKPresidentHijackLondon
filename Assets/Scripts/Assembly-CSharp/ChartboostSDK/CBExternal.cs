using System;
using UnityEngine;

namespace ChartboostSDK
{
	// Token: 0x02000004 RID: 4
	public class CBExternal
	{
		// Token: 0x06000035 RID: 53 RVA: 0x000033E6 File Offset: 0x000017E6
		public static void Log(string message)
		{
			if (CBSettings.isLogging() && Debug.isDebugBuild)
			{
				Debug.Log(CBExternal._logTag + "/" + message);
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00003411 File Offset: 0x00001811
		public static bool isInitialized()
		{
			return CBExternal.initialized;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00003418 File Offset: 0x00001818
		private static bool checkInitialized()
		{
			if (CBExternal.initialized)
			{
				return true;
			}
			Debug.LogError("The Chartboost SDK needs to be initialized before we can show any ads");
			return false;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00003434 File Offset: 0x00001834
		public static void init()
		{
			string selectAndroidAppId = CBSettings.getSelectAndroidAppId();
			string selectAndroidAppSecret = CBSettings.getSelectAndroidAppSecret();
			CBExternal.initWithAppId(selectAndroidAppId, selectAndroidAppSecret);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00003454 File Offset: 0x00001854
		public static void initWithAppId(string appId, string appSignature)
		{
			string unityVersion = Application.unityVersion;
			CBExternal.Log("Unity : initWithAppId " + appId + " and version " + unityVersion);
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.chartboost.sdk.unity.CBPlugin"))
			{
				CBExternal._plugin = androidJavaClass.CallStatic<AndroidJavaObject>("instance", new object[0]);
			}
			CBExternal._plugin.Call("init", new object[]
			{
				appId,
				appSignature,
				unityVersion
			});
			CBExternal.initialized = true;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000034E8 File Offset: 0x000018E8
		public static bool isAnyViewVisible()
		{
			bool flag = false;
			if (!CBExternal.checkInitialized())
			{
				return flag;
			}
			flag = CBExternal._plugin.Call<bool>("isAnyViewVisible", new object[0]);
			CBExternal.Log("Android : isAnyViewVisible = " + flag);
			return flag;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00003530 File Offset: 0x00001930
		public static void cacheInterstitial(CBLocation location)
		{
			if (!CBExternal.checkInitialized())
			{
				return;
			}
			if (location == null)
			{
				Debug.LogError("Chartboost SDK: location passed is null cannot perform the operation requested");
				return;
			}
			CBExternal._plugin.Call("cacheInterstitial", new object[]
			{
				location.ToString()
			});
			CBExternal.Log("Android : cacheInterstitial at location = " + location.ToString());
		}

		// Token: 0x0600003C RID: 60 RVA: 0x0000358C File Offset: 0x0000198C
		public static bool hasInterstitial(CBLocation location)
		{
			if (!CBExternal.checkInitialized())
			{
				return false;
			}
			if (location == null)
			{
				Debug.LogError("Chartboost SDK: location passed is null cannot perform the operation requested");
				return false;
			}
			CBExternal.Log("Android : hasInterstitial at location = " + location.ToString());
			return CBExternal._plugin.Call<bool>("hasInterstitial", new object[]
			{
				location.ToString()
			});
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000035EC File Offset: 0x000019EC
		public static void showInterstitial(CBLocation location)
		{
			if (!CBExternal.checkInitialized())
			{
				return;
			}
			if (location == null)
			{
				Debug.LogError("Chartboost SDK: location passed is null cannot perform the operation requested");
				return;
			}
			CBExternal._plugin.Call("showInterstitial", new object[]
			{
				location.ToString()
			});
			CBExternal.Log("Android : showInterstitial at location = " + location.ToString());
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00003648 File Offset: 0x00001A48
		public static void cacheMoreApps(CBLocation location)
		{
			if (!CBExternal.checkInitialized())
			{
				return;
			}
			if (location == null)
			{
				Debug.LogError("Chartboost SDK: location passed is null cannot perform the operation requested");
				return;
			}
			CBExternal._plugin.Call("cacheMoreApps", new object[]
			{
				location.ToString()
			});
			CBExternal.Log("Android : cacheMoreApps at location = " + location.ToString());
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000036A4 File Offset: 0x00001AA4
		public static bool hasMoreApps(CBLocation location)
		{
			if (!CBExternal.checkInitialized())
			{
				return false;
			}
			if (location == null)
			{
				Debug.LogError("Chartboost SDK: location passed is null cannot perform the operation requested");
				return false;
			}
			CBExternal.Log("Android : hasMoreApps at location = " + location.ToString());
			return CBExternal._plugin.Call<bool>("hasMoreApps", new object[]
			{
				location.ToString()
			});
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00003704 File Offset: 0x00001B04
		public static void showMoreApps(CBLocation location)
		{
			if (!CBExternal.checkInitialized())
			{
				return;
			}
			if (location == null)
			{
				Debug.LogError("Chartboost SDK: location passed is null cannot perform the operation requested");
				return;
			}
			CBExternal._plugin.Call("showMoreApps", new object[]
			{
				location.ToString()
			});
			CBExternal.Log("Android : showMoreApps at location = " + location.ToString());
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00003760 File Offset: 0x00001B60
		public static void cacheInPlay(CBLocation location)
		{
			if (!CBExternal.checkInitialized())
			{
				return;
			}
			if (location == null)
			{
				Debug.LogError("Chartboost SDK: location passed is null cannot perform the operation requested");
				return;
			}
			CBExternal._plugin.Call("cacheInPlay", new object[]
			{
				location.ToString()
			});
			CBExternal.Log("Android : cacheInPlay at location = " + location.ToString());
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000037BC File Offset: 0x00001BBC
		public static bool hasInPlay(CBLocation location)
		{
			if (!CBExternal.checkInitialized())
			{
				return false;
			}
			if (location == null)
			{
				Debug.LogError("Chartboost SDK: location passed is null cannot perform the operation requested");
				return false;
			}
			CBExternal.Log("Android : hasInPlay at location = " + location.ToString());
			return CBExternal._plugin.Call<bool>("hasCachedInPlay", new object[]
			{
				location.ToString()
			});
		}

		// Token: 0x06000043 RID: 67 RVA: 0x0000381C File Offset: 0x00001C1C
		public static CBInPlay getInPlay(CBLocation location)
		{
			CBExternal.Log("Android : getInPlay at location = " + location.ToString());
			if (!CBExternal.checkInitialized())
			{
				return null;
			}
			if (location == null)
			{
				Debug.LogError("Chartboost SDK: location passed is null cannot perform the operation requested");
				return null;
			}
			CBInPlay result;
			try
			{
				AndroidJavaObject inPlayAd = CBExternal._plugin.Call<AndroidJavaObject>("getInPlay", new object[]
				{
					location.ToString()
				});
				CBInPlay cbinPlay = new CBInPlay(inPlayAd, CBExternal._plugin);
				result = cbinPlay;
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000038A8 File Offset: 0x00001CA8
		public static void cacheRewardedVideo(CBLocation location)
		{
			if (!CBExternal.checkInitialized())
			{
				return;
			}
			if (location == null)
			{
				Debug.LogError("Chartboost SDK: location passed is null cannot perform the operation requested");
				return;
			}
			CBExternal._plugin.Call("cacheRewardedVideo", new object[]
			{
				location.ToString()
			});
			CBExternal.Log("Android : cacheRewardedVideo at location = " + location.ToString());
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00003904 File Offset: 0x00001D04
		public static bool hasRewardedVideo(CBLocation location)
		{
			if (!CBExternal.checkInitialized())
			{
				return false;
			}
			if (location == null)
			{
				Debug.LogError("Chartboost SDK: location passed is null cannot perform the operation requested");
				return false;
			}
			CBExternal.Log("Android : hasRewardedVideo at location = " + location.ToString());
			return CBExternal._plugin.Call<bool>("hasRewardedVideo", new object[]
			{
				location.ToString()
			});
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00003964 File Offset: 0x00001D64
		public static void showRewardedVideo(CBLocation location)
		{
			if (!CBExternal.checkInitialized())
			{
				return;
			}
			if (location == null)
			{
				Debug.LogError("Chartboost SDK: location passed is null cannot perform the operation requested");
				return;
			}
			CBExternal._plugin.Call("showRewardedVideo", new object[]
			{
				location.ToString()
			});
			CBExternal.Log("Android : showRewardedVideo at location = " + location.ToString());
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000039C0 File Offset: 0x00001DC0
		public static void chartBoostShouldDisplayInterstitialCallbackResult(bool result)
		{
			if (!CBExternal.checkInitialized())
			{
				return;
			}
			CBExternal._plugin.Call("chartBoostShouldDisplayInterstitialCallbackResult", new object[]
			{
				result
			});
			CBExternal.Log("Android : chartBoostShouldDisplayInterstitialCallbackResult");
		}

		// Token: 0x06000048 RID: 72 RVA: 0x000039F5 File Offset: 0x00001DF5
		public static void chartBoostShouldDisplayRewardedVideoCallbackResult(bool result)
		{
			if (!CBExternal.checkInitialized())
			{
				return;
			}
			CBExternal._plugin.Call("chartBoostShouldDisplayRewardedVideoCallbackResult", new object[]
			{
				result
			});
			CBExternal.Log("Android : chartBoostShouldDisplayRewardedVideoCallbackResult");
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00003A2A File Offset: 0x00001E2A
		public static void chartBoostShouldDisplayMoreAppsCallbackResult(bool result)
		{
			if (!CBExternal.checkInitialized())
			{
				return;
			}
			CBExternal._plugin.Call("chartBoostShouldDisplayMoreAppsCallbackResult", new object[]
			{
				result
			});
			CBExternal.Log("Android : chartBoostShouldDisplayMoreAppsCallbackResult");
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00003A5F File Offset: 0x00001E5F
		public static void didPassAgeGate(bool pass)
		{
			CBExternal._plugin.Call("didPassAgeGate", new object[]
			{
				pass
			});
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00003A7F File Offset: 0x00001E7F
		public static void setShouldPauseClickForConfirmation(bool shouldPause)
		{
			CBExternal._plugin.Call("setShouldPauseClickForConfirmation", new object[]
			{
				shouldPause
			});
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00003A9F File Offset: 0x00001E9F
		public static string getCustomId()
		{
			return CBExternal._plugin.Call<string>("getCustomId", new object[0]);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00003AB6 File Offset: 0x00001EB6
		public static void setCustomId(string customId)
		{
			CBExternal._plugin.Call("setCustomId", new object[]
			{
				customId
			});
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00003AD1 File Offset: 0x00001ED1
		public static bool getAutoCacheAds()
		{
			return CBExternal._plugin.Call<bool>("getAutoCacheAds", new object[0]);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00003AE8 File Offset: 0x00001EE8
		public static void setAutoCacheAds(bool autoCacheAds)
		{
			CBExternal._plugin.Call("setAutoCacheAds", new object[]
			{
				autoCacheAds
			});
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00003B08 File Offset: 0x00001F08
		public static void setShouldRequestInterstitialsInFirstSession(bool shouldRequest)
		{
			CBExternal._plugin.Call("setShouldRequestInterstitialsInFirstSession", new object[]
			{
				shouldRequest
			});
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00003B28 File Offset: 0x00001F28
		public static void setShouldDisplayLoadingViewForMoreApps(bool shouldDisplay)
		{
			CBExternal._plugin.Call("setShouldDisplayLoadingViewForMoreApps", new object[]
			{
				shouldDisplay
			});
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00003B48 File Offset: 0x00001F48
		public static void setShouldPrefetchVideoContent(bool shouldPrefetch)
		{
			CBExternal._plugin.Call("setShouldPrefetchVideoContent", new object[]
			{
				shouldPrefetch
			});
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00003B68 File Offset: 0x00001F68
		public static void trackLevelInfo(string eventLabel, CBLevelType type, int mainLevel, int subLevel, string description)
		{
			CBExternal._plugin.Call("trackLevelInfo", new object[]
			{
				eventLabel,
				(int)type,
				mainLevel,
				subLevel,
				description
			});
			CBExternal.Log(string.Format("Android : PIA Level Tracking:\n\teventLabel = {0}\n\ttype = {1}\n\tmainLevel = {2}\n\tsubLevel = {3}\n\tdescription = {4}", new object[]
			{
				eventLabel,
				(int)type,
				mainLevel,
				subLevel,
				description
			}));
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00003BEC File Offset: 0x00001FEC
		public static void trackLevelInfo(string eventLabel, CBLevelType type, int mainLevel, string description)
		{
			CBExternal._plugin.Call("trackLevelInfo", new object[]
			{
				eventLabel,
				(int)type,
				mainLevel,
				description
			});
			CBExternal.Log(string.Format("Android : PIA Level Tracking:\n\teventLabel = {0}\n\ttype = {1}\n\tmainLevel = {2}\n\tdescription = {3}", new object[]
			{
				eventLabel,
				(int)type,
				mainLevel,
				description
			}));
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00003C59 File Offset: 0x00002059
		public static void setGameObjectName(string name)
		{
			CBExternal._plugin.Call("setGameObjectName", new object[]
			{
				name
			});
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00003C74 File Offset: 0x00002074
		public static void pause(bool paused)
		{
			if (!CBExternal.checkInitialized())
			{
				return;
			}
			CBExternal._plugin.Call("pause", new object[]
			{
				paused
			});
			CBExternal.Log("Android : pause");
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00003CA9 File Offset: 0x000020A9
		public static void destroy()
		{
			if (!CBExternal.checkInitialized())
			{
				return;
			}
			CBExternal._plugin.Call("destroy", new object[0]);
			CBExternal.initialized = false;
			CBExternal.Log("Android : destroy");
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00003CDC File Offset: 0x000020DC
		public static bool onBackPressed()
		{
			if (!CBExternal.checkInitialized())
			{
				return false;
			}
			bool result = CBExternal._plugin.Call<bool>("onBackPressed", new object[0]);
			CBExternal.Log("Android : onBackPressed");
			return result;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00003D18 File Offset: 0x00002118
		public static void trackInAppGooglePlayPurchaseEvent(string title, string description, string price, string currency, string productID, string purchaseData, string purchaseSignature)
		{
			CBExternal.Log("Android: trackInAppGooglePlayPurchaseEvent");
			CBExternal._plugin.Call("trackInAppGooglePlayPurchaseEvent", new object[]
			{
				title,
				description,
				price,
				currency,
				productID,
				purchaseData,
				purchaseSignature
			});
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00003D58 File Offset: 0x00002158
		public static void trackInAppAmazonStorePurchaseEvent(string title, string description, string price, string currency, string productID, string userID, string purchaseToken)
		{
			CBExternal.Log("Android: trackInAppAmazonStorePurchaseEvent");
			CBExternal._plugin.Call("trackInAppAmazonStorePurchaseEvent", new object[]
			{
				title,
				description,
				price,
				currency,
				productID,
				userID,
				purchaseToken
			});
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00003D98 File Offset: 0x00002198
		public static void setMediation(CBMediation mediator, string version)
		{
			CBExternal._plugin.Call("setMediation", new object[]
			{
				mediator.ToString(),
				version
			});
			CBExternal.Log("Android : setMediation to = " + mediator.ToString() + " " + version);
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00003DD7 File Offset: 0x000021D7
		public static bool isWebViewEnabled()
		{
			return CBExternal._plugin.Call<bool>("isWebViewEnabled", new object[0]);
		}

		// Token: 0x0400001E RID: 30
		private static bool initialized;

		// Token: 0x0400001F RID: 31
		private static string _logTag = "ChartboostSDK";

		// Token: 0x04000020 RID: 32
		private static AndroidJavaObject _plugin;
	}
}
