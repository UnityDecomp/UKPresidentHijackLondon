using System;

namespace UnityEngine.Advertisements
{
	// Token: 0x02000025 RID: 37
	public static class Advertisement
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000117 RID: 279 RVA: 0x00003FE8 File Offset: 0x000021E8
		// (set) Token: 0x06000118 RID: 280 RVA: 0x00003FEF File Offset: 0x000021EF
		public static Advertisement.DebugLevel debugLevel
		{
			get
			{
				return Advertisement._debugLevel;
			}
			set
			{
				Advertisement._debugLevel = value;
				UnityAds.setLogLevel(Advertisement._debugLevel);
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000119 RID: 281 RVA: 0x00004001 File Offset: 0x00002201
		public static bool isSupported
		{
			get
			{
				return Application.isEditor || Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600011A RID: 282 RVA: 0x00004024 File Offset: 0x00002224
		public static bool isInitialized
		{
			get
			{
				return UnityAds.isInitialized;
			}
		}

		// Token: 0x0600011B RID: 283 RVA: 0x0000402B File Offset: 0x0000222B
		public static void Initialize(string appId)
		{
			Advertisement.Initialize(appId, false);
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00004034 File Offset: 0x00002234
		public static void Initialize(string appId, bool testMode)
		{
			UnityAds.SharedInstance.Init(appId, testMode);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00004042 File Offset: 0x00002242
		public static void Show()
		{
			Advertisement.Show(null, null);
		}

		// Token: 0x0600011E RID: 286 RVA: 0x0000404B File Offset: 0x0000224B
		public static void Show(string zoneId)
		{
			Advertisement.Show(zoneId, null);
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00004054 File Offset: 0x00002254
		public static void Show(string zoneId, ShowOptions options)
		{
			UnityAds.SharedInstance.Show(zoneId, options);
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000120 RID: 288 RVA: 0x00004062 File Offset: 0x00002262
		// (set) Token: 0x06000121 RID: 289 RVA: 0x00004069 File Offset: 0x00002269
		[Obsolete("Advertisement.allowPrecache is no longer supported and does nothing")]
		public static bool allowPrecache
		{
			get
			{
				return UnityAds.allowPrecache;
			}
			set
			{
				UnityAds.allowPrecache = value;
			}
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00004071 File Offset: 0x00002271
		public static bool IsReady()
		{
			return Advertisement.IsReady(null);
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00004079 File Offset: 0x00002279
		public static bool IsReady(string zoneId)
		{
			return UnityAds.canShowZone(zoneId);
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00004081 File Offset: 0x00002281
		[Obsolete("Use Advertisement.IsReady method instead")]
		public static bool isReady(string zoneId = null)
		{
			return Advertisement.IsReady(zoneId);
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000125 RID: 293 RVA: 0x00004089 File Offset: 0x00002289
		public static bool isShowing
		{
			get
			{
				return UnityAds.isShowing;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000126 RID: 294 RVA: 0x00004090 File Offset: 0x00002290
		// (set) Token: 0x06000127 RID: 295 RVA: 0x00004097 File Offset: 0x00002297
		public static bool UnityDeveloperInternalTestMode { get; set; }

		// Token: 0x04000092 RID: 146
		public static readonly string version = "1.3.6";

		// Token: 0x04000093 RID: 147
		private static Advertisement.DebugLevel _debugLevel = (!Debug.isDebugBuild) ? ((Advertisement.DebugLevel)7) : ((Advertisement.DebugLevel)15);

		// Token: 0x02000026 RID: 38
		public enum DebugLevel
		{
			// Token: 0x04000096 RID: 150
			None,
			// Token: 0x04000097 RID: 151
			Error,
			// Token: 0x04000098 RID: 152
			Warning,
			// Token: 0x04000099 RID: 153
			Info = 4,
			// Token: 0x0400009A RID: 154
			Debug = 8,
			// Token: 0x0400009B RID: 155
			[Obsolete("Use Advertisement.DebugLevel.None instead")]
			NONE = 0,
			// Token: 0x0400009C RID: 156
			[Obsolete("Use Advertisement.DebugLevel.Error instead")]
			ERROR,
			// Token: 0x0400009D RID: 157
			[Obsolete("Use Advertisement.DebugLevel.Warning instead")]
			WARNING,
			// Token: 0x0400009E RID: 158
			[Obsolete("Use Advertisement.DebugLevel.Info instead")]
			INFO = 4,
			// Token: 0x0400009F RID: 159
			[Obsolete("Use Advertisement.DebugLevel.Debug instead")]
			DEBUG = 8
		}
	}
}
