using System;
using System.Diagnostics;
using System.Reflection;
using GoogleMobileAds.Common;

namespace GoogleMobileAds.Api
{
	// Token: 0x02000021 RID: 33
	public class NativeExpressAdView
	{
		// Token: 0x060001A3 RID: 419 RVA: 0x000074E4 File Offset: 0x000058E4
		public NativeExpressAdView(string adUnitId, AdSize adSize, AdPosition position)
		{
			Type type = Type.GetType("GoogleMobileAds.GoogleMobileAdsClientFactory,Assembly-CSharp");
			MethodInfo method = type.GetMethod("BuildNativeExpressAdClient", BindingFlags.Static | BindingFlags.Public);
			this.client = (INativeExpressAdClient)method.Invoke(null, null);
			this.client.CreateNativeExpressAdView(adUnitId, adSize, position);
			this.ConfigureNativeExpressAdEvents();
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x00007538 File Offset: 0x00005938
		public NativeExpressAdView(string adUnitId, AdSize adSize, int x, int y)
		{
			Type type = Type.GetType("GoogleMobileAds.GoogleMobileAdsClientFactory,Assembly-CSharp");
			MethodInfo method = type.GetMethod("BuildNativeExpressAdClient", BindingFlags.Static | BindingFlags.Public);
			this.client = (INativeExpressAdClient)method.Invoke(null, null);
			this.client.CreateNativeExpressAdView(adUnitId, adSize, x, y);
			this.ConfigureNativeExpressAdEvents();
		}

		// Token: 0x14000029 RID: 41
		// (add) Token: 0x060001A5 RID: 421 RVA: 0x00007590 File Offset: 0x00005990
		// (remove) Token: 0x060001A6 RID: 422 RVA: 0x000075C8 File Offset: 0x000059C8
		
		public event EventHandler<EventArgs> OnAdLoaded;

		// Token: 0x1400002A RID: 42
		// (add) Token: 0x060001A7 RID: 423 RVA: 0x00007600 File Offset: 0x00005A00
		// (remove) Token: 0x060001A8 RID: 424 RVA: 0x00007638 File Offset: 0x00005A38
		
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x1400002B RID: 43
		// (add) Token: 0x060001A9 RID: 425 RVA: 0x00007670 File Offset: 0x00005A70
		// (remove) Token: 0x060001AA RID: 426 RVA: 0x000076A8 File Offset: 0x00005AA8
		
		public event EventHandler<EventArgs> OnAdOpening;

		// Token: 0x1400002C RID: 44
		// (add) Token: 0x060001AB RID: 427 RVA: 0x000076E0 File Offset: 0x00005AE0
		// (remove) Token: 0x060001AC RID: 428 RVA: 0x00007718 File Offset: 0x00005B18
		
		public event EventHandler<EventArgs> OnAdClosed;

		// Token: 0x1400002D RID: 45
		// (add) Token: 0x060001AD RID: 429 RVA: 0x00007750 File Offset: 0x00005B50
		// (remove) Token: 0x060001AE RID: 430 RVA: 0x00007788 File Offset: 0x00005B88
		
		public event EventHandler<EventArgs> OnAdLeavingApplication;

		// Token: 0x060001AF RID: 431 RVA: 0x000077BE File Offset: 0x00005BBE
		public void LoadAd(AdRequest request)
		{
			this.client.LoadAd(request);
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x000077CC File Offset: 0x00005BCC
		public void Hide()
		{
			this.client.HideNativeExpressAdView();
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x000077D9 File Offset: 0x00005BD9
		public void Show()
		{
			this.client.ShowNativeExpressAdView();
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x000077E6 File Offset: 0x00005BE6
		public void Destroy()
		{
			this.client.DestroyNativeExpressAdView();
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x000077F4 File Offset: 0x00005BF4
		private void ConfigureNativeExpressAdEvents()
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

		// Token: 0x040000FB RID: 251
		private INativeExpressAdClient client;
	}
}
