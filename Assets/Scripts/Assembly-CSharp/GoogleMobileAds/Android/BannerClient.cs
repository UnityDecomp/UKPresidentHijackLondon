using System;
using System.Diagnostics;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	// Token: 0x0200002E RID: 46
	public class BannerClient : AndroidJavaProxy, IBannerClient
	{
		// Token: 0x0600025E RID: 606 RVA: 0x00008760 File Offset: 0x00006B60
		public BannerClient() : base("com.google.unity.ads.UnityAdListener")
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			this.bannerView = new AndroidJavaObject("com.google.unity.ads.Banner", new object[]
			{
				@static,
				this
			});
		}

		// Token: 0x14000057 RID: 87
		// (add) Token: 0x0600025F RID: 607 RVA: 0x000087B0 File Offset: 0x00006BB0
		// (remove) Token: 0x06000260 RID: 608 RVA: 0x000087E8 File Offset: 0x00006BE8
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<EventArgs> OnAdLoaded;

		// Token: 0x14000058 RID: 88
		// (add) Token: 0x06000261 RID: 609 RVA: 0x00008820 File Offset: 0x00006C20
		// (remove) Token: 0x06000262 RID: 610 RVA: 0x00008858 File Offset: 0x00006C58
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x14000059 RID: 89
		// (add) Token: 0x06000263 RID: 611 RVA: 0x00008890 File Offset: 0x00006C90
		// (remove) Token: 0x06000264 RID: 612 RVA: 0x000088C8 File Offset: 0x00006CC8
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<EventArgs> OnAdOpening;

		// Token: 0x1400005A RID: 90
		// (add) Token: 0x06000265 RID: 613 RVA: 0x00008900 File Offset: 0x00006D00
		// (remove) Token: 0x06000266 RID: 614 RVA: 0x00008938 File Offset: 0x00006D38
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<EventArgs> OnAdClosed;

		// Token: 0x1400005B RID: 91
		// (add) Token: 0x06000267 RID: 615 RVA: 0x00008970 File Offset: 0x00006D70
		// (remove) Token: 0x06000268 RID: 616 RVA: 0x000089A8 File Offset: 0x00006DA8
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<EventArgs> OnAdLeavingApplication;

		// Token: 0x06000269 RID: 617 RVA: 0x000089DE File Offset: 0x00006DDE
		public void CreateBannerView(string adUnitId, AdSize adSize, AdPosition position)
		{
			this.bannerView.Call("create", new object[]
			{
				adUnitId,
				Utils.GetAdSizeJavaObject(adSize),
				(int)position
			});
		}

		// Token: 0x0600026A RID: 618 RVA: 0x00008A0C File Offset: 0x00006E0C
		public void CreateBannerView(string adUnitId, AdSize adSize, int x, int y)
		{
			this.bannerView.Call("create", new object[]
			{
				adUnitId,
				Utils.GetAdSizeJavaObject(adSize),
				x,
				y
			});
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00008A44 File Offset: 0x00006E44
		public void LoadAd(AdRequest request)
		{
			this.bannerView.Call("loadAd", new object[]
			{
				Utils.GetAdRequestJavaObject(request)
			});
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00008A65 File Offset: 0x00006E65
		public void ShowBannerView()
		{
			this.bannerView.Call("show", new object[0]);
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00008A7D File Offset: 0x00006E7D
		public void HideBannerView()
		{
			this.bannerView.Call("hide", new object[0]);
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00008A95 File Offset: 0x00006E95
		public void DestroyBannerView()
		{
			this.bannerView.Call("destroy", new object[0]);
		}

		// Token: 0x0600026F RID: 623 RVA: 0x00008AAD File Offset: 0x00006EAD
		public void onAdLoaded()
		{
			if (this.OnAdLoaded != null)
			{
				this.OnAdLoaded(this, EventArgs.Empty);
			}
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00008ACC File Offset: 0x00006ECC
		public void onAdFailedToLoad(string errorReason)
		{
			if (this.OnAdFailedToLoad != null)
			{
				AdFailedToLoadEventArgs e = new AdFailedToLoadEventArgs
				{
					Message = errorReason
				};
				this.OnAdFailedToLoad(this, e);
			}
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00008B00 File Offset: 0x00006F00
		public void onAdOpened()
		{
			if (this.OnAdOpening != null)
			{
				this.OnAdOpening(this, EventArgs.Empty);
			}
		}

		// Token: 0x06000272 RID: 626 RVA: 0x00008B1E File Offset: 0x00006F1E
		public void onAdClosed()
		{
			if (this.OnAdClosed != null)
			{
				this.OnAdClosed(this, EventArgs.Empty);
			}
		}

		// Token: 0x06000273 RID: 627 RVA: 0x00008B3C File Offset: 0x00006F3C
		public void onAdLeftApplication()
		{
			if (this.OnAdLeavingApplication != null)
			{
				this.OnAdLeavingApplication(this, EventArgs.Empty);
			}
		}

		// Token: 0x04000118 RID: 280
		private AndroidJavaObject bannerView;
	}
}
