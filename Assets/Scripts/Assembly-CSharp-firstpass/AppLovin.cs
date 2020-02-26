using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x0200000D RID: 13
public class AppLovin
{
	// Token: 0x06000037 RID: 55 RVA: 0x000028C5 File Offset: 0x00000AC5
	public AppLovin(AndroidJavaObject activity)
	{
		if (activity == null)
		{
			throw new MissingReferenceException("No parent activity specified");
		}
		this.currentActivity = activity;
	}

	// Token: 0x06000038 RID: 56 RVA: 0x000028F5 File Offset: 0x00000AF5
	public AppLovin()
	{
	}

	// Token: 0x06000039 RID: 57 RVA: 0x00002910 File Offset: 0x00000B10
	public static AppLovin getDefaultPlugin()
	{
		if (AppLovin.DefaultPlugin == null)
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AppLovin.DefaultPlugin = new AppLovin(androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity"));
		}
		return AppLovin.DefaultPlugin;
	}

	// Token: 0x0600003A RID: 58 RVA: 0x0000294C File Offset: 0x00000B4C
	public void initializeSdk()
	{
		this.applovinFacade.CallStatic("InitializeSdk", new object[]
		{
			this.currentActivity
		});
	}

	// Token: 0x0600003B RID: 59 RVA: 0x0000296D File Offset: 0x00000B6D
	public void showAd(string zoneId = null)
	{
		this.applovinFacade.CallStatic("ShowAd", new object[]
		{
			this.currentActivity,
			zoneId
		});
	}

	// Token: 0x0600003C RID: 60 RVA: 0x00002992 File Offset: 0x00000B92
	public void showInterstitial(string placement = null)
	{
		this.applovinFacade.CallStatic("ShowInterstitial", new object[]
		{
			this.currentActivity,
			placement
		});
	}

	// Token: 0x0600003D RID: 61 RVA: 0x000029B7 File Offset: 0x00000BB7
	public void showInterstitialForZoneId(string zoneId = null)
	{
		this.applovinFacade.CallStatic("ShowInterstitialForZoneId", new object[]
		{
			this.currentActivity,
			zoneId
		});
	}

	// Token: 0x0600003E RID: 62 RVA: 0x000029DC File Offset: 0x00000BDC
	public void hideAd()
	{
		this.applovinFacade.CallStatic("HideAd", new object[]
		{
			this.currentActivity
		});
	}

	// Token: 0x0600003F RID: 63 RVA: 0x000029FD File Offset: 0x00000BFD
	public void setAdPosition(float x, float y)
	{
		this.applovinFacade.CallStatic("SetAdPosition", new object[]
		{
			this.currentActivity,
			x,
			y
		});
	}

	// Token: 0x06000040 RID: 64 RVA: 0x00002A30 File Offset: 0x00000C30
	public void setAdWidth(int width)
	{
		this.applovinFacade.CallStatic("SetAdWidth", new object[]
		{
			this.currentActivity,
			width
		});
	}

	// Token: 0x06000041 RID: 65 RVA: 0x00002A5A File Offset: 0x00000C5A
	public void setVerboseLoggingOn(string verboseLoggingOn)
	{
		this.applovinFacade.CallStatic("SetVerboseLoggingOn", new object[]
		{
			verboseLoggingOn
		});
	}

	// Token: 0x06000042 RID: 66 RVA: 0x00002A76 File Offset: 0x00000C76
	private void setMuted(string muted)
	{
		this.applovinFacade.CallStatic("SetMuted", new object[]
		{
			muted
		});
	}

	// Token: 0x06000043 RID: 67 RVA: 0x00002A94 File Offset: 0x00000C94
	private bool isMuted()
	{
		string value = this.applovinFacade.CallStatic<string>("IsMuted", new object[0]);
		return bool.Parse(value);
	}

	// Token: 0x06000044 RID: 68 RVA: 0x00002ABE File Offset: 0x00000CBE
	private void setTestAdsEnabled(string enabled)
	{
		this.applovinFacade.CallStatic("SetTestAdsEnabled", new object[]
		{
			enabled
		});
	}

	// Token: 0x06000045 RID: 69 RVA: 0x00002ADC File Offset: 0x00000CDC
	private bool isTestAdsEnabled()
	{
		string value = this.applovinFacade.CallStatic<string>("IsTestAdsEnabled", new object[0]);
		return bool.Parse(value);
	}

