using System;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	// Token: 0x02000031 RID: 49
	public class MobileAdsClient : IMobileAdsClient
	{
		// Token: 0x06000290 RID: 656 RVA: 0x00008FF6 File Offset: 0x000073F6
		private MobileAdsClient()
		{
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000291 RID: 657 RVA: 0x00008FFE File Offset: 0x000073FE
		public static MobileAdsClient Instance
		{
			get
			{
				return MobileAdsClient.instance;
			}
		}

		// Token: 0x06000292 RID: 658 RVA: 0x00009008 File Offset: 0x00007408
		public void Initialize(string appId)
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("com.google.android.gms.ads.MobileAds");
			androidJavaClass2.CallStatic("initialize", new object[]
			{
				@static,
				appId
			});
		}

		// Token: 0x04000125 RID: 293
		private static MobileAdsClient instance = new MobileAdsClient();
	}
}
