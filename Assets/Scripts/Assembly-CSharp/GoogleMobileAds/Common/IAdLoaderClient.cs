using System;
using GoogleMobileAds.Api;

namespace GoogleMobileAds.Common
{
	// Token: 0x02000025 RID: 37
	public interface IAdLoaderClient
	{
		// Token: 0x1400003D RID: 61
		// (add) Token: 0x06000204 RID: 516
		// (remove) Token: 0x06000205 RID: 517
		event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x1400003E RID: 62
		// (add) Token: 0x06000206 RID: 518
		// (remove) Token: 0x06000207 RID: 519
		event EventHandler<CustomNativeEventArgs> OnCustomNativeTemplateAdLoaded;

		// Token: 0x06000208 RID: 520
		void LoadAd(AdRequest request);
	}
}
