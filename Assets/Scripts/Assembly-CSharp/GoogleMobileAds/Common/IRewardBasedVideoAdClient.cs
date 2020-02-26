using System;
using GoogleMobileAds.Api;

namespace GoogleMobileAds.Common
{
	// Token: 0x0200002B RID: 43
	public interface IRewardBasedVideoAdClient
	{
		// Token: 0x1400004E RID: 78
		// (add) Token: 0x0600023F RID: 575
		// (remove) Token: 0x06000240 RID: 576
		event EventHandler<EventArgs> OnAdLoaded;

		// Token: 0x1400004F RID: 79
		// (add) Token: 0x06000241 RID: 577
		// (remove) Token: 0x06000242 RID: 578
		event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x14000050 RID: 80
		// (add) Token: 0x06000243 RID: 579
		// (remove) Token: 0x06000244 RID: 580
		event EventHandler<EventArgs> OnAdOpening;

		// Token: 0x14000051 RID: 81
		// (add) Token: 0x06000245 RID: 581
		// (remove) Token: 0x06000246 RID: 582
		event EventHandler<EventArgs> OnAdStarted;

		// Token: 0x14000052 RID: 82
		// (add) Token: 0x06000247 RID: 583
		// (remove) Token: 0x06000248 RID: 584
		event EventHandler<Reward> OnAdRewarded;

		// Token: 0x14000053 RID: 83
		// (add) Token: 0x06000249 RID: 585
		// (remove) Token: 0x0600024A RID: 586
		event EventHandler<EventArgs> OnAdClosed;

		// Token: 0x14000054 RID: 84
		// (add) Token: 0x0600024B RID: 587
		// (remove) Token: 0x0600024C RID: 588
		event EventHandler<EventArgs> OnAdLeavingApplication;

		// Token: 0x0600024D RID: 589
		void CreateRewardBasedVideoAd();

		// Token: 0x0600024E RID: 590
		void LoadAd(AdRequest request, string adUnitId);

		// Token: 0x0600024F RID: 591
		bool IsLoaded();

		// Token: 0x06000250 RID: 592
		void ShowRewardBasedVideoAd();
	}
}
