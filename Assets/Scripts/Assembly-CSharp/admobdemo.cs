using System;
using admob;
using UnityEngine;

// Token: 0x02000002 RID: 2
public class admobdemo : MonoBehaviour
{
	// Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000458
	private void Start()
	{
		Debug.Log("start unity demo-------------");
		this.initAdmob();
	}

	// Token: 0x06000003 RID: 3 RVA: 0x0000206A File Offset: 0x0000046A
	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			Debug.Log(KeyCode.Escape + "-----------------");
		}
	}

	// Token: 0x06000004 RID: 4 RVA: 0x00002090 File Offset: 0x00000490
	private void initAdmob()
	{
		this.ad = Admob.Instance();
		this.ad.bannerEventHandler += this.onBannerEvent;
		this.ad.interstitialEventHandler += this.onInterstitialEvent;
		this.ad.rewardedVideoEventHandler += this.onRewardedVideoEvent;
		this.ad.nativeBannerEventHandler += this.onNativeBannerEvent;
		this.ad.initAdmob("ca-app-pub-3940256099942544/2934735716", "ca-app-pub-3940256099942544/4411468910");
		this.ad.setGender(AdmobGender.MALE);
		string[] array = new string[]
		{
			"game",
			"crash",
			"male game"
		};
		Debug.Log("admob inited -------------");
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00002154 File Offset: 0x00000554
	private void OnGUI()
	{
		if (GUI.Button(new Rect(120f, 0f, 100f, 60f), "showInterstitial"))
		{
			if (this.ad.isInterstitialReady())
			{
				this.ad.showInterstitial();
			}
			else
			{
				this.ad.loadInterstitial();
			}
		}
		if (GUI.Button(new Rect(240f, 0f, 100f, 60f), "showRewardVideo"))
		{
			if (this.ad.isRewardedVideoReady())
			{
				this.ad.showRewardedVideo();
			}
			else
			{
				this.ad.loadRewardedVideo("ca-app-pub-3940256099942544/1712485313");
			}
		}
		if (GUI.Button(new Rect(0f, 100f, 100f, 60f), "showbanner"))
		{
			Admob.Instance().showBannerRelative(AdSize.SmartBanner, AdPosition.BOTTOM_CENTER, 0, "defaultBanner");
		}
		if (GUI.Button(new Rect(120f, 100f, 100f, 60f), "showbannerABS"))
		{
			Admob.Instance().showBannerAbsolute(AdSize.Banner, 20, 300, "defaultBanner");
		}
		if (GUI.Button(new Rect(240f, 100f, 100f, 60f), "removebanner"))
		{
			Admob.Instance().removeBanner("defaultBanner");
		}
		string nativeBannerID = "ca-app-pub-3940256099942544/2934735716";
		if (GUI.Button(new Rect(0f, 200f, 100f, 60f), "showNative"))
		{
			Admob.Instance().showNativeBannerRelative(new AdSize(320, 120), AdPosition.BOTTOM_CENTER, 0, nativeBannerID, "defaultNativeBanner");
		}
		if (GUI.Button(new Rect(120f, 200f, 100f, 60f), "showNativeABS"))
		{
			Admob.Instance().showNativeBannerAbsolute(new AdSize(320, 120), 20, 300, nativeBannerID, "defaultNativeBanner");
		}
		if (GUI.Button(new Rect(240f, 200f, 100f, 60f), "removeNative"))
		{
			Admob.Instance().removeNativeBanner("defaultNativeBanner");
		}
	}

	// Token: 0x06000006 RID: 6 RVA: 0x0000239A File Offset: 0x0000079A
	private void onInterstitialEvent(string eventName, string msg)
	{
		Debug.Log("handler onAdmobEvent---" + eventName + "   " + msg);
		if (eventName == AdmobEvent.onAdLoaded)
		{
			Admob.Instance().showInterstitial();
		}
	}

	// Token: 0x06000007 RID: 7 RVA: 0x000023CC File Offset: 0x000007CC
	private void onBannerEvent(string eventName, string msg)
	{
		Debug.Log("handler onAdmobBannerEvent---" + eventName + "   " + msg);
	}

	// Token: 0x06000008 RID: 8 RVA: 0x000023E4 File Offset: 0x000007E4
	private void onRewardedVideoEvent(string eventName, string msg)
	{
		Debug.Log("handler onRewardedVideoEvent---" + eventName + "  rewarded: " + msg);
	}

	// Token: 0x06000009 RID: 9 RVA: 0x000023FC File Offset: 0x000007FC
	private void onNativeBannerEvent(string eventName, string msg)
	{
		Debug.Log("handler onAdmobNativeBannerEvent---" + eventName + "   " + msg);
	}

	// Token: 0x04000001 RID: 1
	private Admob ad;
}
