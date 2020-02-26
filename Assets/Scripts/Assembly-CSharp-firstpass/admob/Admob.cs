using System;
using System.Diagnostics;
using UnityEngine;

namespace admob
{
	// Token: 0x02000002 RID: 2
	public class Admob
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
		// (remove) Token: 0x06000003 RID: 3 RVA: 0x00002090 File Offset: 0x00000290
		
		public event Admob.AdmobEventHandler bannerEventHandler;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000004 RID: 4 RVA: 0x000020C8 File Offset: 0x000002C8
		// (remove) Token: 0x06000005 RID: 5 RVA: 0x00002100 File Offset: 0x00000300
		
		public event Admob.AdmobEventHandler interstitialEventHandler;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000006 RID: 6 RVA: 0x00002138 File Offset: 0x00000338
		// (remove) Token: 0x06000007 RID: 7 RVA: 0x00002170 File Offset: 0x00000370
		
		public event Admob.AdmobEventHandler rewardedVideoEventHandler;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000008 RID: 8 RVA: 0x000021A8 File Offset: 0x000003A8
		// (remove) Token: 0x06000009 RID: 9 RVA: 0x000021E0 File Offset: 0x000003E0
		
		public event Admob.AdmobEventHandler nativeBannerEventHandler;

		// Token: 0x0600000A RID: 10 RVA: 0x00002216 File Offset: 0x00000416
		public static Admob Instance()
		{
			if (Admob._instance == null)
			{
				Admob._instance = new Admob();
				Admob._instance.preInitAdmob();
			}
			return Admob._instance;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000223C File Offset: 0x0000043C
		private void preInitAdmob()
		{
			if (this.jadmob == null)
			{
				AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.admob.plugin.AdmobUnityPlugin");
				this.jadmob = androidJavaClass.CallStatic<AndroidJavaObject>("getInstance", new object[0]);
				Admob.InnerAdmobListener innerAdmobListener = new Admob.InnerAdmobListener();
				innerAdmobListener.admobInstance = this;
				AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
				AndroidJavaObject @static = androidJavaClass2.GetStatic<AndroidJavaObject>("currentActivity");
				this.jadmob.Call("setContext", new object[]
				{
					@static,
					new AdmobListenerProxy(innerAdmobListener)
				});
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000022BD File Offset: 0x000004BD
		public void removeAllBanner()
		{
			this.jadmob.Call("removeAllBanner", new object[0]);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000022D5 File Offset: 0x000004D5
		public void initAdmob(string bannerID, string fullID)
		{
			this.jadmob.Call("initAdmob", new object[]
			{
				bannerID,
				fullID
			});
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000022F8 File Offset: 0x000004F8
		public void showBannerRelative(AdSize size, int position, int marginY, string instanceName = "defaultBanner")
		{
			this.jadmob.Call("showBannerRelative", new object[]
			{
				size.Width,
				size.Height,
				position,
				marginY,
				instanceName
			});
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002350 File Offset: 0x00000550
		public void showBannerAbsolute(AdSize size, int x, int y, string instanceName = "defaultBanner")
		{
			this.jadmob.Call("showBannerAbsolute", new object[]
			{
				size.Width,
				size.Height,
				x,
				y,
				instanceName
			});
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000023A6 File Offset: 0x000005A6
		public void removeBanner(string instanceName = "defaultBanner")
		{
			this.jadmob.Call("removeBanner", new object[]
			{
				instanceName
			});
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000023C2 File Offset: 0x000005C2
		public void loadInterstitial()
		{
			this.jadmob.Call("loadInterstitial", new object[0]);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000023DC File Offset: 0x000005DC
		public bool isInterstitialReady()
		{
			return this.jadmob.Call<bool>("isInterstitialReady", new object[0]);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002401 File Offset: 0x00000601
		public void showInterstitial()
		{
			this.jadmob.Call("showInterstitial", new object[0]);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002419 File Offset: 0x00000619
		public void loadRewardedVideo(string rewardedVideoID)
		{
			this.jadmob.Call("loadRewardedVideo", new object[]
			{
				rewardedVideoID
			});
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002438 File Offset: 0x00000638
		public bool isRewardedVideoReady()
		{
			return this.jadmob.Call<bool>("isRewardedVideoReady", new object[0]);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000245D File Offset: 0x0000065D
		public void showRewardedVideo()
		{
			this.jadmob.Call("showRewardedVideo", new object[0]);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002475 File Offset: 0x00000675
		public void setGender(int v)
		{
			this.jadmob.Call("setGender", new object[]
			{
				v
			});
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002496 File Offset: 0x00000696
		public void setKeywords(string[] v)
		{
			this.jadmob.Call("setKeywords", new object[]
			{
				v
			});
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000024B2 File Offset: 0x000006B2
		public void setTesting(bool value)
		{
			this.jadmob.Call("setTesting", new object[]
			{
				value
			});
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000024D3 File Offset: 0x000006D3
		public void setForChildren(bool value)
		{
			this.jadmob.Call("setForChildren", new object[]
			{
				value
			});
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000024F4 File Offset: 0x000006F4
		public void showNativeBannerRelative(AdSize size, int position, int marginY, string nativeBannerID, string instanceName = "defaultNativeBanner")
		{
			this.jadmob.Call("showNativeBannerRelative", new object[]
			{
				size.Width,
				size.Height,
				position,
				marginY,
				nativeBannerID,
				instanceName
			});
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002550 File Offset: 0x00000750
		public void showNativeBannerAbsolute(AdSize size, int x, int y, string nativeBannerID, string instanceName = "defaultNativeBanner")
		{
			this.jadmob.Call("showNativeBannerAbsolute", new object[]
			{
				size.Width,
				size.Height,
				x,
				y,
				nativeBannerID,
				instanceName
			});
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000025AB File Offset: 0x000007AB
		public void removeNativeBanner(string instanceName = "defaultNativeBanner")
		{
			this.jadmob.Call("removeNativeBanner", new object[]
			{
				instanceName
			});
		}

		// Token: 0x04000005 RID: 5
		private static Admob _instance;

		// Token: 0x04000006 RID: 6
		private AndroidJavaObject jadmob;

		// Token: 0x02000003 RID: 3
		// (Invoke) Token: 0x0600001F RID: 31
		public delegate void AdmobEventHandler(string eventName, string msg);

		// Token: 0x02000004 RID: 4
		private class InnerAdmobListener : IAdmobListener
		{
			// Token: 0x06000023 RID: 35 RVA: 0x000025D0 File Offset: 0x000007D0
			public void onAdmobEvent(string adtype, string eventName, string paramString)
			{
				if (adtype == "banner")
				{
					if (this.admobInstance.bannerEventHandler != null)
					{
						this.admobInstance.bannerEventHandler(eventName, paramString);
					}
				}
				else if (adtype == "interstitial")
				{
					if (this.admobInstance.interstitialEventHandler != null)
					{
						this.admobInstance.interstitialEventHandler(eventName, paramString);
					}
				}
				else if (adtype == "rewardedVideo")
				{
					if (this.admobInstance.rewardedVideoEventHandler != null)
					{
						this.admobInstance.rewardedVideoEventHandler(eventName, paramString);
					}
				}
				else if (adtype == "nativeBanner" && this.admobInstance.nativeBannerEventHandler != null)
				{
					this.admobInstance.nativeBannerEventHandler(eventName, paramString);
				}
			}

			// Token: 0x04000007 RID: 7
			internal Admob admobInstance;
		}
	}
}
