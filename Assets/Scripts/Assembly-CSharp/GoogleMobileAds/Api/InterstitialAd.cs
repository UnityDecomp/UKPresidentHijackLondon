using System;
using System.Diagnostics;
using System.Reflection;
using GoogleMobileAds.Common;

namespace GoogleMobileAds.Api
{
	// Token: 0x0200001E RID: 30
	public class InterstitialAd
	{
		// Token: 0x06000186 RID: 390 RVA: 0x000070D0 File Offset: 0x000054D0
		public InterstitialAd(string adUnitId)
		{
			Type type = Type.GetType("GoogleMobileAds.GoogleMobileAdsClientFactory,Assembly-CSharp");
			MethodInfo method = type.GetMethod("BuildInterstitialClient", BindingFlags.Static | BindingFlags.Public);
			this.client = (IInterstitialClient)method.Invoke(null, null);
			this.client.CreateInterstitialAd(adUnitId);
			this.client.OnAdLoaded += delegate(object sender, EventArgs args)
			{
				if (this.OnAdLoaded != null)
				{
					this.OnAdLoaded(this, args);
				}
			};
			this.client.OnAdFailedToLoad += delegate(object sender, AdFailedToLoadEventArgs args)
			{
				if (this.OnAdFailedToLoad != null)
				{
					this.OnAdFailedToLoad(this, args);
				}
			};
			this.client.OnAdOpening += delegate(object sender, EventArgs args)
			{
				if (this.OnAdOpening != null)
				{
					this.OnAdOpening(this, args);
				}
			};
			this.client.OnAdClosed += delegate(object sender, EventArgs args)
			{
				if (this.OnAdClosed != null)
				{
					this.OnAdClosed(this, args);
				}
			};
			this.client.OnAdLeavingApplication += delegate(object sender, EventArgs args)
			{
				if (this.OnAdLeavingApplication != null)
				{
					this.OnAdLeavingApplication(this, args);
				}
			};
		}

		// Token: 0x14000024 RID: 36
		// (add) Token: 0x06000187 RID: 391 RVA: 0x00007190 File Offset: 0x00005590
		// (remove) Token: 0x06000188 RID: 392 RVA: 0x000071C8 File Offset: 0x000055C8
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<EventArgs> OnAdLoaded;

		// Token: 0x14000025 RID: 37
		// (add) Token: 0x06000189 RID: 393 RVA: 0x00007200 File Offset: 0x00005600
		// (remove) Token: 0x0600018A RID: 394 RVA: 0x00007238 File Offset: 0x00005638
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x14000026 RID: 38
		// (add) Token: 0x0600018B RID: 395 RVA: 0x00007270 File Offset: 0x00005670
		// (remove) Token: 0x0600018C RID: 396 RVA: 0x000072A8 File Offset: 0x000056A8
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<EventArgs> OnAdOpening;

		// Token: 0x14000027 RID: 39
		// (add) Token: 0x0600018D RID: 397 RVA: 0x000072E0 File Offset: 0x000056E0
		// (remove) Token: 0x0600018E RID: 398 RVA: 0x00007318 File Offset: 0x00005718
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<EventArgs> OnAdClosed;

		// Token: 0x14000028 RID: 40
		// (add) Token: 0x0600018F RID: 399 RVA: 0x00007350 File Offset: 0x00005750
		// (remove) Token: 0x06000190 RID: 400 RVA: 0x00007388 File Offset: 0x00005788
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<EventArgs> OnAdLeavingApplication;

		// Token: 0x06000191 RID: 401 RVA: 0x000073BE File Offset: 0x000057BE
		public void LoadAd(AdRequest request)
		{
			this.client.LoadAd(request);
		}

		// Token: 0x06000192 RID: 402 RVA: 0x000073CC File Offset: 0x000057CC
		public bool IsLoaded()
		{
			return this.client.IsLoaded();
		}

		// Token: 0x06000193 RID: 403 RVA: 0x000073D9 File Offset: 0x000057D9
		public void Show()
		{
			this.client.ShowInterstitial();
		}

		// Token: 0x06000194 RID: 404 RVA: 0x000073E6 File Offset: 0x000057E6
		public void Destroy()
		{
			this.client.DestroyInterstitial();
		}

		// Token: 0x040000F3 RID: 243
		private IInterstitialClient client;
	}
}
