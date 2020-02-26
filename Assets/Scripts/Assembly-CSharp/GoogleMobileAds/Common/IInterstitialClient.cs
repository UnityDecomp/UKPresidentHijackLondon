using System;
using GoogleMobileAds.Api;

namespace GoogleMobileAds.Common
{
	// Token: 0x02000028 RID: 40
	public interface IInterstitialClient
	{
		// Token: 0x14000044 RID: 68
		// (add) Token: 0x0600021F RID: 543
		// (remove) Token: 0x06000220 RID: 544
		event EventHandler<EventArgs> OnAdLoaded;

		// Token: 0x14000045 RID: 69
		// (add) Token: 0x06000221 RID: 545
		// (remove) Token: 0x06000222 RID: 546
		event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x14000046 RID: 70
		// (add) Token: 0x06000223 RID: 547
		// (remove) Token: 0x06000224 RID: 548
		event EventHandler<EventArgs> OnAdOpening;

		// Token: 0x14000047 RID: 71
		// (add) Token: 0x06000225 RID: 549
		// (remove) Token: 0x06000226 RID: 550
		event EventHandler<EventArgs> OnAdClosed;

		// Token: 0x14000048 RID: 72
		// (add) Token: 0x06000227 RID: 551
		// (remove) Token: 0x06000228 RID: 552
		event EventHandler<EventArgs> OnAdLeavingApplication;

		// Token: 0x06000229 RID: 553
		void CreateInterstitialAd(string adUnitId);

		// Token: 0x0600022A RID: 554
		void LoadAd(AdRequest request);

		// Token: 0x0600022B RID: 555
		bool IsLoaded();

		// Token: 0x0600022C RID: 556
		void ShowInterstitial();

		// Token: 0x0600022D RID: 557
		void DestroyInterstitial();
	}
}
