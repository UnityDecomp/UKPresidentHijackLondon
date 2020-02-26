using System;
using System.Diagnostics;
using System.Reflection;
using GoogleMobileAds.Common;

namespace GoogleMobileAds.Api
{
	// Token: 0x0200001A RID: 26
	public class BannerView
	{
		// Token: 0x06000166 RID: 358 RVA: 0x00006C28 File Offset: 0x00005028
		public BannerView(string adUnitId, AdSize adSize, AdPosition position)
		{
			Type type = Type.GetType("GoogleMobileAds.GoogleMobileAdsClientFactory,Assembly-CSharp");
			MethodInfo method = type.GetMethod("BuildBannerClient", BindingFlags.Static | BindingFlags.Public);
			this.client = (IBannerClient)method.Invoke(null, null);
			this.client.CreateBannerView(adUnitId, adSize, position);
			this.ConfigureBannerEvents();
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00006C7C File Offset: 0x0000507C
		public BannerView(string adUnitId, AdSize adSize, int x, int y)
		{
			Type type = Type.GetType("GoogleMobileAds.GoogleMobileAdsClientFactory,Assembly-CSharp");
			MethodInfo method = type.GetMethod("BuildBannerClient", BindingFlags.Static | BindingFlags.Public);
			this.client = (IBannerClient)method.Invoke(null, null);
			this.client.CreateBannerView(adUnitId, adSize, x, y);
			this.ConfigureBannerEvents();
		}

		// Token: 0x1400001F RID: 31
		// (add) Token: 0x06000168 RID: 360 RVA: 0x00006CD4 File Offset: 0x000050D4
		// (remove) Token: 0x06000169 RID: 361 RVA: 0x00006D0C File Offset: 0x0000510C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<EventArgs> OnAdLoaded;

		// Token: 0x14000020 RID: 32
		// (add) Token: 0x0600016A RID: 362 RVA: 0x00006D44 File Offset: 0x00005144
		// (remove) Token: 0x0600016B RID: 363 RVA: 0x00006D7C File Offset: 0x0000517C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x14000021 RID: 33
		// (add) Token: 0x0600016C RID: 364 RVA: 0x00006DB4 File Offset: 0x000051B4
		// (remove) Token: 0x0600016D RID: 365 RVA: 0x00006DEC File Offset: 0x000051EC
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<EventArgs> OnAdOpening;

		// Token: 0x14000022 RID: 34
		// (add) Token: 0x0600016E RID: 366 RVA: 0x00006E24 File Offset: 0x00005224
		// (remove) Token: 0x0600016F RID: 367 RVA: 0x00006E5C File Offset: 0x0000525C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<EventArgs> OnAdClosed;

		// Token: 0x14000023 RID: 35
		// (add) Token: 0x06000170 RID: 368 RVA: 0x00006E94 File Offset: 0x00005294
		// (remove) Token: 0x06000171 RID: 369 RVA: 0x00006ECC File Offset: 0x000052CC
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<EventArgs> OnAdLeavingApplication;

		// Token: 0x06000172 RID: 370 RVA: 0x00006F02 File Offset: 0x00005302
		public void LoadAd(AdRequest request)
		{
			this.client.LoadAd(request);
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00006F10 File Offset: 0x00005310
		public void Hide()
		{
			this.client.HideBannerView();
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00006F1D File Offset: 0x0000531D
		public void Show()
		{
			this.client.ShowBannerView();
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00006F2A File Offset: 0x0000532A
		public void Destroy()
		{
			this.client.DestroyBannerView();
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00006F38 File Offset: 0x00005338
		private void ConfigureBannerEvents()
		{
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

		// Token: 0x040000E7 RID: 231
		private IBannerClient client;
	}
}
