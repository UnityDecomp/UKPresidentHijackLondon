using System;
using System.Reflection;
using GoogleMobileAds.Common;

namespace GoogleMobileAds.Api
{
	// Token: 0x02000020 RID: 32
	public class MobileAds
	{
		// Token: 0x060001A0 RID: 416 RVA: 0x00007496 File Offset: 0x00005896
		public static void Initialize(string appId)
		{
			MobileAds.client.Initialize(appId);
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x000074A4 File Offset: 0x000058A4
		private static IMobileAdsClient GetMobileAdsClient()
		{
			Type type = Type.GetType("GoogleMobileAds.GoogleMobileAdsClientFactory,Assembly-CSharp");
			MethodInfo method = type.GetMethod("MobileAdsInstance", BindingFlags.Static | BindingFlags.Public);
			return (IMobileAdsClient)method.Invoke(null, null);
		}

		// Token: 0x040000FA RID: 250
		private static readonly IMobileAdsClient client = MobileAds.GetMobileAdsClient();
	}
}
