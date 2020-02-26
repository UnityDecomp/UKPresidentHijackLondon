using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

namespace ChartboostSDK
{
	// Token: 0x02000011 RID: 17
	public class Chartboost : MonoBehaviour
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600009D RID: 157 RVA: 0x00005210 File Offset: 0x00003610
		// (remove) Token: 0x0600009E RID: 158 RVA: 0x00005244 File Offset: 0x00003644
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<bool> didInitialize;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x0600009F RID: 159 RVA: 0x00005278 File Offset: 0x00003678
		// (remove) Token: 0x060000A0 RID: 160 RVA: 0x000052AC File Offset: 0x000036AC
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Func<CBLocation, bool> shouldDisplayInterstitial;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x060000A1 RID: 161 RVA: 0x000052E0 File Offset: 0x000036E0
		// (remove) Token: 0x060000A2 RID: 162 RVA: 0x00005314 File Offset: 0x00003714
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<CBLocation> didDisplayInterstitial;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x060000A3 RID: 163 RVA: 0x00005348 File Offset: 0x00003748
		// (remove) Token: 0x060000A4 RID: 164 RVA: 0x0000537C File Offset: 0x0000377C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<CBLocation> didCacheInterstitial;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x060000A5 RID: 165 RVA: 0x000053B0 File Offset: 0x000037B0
		// (remove) Token: 0x060000A6 RID: 166 RVA: 0x000053E4 File Offset: 0x000037E4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<CBLocation> didClickInterstitial;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x060000A7 RID: 167 RVA: 0x00005418 File Offset: 0x00003818
		// (remove) Token: 0x060000A8 RID: 168 RVA: 0x0000544C File Offset: 0x0000384C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<CBLocation> didCloseInterstitial;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x060000A9 RID: 169 RVA: 0x00005480 File Offset: 0x00003880
		// (remove) Token: 0x060000AA RID: 170 RVA: 0x000054B4 File Offset: 0x000038B4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<CBLocation> didDismissInterstitial;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x060000AB RID: 171 RVA: 0x000054E8 File Offset: 0x000038E8
		// (remove) Token: 0x060000AC RID: 172 RVA: 0x0000551C File Offset: 0x0000391C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<CBLocation, CBImpressionError> didFailToLoadInterstitial;

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x060000AD RID: 173 RVA: 0x00005550 File Offset: 0x00003950
		// (remove) Token: 0x060000AE RID: 174 RVA: 0x00005584 File Offset: 0x00003984
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<CBLocation, CBClickError> didFailToRecordClick;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x060000AF RID: 175 RVA: 0x000055B8 File Offset: 0x000039B8
		// (remove) Token: 0x060000B0 RID: 176 RVA: 0x000055EC File Offset: 0x000039EC
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Func<CBLocation, bool> shouldDisplayMoreApps;

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x060000B1 RID: 177 RVA: 0x00005620 File Offset: 0x00003A20
		// (remove) Token: 0x060000B2 RID: 178 RVA: 0x00005654 File Offset: 0x00003A54
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<CBLocation> didDisplayMoreApps;

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x060000B3 RID: 179 RVA: 0x00005688 File Offset: 0x00003A88
		// (remove) Token: 0x060000B4 RID: 180 RVA: 0x000056BC File Offset: 0x00003ABC
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<CBLocation> didCacheMoreApps;

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x060000B5 RID: 181 RVA: 0x000056F0 File Offset: 0x00003AF0
		// (remove) Token: 0x060000B6 RID: 182 RVA: 0x00005724 File Offset: 0x00003B24
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<CBLocation> didClickMoreApps;

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x060000B7 RID: 183 RVA: 0x00005758 File Offset: 0x00003B58
		// (remove) Token: 0x060000B8 RID: 184 RVA: 0x0000578C File Offset: 0x00003B8C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<CBLocation> didCloseMoreApps;

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x060000B9 RID: 185 RVA: 0x000057C0 File Offset: 0x00003BC0
		// (remove) Token: 0x060000BA RID: 186 RVA: 0x000057F4 File Offset: 0x00003BF4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<CBLocation> didDismissMoreApps;

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x060000BB RID: 187 RVA: 0x00005828 File Offset: 0x00003C28
		// (remove) Token: 0x060000BC RID: 188 RVA: 0x0000585C File Offset: 0x00003C5C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<CBLocation, CBImpressionError> didFailToLoadMoreApps;

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x060000BD RID: 189 RVA: 0x00005890 File Offset: 0x00003C90
		// (remove) Token: 0x060000BE RID: 190 RVA: 0x000058C4 File Offset: 0x00003CC4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Func<CBLocation, bool> shouldDisplayRewardedVideo;

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x060000BF RID: 191 RVA: 0x000058F8 File Offset: 0x00003CF8
		// (remove) Token: 0x060000C0 RID: 192 RVA: 0x0000592C File Offset: 0x00003D2C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<CBLocation> didDisplayRewardedVideo;

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x060000C1 RID: 193 RVA: 0x00005960 File Offset: 0x00003D60
		// (remove) Token: 0x060000C2 RID: 194 RVA: 0x00005994 File Offset: 0x00003D94
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<CBLocation> didCacheRewardedVideo;

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x060000C3 RID: 195 RVA: 0x000059C8 File Offset: 0x00003DC8
		// (remove) Token: 0x060000C4 RID: 196 RVA: 0x000059FC File Offset: 0x00003DFC
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<CBLocation> didClickRewardedVideo;

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x060000C5 RID: 197 RVA: 0x00005A30 File Offset: 0x00003E30
		// (remove) Token: 0x060000C6 RID: 198 RVA: 0x00005A64 File Offset: 0x00003E64
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<CBLocation> didCloseRewardedVideo;

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x060000C7 RID: 199 RVA: 0x00005A98 File Offset: 0x00003E98
		// (remove) Token: 0x060000C8 RID: 200 RVA: 0x00005ACC File Offset: 0x00003ECC
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<CBLocation> didDismissRewardedVideo;

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x060000C9 RID: 201 RVA: 0x00005B00 File Offset: 0x00003F00
		// (remove) Token: 0x060000CA RID: 202 RVA: 0x00005B34 File Offset: 0x00003F34
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<CBLocation, int> didCompleteRewardedVideo;

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x060000CB RID: 203 RVA: 0x00005B68 File Offset: 0x00003F68
		// (remove) Token: 0x060000CC RID: 204 RVA: 0x00005B9C File Offset: 0x00003F9C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<CBLocation, CBImpressionError> didFailToLoadRewardedVideo;

