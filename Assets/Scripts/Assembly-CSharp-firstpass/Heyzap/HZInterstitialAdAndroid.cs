using System;
using UnityEngine;

namespace Heyzap
{
	// Token: 0x0200001E RID: 30
	public class HZInterstitialAdAndroid
	{
		// Token: 0x060000ED RID: 237 RVA: 0x00003A60 File Offset: 0x00001C60
		public static void ShowWithOptions(HZShowOptions showOptions)
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return;
			}
			AndroidJNIHelper.debug = false;
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.heyzap.sdk.extensions.unity3d.UnityHelper"))
			{
				androidJavaClass.CallStatic("showInterstitial", new object[]
				{
					showOptions.Tag
				});
			}
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00003AC8 File Offset: 0x00001CC8
		public static void Fetch(string tag = "default")
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return;
			}
			AndroidJNIHelper.debug = false;
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.heyzap.sdk.extensions.unity3d.UnityHelper"))
			{
				androidJavaClass.CallStatic("fetchInterstitial", new object[]
				{
					tag
				});
			}
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00003B2C File Offset: 0x00001D2C
		public static bool IsAvailable(string tag = "default")
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return false;
			}
			AndroidJNIHelper.debug = false;
			bool result;
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.heyzap.sdk.extensions.unity3d.UnityHelper"))
			{
				result = androidJavaClass.CallStatic<bool>("isInterstitialAvailable", new object[]
				{
					tag
				});
			}
			return result;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00003B94 File Offset: 0x00001D94
		public static void chartboostShowForLocation(string location)
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return;
			}
			AndroidJNIHelper.debug = false;
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.heyzap.sdk.extensions.unity3d.UnityHelper"))
			{
				androidJavaClass.CallStatic("chartboostLocationShow", new object[]
				{
					location
				});
			}
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00003BF8 File Offset: 0x00001DF8
		public static bool chartboostIsAvailableForLocation(string location)
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return false;
			}
			AndroidJNIHelper.debug = false;
			bool result;
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.heyzap.sdk.extensions.unity3d.UnityHelper"))
			{
				result = androidJavaClass.CallStatic<bool>("chartboostLocationIsAvailable", new object[]
				{
					location
				});
			}
			return result;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00003C60 File Offset: 0x00001E60
		public static void chartboostFetchForLocation(string location)
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return;
			}
			AndroidJNIHelper.debug = false;
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.heyzap.sdk.extensions.unity3d.UnityHelper"))
			{
				androidJavaClass.CallStatic("chartboostLocationFetch", new object[]
				{
					location
				});
			}
		}
	}
}
