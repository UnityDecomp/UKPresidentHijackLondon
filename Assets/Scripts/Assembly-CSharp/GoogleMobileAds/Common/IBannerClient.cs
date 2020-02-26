using System;
using GoogleMobileAds.Api;

namespace GoogleMobileAds.Common
{
	// Token: 0x02000026 RID: 38
	public interface IBannerClient
	{
		// Token: 0x1400003F RID: 63
		// (add) Token: 0x06000209 RID: 521
		// (remove) Token: 0x0600020A RID: 522
		event EventHandler<EventArgs> OnAdLoaded;

		// Token: 0x14000040 RID: 64
		// (add) Token: 0x0600020B RID: 523
		// (remove) Token: 0x0600020C RID: 524
		event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x14000041 RID: 65
		// (add) Token: 0x0600020D RID: 525
		// (remove) Token: 0x0600020E RID: 526
		event EventHandler<EventArgs> OnAdOpening;

		// Token: 0x14000042 RID: 66
		// (add) Token: 0x0600020F RID: 527
		// (remove) Token: 0x06000210 RID: 528
		event EventHandler<EventArgs> OnAdClosed;

		// Token: 0x14000043 RID: 67
		// (add) Token: 0x06000211 RID: 529
		// (remove) Token: 0x06000212 RID: 530
		event EventHandler<EventArgs> OnAdLeavingApplication;

		// Token: 0x06000213 RID: 531
		void CreateBannerView(string adUnitId, AdSize adSize, AdPosition position);

		// Token: 0x06000214 RID: 532
		void CreateBannerView(string adUnitId, AdSize adSize, int x, int y);

		// Token: 0x06000215 RID: 533
		void LoadAd(AdRequest request);

		// Token: 0x06000216 RID: 534
		void ShowBannerView();

		// Token: 0x06000217 RID: 535
		void HideBannerView();

		// Token: 0x06000218 RID: 536
		void DestroyBannerView();
	}
}
