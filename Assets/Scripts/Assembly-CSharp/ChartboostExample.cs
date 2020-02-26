using System;
using System.Collections.Generic;
using ChartboostSDK;
using UnityEngine;

// Token: 0x02000003 RID: 3
public class ChartboostExample : MonoBehaviour
{
	// Token: 0x0600000B RID: 11 RVA: 0x0000246C File Offset: 0x0000086C
	private void OnEnable()
	{
		this.SetupDelegates();
	}

	// Token: 0x0600000C RID: 12 RVA: 0x00002474 File Offset: 0x00000874
	private void Start()
	{
		this.delegateHistory = new List<string>();
		Chartboost.setAutoCacheAds(this.autocache);
		Chartboost.setMediation(CBMediation.AdMob, "1.0");
		this.AddLog("Is Initialized: " + Chartboost.isInitialized());
	}

	// Token: 0x0600000D RID: 13 RVA: 0x000024C0 File Offset: 0x000008C0
	private void SetupDelegates()
	{
		Chartboost.didInitialize += this.didInitialize;
		Chartboost.didFailToLoadInterstitial += this.didFailToLoadInterstitial;
		Chartboost.didDismissInterstitial += this.didDismissInterstitial;
		Chartboost.didCloseInterstitial += this.didCloseInterstitial;
		Chartboost.didClickInterstitial += this.didClickInterstitial;
		Chartboost.didCacheInterstitial += this.didCacheInterstitial;
		Chartboost.shouldDisplayInterstitial += this.shouldDisplayInterstitial;
		Chartboost.didDisplayInterstitial += this.didDisplayInterstitial;
		Chartboost.didFailToLoadMoreApps += this.didFailToLoadMoreApps;
		Chartboost.didDismissMoreApps += this.didDismissMoreApps;
		Chartboost.didCloseMoreApps += this.didCloseMoreApps;
		Chartboost.didClickMoreApps += this.didClickMoreApps;
		Chartboost.didCacheMoreApps += this.didCacheMoreApps;
		Chartboost.shouldDisplayMoreApps += this.shouldDisplayMoreApps;
		Chartboost.didDisplayMoreApps += this.didDisplayMoreApps;
		Chartboost.didFailToRecordClick += this.didFailToRecordClick;
		Chartboost.didFailToLoadRewardedVideo += this.didFailToLoadRewardedVideo;
		Chartboost.didDismissRewardedVideo += this.didDismissRewardedVideo;
		Chartboost.didCloseRewardedVideo += this.didCloseRewardedVideo;
		Chartboost.didClickRewardedVideo += this.didClickRewardedVideo;
		Chartboost.didCacheRewardedVideo += this.didCacheRewardedVideo;
		Chartboost.shouldDisplayRewardedVideo += this.shouldDisplayRewardedVideo;
		Chartboost.didCompleteRewardedVideo += this.didCompleteRewardedVideo;
		Chartboost.didDisplayRewardedVideo += this.didDisplayRewardedVideo;
		Chartboost.didCacheInPlay += this.didCacheInPlay;
		Chartboost.didFailToLoadInPlay += this.didFailToLoadInPlay;
		Chartboost.didPauseClickForConfirmation += this.didPauseClickForConfirmation;
		Chartboost.willDisplayVideo += this.willDisplayVideo;
	}

	// Token: 0x0600000E RID: 14 RVA: 0x000026AC File Offset: 0x00000AAC
	private void Update()
	{
		this.UpdateScrolling();
		this.frameCount++;
		if (this.frameCount > 30)
		{
			this.hasInterstitial = Chartboost.hasInterstitial(CBLocation.Default);
			this.hasMoreApps = Chartboost.hasMoreApps(CBLocation.Default);
			this.hasRewardedVideo = Chartboost.hasRewardedVideo(CBLocation.Default);
			this.hasInPlay = Chartboost.hasInPlay(CBLocation.Default);
			this.frameCount = 0;
		}
	}

	// Token: 0x0600000F RID: 15 RVA: 0x00002724 File Offset: 0x00000B24
	private void UpdateScrolling()
	{
		if (Input.touchCount != 1)
		{
			return;
		}
		Touch touch = Input.touches[0];
		if (touch.phase == TouchPhase.Began)
		{
			this.beginFinger = touch.position;
			this.beginPanel = this.scrollPosition;
		}
		if (touch.phase == TouchPhase.Moved)
		{
			this.deltaFingerY = touch.position.y - this.beginFinger.y;
			float y = this.beginPanel.y + this.deltaFingerY / this.scale;
			this.latestPanel = this.beginPanel;
			this.latestPanel.y = y;
			this.scrollPosition = this.latestPanel;
		}
	}

