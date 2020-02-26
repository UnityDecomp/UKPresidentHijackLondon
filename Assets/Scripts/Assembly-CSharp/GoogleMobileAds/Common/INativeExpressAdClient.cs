using System;
using GoogleMobileAds.Api;

namespace GoogleMobileAds.Common
{
	// Token: 0x0200002A RID: 42
	public interface INativeExpressAdClient
	{
		// Token: 0x14000049 RID: 73
		// (add) Token: 0x0600022F RID: 559
		// (remove) Token: 0x06000230 RID: 560
		event EventHandler<EventArgs> OnAdLoaded;

		// Token: 0x1400004A RID: 74
		// (add) Token: 0x06000231 RID: 561
		// (remove) Token: 0x06000232 RID: 562
		event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x1400004B RID: 75
		// (add) Token: 0x06000233 RID: 563
		// (remove) Token: 0x06000234 RID: 564
		event EventHandler<EventArgs> OnAdOpening;

		// Token: 0x1400004C RID: 76
		// (add) Token: 0x06000235 RID: 565
		// (remove) Token: 0x06000236 RID: 566
		event EventHandler<EventArgs> OnAdClosed;

		// Token: 0x1400004D RID: 77
		// (add) Token: 0x06000237 RID: 567
		// (remove) Token: 0x06000238 RID: 568
		event EventHandler<EventArgs> OnAdLeavingApplication;

		// Token: 0x06000239 RID: 569
		void CreateNativeExpressAdView(string adUnitId, AdSize adSize, AdPosition position);

		// Token: 0x0600023A RID: 570
		void CreateNativeExpressAdView(string adUnitId, AdSize adSize, int x, int y);

		// Token: 0x0600023B RID: 571
		void LoadAd(AdRequest request);

		// Token: 0x0600023C RID: 572
		void ShowNativeExpressAdView();

		// Token: 0x0600023D RID: 573
		void HideNativeExpressAdView();

		// Token: 0x0600023E RID: 574
		void DestroyNativeExpressAdView();
	}
}
