using System;
using UnityEngine;

namespace Heyzap
{
	// Token: 0x02000024 RID: 36
	public class HZVideoAdAndroid : MonoBehaviour
	{
		// Token: 0x06000114 RID: 276 RVA: 0x00003EB4 File Offset: 0x000020B4
		public static void ShowWithOptions(HZShowOptions showOptions)
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return;
			}
			AndroidJNIHelper.debug = false;
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.heyzap.sdk.extensions.unity3d.UnityHelper"))
			{
				androidJavaClass.CallStatic("showVideo", new object[]
				{
					showOptions.Tag
				});
			}
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00003F1C File Offset: 0x0000211C
		public static void Fetch(string tag)
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return;
			}
			AndroidJNIHelper.debug = false;
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.heyzap.sdk.extensions.unity3d.UnityHelper"))
			{
				androidJavaClass.CallStatic("fetchVideo", new object[]
				{
					tag
				});
			}
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00003F80 File Offset: 0x00002180
		public static bool IsAvailable(string tag)
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return false;
			}
			AndroidJNIHelper.debug = false;
			bool result;
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.heyzap.sdk.extensions.unity3d.UnityHelper"))
			{
				result = androidJavaClass.CallStatic<bool>("isVideoAvailable", new object[]
				{
					tag
				});
			}
			return result;
		}
	}
}
