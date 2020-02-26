using System;
using System.Collections.Generic;
using System.Net;
using UnityEngine.Advertisements.Optional;

namespace UnityEngine.Advertisements
{
	// Token: 0x0200002E RID: 46
	internal class UnityAds : MonoBehaviour
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600014F RID: 335 RVA: 0x00004CB8 File Offset: 0x00002EB8
		public static UnityAds SharedInstance
		{
			get
			{
				if (!UnityAds.sharedInstance)
				{
					UnityAds.sharedInstance = (UnityAds)Object.FindObjectOfType(typeof(UnityAds));
				}
				if (!UnityAds.sharedInstance)
				{
					GameObject gameObject = new GameObject
					{
						hideFlags = (HideFlags.HideInHierarchy | HideFlags.HideInInspector)
					};
					UnityAds.sharedInstance = gameObject.AddComponent<UnityAds>();
					gameObject.name = "UnityAdsPluginBridgeObject";
					Object.DontDestroyOnLoad(gameObject);
				}
				return UnityAds.sharedInstance;
			}
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00004D2C File Offset: 0x00002F2C
		public void Init(string gameId, bool testModeEnabled)
		{
			if (UnityAds.initCalled)
			{
				return;
			}
			UnityAds.initCalled = true;
			try
			{
				if (Application.internetReachability == NetworkReachability.NotReachable)
				{
					Utils.LogError("Internet not reachable, can't initialize ads");
					return;
				}
				IPHostEntry hostEntry = Dns.GetHostEntry("impact.applifier.com");
				if (hostEntry.AddressList.Length == 1 && hostEntry.AddressList[0].Equals(new IPAddress(new byte[]
				{
					127,
					0,
					0,
					1
				})))
				{
					Utils.LogError("Video ad server resolves to localhost (due to ad blocker?), can't initialize ads");
					return;
				}
			}
			catch (Exception ex)
			{
				Utils.LogDebug("Exception during connectivity check: " + ex.Message);
			}
			UnityAdsExternal.init(gameId, testModeEnabled, UnityAds.SharedInstance.gameObject.name, UnityAds._versionString);
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00004DFC File Offset: 0x00002FFC
		public void Awake()
		{
			if (base.gameObject == UnityAds.SharedInstance.gameObject)
			{
				Object.DontDestroyOnLoad(base.gameObject);
			}
			else
			{
				Object.Destroy(base.gameObject);
			}
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00004E33 File Offset: 0x00003033
		public static bool isSupported()
		{
			return UnityAdsExternal.isSupported();
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00004E3A File Offset: 0x0000303A
		public static string getSDKVersion()
		{
			return UnityAdsExternal.getSDKVersion();
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00004E41 File Offset: 0x00003041
		public static void setLogLevel(Advertisement.DebugLevel logLevel)
		{
			UnityAdsExternal.setLogLevel(logLevel);
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00004E49 File Offset: 0x00003049
		public static bool canShowZone(string zone)
		{
			return UnityAds.isInitialized && !UnityAds.isShowing && UnityAdsExternal.canShowZone(zone);
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00004E67 File Offset: 0x00003067
		public static bool hasMultipleRewardItems()
		{
			return UnityAdsExternal.hasMultipleRewardItems();
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00004E70 File Offset: 0x00003070
		public static List<string> getRewardItemKeys()
		{
			List<string> list = new List<string>();
			string rewardItemKeys = UnityAdsExternal.getRewardItemKeys();
			return new List<string>(rewardItemKeys.Split(new char[]
			{
				';'
			}));
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00004EA1 File Offset: 0x000030A1
		public static string getDefaultRewardItemKey()
		{
			return UnityAdsExternal.getDefaultRewardItemKey();
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00004EA8 File Offset: 0x000030A8
		public static string getCurrentRewardItemKey()
		{
			return UnityAdsExternal.getCurrentRewardItemKey();
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00004EAF File Offset: 0x000030AF
		public static bool setRewardItemKey(string rewardItemKey)
		{
			return UnityAdsExternal.setRewardItemKey(rewardItemKey);
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00004EB7 File Offset: 0x000030B7
		public static void setDefaultRewardItemAsRewardItem()
		{
			UnityAdsExternal.setDefaultRewardItemAsRewardItem();
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00004EBE File Offset: 0x000030BE
		public static string getRewardItemNameKey()
		{
			if (UnityAds._rewardItemNameKey == null || UnityAds._rewardItemNameKey.Length == 0)
			{
				UnityAds.fillRewardItemKeyData();
			}
			return UnityAds._rewardItemNameKey;
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00004EE3 File Offset: 0x000030E3
		public static string getRewardItemPictureKey()
		{
			if (UnityAds._rewardItemPictureKey == null || UnityAds._rewardItemPictureKey.Length == 0)
			{
				UnityAds.fillRewardItemKeyData();
			}
			return UnityAds._rewardItemPictureKey;
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00004F08 File Offset: 0x00003108
		public static Dictionary<string, string> getRewardItemDetailsWithKey(string rewardItemKey)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string text = string.Empty;
			text = UnityAdsExternal.getRewardItemDetailsWithKey(rewardItemKey);
			if (text != null)
			{
				List<string> list = new List<string>(text.Split(new char[]
				{
					';'
				}));
				Utils.LogDebug("UnityAndroid: getRewardItemDetailsWithKey() rewardItemDataString=" + text);
				if (list.Count == 2)
				{
					dictionary.Add(UnityAds.getRewardItemNameKey(), list.ToArray().GetValue(0).ToString());
					dictionary.Add(UnityAds.getRewardItemPictureKey(), list.ToArray().GetValue(1).ToString());
				}
			}
			return dictionary;
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00004F9C File Offset: 0x0000319C
		public void Show(string zoneId = null, ShowOptions options = null)
		{
			string text = null;
			UnityAds._resultDelivered = false;
			if (options != null)
			{
				if (options.resultCallback != null)
				{
					UnityAds.resultCallback = options.resultCallback;
				}
				ShowOptionsExtended showOptionsExtended = options as ShowOptionsExtended;
				if (showOptionsExtended != null && showOptionsExtended.gamerSid != null && showOptionsExtended.gamerSid.Length > 0)
				{
					text = showOptionsExtended.gamerSid;
				}
				else
				{
					text = options.gamerSid;
				}
			}
			if (!UnityAds.isInitialized || UnityAds.isShowing)
			{
				UnityAds.deliverCallback(ShowResult.Failed);
				return;
			}
			if (text != null)
			{
				if (!UnityAds.show(zoneId, string.Empty, new Dictionary<string, string>
				{
					{
						"sid",
						text
					}
				}))
				{
					UnityAds.deliverCallback(ShowResult.Failed);
				}
			}
			else if (!UnityAds.show(zoneId))
			{
				UnityAds.deliverCallback(ShowResult.Failed);
			}
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00005069 File Offset: 0x00003269
		public static bool show(string zoneId = null)
		{
			return UnityAds.show(zoneId, string.Empty, null);
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00005077 File Offset: 0x00003277
		public static bool show(string zoneId, string rewardItemKey)
		{
			return UnityAds.show(zoneId, rewardItemKey, null);
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00005084 File Offset: 0x00003284
		public static bool show(string zoneId, string rewardItemKey, Dictionary<string, string> options)
		{
			if (!UnityAds.isShowing)
			{
				UnityAds.isShowing = true;
				if (UnityAds.SharedInstance)
				{
					string options2 = UnityAds.parseOptionsDictionary(options);
					if (UnityAdsExternal.show(zoneId, rewardItemKey, options2))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06000163 RID: 355 RVA: 0x000050C7 File Offset: 0x000032C7
		private static void deliverCallback(ShowResult result)
		{
			UnityAds.isShowing = false;
			if (UnityAds.resultCallback != null && !UnityAds._resultDelivered)
			{
				UnityAds._resultDelivered = true;
				UnityAds.resultCallback(result);
				UnityAds.resultCallback = null;
			}
		}

		// Token: 0x06000164 RID: 356 RVA: 0x000050FA File Offset: 0x000032FA
		public static void hide()
		{
			if (UnityAds.isShowing)
			{
				UnityAdsExternal.hide();
			}
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0000510C File Offset: 0x0000330C
		private static void fillRewardItemKeyData()
		{
			string rewardItemDetailsKeys = UnityAdsExternal.getRewardItemDetailsKeys();
			if (rewardItemDetailsKeys != null && rewardItemDetailsKeys.Length > 2)
			{
				List<string> list = new List<string>(rewardItemDetailsKeys.Split(new char[]
				{
					';'
				}));
				UnityAds._rewardItemNameKey = list.ToArray().GetValue(0).ToString();
				UnityAds._rewardItemPictureKey = list.ToArray().GetValue(1).ToString();
			}
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00005174 File Offset: 0x00003374
		private static string parseOptionsDictionary(Dictionary<string, string> options)
		{
			string text = string.Empty;
			if (options != null)
			{
				bool flag = false;
				if (options.ContainsKey("noOfferScreen"))
				{
					text = text + ((!flag) ? string.Empty : ",") + "noOfferScreen:" + options["noOfferScreen"];
					flag = true;
				}
				if (options.ContainsKey("openAnimated"))
				{
					text = text + ((!flag) ? string.Empty : ",") + "openAnimated:" + options["openAnimated"];
					flag = true;
				}
				if (options.ContainsKey("sid"))
				{
					text = text + ((!flag) ? string.Empty : ",") + "sid:" + options["sid"];
					flag = true;
				}
				if (options.ContainsKey("muteVideoSounds"))
				{
					text = text + ((!flag) ? string.Empty : ",") + "muteVideoSounds:" + options["muteVideoSounds"];
					flag = true;
				}
				if (options.ContainsKey("useDeviceOrientationForVideo"))
				{
					text = text + ((!flag) ? string.Empty : ",") + "useDeviceOrientationForVideo:" + options["useDeviceOrientationForVideo"];
				}
			}
			return text;
		}

		// Token: 0x06000167 RID: 359 RVA: 0x000052C6 File Offset: 0x000034C6
		public void onHide()
		{
			UnityAds.isShowing = false;
			UnityAds.deliverCallback(ShowResult.Skipped);
			Utils.LogDebug("onHide");
		}

		// Token: 0x06000168 RID: 360 RVA: 0x000052DE File Offset: 0x000034DE
		public void onShow()
		{
			Utils.LogDebug("onShow");
		}

		// Token: 0x06000169 RID: 361 RVA: 0x000052EA File Offset: 0x000034EA
		public void onVideoStarted()
		{
			Utils.LogDebug("onVideoStarted");
		}

		// Token: 0x0600016A RID: 362 RVA: 0x000052F8 File Offset: 0x000034F8
		public void onVideoCompleted(string parameters)
		{
			if (parameters != null)
			{
				List<string> list = new List<string>(parameters.Split(new char[]
				{
					';'
				}));
				string text = list.ToArray().GetValue(0).ToString();
				bool flag = list.ToArray().GetValue(1).ToString() == "true";
				Utils.LogDebug(string.Concat(new object[]
				{
					"onVideoCompleted: ",
					text,
					" - ",
					flag
				}));
				if (flag)
				{
					UnityAds.deliverCallback(ShowResult.Skipped);
				}
				else
				{
					UnityAds.deliverCallback(ShowResult.Finished);
				}
			}
		}

		// Token: 0x0600016B RID: 363 RVA: 0x000053A0 File Offset: 0x000035A0
		public void onFetchCompleted()
		{
			UnityAds.isInitialized = true;
			Utils.LogDebug("onFetchCompleted");
		}

		// Token: 0x0600016C RID: 364 RVA: 0x000053B2 File Offset: 0x000035B2
		public void onFetchFailed()
		{
			Utils.LogDebug("onFetchFailed");
		}

		// Token: 0x040000B5 RID: 181
		public static bool isShowing = false;

		// Token: 0x040000B6 RID: 182
		public static bool isInitialized = false;

		// Token: 0x040000B7 RID: 183
		public static bool allowPrecache = true;

		// Token: 0x040000B8 RID: 184
		private static bool initCalled = false;

		// Token: 0x040000B9 RID: 185
		private static UnityAds sharedInstance;

		// Token: 0x040000BA RID: 186
		private static string _rewardItemNameKey = string.Empty;

		// Token: 0x040000BB RID: 187
		private static string _rewardItemPictureKey = string.Empty;

		// Token: 0x040000BC RID: 188
		private static bool _resultDelivered = false;

		// Token: 0x040000BD RID: 189
		private static Action<ShowResult> resultCallback = null;

		// Token: 0x040000BE RID: 190
		private static string _versionString = Application.unityVersion + "_" + Advertisement.version;
	}
}