	// Token: 0x06000010 RID: 16 RVA: 0x000027E0 File Offset: 0x00000BE0
	private void AddLog(string text)
	{
		Debug.Log(text);
		this.delegateHistory.Insert(0, text + "\n");
		int count = this.delegateHistory.Count;
		if (count > 20)
		{
			this.delegateHistory.RemoveRange(20, count - 20);
		}
	}

	// Token: 0x06000011 RID: 17 RVA: 0x00002830 File Offset: 0x00000C30
	private void OnGUI()
	{
		float num = (float)Screen.width;
		float num2 = (float)Screen.height;
		float a = num / 240f;
		float b = num2 / 210f;
		float num3 = Mathf.Min(6f, Mathf.Min(a, b));
		if (this.scale != num3)
		{
			this.scale = num3;
			this.guiScale = new Vector3(this.scale, this.scale, 1f);
		}
		GUI.matrix = Matrix4x4.Scale(this.guiScale);
		this.ELEMENT_WIDTH = (int)(num / this.scale) - 30;
		float num4 = (float)this.REQUIRED_HEIGHT;
		if (this.inPlayAd != null)
		{
			num4 += 60f;
		}
		this.scrollRect = new Rect(0f, (float)this.BANNER_HEIGHT, (float)(this.ELEMENT_WIDTH + 30), num2 / this.scale - (float)this.BANNER_HEIGHT);
		this.scrollArea = new Rect(-10f, (float)this.BANNER_HEIGHT, (float)this.ELEMENT_WIDTH, num4);
		this.LayoutHeader();
		if (this.activeAgeGate)
		{
			GUI.ModalWindow(1, new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), new GUI.WindowFunction(this.LayoutAgeGate), "Age Gate");
			return;
		}
		this.scrollPosition = GUI.BeginScrollView(this.scrollRect, this.scrollPosition, this.scrollArea);
		this.LayoutButtons();
		this.LayoutToggles();
		GUI.EndScrollView();
	}

	// Token: 0x06000012 RID: 18 RVA: 0x000029A4 File Offset: 0x00000DA4
	private void LayoutHeader()
	{
		GUILayout.Label(this.logo, new GUILayoutOption[]
		{
			GUILayout.Height(30f),
			GUILayout.Width((float)(this.ELEMENT_WIDTH + 20))
		});
		string text = string.Empty;
		foreach (string str in this.delegateHistory)
		{
			text += str;
		}
		GUILayout.TextArea(text, new GUILayoutOption[]
		{
			GUILayout.Height(70f),
			GUILayout.Width((float)(this.ELEMENT_WIDTH + 20))
		});
	}

	// Token: 0x06000013 RID: 19 RVA: 0x00002A64 File Offset: 0x00000E64
	private void LayoutToggles()
	{
		GUILayout.Space(5f);
		GUILayout.Label("Options:", new GUILayoutOption[0]);
		this.showInterstitial = GUILayout.Toggle(this.showInterstitial, "Should Display Interstitial", new GUILayoutOption[0]);
		this.showMoreApps = GUILayout.Toggle(this.showMoreApps, "Should Display More Apps", new GUILayoutOption[0]);
		this.showRewardedVideo = GUILayout.Toggle(this.showRewardedVideo, "Should Display Rewarded Video", new GUILayoutOption[0]);
		if (GUILayout.Toggle(this.ageGate, "Should Pause for AgeGate", new GUILayoutOption[0]) != this.ageGate)
		{
			this.ageGate = !this.ageGate;
			Chartboost.setShouldPauseClickForConfirmation(this.ageGate);
		}
		if (GUILayout.Toggle(this.autocache, "Auto cache ads", new GUILayoutOption[0]) != this.autocache)
		{
			this.autocache = !this.autocache;
			Chartboost.setAutoCacheAds(this.autocache);
		}
	}

	// Token: 0x06000014 RID: 20 RVA: 0x00002B58 File Offset: 0x00000F58
	private void LayoutButtons()
	{
		GUILayout.Space(5f);
		GUILayout.Label("Has Interstitial: " + this.hasInterstitial, new GUILayoutOption[0]);
		if (GUILayout.Button("Cache Interstitial", new GUILayoutOption[]
		{
			GUILayout.Width((float)this.ELEMENT_WIDTH)
		}))
		{
			Chartboost.cacheInterstitial(CBLocation.Default);
		}
		if (GUILayout.Button("Show Interstitial", new GUILayoutOption[]
		{
			GUILayout.Width((float)this.ELEMENT_WIDTH)
		}))
		{
			Chartboost.showInterstitial(CBLocation.Default);
		}
		GUILayout.Space(5f);
		GUILayout.Label("Has MoreApps: " + this.hasMoreApps, new GUILayoutOption[0]);
		if (GUILayout.Button("Cache More Apps", new GUILayoutOption[]
		{
			GUILayout.Width((float)this.ELEMENT_WIDTH)
		}))
		{
			Chartboost.cacheMoreApps(CBLocation.Default);
		}
		if (GUILayout.Button("Show More Apps", new GUILayoutOption[]
		{
			GUILayout.Width((float)this.ELEMENT_WIDTH)
		}))
		{
			Chartboost.showMoreApps(CBLocation.Default);
		}
		GUILayout.Space(5f);
		GUILayout.Label("Has Rewarded Video: " + this.hasRewardedVideo, new GUILayoutOption[0]);
		if (GUILayout.Button("Cache Rewarded Video", new GUILayoutOption[]
		{
			GUILayout.Width((float)this.ELEMENT_WIDTH)
		}))
		{
			Chartboost.cacheRewardedVideo(CBLocation.Default);
		}
		if (GUILayout.Button("Show Rewarded Video", new GUILayoutOption[]
		{
			GUILayout.Width((float)this.ELEMENT_WIDTH)
		}))
		{
			Chartboost.showRewardedVideo(CBLocation.Default);
		}
		GUILayout.Space(5f);
		GUILayout.Label("Has InPlay: " + this.hasInPlay, new GUILayoutOption[0]);
		if (GUILayout.Button("Cache InPlay Ad", new GUILayoutOption[]
		{
			GUILayout.Width((float)this.ELEMENT_WIDTH)
		}))
		{
			Chartboost.cacheInPlay(CBLocation.Default);
		}
		if (GUILayout.Button("Show InPlay Ad", new GUILayoutOption[]
		{
			GUILayout.Width((float)this.ELEMENT_WIDTH)
		}))
		{
			this.inPlayAd = Chartboost.getInPlay(CBLocation.Default);
			if (this.inPlayAd != null)
			{
				this.inPlayAd.show();
			}
		}
		if (this.inPlayAd != null)
		{
			GUILayout.Label("app: " + this.inPlayAd.appName, new GUILayoutOption[0]);
			if (GUILayout.Button(this.inPlayAd.appIcon, new GUILayoutOption[]
			{
				GUILayout.Width((float)this.ELEMENT_WIDTH)
			}))
			{
				this.inPlayAd.click();
			}
		}
		GUILayout.Space(5f);
		GUILayout.Label("Post install events:", new GUILayoutOption[0]);
		if (GUILayout.Button("Send PIA Main Level Event", new GUILayoutOption[]
		{
			GUILayout.Width((float)this.ELEMENT_WIDTH)
		}))
		{
			Chartboost.trackLevelInfo("Test Data", CBLevelType.HIGHEST_LEVEL_REACHED, 1, "Test Send mail level Information");
		}
		if (GUILayout.Button("Send PIA Sub Level Event", new GUILayoutOption[]
		{
			GUILayout.Width((float)this.ELEMENT_WIDTH)
		}))
		{
			Chartboost.trackLevelInfo("Test Data", CBLevelType.HIGHEST_LEVEL_REACHED, 1, 2, "Test Send sub level Information");
		}
		if (GUILayout.Button("Track IAP", new GUILayoutOption[]
		{
			GUILayout.Width((float)this.ELEMENT_WIDTH)
		}))
		{
			this.TrackIAP();
		}
	}

	// Token: 0x06000015 RID: 21 RVA: 0x00002EA8 File Offset: 0x000012A8
	private void LayoutAgeGate(int windowID)
	{
		GUILayout.Space((float)this.BANNER_HEIGHT);
		GUILayout.Label("Want to pass the age gate?", new GUILayoutOption[0]);
		GUILayout.BeginHorizontal(new GUILayoutOption[]
		{
			GUILayout.Width((float)this.ELEMENT_WIDTH)
		});
		if (GUILayout.Button("YES", new GUILayoutOption[0]))
		{
			Chartboost.didPassAgeGate(true);
			this.activeAgeGate = false;
		}
		if (GUILayout.Button("NO", new GUILayoutOption[0]))
		{
			Chartboost.didPassAgeGate(false);
			this.activeAgeGate = false;
		}
		GUILayout.EndHorizontal();
	}

	// Token: 0x06000016 RID: 22 RVA: 0x00002F34 File Offset: 0x00001334
	private void OnDisable()
	{
		Chartboost.didInitialize -= this.didInitialize;
		Chartboost.didFailToLoadInterstitial -= this.didFailToLoadInterstitial;
		Chartboost.didDismissInterstitial -= this.didDismissInterstitial;
		Chartboost.didCloseInterstitial -= this.didCloseInterstitial;
		Chartboost.didClickInterstitial -= this.didClickInterstitial;
		Chartboost.didCacheInterstitial -= this.didCacheInterstitial;
		Chartboost.shouldDisplayInterstitial -= this.shouldDisplayInterstitial;
		Chartboost.didDisplayInterstitial -= this.didDisplayInterstitial;
		Chartboost.didFailToLoadMoreApps -= this.didFailToLoadMoreApps;
		Chartboost.didDismissMoreApps -= this.didDismissMoreApps;
		Chartboost.didCloseMoreApps -= this.didCloseMoreApps;
		Chartboost.didClickMoreApps -= this.didClickMoreApps;
		Chartboost.didCacheMoreApps -= this.didCacheMoreApps;
		Chartboost.shouldDisplayMoreApps -= this.shouldDisplayMoreApps;
		Chartboost.didDisplayMoreApps -= this.didDisplayMoreApps;
		Chartboost.didFailToRecordClick -= this.didFailToRecordClick;
		Chartboost.didFailToLoadRewardedVideo -= this.didFailToLoadRewardedVideo;
		Chartboost.didDismissRewardedVideo -= this.didDismissRewardedVideo;
		Chartboost.didCloseRewardedVideo -= this.didCloseRewardedVideo;
		Chartboost.didClickRewardedVideo -= this.didClickRewardedVideo;
		Chartboost.didCacheRewardedVideo -= this.didCacheRewardedVideo;
		Chartboost.shouldDisplayRewardedVideo -= this.shouldDisplayRewardedVideo;
		Chartboost.didCompleteRewardedVideo -= this.didCompleteRewardedVideo;
		Chartboost.didDisplayRewardedVideo -= this.didDisplayRewardedVideo;
		Chartboost.didCacheInPlay -= this.didCacheInPlay;
		Chartboost.didFailToLoadInPlay -= this.didFailToLoadInPlay;
		Chartboost.didPauseClickForConfirmation -= this.didPauseClickForConfirmation;
		Chartboost.willDisplayVideo -= this.willDisplayVideo;
	}

	// Token: 0x06000017 RID: 23 RVA: 0x0000311D File Offset: 0x0000151D
	private void didInitialize(bool status)
	{
		this.AddLog(string.Format("didInitialize: {0}", status));
	}

	// Token: 0x06000018 RID: 24 RVA: 0x00003135 File Offset: 0x00001535
	private void didFailToLoadInterstitial(CBLocation location, CBImpressionError error)
	{
		this.AddLog(string.Format("didFailToLoadInterstitial: {0} at location {1}", error, location));
	}

	// Token: 0x06000019 RID: 25 RVA: 0x0000314E File Offset: 0x0000154E
	private void didDismissInterstitial(CBLocation location)
	{
		this.AddLog("didDismissInterstitial: " + location);
	}

	// Token: 0x0600001A RID: 26 RVA: 0x00003161 File Offset: 0x00001561
	private void didCloseInterstitial(CBLocation location)
	{
		this.AddLog("didCloseInterstitial: " + location);
	}

	// Token: 0x0600001B RID: 27 RVA: 0x00003174 File Offset: 0x00001574
	private void didClickInterstitial(CBLocation location)
	{
		this.AddLog("didClickInterstitial: " + location);
	}

	// Token: 0x0600001C RID: 28 RVA: 0x00003187 File Offset: 0x00001587
	private void didCacheInterstitial(CBLocation location)
	{
		this.AddLog("didCacheInterstitial: " + location);
	}

	// Token: 0x0600001D RID: 29 RVA: 0x0000319A File Offset: 0x0000159A
	private bool shouldDisplayInterstitial(CBLocation location)
	{
		this.AddLog(string.Concat(new object[]
		{
			"shouldDisplayInterstitial @",
			location,
			" : ",
			this.showInterstitial
		}));
		return this.showInterstitial;
	}

	// Token: 0x0600001E RID: 30 RVA: 0x000031D5 File Offset: 0x000015D5
	private void didDisplayInterstitial(CBLocation location)
	{
		this.AddLog("didDisplayInterstitial: " + location);
	}

	// Token: 0x0600001F RID: 31 RVA: 0x000031E8 File Offset: 0x000015E8
	private void didFailToLoadMoreApps(CBLocation location, CBImpressionError error)
	{
		this.AddLog(string.Format("didFailToLoadMoreApps: {0} at location: {1}", error, location));
	}

	// Token: 0x06000020 RID: 32 RVA: 0x00003201 File Offset: 0x00001601
	private void didDismissMoreApps(CBLocation location)
	{
		this.AddLog(string.Format("didDismissMoreApps at location: {0}", location));
	}

	// Token: 0x06000021 RID: 33 RVA: 0x00003214 File Offset: 0x00001614
	private void didCloseMoreApps(CBLocation location)
	{
		this.AddLog(string.Format("didCloseMoreApps at location: {0}", location));
	}

	// Token: 0x06000022 RID: 34 RVA: 0x00003227 File Offset: 0x00001627
	private void didClickMoreApps(CBLocation location)
	{
		this.AddLog(string.Format("didClickMoreApps at location: {0}", location));
	}

	// Token: 0x06000023 RID: 35 RVA: 0x0000323A File Offset: 0x0000163A
	private void didCacheMoreApps(CBLocation location)
	{
		this.AddLog(string.Format("didCacheMoreApps at location: {0}", location));
	}

	// Token: 0x06000024 RID: 36 RVA: 0x0000324D File Offset: 0x0000164D
	private bool shouldDisplayMoreApps(CBLocation location)
	{
		this.AddLog(string.Format("shouldDisplayMoreApps at location: {0}: {1}", location, this.showMoreApps));
		return this.showMoreApps;
	}

	// Token: 0x06000025 RID: 37 RVA: 0x00003271 File Offset: 0x00001671
	private void didDisplayMoreApps(CBLocation location)
	{
		this.AddLog("didDisplayMoreApps: " + location);
	}

	// Token: 0x06000026 RID: 38 RVA: 0x00003284 File Offset: 0x00001684
	private void didFailToRecordClick(CBLocation location, CBClickError error)
	{
		this.AddLog(string.Format("didFailToRecordClick: {0} at location: {1}", error, location));
	}

	// Token: 0x06000027 RID: 39 RVA: 0x0000329D File Offset: 0x0000169D
	private void didFailToLoadRewardedVideo(CBLocation location, CBImpressionError error)
	{
		this.AddLog(string.Format("didFailToLoadRewardedVideo: {0} at location {1}", error, location));
	}

	// Token: 0x06000028 RID: 40 RVA: 0x000032B6 File Offset: 0x000016B6
	private void didDismissRewardedVideo(CBLocation location)
	{
		this.AddLog("didDismissRewardedVideo: " + location);
	}

	// Token: 0x06000029 RID: 41 RVA: 0x000032C9 File Offset: 0x000016C9
	private void didCloseRewardedVideo(CBLocation location)
	{
		this.AddLog("didCloseRewardedVideo: " + location);
	}

	// Token: 0x0600002A RID: 42 RVA: 0x000032DC File Offset: 0x000016DC
	private void didClickRewardedVideo(CBLocation location)
	{
		this.AddLog("didClickRewardedVideo: " + location);
	}

	// Token: 0x0600002B RID: 43 RVA: 0x000032EF File Offset: 0x000016EF
	private void didCacheRewardedVideo(CBLocation location)
	{
		this.AddLog("didCacheRewardedVideo: " + location);
	}

	// Token: 0x0600002C RID: 44 RVA: 0x00003302 File Offset: 0x00001702
	private bool shouldDisplayRewardedVideo(CBLocation location)
	{
		this.AddLog(string.Concat(new object[]
		{
			"shouldDisplayRewardedVideo @",
			location,
			" : ",
			this.showRewardedVideo
		}));
		return this.showRewardedVideo;
	}

	// Token: 0x0600002D RID: 45 RVA: 0x0000333D File Offset: 0x0000173D
	private void didCompleteRewardedVideo(CBLocation location, int reward)
	{
		this.AddLog(string.Format("didCompleteRewardedVideo: reward {0} at location {1}", reward, location));
	}

	// Token: 0x0600002E RID: 46 RVA: 0x00003356 File Offset: 0x00001756
	private void didDisplayRewardedVideo(CBLocation location)
	{
		this.AddLog("didDisplayRewardedVideo: " + location);
	}

	// Token: 0x0600002F RID: 47 RVA: 0x00003369 File Offset: 0x00001769
	private void didCacheInPlay(CBLocation location)
	{
		this.AddLog("didCacheInPlay called: " + location);
	}

	// Token: 0x06000030 RID: 48 RVA: 0x0000337C File Offset: 0x0000177C
	private void didFailToLoadInPlay(CBLocation location, CBImpressionError error)
	{
		this.AddLog(string.Format("didFailToLoadInPlay: {0} at location: {1}", error, location));
	}

	// Token: 0x06000031 RID: 49 RVA: 0x00003395 File Offset: 0x00001795
	private void didPauseClickForConfirmation()
	{
	}

	// Token: 0x06000032 RID: 50 RVA: 0x00003397 File Offset: 0x00001797
	private void willDisplayVideo(CBLocation location)
	{
		this.AddLog("willDisplayVideo: " + location);
	}

	// Token: 0x06000033 RID: 51 RVA: 0x000033AA File Offset: 0x000017AA
	private void TrackIAP()
	{
		Debug.Log("TrackIAP");
		Chartboost.trackInAppGooglePlayPurchaseEvent("SampleItem", "TestPurchase", "0.99", "USD", "ProductID", "PurchaseData", "PurchaseSignature");
	}

	// Token: 0x04000002 RID: 2
	public GameObject inPlayIcon;

	// Token: 0x04000003 RID: 3
	public GameObject inPlayText;

	// Token: 0x04000004 RID: 4
	public Texture2D logo;

	// Token: 0x04000005 RID: 5
	private CBInPlay inPlayAd;

	// Token: 0x04000006 RID: 6
	public Vector2 scrollPosition = Vector2.zero;

	// Token: 0x04000007 RID: 7
	private List<string> delegateHistory;

	// Token: 0x04000008 RID: 8
	private bool hasInterstitial;

	// Token: 0x04000009 RID: 9
	private bool hasMoreApps;

	// Token: 0x0400000A RID: 10
	private bool hasRewardedVideo;

	// Token: 0x0400000B RID: 11
	private bool hasInPlay;

	// Token: 0x0400000C RID: 12
	private int frameCount;

	// Token: 0x0400000D RID: 13
	private bool ageGate;

	// Token: 0x0400000E RID: 14
	private bool autocache = true;

	// Token: 0x0400000F RID: 15
	private bool activeAgeGate;

	// Token: 0x04000010 RID: 16
	private bool showInterstitial = true;

	// Token: 0x04000011 RID: 17
	private bool showMoreApps = true;

	// Token: 0x04000012 RID: 18
	private bool showRewardedVideo = true;

	// Token: 0x04000013 RID: 19
	private int BANNER_HEIGHT = 110;

	// Token: 0x04000014 RID: 20
	private int REQUIRED_HEIGHT = 650;

	// Token: 0x04000015 RID: 21
	private int ELEMENT_WIDTH = 190;

	// Token: 0x04000016 RID: 22
	private Rect scrollRect;

	// Token: 0x04000017 RID: 23
	private Rect scrollArea;

	// Token: 0x04000018 RID: 24
	private Vector3 guiScale;

	// Token: 0x04000019 RID: 25
	private float scale;

	// Token: 0x0400001A RID: 26
	private Vector2 beginFinger;

	// Token: 0x0400001B RID: 27
	private float deltaFingerY;

	// Token: 0x0400001C RID: 28
	private Vector2 beginPanel;

	// Token: 0x0400001D RID: 29
	private Vector2 latestPanel;
}