		// Token: 0x14000019 RID: 25
		// (add) Token: 0x060000CD RID: 205 RVA: 0x00005BD0 File Offset: 0x00003FD0
		// (remove) Token: 0x060000CE RID: 206 RVA: 0x00005C04 File Offset: 0x00004004
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<CBLocation> didCacheInPlay;

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x060000CF RID: 207 RVA: 0x00005C38 File Offset: 0x00004038
		// (remove) Token: 0x060000D0 RID: 208 RVA: 0x00005C6C File Offset: 0x0000406C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<CBLocation, CBImpressionError> didFailToLoadInPlay;

		// Token: 0x1400001B RID: 27
		// (add) Token: 0x060000D1 RID: 209 RVA: 0x00005CA0 File Offset: 0x000040A0
		// (remove) Token: 0x060000D2 RID: 210 RVA: 0x00005CD4 File Offset: 0x000040D4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<CBLocation> willDisplayVideo;

		// Token: 0x1400001C RID: 28
		// (add) Token: 0x060000D3 RID: 211 RVA: 0x00005D08 File Offset: 0x00004108
		// (remove) Token: 0x060000D4 RID: 212 RVA: 0x00005D3C File Offset: 0x0000413C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action didPauseClickForConfirmation;

		// Token: 0x060000D5 RID: 213 RVA: 0x00005D70 File Offset: 0x00004170
		public static bool isInitialized()
		{
			return CBExternal.isInitialized();
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00005D77 File Offset: 0x00004177
		public static bool isAnyViewVisible()
		{
			return CBExternal.isAnyViewVisible();
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00005D7E File Offset: 0x0000417E
		public static void cacheInterstitial(CBLocation location)
		{
			CBExternal.cacheInterstitial(location);
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00005D86 File Offset: 0x00004186
		public static bool hasInterstitial(CBLocation location)
		{
			return CBExternal.hasInterstitial(location);
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00005D8E File Offset: 0x0000418E
		public static void showInterstitial(CBLocation location)
		{
			CBExternal.showInterstitial(location);
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00005D96 File Offset: 0x00004196
		public static void cacheMoreApps(CBLocation location)
		{
			CBExternal.cacheMoreApps(location);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00005D9E File Offset: 0x0000419E
		public static bool hasMoreApps(CBLocation location)
		{
			return CBExternal.hasMoreApps(location);
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00005DA6 File Offset: 0x000041A6
		public static void showMoreApps(CBLocation location)
		{
			CBExternal.showMoreApps(location);
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00005DAE File Offset: 0x000041AE
		public static void cacheRewardedVideo(CBLocation location)
		{
			CBExternal.cacheRewardedVideo(location);
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00005DB6 File Offset: 0x000041B6
		public static bool hasRewardedVideo(CBLocation location)
		{
			return CBExternal.hasRewardedVideo(location);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00005DBE File Offset: 0x000041BE
		public static void showRewardedVideo(CBLocation location)
		{
			CBExternal.showRewardedVideo(location);
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00005DC6 File Offset: 0x000041C6
		public static void cacheInPlay(CBLocation location)
		{
			CBExternal.cacheInPlay(location);
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00005DCE File Offset: 0x000041CE
		public static bool hasInPlay(CBLocation location)
		{
			return CBExternal.hasInPlay(location);
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00005DD6 File Offset: 0x000041D6
		public static CBInPlay getInPlay(CBLocation location)
		{
			return CBExternal.getInPlay(location);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00005DDE File Offset: 0x000041DE
		public static void didPassAgeGate(bool pass)
		{
			if (Chartboost.showingAgeGate)
			{
				Chartboost.doShowAgeGate(false);
				CBExternal.didPassAgeGate(pass);
			}
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00005DF6 File Offset: 0x000041F6
		[Obsolete("Age Gate is only available in iOS")]
		public static void setShouldPauseClickForConfirmation(bool shouldPause)
		{
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00005DF8 File Offset: 0x000041F8
		public static string getCustomId()
		{
			return CBExternal.getCustomId();
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00005DFF File Offset: 0x000041FF
		public static void setCustomId(string customId)
		{
			CBExternal.setCustomId(customId);
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00005E07 File Offset: 0x00004207
		public static bool getAutoCacheAds()
		{
			return CBExternal.getAutoCacheAds();
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00005E0E File Offset: 0x0000420E
		public static void setAutoCacheAds(bool autoCacheAds)
		{
			CBExternal.setAutoCacheAds(autoCacheAds);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00005E16 File Offset: 0x00004216
		public static void setShouldRequestInterstitialsInFirstSession(bool shouldRequest)
		{
			CBExternal.setShouldRequestInterstitialsInFirstSession(shouldRequest);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00005E1E File Offset: 0x0000421E
		public static void setShouldDisplayLoadingViewForMoreApps(bool shouldDisplay)
		{
			CBExternal.setShouldDisplayLoadingViewForMoreApps(shouldDisplay);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00005E26 File Offset: 0x00004226
		public static void setShouldPrefetchVideoContent(bool shouldPrefetch)
		{
			CBExternal.setShouldPrefetchVideoContent(shouldPrefetch);
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00005E2E File Offset: 0x0000422E
		public static void trackLevelInfo(string eventLabel, CBLevelType type, int mainLevel, int subLevel, string description)
		{
			CBExternal.trackLevelInfo(eventLabel, type, mainLevel, subLevel, description);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00005E3B File Offset: 0x0000423B
		public static void trackLevelInfo(string eventLabel, CBLevelType type, int mainLevel, string description)
		{
			CBExternal.trackLevelInfo(eventLabel, type, mainLevel, description);
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00005E46 File Offset: 0x00004246
		public static void trackInAppGooglePlayPurchaseEvent(string title, string description, string price, string currency, string productID, string purchaseData, string purchaseSignature)
		{
			CBExternal.trackInAppGooglePlayPurchaseEvent(title, description, price, currency, productID, purchaseData, purchaseSignature);
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00005E57 File Offset: 0x00004257
		public static void trackInAppAmazonStorePurchaseEvent(string title, string description, string price, string currency, string productID, string userID, string purchaseToken)
		{
			CBExternal.trackInAppAmazonStorePurchaseEvent(title, description, price, currency, productID, userID, purchaseToken);
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00005E68 File Offset: 0x00004268
		public static void setMediation(CBMediation mediator, string version)
		{
			CBExternal.setMediation(mediator, version);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00005E74 File Offset: 0x00004274
		public static Chartboost Create()
		{
			if (Chartboost.instance == null)
			{
				GameObject gameObject = new GameObject("Chartboost");
				Chartboost.instance = gameObject.AddComponent<Chartboost>();
			}
			else
			{
				UnityEngine.Debug.LogWarning("CHARTBOOST: Chartboost instance already exists. Create() ignored");
			}
			return Chartboost.instance;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00005EBB File Offset: 0x000042BB
		public static Chartboost CreateWithAppId(string appId, string appSignature)
		{
			CBSettings.setAppId(appId, appSignature);
			return Chartboost.Create();
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00005ECC File Offset: 0x000042CC
		private void Awake()
		{
			if (Chartboost.instance == null)
			{
				Chartboost.instance = this;
				CBExternal.init();
				CBExternal.setGameObjectName(base.gameObject.name);
				UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
				Chartboost.showingAgeGate = false;
			}
			else
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00005F25 File Offset: 0x00004325
		private void OnDestroy()
		{
			if (this == Chartboost.instance)
			{
				Chartboost.instance = null;
				CBExternal.destroy();
			}
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00005F42 File Offset: 0x00004342
		private void Update()
		{
			if (Input.GetKeyUp(KeyCode.Escape) && CBExternal.onBackPressed())
			{
				return;
			}
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00005F5B File Offset: 0x0000435B
		private void OnApplicationPause(bool paused)
		{
			CBExternal.pause(paused);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00005F63 File Offset: 0x00004363
		private void OnDisable()
		{
			if (this == Chartboost.instance)
			{
				Chartboost.instance = null;
				CBExternal.destroy();
			}
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00005F80 File Offset: 0x00004380
		private static CBImpressionError impressionErrorFromInt(object errorObj)
		{
			bool flag = Application.platform == RuntimePlatform.IPhonePlayer;
			int num;
			try
			{
				num = Convert.ToInt32(errorObj);
			}
			catch
			{
				num = -1;
			}
			int num2 = 10;
			if (!flag)
			{
				num2 = 18;
			}
			if (num < 0 || num > num2)
			{
				return CBImpressionError.Internal;
			}
			if (flag && num == 8)
			{
				return CBImpressionError.UserCancellation;
			}
			if (flag && num == 9)
			{
				return CBImpressionError.InvalidLocation;
			}
			if (flag && num == 10)
			{
				return CBImpressionError.PrefetchingIncomplete;
			}
			return (CBImpressionError)num;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x0000600C File Offset: 0x0000440C
		private static CBClickError clickErrorFromInt(object errorObj)
		{
			int num;
			try
			{
				num = Convert.ToInt32(errorObj);
			}
			catch
			{
				num = -1;
			}
			int num2 = 3;
			if (num < 0 || num > num2)
			{
				return CBClickError.Internal;
			}
			return (CBClickError)num;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00006050 File Offset: 0x00004450
		private void didInitializeEvent(string data)
		{
			if (Chartboost.didInitialize != null)
			{
				Chartboost.didInitialize(Convert.ToBoolean(data));
			}
		}

		// Token: 0x060000FB RID: 251 RVA: 0x0000606C File Offset: 0x0000446C
		private void didFailToLoadInterstitialEvent(string dataString)
		{
			Hashtable hashtable = (Hashtable)CBJSON.Deserialize(dataString);
			CBImpressionError arg = Chartboost.impressionErrorFromInt(hashtable["errorCode"]);
			if (Chartboost.didFailToLoadInterstitial != null)
			{
				Chartboost.didFailToLoadInterstitial(CBLocation.locationFromName(hashtable["location"] as string), arg);
			}
		}

		// Token: 0x060000FC RID: 252 RVA: 0x000060C0 File Offset: 0x000044C0
		private void didDismissInterstitialEvent(string location)
		{
			Chartboost.doUnityPause(false, false);
			if (CBExternal.isWebViewEnabled())
			{
				Screen.orientation = ScreenOrientation.AutoRotation;
			}
			if (Chartboost.didDismissInterstitial != null)
			{
				Chartboost.didDismissInterstitial(CBLocation.locationFromName(location));
			}
		}

		// Token: 0x060000FD RID: 253 RVA: 0x000060F3 File Offset: 0x000044F3
		private void didClickInterstitialEvent(string location)
		{
			if (Chartboost.didClickInterstitial != null)
			{
				Chartboost.didClickInterstitial(CBLocation.locationFromName(location));
			}
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0000610F File Offset: 0x0000450F
		private void didCloseInterstitialEvent(string location)
		{
			if (Chartboost.didCloseInterstitial != null)
			{
				Chartboost.didCloseInterstitial(CBLocation.locationFromName(location));
			}
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0000612B File Offset: 0x0000452B
		private void didCacheInterstitialEvent(string location)
		{
			if (Chartboost.didCacheInterstitial != null)
			{
				Chartboost.didCacheInterstitial(CBLocation.locationFromName(location));
			}
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00006148 File Offset: 0x00004548
		private void shouldDisplayInterstitialEvent(string location)
		{
			bool flag = true;
			if (Chartboost.shouldDisplayInterstitial != null)
			{
				flag = Chartboost.shouldDisplayInterstitial(CBLocation.locationFromName(location));
			}
			CBExternal.chartBoostShouldDisplayInterstitialCallbackResult(flag);
			if (flag)
			{
				Chartboost.showInterstitial(CBLocation.locationFromName(location));
			}
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00006189 File Offset: 0x00004589
		public void didDisplayInterstitialEvent(string location)
		{
			Chartboost.doUnityPause(true, true);
			if (CBExternal.isWebViewEnabled())
			{
				Screen.orientation = Screen.orientation;
			}
			if (Chartboost.didDisplayInterstitial != null)
			{
				Chartboost.didDisplayInterstitial(CBLocation.locationFromName(location));
			}
		}

		// Token: 0x06000102 RID: 258 RVA: 0x000061C0 File Offset: 0x000045C0
		private void didFailToLoadMoreAppsEvent(string dataString)
		{
			Hashtable hashtable = (Hashtable)CBJSON.Deserialize(dataString);
			CBImpressionError arg = Chartboost.impressionErrorFromInt(hashtable["errorCode"]);
			if (Chartboost.didFailToLoadMoreApps != null)
			{
				Chartboost.didFailToLoadMoreApps(CBLocation.locationFromName(hashtable["location"] as string), arg);
			}
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00006214 File Offset: 0x00004614
		private void didDismissMoreAppsEvent(string location)
		{
			Chartboost.doUnityPause(false, false);
			if (Chartboost.didDismissMoreApps != null)
			{
				Chartboost.didDismissMoreApps(CBLocation.locationFromName(location));
			}
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00006237 File Offset: 0x00004637
		private void didClickMoreAppsEvent(string location)
		{
			if (Chartboost.didClickMoreApps != null)
			{
				Chartboost.didClickMoreApps(CBLocation.locationFromName(location));
			}
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00006253 File Offset: 0x00004653
		private void didCloseMoreAppsEvent(string location)
		{
			if (Chartboost.didCloseMoreApps != null)
			{
				Chartboost.didCloseMoreApps(CBLocation.locationFromName(location));
			}
		}

		// Token: 0x06000106 RID: 262 RVA: 0x0000626F File Offset: 0x0000466F
		private void didCacheMoreAppsEvent(string location)
		{
			if (Chartboost.didCacheMoreApps != null)
			{
				Chartboost.didCacheMoreApps(CBLocation.locationFromName(location));
			}
		}

		// Token: 0x06000107 RID: 263 RVA: 0x0000628C File Offset: 0x0000468C
		private void shouldDisplayMoreAppsEvent(string location)
		{
			bool flag = true;
			if (Chartboost.shouldDisplayMoreApps != null)
			{
				flag = Chartboost.shouldDisplayMoreApps(CBLocation.locationFromName(location));
			}
			CBExternal.chartBoostShouldDisplayMoreAppsCallbackResult(flag);
			if (flag)
			{
				Chartboost.showMoreApps(CBLocation.locationFromName(location));
			}
		}

		// Token: 0x06000108 RID: 264 RVA: 0x000062CD File Offset: 0x000046CD
		private void didDisplayMoreAppsEvent(string location)
		{
			Chartboost.doUnityPause(true, true);
			if (Chartboost.didDisplayMoreApps != null)
			{
				Chartboost.didDisplayMoreApps(CBLocation.locationFromName(location));
			}
		}

		// Token: 0x06000109 RID: 265 RVA: 0x000062F0 File Offset: 0x000046F0
		private void didFailToRecordClickEvent(string dataString)
		{
			Hashtable hashtable = (Hashtable)CBJSON.Deserialize(dataString);
			CBClickError arg = Chartboost.clickErrorFromInt(hashtable["errorCode"]);
			if (Chartboost.didFailToRecordClick != null)
			{
				Chartboost.didFailToRecordClick(CBLocation.locationFromName(hashtable["location"] as string), arg);
			}
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00006344 File Offset: 0x00004744
		private void didFailToLoadRewardedVideoEvent(string dataString)
		{
			Hashtable hashtable = (Hashtable)CBJSON.Deserialize(dataString);
			CBImpressionError arg = Chartboost.impressionErrorFromInt(hashtable["errorCode"]);
			if (Chartboost.didFailToLoadRewardedVideo != null)
			{
				Chartboost.didFailToLoadRewardedVideo(CBLocation.locationFromName(hashtable["location"] as string), arg);
			}
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00006398 File Offset: 0x00004798
		private void didDismissRewardedVideoEvent(string location)
		{
			Chartboost.doUnityPause(false, false);
			if (CBExternal.isWebViewEnabled())
			{
				Screen.orientation = ScreenOrientation.AutoRotation;
			}
			if (Chartboost.didDismissRewardedVideo != null)
			{
				Chartboost.didDismissRewardedVideo(CBLocation.locationFromName(location));
			}
		}

		// Token: 0x0600010C RID: 268 RVA: 0x000063CB File Offset: 0x000047CB
		private void didClickRewardedVideoEvent(string location)
		{
			if (Chartboost.didClickRewardedVideo != null)
			{
				Chartboost.didClickRewardedVideo(CBLocation.locationFromName(location));
			}
		}

		// Token: 0x0600010D RID: 269 RVA: 0x000063E7 File Offset: 0x000047E7
		private void didCloseRewardedVideoEvent(string location)
		{
			if (Chartboost.didCloseRewardedVideo != null)
			{
				Chartboost.didCloseRewardedVideo(CBLocation.locationFromName(location));
			}
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00006403 File Offset: 0x00004803
		private void didCacheRewardedVideoEvent(string location)
		{
			if (Chartboost.didCacheRewardedVideo != null)
			{
				Chartboost.didCacheRewardedVideo(CBLocation.locationFromName(location));
			}
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00006420 File Offset: 0x00004820
		private void shouldDisplayRewardedVideoEvent(string location)
		{
			bool flag = true;
			if (Chartboost.shouldDisplayRewardedVideo != null)
			{
				flag = Chartboost.shouldDisplayRewardedVideo(CBLocation.locationFromName(location));
			}
			CBExternal.chartBoostShouldDisplayRewardedVideoCallbackResult(flag);
			if (flag)
			{
				Chartboost.showRewardedVideo(CBLocation.locationFromName(location));
			}
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00006464 File Offset: 0x00004864
		private void didCompleteRewardedVideoEvent(string dataString)
		{
			Hashtable hashtable = (Hashtable)CBJSON.Deserialize(dataString);
			int arg;
			try
			{
				arg = Convert.ToInt32(hashtable["reward"]);
			}
			catch
			{
				arg = 0;
			}
			if (Chartboost.didCompleteRewardedVideo != null)
			{
				Chartboost.didCompleteRewardedVideo(CBLocation.locationFromName(hashtable["location"] as string), arg);
			}
		}

		// Token: 0x06000111 RID: 273 RVA: 0x000064D8 File Offset: 0x000048D8
		private void didDisplayRewardedVideoEvent(string location)
		{
			Chartboost.doUnityPause(true, true);
			if (CBExternal.isWebViewEnabled())
			{
				Screen.orientation = Screen.orientation;
			}
			if (Chartboost.didDisplayRewardedVideo != null)
			{
				Chartboost.didDisplayRewardedVideo(CBLocation.locationFromName(location));
			}
		}

		// Token: 0x06000112 RID: 274 RVA: 0x0000650F File Offset: 0x0000490F
		private void didCacheInPlayEvent(string location)
		{
			if (Chartboost.didCacheInPlay != null)
			{
				Chartboost.didCacheInPlay(CBLocation.locationFromName(location));
			}
		}

		// Token: 0x06000113 RID: 275 RVA: 0x0000652C File Offset: 0x0000492C
		private void didFailToLoadInPlayEvent(string dataString)
		{
			Hashtable hashtable = (Hashtable)CBJSON.Deserialize(dataString);
			CBImpressionError arg = Chartboost.impressionErrorFromInt(hashtable["errorCode"]);
			if (Chartboost.didFailToLoadInPlay != null)
			{
				Chartboost.didFailToLoadInPlay(CBLocation.locationFromName(hashtable["location"] as string), arg);
			}
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00006580 File Offset: 0x00004980
		private void didPauseClickForConfirmationEvent()
		{
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00006582 File Offset: 0x00004982
		private void willDisplayVideoEvent(string location)
		{
			if (Chartboost.willDisplayVideo != null)
			{
				Chartboost.willDisplayVideo(CBLocation.locationFromName(location));
			}
		}

		// Token: 0x06000116 RID: 278 RVA: 0x000065A0 File Offset: 0x000049A0
		private static void doUnityPause(bool pause, bool setShouldPause)
		{
			Chartboost.shouldPause = setShouldPause;
			if (pause && !Chartboost.isPaused)
			{
				Chartboost.lastTimeScale = Time.timeScale;
				Time.timeScale = 0f;
				Chartboost.isPaused = true;
				Chartboost.disableUI(true);
			}
			else if (!pause && Chartboost.isPaused)
			{
				Time.timeScale = Chartboost.lastTimeScale;
				Chartboost.isPaused = false;
				Chartboost.disableUI(false);
			}
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0000660E File Offset: 0x00004A0E
		private static void doShowAgeGate(bool visible)
		{
			if (Chartboost.shouldPause)
			{
				Chartboost.doUnityPause(!visible, true);
			}
			Chartboost.showingAgeGate = visible;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0000662A File Offset: 0x00004A2A
		private static void disableUI(bool pause)
		{
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0000662C File Offset: 0x00004A2C
		public static bool isImpressionVisible()
		{
			return Chartboost.isPaused;
		}

		// Token: 0x040000B3 RID: 179
		private static bool showingAgeGate;

		// Token: 0x040000B4 RID: 180
		private static Chartboost instance;

		// Token: 0x040000B5 RID: 181
		private static bool isPaused;

		// Token: 0x040000B6 RID: 182
		private static bool shouldPause;

		// Token: 0x040000B7 RID: 183
		private static float lastTimeScale;
	}
}
