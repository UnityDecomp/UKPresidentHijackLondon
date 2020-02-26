using System;
using System.Diagnostics;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	// Token: 0x02000030 RID: 48
	public class InterstitialClient : AndroidJavaProxy, IInterstitialClient
	{
		// Token: 0x0600027B RID: 635 RVA: 0x00008C44 File Offset: 0x00007044
		public InterstitialClient() : base("com.google.unity.ads.UnityAdListener")
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			this.interstitial = new AndroidJavaObject("com.google.unity.ads.Interstitial", new object[]
			{
				@static,
				this
			});
		}

		// Token: 0x1400005C RID: 92
		// (add) Token: 0x0600027C RID: 636 RVA: 0x00008C94 File Offset: 0x00007094
		// (remove) Token: 0x0600027D RID: 637 RVA: 0x00008CCC File Offset: 0x000070CC
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<EventArgs> OnAdLoaded;

		// Token: 0x1400005D RID: 93
		// (add) Token: 0x0600027E RID: 638 RVA: 0x00008D04 File Offset: 0x00007104
		// (remove) Token: 0x0600027F RID: 639 RVA: 0x00008D3C File Offset: 0x0000713C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x1400005E RID: 94
		// (add) Token: 0x06000280 RID: 640 RVA: 0x00008D74 File Offset: 0x00007174
		// (remove) Token: 0x06000281 RID: 641 RVA: 0x00008DAC File Offset: 0x000071AC
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<EventArgs> OnAdOpening;

		// Token: 0x1400005F RID: 95
		// (add) Token: 0x06000282 RID: 642 RVA: 0x00008DE4 File Offset: 0x000071E4
		// (remove) Token: 0x06000283 RID: 643 RVA: 0x00008E1C File Offset: 0x0000721C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<EventArgs> OnAdClosed;

		// Token: 0x14000060 RID: 96
		// (add) Token: 0x06000284 RID: 644 RVA: 0x00008E54 File Offset: 0x00007254
		// (remove) Token: 0x06000285 RID: 645 RVA: 0x00008E8C File Offset: 0x0000728C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<EventArgs> OnAdLeavingApplication;

		// Token: 0x06000286 RID: 646 RVA: 0x00008EC2 File Offset: 0x000072C2
		public void CreateInterstitialAd(string adUnitId)
		{
			this.interstitial.Call("create", new object[]
			{
				adUnitId
			});
		}

		// Token: 0x06000287 RID: 647 RVA: 0x00008EDE File Offset: 0x000072DE
		public void LoadAd(AdRequest request)
		{
			this.interstitial.Call("loadAd", new object[]
			{
				Utils.GetAdRequestJavaObject(request)
			});
		}

		// Token: 0x06000288 RID: 648 RVA: 0x00008EFF File Offset: 0x000072FF
		public bool IsLoaded()
		{
			return this.interstitial.Call<bool>("isLoaded", new object[0]);
		}

		// Token: 0x06000289 RID: 649 RVA: 0x00008F17 File Offset: 0x00007317
		public void ShowInterstitial()
		{
			this.interstitial.Call("show", new object[0]);
		}

		// Token: 0x0600028A RID: 650 RVA: 0x00008F2F File Offset: 0x0000732F
		public void DestroyInterstitial()
		{
			this.interstitial.Call("destroy", new object[0]);
		}

		// Token: 0x0600028B RID: 651 RVA: 0x00008F47 File Offset: 0x00007347
		public void onAdLoaded()
		{
			if (this.OnAdLoaded != null)
			{
				this.OnAdLoaded(this, EventArgs.Empty);
			}
		}

		// Token: 0x0600028C RID: 652 RVA: 0x00008F68 File Offset: 0x00007368
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

		// Token: 0x0600028D RID: 653 RVA: 0x00008F9C File Offset: 0x0000739C
		public void onAdOpened()
		{
			if (this.OnAdOpening != null)
			{
				this.OnAdOpening(this, EventArgs.Empty);
			}
		}

		// Token: 0x0600028E RID: 654 RVA: 0x00008FBA File Offset: 0x000073BA
		public void onAdClosed()
		{
			if (this.OnAdClosed != null)
			{
				this.OnAdClosed(this, EventArgs.Empty);
			}
		}

		// Token: 0x0600028F RID: 655 RVA: 0x00008FD8 File Offset: 0x000073D8
		public void onAdLeftApplication()
		{
			if (this.OnAdLeavingApplication != null)
			{
				this.OnAdLeavingApplication(this, EventArgs.Empty);
			}
		}

		// Token: 0x0400011F RID: 287
		private AndroidJavaObject interstitial;
	}
}