	// Token: 0x06000046 RID: 70 RVA: 0x00002B06 File Offset: 0x00000D06
	public void setSdkKey(string sdkKey)
	{
		this.applovinFacade.CallStatic("SetSdkKey", new object[]
		{
			this.currentActivity,
			sdkKey
		});
	}

	// Token: 0x06000047 RID: 71 RVA: 0x00002B2B File Offset: 0x00000D2B
	public void preloadInterstitial(string zoneId = null)
	{
		this.applovinFacade.CallStatic("PreloadInterstitial", new object[]
		{
			this.currentActivity,
			zoneId
		});
	}

	// Token: 0x06000048 RID: 72 RVA: 0x00002B50 File Offset: 0x00000D50
	public bool hasPreloadedInterstitial(string zoneId = null)
	{
		string value = this.applovinFacade.CallStatic<string>("IsInterstitialReady", new object[]
		{
			this.currentActivity,
			zoneId
		});
		return bool.Parse(value);
	}

	// Token: 0x06000049 RID: 73 RVA: 0x00002B88 File Offset: 0x00000D88
	public bool isInterstitialShowing()
	{
		string value = this.applovinFacade.CallStatic<string>("IsInterstitialShowing", new object[]
		{
			this.currentActivity
		});
		return bool.Parse(value);
	}

	// Token: 0x0600004A RID: 74 RVA: 0x00002BBB File Offset: 0x00000DBB
	public void setAdListener(string gameObjectToNotify)
	{
		this.applovinFacade.CallStatic("SetUnityAdListener", new object[]
		{
			gameObjectToNotify
		});
	}

	// Token: 0x0600004B RID: 75 RVA: 0x00002BD7 File Offset: 0x00000DD7
	public void setRewardedVideoUsername(string username)
	{
		this.applovinFacade.CallStatic("SetIncentivizedUsername", new object[]
		{
			this.currentActivity,
			username
		});
	}

	// Token: 0x0600004C RID: 76 RVA: 0x00002BFC File Offset: 0x00000DFC
	public void loadIncentInterstitial(string zoneId = null)
	{
		this.applovinFacade.CallStatic("LoadIncentInterstitial", new object[]
		{
			this.currentActivity,
			zoneId
		});
	}

	// Token: 0x0600004D RID: 77 RVA: 0x00002C21 File Offset: 0x00000E21
	public void showIncentInterstitial(string placement = null)
	{
		this.applovinFacade.CallStatic("ShowIncentInterstitial", new object[]
		{
			this.currentActivity,
			placement
		});
	}

	// Token: 0x0600004E RID: 78 RVA: 0x00002C46 File Offset: 0x00000E46
	public void showIncentInterstitialForZoneId(string zoneId = null)
	{
		this.applovinFacade.CallStatic("ShowIncentInterstitialForZoneId", new object[]
		{
			this.currentActivity,
			zoneId
		});
	}

	// Token: 0x0600004F RID: 79 RVA: 0x00002C6C File Offset: 0x00000E6C
	public bool isIncentInterstitialReady(string zoneId = null)
	{
		string value = this.applovinFacade.CallStatic<string>("IsIncentReady", new object[]
		{
			this.currentActivity,
			zoneId
		});
		return bool.Parse(value);
	}

	// Token: 0x06000050 RID: 80 RVA: 0x00002CA4 File Offset: 0x00000EA4
	public bool isPreloadedInterstitialVideo()
	{
		string value = this.applovinFacade.CallStatic<string>("IsCurrentInterstitialVideo", new object[]
		{
			this.currentActivity
		});
		return bool.Parse(value);
	}

