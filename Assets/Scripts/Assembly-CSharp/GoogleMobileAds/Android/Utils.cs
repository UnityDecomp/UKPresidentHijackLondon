using System;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using GoogleMobileAds.Api.Mediation;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	// Token: 0x02000034 RID: 52
	internal class Utils
	{
		// Token: 0x060002CE RID: 718 RVA: 0x00009A70 File Offset: 0x00007E70
		public static AndroidJavaObject GetAdSizeJavaObject(AdSize adSize)
		{
			if (adSize.IsSmartBanner)
			{
				return new AndroidJavaClass("com.google.android.gms.ads.AdSize").GetStatic<AndroidJavaObject>("SMART_BANNER");
			}
			return new AndroidJavaObject("com.google.android.gms.ads.AdSize", new object[]
			{
				adSize.Width,
				adSize.Height
			});
		}

		// Token: 0x060002CF RID: 719 RVA: 0x00009ACC File Offset: 0x00007ECC
		public static AndroidJavaObject GetAdRequestJavaObject(AdRequest request)
		{
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.google.android.gms.ads.AdRequest$Builder", new object[0]);
			foreach (string text in request.Keywords)
			{
				androidJavaObject.Call<AndroidJavaObject>("addKeyword", new object[]
				{
					text
				});
			}
			foreach (string text2 in request.TestDevices)
			{
				if (text2 == "SIMULATOR")
				{
					string @static = new AndroidJavaClass("com.google.android.gms.ads.AdRequest").GetStatic<string>("DEVICE_ID_EMULATOR");
					androidJavaObject.Call<AndroidJavaObject>("addTestDevice", new object[]
					{
						@static
					});
				}
				else
				{
					androidJavaObject.Call<AndroidJavaObject>("addTestDevice", new object[]
					{
						text2
					});
				}
			}
			if (request.Birthday != null)
			{
				DateTime valueOrDefault = request.Birthday.GetValueOrDefault();
				AndroidJavaObject androidJavaObject2 = new AndroidJavaObject("java.util.Date", new object[]
				{
					valueOrDefault.Year,
					valueOrDefault.Month,
					valueOrDefault.Day
				});
				androidJavaObject.Call<AndroidJavaObject>("setBirthday", new object[]
				{
					androidJavaObject2
				});
			}
			if (request.Gender != null)
			{
				int? num = null;
				Gender valueOrDefault2 = request.Gender.GetValueOrDefault();
				if (valueOrDefault2 != Gender.Unknown)
				{
					if (valueOrDefault2 != Gender.Male)
					{
						if (valueOrDefault2 == Gender.Female)
						{
							num = new int?(new AndroidJavaClass("com.google.android.gms.ads.AdRequest").GetStatic<int>("GENDER_FEMALE"));
						}
					}
					else
					{
						num = new int?(new AndroidJavaClass("com.google.android.gms.ads.AdRequest").GetStatic<int>("GENDER_MALE"));
					}
				}
				else
				{
					num = new int?(new AndroidJavaClass("com.google.android.gms.ads.AdRequest").GetStatic<int>("GENDER_UNKNOWN"));
				}
				if (num != null)
				{
					androidJavaObject.Call<AndroidJavaObject>("setGender", new object[]
					{
						num
					});
				}
			}
			if (request.TagForChildDirectedTreatment != null)
			{
				androidJavaObject.Call<AndroidJavaObject>("tagForChildDirectedTreatment", new object[]
				{
					request.TagForChildDirectedTreatment.GetValueOrDefault()
				});
			}
			androidJavaObject.Call<AndroidJavaObject>("setRequestAgent", new object[]
			{
				"unity-3.6.0"
			});
			AndroidJavaObject androidJavaObject3 = new AndroidJavaObject("android.os.Bundle", new object[0]);
			foreach (KeyValuePair<string, string> keyValuePair in request.Extras)
			{
				androidJavaObject3.Call("putString", new object[]
				{
					keyValuePair.Key,
					keyValuePair.Value
				});
			}
			AndroidJavaObject androidJavaObject4 = new AndroidJavaObject("com.google.android.gms.ads.mediation.admob.AdMobExtras", new object[]
			{
				androidJavaObject3
			});
			androidJavaObject.Call<AndroidJavaObject>("addNetworkExtras", new object[]
			{
				androidJavaObject4
			});
			foreach (MediationExtras mediationExtras in request.MediationExtras)
			{
				AndroidJavaObject androidJavaObject5 = new AndroidJavaObject(mediationExtras.AndroidMediationExtraBuilderClassName, new object[0]);
				AndroidJavaObject androidJavaObject6 = new AndroidJavaObject("java.util.HashMap", new object[0]);
				foreach (KeyValuePair<string, string> keyValuePair2 in mediationExtras.Extras)
				{
					androidJavaObject6.Call<string>("put", new object[]
					{
						keyValuePair2.Key,
						keyValuePair2.Value
					});
				}
				AndroidJavaObject androidJavaObject7 = androidJavaObject5.Call<AndroidJavaObject>("buildExtras", new object[]
				{
					androidJavaObject6
				});
				androidJavaObject.Call<AndroidJavaObject>("addNetworkExtrasBundle", new object[]
				{
					androidJavaObject5.Call<AndroidJavaClass>("getAdapterClass", new object[0]),
					androidJavaObject7
				});
			}
			return androidJavaObject.Call<AndroidJavaObject>("build", new object[0]);
		}

		// Token: 0x0400013B RID: 315
		public const string AdListenerClassName = "com.google.android.gms.ads.AdListener";

		// Token: 0x0400013C RID: 316
		public const string AdRequestClassName = "com.google.android.gms.ads.AdRequest";

		// Token: 0x0400013D RID: 317
		public const string AdRequestBuilderClassName = "com.google.android.gms.ads.AdRequest$Builder";

		// Token: 0x0400013E RID: 318
		public const string AdSizeClassName = "com.google.android.gms.ads.AdSize";

		// Token: 0x0400013F RID: 319
		public const string AdMobExtrasClassName = "com.google.android.gms.ads.mediation.admob.AdMobExtras";

		// Token: 0x04000140 RID: 320
		public const string PlayStorePurchaseListenerClassName = "com.google.android.gms.ads.purchase.PlayStorePurchaseListener";

		// Token: 0x04000141 RID: 321
		public const string MobileAdsClassName = "com.google.android.gms.ads.MobileAds";

		// Token: 0x04000142 RID: 322
		public const string BannerViewClassName = "com.google.unity.ads.Banner";

		// Token: 0x04000143 RID: 323
		public const string InterstitialClassName = "com.google.unity.ads.Interstitial";

		// Token: 0x04000144 RID: 324
		public const string RewardBasedVideoClassName = "com.google.unity.ads.RewardBasedVideo";

		// Token: 0x04000145 RID: 325
		public const string NativeExpressAdViewClassName = "com.google.unity.ads.NativeExpressAd";

		// Token: 0x04000146 RID: 326
		public const string NativeAdLoaderClassName = "com.google.unity.ads.NativeAdLoader";

		// Token: 0x04000147 RID: 327
		public const string UnityAdListenerClassName = "com.google.unity.ads.UnityAdListener";

		// Token: 0x04000148 RID: 328
		public const string UnityRewardBasedVideoAdListenerClassName = "com.google.unity.ads.UnityRewardBasedVideoAdListener";

		// Token: 0x04000149 RID: 329
		public const string UnityAdLoaderListenerClassName = "com.google.unity.ads.UnityAdLoaderListener";

		// Token: 0x0400014A RID: 330
		public const string PluginUtilsClassName = "com.google.unity.ads.PluginUtils";

		// Token: 0x0400014B RID: 331
		public const string UnityActivityClassName = "com.unity3d.player.UnityPlayer";

		// Token: 0x0400014C RID: 332
		public const string BundleClassName = "android.os.Bundle";

		// Token: 0x0400014D RID: 333
		public const string DateClassName = "java.util.Date";
	}
}
