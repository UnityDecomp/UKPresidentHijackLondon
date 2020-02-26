using System;
using UnityEngine;

namespace Heyzap
{
	// Token: 0x02000011 RID: 17
	public class HeyzapAds : MonoBehaviour
	{
		// Token: 0x06000074 RID: 116 RVA: 0x00002F50 File Offset: 0x00001150
		public static void Start(string publisher_id, int options)
		{
			HeyzapAdsAndroid.Start(publisher_id, options);
			HeyzapAds.InitReceiver();
			HZInterstitialAd.InitReceiver();
			HZVideoAd.InitReceiver();
			HZIncentivizedAd.InitReceiver();
			HZBannerAd.InitReceiver();
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00002F72 File Offset: 0x00001172
		public static string GetRemoteData()
		{
			return HeyzapAdsAndroid.GetRemoteData();
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00002F79 File Offset: 0x00001179
		public static void ShowMediationTestSuite()
		{
			HeyzapAdsAndroid.ShowMediationTestSuite();
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00002F80 File Offset: 0x00001180
		public static bool OnBackPressed()
		{
			return HeyzapAdsAndroid.OnBackPressed();
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00002F87 File Offset: 0x00001187
		public static bool IsNetworkInitialized(string network)
		{
			return HeyzapAdsAndroid.IsNetworkInitialized(network);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00002F8F File Offset: 0x0000118F
		public static void SetNetworkCallbackListener(HeyzapAds.NetworkCallbackListener listener)
		{
			HeyzapAds.networkCallbackListener = listener;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00002F97 File Offset: 0x00001197
		public static void PauseExpensiveWork()
		{
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00002F99 File Offset: 0x00001199
		public static void ResumeExpensiveWork()
		{
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00002F9B File Offset: 0x0000119B
		public static void ShowDebugLogs()
		{
			HeyzapAdsAndroid.ShowDebugLogs();
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00002FA2 File Offset: 0x000011A2
		public static void HideDebugLogs()
		{
			HeyzapAdsAndroid.HideDebugLogs();
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00002FA9 File Offset: 0x000011A9
		public static void ShowThirdPartyDebugLogs()
		{
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00002FAB File Offset: 0x000011AB
		public static void HideThirdPartyDebugLogs()
		{
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00002FB0 File Offset: 0x000011B0
		public void SetNetworkCallbackMessage(string message)
		{
			string[] array = message.Split(new char[]
			{
				','
			});
			HeyzapAds.SetNetworkCallback(array[0], array[1]);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00002FDA File Offset: 0x000011DA
		protected static void SetNetworkCallback(string network, string callback)
		{
			if (HeyzapAds.networkCallbackListener != null)
			{
				HeyzapAds.networkCallbackListener(network, callback);
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00002FF4 File Offset: 0x000011F4
		public static void InitReceiver()
		{
			if (HeyzapAds._instance == null)
			{
				GameObject gameObject = new GameObject("HeyzapAds");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				HeyzapAds._instance = gameObject.AddComponent<HeyzapAds>();
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000302D File Offset: 0x0000122D
		public static string TagForString(string tag)
		{
			if (tag == null)
			{
				tag = "default";
			}
			return tag;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x0000303D File Offset: 0x0000123D
		[Obsolete("Use the Start() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void start(string publisher_id, int options)
		{
			HeyzapAds.Start(publisher_id, options);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00003046 File Offset: 0x00001246
		[Obsolete("Use the GetRemoteData() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static string getRemoteData()
		{
			return HeyzapAds.GetRemoteData();
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000304D File Offset: 0x0000124D
		[Obsolete("Use the ShowMediationTestSuite() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void showMediationTestSuite()
		{
			HeyzapAds.ShowMediationTestSuite();
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00003054 File Offset: 0x00001254
		[Obsolete("Use the IsNetworkInitialized(String) method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static bool isNetworkInitialized(string network)
		{
			return HeyzapAds.IsNetworkInitialized(network);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0000305C File Offset: 0x0000125C
		[Obsolete("Use the SetNetworkCallbackListener(NetworkCallbackListener) method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void setNetworkCallbackListener(HeyzapAds.NetworkCallbackListener listener)
		{
			HeyzapAds.SetNetworkCallbackListener(listener);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00003064 File Offset: 0x00001264
		[Obsolete("Use the PauseExpensiveWork() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void pauseExpensiveWork()
		{
			HeyzapAds.PauseExpensiveWork();
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0000306B File Offset: 0x0000126B
		[Obsolete("Use the ResumeExpensiveWork() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void resumeExpensiveWork()
		{
			HeyzapAds.ResumeExpensiveWork();
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00003072 File Offset: 0x00001272
		[Obsolete("Use the ShowDebugLogs() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void showDebugLogs()
		{
			HeyzapAds.ShowDebugLogs();
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00003079 File Offset: 0x00001279
		[Obsolete("Use the HideDebugLogs() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void hideDebugLogs()
		{
			HeyzapAds.HideDebugLogs();
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00003080 File Offset: 0x00001280
		[Obsolete("Use the OnBackPressed() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static bool onBackPressed()
		{
			return HeyzapAds.OnBackPressed();
		}

		// Token: 0x0400004E RID: 78
		private static HeyzapAds.NetworkCallbackListener networkCallbackListener;

		// Token: 0x0400004F RID: 79
		private static HeyzapAds _instance;

		// Token: 0x04000050 RID: 80
		public const int FLAG_NO_OPTIONS = 0;

		// Token: 0x04000051 RID: 81
		public const int FLAG_DISABLE_AUTOMATIC_FETCHING = 1;

		// Token: 0x04000052 RID: 82
		public const int FLAG_INSTALL_TRACKING_ONLY = 2;

		// Token: 0x04000053 RID: 83
		public const int FLAG_AMAZON = 4;

		// Token: 0x04000054 RID: 84
		public const int FLAG_DISABLE_MEDIATION = 8;

		// Token: 0x04000055 RID: 85
		public const int FLAG_DISABLE_AUTOMATIC_IAP_RECORDING = 16;

		// Token: 0x04000056 RID: 86
		public const int FLAG_NATIVE_ADS_ONLY = 32;

		// Token: 0x04000057 RID: 87
		public const int FLAG_CHILD_DIRECTED_ADS = 64;

		// Token: 0x04000058 RID: 88
		[Obsolete("Use FLAG_AMAZON instead - we refactored the flags to be consistently named.")]
		public const int AMAZON = 4;

		// Token: 0x04000059 RID: 89
		[Obsolete("Use FLAG_DISABLE_MEDIATION instead - we refactored the flags to be consistently named.")]
		public const int DISABLE_MEDIATION = 8;

		// Token: 0x0400005A RID: 90
		public const string DEFAULT_TAG = "default";

		// Token: 0x02000012 RID: 18
		// (Invoke) Token: 0x06000090 RID: 144
		public delegate void NetworkCallbackListener(string network, string callback);

		// Token: 0x02000013 RID: 19
		public static class NetworkCallback
		{
			// Token: 0x0400005B RID: 91
			public const string INITIALIZED = "initialized";

			// Token: 0x0400005C RID: 92
			public const string SHOW = "show";

			// Token: 0x0400005D RID: 93
			public const string AVAILABLE = "available";

			// Token: 0x0400005E RID: 94
			public const string HIDE = "hide";

			// Token: 0x0400005F RID: 95
			public const string FETCH_FAILED = "fetch_failed";

			// Token: 0x04000060 RID: 96
			public const string CLICK = "click";

			// Token: 0x04000061 RID: 97
			public const string DISMISS = "dismiss";

			// Token: 0x04000062 RID: 98
			public const string INCENTIVIZED_RESULT_COMPLETE = "incentivized_result_complete";

			// Token: 0x04000063 RID: 99
			public const string INCENTIVIZED_RESULT_INCOMPLETE = "incentivized_result_incomplete";

			// Token: 0x04000064 RID: 100
			public const string AUDIO_STARTING = "audio_starting";

			// Token: 0x04000065 RID: 101
			public const string AUDIO_FINISHED = "audio_finished";

			// Token: 0x04000066 RID: 102
			public const string BANNER_LOADED = "banner-loaded";

			// Token: 0x04000067 RID: 103
			public const string BANNER_CLICK = "banner-click";

			// Token: 0x04000068 RID: 104
			public const string BANNER_HIDE = "banner-hide";

			// Token: 0x04000069 RID: 105
			public const string BANNER_DISMISS = "banner-dismiss";

			// Token: 0x0400006A RID: 106
			public const string BANNER_FETCH_FAILED = "banner-fetch_failed";

			// Token: 0x0400006B RID: 107
			public const string LEAVE_APPLICATION = "leave_application";

			// Token: 0x0400006C RID: 108
			public const string FACEBOOK_LOGGING_IMPRESSION = "logging_impression";

			// Token: 0x0400006D RID: 109
			public const string CHARTBOOST_MOREAPPS_FETCH_FAILED = "moreapps-fetch_failed";

			// Token: 0x0400006E RID: 110
			public const string CHARTBOOST_MOREAPPS_HIDE = "moreapps-hide";

			// Token: 0x0400006F RID: 111
			public const string CHARTBOOST_MOREAPPS_DISMISS = "moreapps-dismiss";

			// Token: 0x04000070 RID: 112
			public const string CHARTBOOST_MOREAPPS_CLICK = "moreapps-click";

			// Token: 0x04000071 RID: 113
			public const string CHARTBOOST_MOREAPPS_SHOW = "moreapps-show";

			// Token: 0x04000072 RID: 114
			public const string CHARTBOOST_MOREAPPS_AVAILABLE = "moreapps-available";

			// Token: 0x04000073 RID: 115
			public const string CHARTBOOST_MOREAPPS_CLICK_FAILED = "moreapps-click_failed";
		}

		// Token: 0x02000014 RID: 20
		public static class Network
		{
			// Token: 0x04000074 RID: 116
			public const string HEYZAP = "heyzap";

			// Token: 0x04000075 RID: 117
			public const string HEYZAP_CROSS_PROMO = "heyzap_cross_promo";

			// Token: 0x04000076 RID: 118
			public const string HEYZAP_EXCHANGE = "heyzap_exchange";

			// Token: 0x04000077 RID: 119
			public const string FACEBOOK = "facebook";

			// Token: 0x04000078 RID: 120
			public const string UNITYADS = "unityads";

			// Token: 0x04000079 RID: 121
			public const string APPLOVIN = "applovin";

			// Token: 0x0400007A RID: 122
			public const string VUNGLE = "vungle";

			// Token: 0x0400007B RID: 123
			public const string CHARTBOOST = "chartboost";

			// Token: 0x0400007C RID: 124
			public const string ADCOLONY = "adcolony";

			// Token: 0x0400007D RID: 125
			public const string ADMOB = "admob";

			// Token: 0x0400007E RID: 126
			public const string IAD = "iad";

			// Token: 0x0400007F RID: 127
			public const string LEADBOLT = "leadbolt";

			// Token: 0x04000080 RID: 128
			public const string INMOBI = "inmobi";
		}
	}
}
