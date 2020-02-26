using System;
using GoogleMobileAds.Android;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;

namespace GoogleMobileAds
{
	// Token: 0x02000035 RID: 53
	public class GoogleMobileAdsClientFactory
	{
		// Token: 0x060002D1 RID: 721 RVA: 0x00009F70 File Offset: 0x00008370
		public static IBannerClient BuildBannerClient()
		{
			return new BannerClient();
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x00009F77 File Offset: 0x00008377
		public static IInterstitialClient BuildInterstitialClient()
		{
			return new InterstitialClient();
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x00009F7E File Offset: 0x0000837E
		public static IRewardBasedVideoAdClient BuildRewardBasedVideoAdClient()
		{
			return new RewardBasedVideoAdClient();
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x00009F85 File Offset: 0x00008385
		public static IAdLoaderClient BuildAdLoaderClient(AdLoader adLoader)
		{
			return new AdLoaderClient(adLoader);
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x00009F8D File Offset: 0x0000838D
		public static INativeExpressAdClient BuildNativeExpressAdClient()
		{
			return new NativeExpressAdClient();
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x00009F94 File Offset: 0x00008394
		public static IMobileAdsClient MobileAdsInstance()
		{
			return MobileAdsClient.Instance;
		}
	}
}