	// Token: 0x06000051 RID: 81 RVA: 0x00002CD8 File Offset: 0x00000ED8
	public void trackEvent(string eventType, IDictionary<string, string> parameters)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (parameters != null)
		{
			foreach (KeyValuePair<string, string> keyValuePair in parameters)
			{
				if (keyValuePair.Key != null && keyValuePair.Value != null)
				{
					stringBuilder.Append(keyValuePair.Key);
					stringBuilder.Append('\u001d');
					stringBuilder.Append(keyValuePair.Value);
					stringBuilder.Append('\u001c');
				}
			}
		}
		this.applovinFacade.CallStatic("TrackEvent", new object[]
		{
			this.currentActivity,
			eventType,
			stringBuilder.ToString()
		});
	}

	// Token: 0x06000052 RID: 82 RVA: 0x00002DA4 File Offset: 0x00000FA4
	public void enableImmersiveMode()
	{
		this.applovinFacade.CallStatic("EnableImmersiveMode", new object[]
		{
			this.currentActivity
		});
	}

	// Token: 0x06000053 RID: 83 RVA: 0x00002DC5 File Offset: 0x00000FC5
	public static void ShowAd(string zoneId = null)
	{
		AppLovin.getDefaultPlugin().showAd(zoneId);
	}

	// Token: 0x06000054 RID: 84 RVA: 0x00002DD2 File Offset: 0x00000FD2
	public static void ShowAd(float x, float y)
	{
		AppLovin.SetAdPosition(x, y);
		AppLovin.ShowAd(null);
	}

	// Token: 0x06000055 RID: 85 RVA: 0x00002DE1 File Offset: 0x00000FE1
	public static void ShowInterstitial()
	{
		AppLovin.getDefaultPlugin().showInterstitial(null);
	}

	// Token: 0x06000056 RID: 86 RVA: 0x00002DEE File Offset: 0x00000FEE
	public static void ShowInterstitial(string placement)
	{
		AppLovin.getDefaultPlugin().showInterstitial(placement);
	}

	// Token: 0x06000057 RID: 87 RVA: 0x00002DFB File Offset: 0x00000FFB
	public static void ShowInterstitialForZoneId(string zoneId)
	{
		AppLovin.getDefaultPlugin().showInterstitialForZoneId(zoneId);
	}

	// Token: 0x06000058 RID: 88 RVA: 0x00002E08 File Offset: 0x00001008
	public static void LoadRewardedInterstitial(string zoneId = null)
	{
		AppLovin.getDefaultPlugin().loadIncentInterstitial(zoneId);
	}

	// Token: 0x06000059 RID: 89 RVA: 0x00002E15 File Offset: 0x00001015
	public static void ShowRewardedInterstitial()
	{
		AppLovin.getDefaultPlugin().showIncentInterstitial(null);
	}

	// Token: 0x0600005A RID: 90 RVA: 0x00002E22 File Offset: 0x00001022
	public static void ShowRewardedInterstitial(string placement)
	{
		AppLovin.getDefaultPlugin().showIncentInterstitial(placement);
	}

	// Token: 0x0600005B RID: 91 RVA: 0x00002E2F File Offset: 0x0000102F
	public static void ShowRewardedInterstitialForZoneId(string zoneId = null)
	{
		AppLovin.getDefaultPlugin().showIncentInterstitialForZoneId(zoneId);
	}

	// Token: 0x0600005C RID: 92 RVA: 0x00002E3C File Offset: 0x0000103C
	public static void HideAd()
	{
		AppLovin.getDefaultPlugin().hideAd();
	}

	// Token: 0x0600005D RID: 93 RVA: 0x00002E48 File Offset: 0x00001048
	public static void SetAdPosition(float x, float y)
	{
		AppLovin.getDefaultPlugin().setAdPosition(x, y);
	}

	// Token: 0x0600005E RID: 94 RVA: 0x00002E56 File Offset: 0x00001056
	public static void SetAdWidth(int width)
	{
		AppLovin.getDefaultPlugin().setAdWidth(width);
	}

	// Token: 0x0600005F RID: 95 RVA: 0x00002E63 File Offset: 0x00001063
	public static void SetSdkKey(string sdkKey)
	{
		AppLovin.getDefaultPlugin().setSdkKey(sdkKey);
	}

	// Token: 0x06000060 RID: 96 RVA: 0x00002E70 File Offset: 0x00001070
	public static void SetVerboseLoggingOn(string verboseLogging)
	{
		AppLovin.getDefaultPlugin().setVerboseLoggingOn(verboseLogging);
	}

	// Token: 0x06000061 RID: 97 RVA: 0x00002E7D File Offset: 0x0000107D
	public static void SetMuted(string muted)
	{
		AppLovin.getDefaultPlugin().setMuted(muted);
	}

	// Token: 0x06000062 RID: 98 RVA: 0x00002E8A File Offset: 0x0000108A
	public static bool IsMuted()
	{
		return AppLovin.getDefaultPlugin().isMuted();
	}

	// Token: 0x06000063 RID: 99 RVA: 0x00002E96 File Offset: 0x00001096
	public static void SetTestAdsEnabled(string enabled)
	{
		AppLovin.getDefaultPlugin().setTestAdsEnabled(enabled);
	}

	// Token: 0x06000064 RID: 100 RVA: 0x00002EA3 File Offset: 0x000010A3
	public static bool IsTestAdsEnabled()
	{
		return AppLovin.getDefaultPlugin().isTestAdsEnabled();
	}

	// Token: 0x06000065 RID: 101 RVA: 0x00002EAF File Offset: 0x000010AF
	public static void PreloadInterstitial(string zoneId = null)
	{
		AppLovin.getDefaultPlugin().preloadInterstitial(zoneId);
	}

	// Token: 0x06000066 RID: 102 RVA: 0x00002EBC File Offset: 0x000010BC
	public static bool HasPreloadedInterstitial(string zoneId = null)
	{
		return AppLovin.getDefaultPlugin().hasPreloadedInterstitial(zoneId);
	}

	// Token: 0x06000067 RID: 103 RVA: 0x00002EC9 File Offset: 0x000010C9
	public static bool IsInterstitialShowing()
	{
		return AppLovin.getDefaultPlugin().isInterstitialShowing();
	}

	// Token: 0x06000068 RID: 104 RVA: 0x00002ED5 File Offset: 0x000010D5
	public static bool IsIncentInterstitialReady(string zoneId = null)
	{
		return AppLovin.getDefaultPlugin().isIncentInterstitialReady(zoneId);
	}

	// Token: 0x06000069 RID: 105 RVA: 0x00002EE2 File Offset: 0x000010E2
	public static bool IsPreloadedInterstitialVideo()
	{
		return AppLovin.getDefaultPlugin().isPreloadedInterstitialVideo();
	}

	// Token: 0x0600006A RID: 106 RVA: 0x00002EEE File Offset: 0x000010EE
	public static void InitializeSdk()
	{
		AppLovin.getDefaultPlugin().initializeSdk();
	}

	// Token: 0x0600006B RID: 107 RVA: 0x00002EFA File Offset: 0x000010FA
	public static void SetUnityAdListener(string gameObjectToNotify)
	{
		AppLovin.getDefaultPlugin().setAdListener(gameObjectToNotify);
	}

	// Token: 0x0600006C RID: 108 RVA: 0x00002F07 File Offset: 0x00001107
	public static void SetRewardedVideoUsername(string username)
	{
		AppLovin.getDefaultPlugin().setRewardedVideoUsername(username);
	}

	// Token: 0x0600006D RID: 109 RVA: 0x00002F14 File Offset: 0x00001114
	public static void TrackEvent(string eventType, IDictionary<string, string> parameters)
	{
		AppLovin.getDefaultPlugin().trackEvent(eventType, parameters);
	}

	// Token: 0x0600006E RID: 110 RVA: 0x00002F22 File Offset: 0x00001122
	public static void EnableImmersiveMode()
	{
		AppLovin.getDefaultPlugin().enableImmersiveMode();
	}

	// Token: 0x0400002F RID: 47
	public const float AD_POSITION_CENTER = -10000f;

	// Token: 0x04000030 RID: 48
	public const float AD_POSITION_LEFT = -20000f;

	// Token: 0x04000031 RID: 49
	public const float AD_POSITION_RIGHT = -30000f;

	// Token: 0x04000032 RID: 50
	public const float AD_POSITION_TOP = -40000f;

	// Token: 0x04000033 RID: 51
	public const float AD_POSITION_BOTTOM = -50000f;

	// Token: 0x04000034 RID: 52
	private const char _InternalPrimarySeparator = '\u001c';

	// Token: 0x04000035 RID: 53
	private const char _InternalSecondarySeparator = '\u001d';

	// Token: 0x04000036 RID: 54
	public AndroidJavaClass applovinFacade = new AndroidJavaClass("com.applovin.sdk.unity.AppLovinFacade");

	// Token: 0x04000037 RID: 55
	public AndroidJavaObject currentActivity;

	// Token: 0x04000038 RID: 56
	public static AppLovin DefaultPlugin;
}
