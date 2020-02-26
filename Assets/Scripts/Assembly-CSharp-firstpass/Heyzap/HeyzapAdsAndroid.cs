using System;
using UnityEngine;

namespace Heyzap
{
	// Token: 0x02000015 RID: 21
	public class HeyzapAdsAndroid : MonoBehaviour
	{
		// Token: 0x06000094 RID: 148 RVA: 0x00003094 File Offset: 0x00001294
		public static void Start(string publisher_id, int options = 0)
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return;
			}
			AndroidJNIHelper.debug = false;
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.heyzap.sdk.extensions.unity3d.UnityHelper"))
			{
				androidJavaClass.CallStatic("start", new object[]
				{
					publisher_id,
					options
				});
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00003100 File Offset: 0x00001300
		public static bool IsNetworkInitialized(string network)
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return false;
			}
			AndroidJNIHelper.debug = false;
			bool result;
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.heyzap.sdk.extensions.unity3d.UnityHelper"))
			{
				result = androidJavaClass.CallStatic<bool>("isNetworkInitialized", new object[]
				{
					network
				});
			}
			return result;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00003168 File Offset: 0x00001368
		public static bool OnBackPressed()
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return false;
			}
			AndroidJNIHelper.debug = false;
			bool result;
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.heyzap.sdk.extensions.unity3d.UnityHelper"))
			{
				result = androidJavaClass.CallStatic<bool>("onBackPressed", new object[0]);
			}
			return result;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x000031CC File Offset: 0x000013CC
		public static void ShowMediationTestSuite()
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return;
			}
			AndroidJNIHelper.debug = false;
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.heyzap.sdk.extensions.unity3d.UnityHelper"))
			{
				androidJavaClass.CallStatic("showNetworkActivity", new object[0]);
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000322C File Offset: 0x0000142C
		public static string GetRemoteData()
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return "{}";
			}
			AndroidJNIHelper.debug = false;
			string result;
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.heyzap.sdk.extensions.unity3d.UnityHelper"))
			{
				result = androidJavaClass.CallStatic<string>("getCustomPublisherData", new object[0]);
			}
			return result;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00003294 File Offset: 0x00001494
		public static void ShowDebugLogs()
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return;
			}
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.heyzap.sdk.extensions.unity3d.UnityHelper"))
			{
				androidJavaClass.CallStatic("showDebugLogs", new object[0]);
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x000032EC File Offset: 0x000014EC
		public static void HideDebugLogs()
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return;
			}
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.heyzap.sdk.extensions.unity3d.UnityHelper"))
			{
				androidJavaClass.CallStatic("hideDebugLogs", new object[0]);
			}
		}
	}
}
