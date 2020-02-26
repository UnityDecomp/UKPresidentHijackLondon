using System;
using UnityEngine;

namespace Heyzap
{
	// Token: 0x02000018 RID: 24
	public class HZBannerAdAndroid : MonoBehaviour
	{
		// Token: 0x060000B0 RID: 176 RVA: 0x00003470 File Offset: 0x00001670
		public static bool GetCurrentBannerDimensions(out Rect banner)
		{
			banner = new Rect(0f, 0f, 0f, 0f);
			if (Application.platform != RuntimePlatform.Android)
			{
				return false;
			}
			AndroidJNIHelper.debug = false;
			bool result;
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.heyzap.sdk.extensions.unity3d.UnityHelper"))
			{
				string text = androidJavaClass.CallStatic<string>("getBannerDimensions", new object[0]);
				if (text == null || text.Length == 0)
				{
					result = false;
				}
				else
				{
					string[] array = text.Split(new char[]
					{
						' '
					});
					if (array.Length != 4)
					{
						result = false;
					}
					else
					{
						banner = new Rect((float)int.Parse(array[0]), (float)int.Parse(array[1]), (float)int.Parse(array[2]), (float)int.Parse(array[3]));
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00003554 File Offset: 0x00001754
		public static void ShowWithOptions(HZBannerShowOptions showOptions)
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return;
			}
			AndroidJNIHelper.debug = false;
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.heyzap.sdk.extensions.unity3d.UnityHelper"))
			{
				androidJavaClass.CallStatic("showBanner", new object[]
				{
					showOptions.Tag,
					showOptions.Position
				});
			}
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x000035C4 File Offset: 0x000017C4
		public static void Hide()
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return;
			}
			AndroidJNIHelper.debug = false;
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.heyzap.sdk.extensions.unity3d.UnityHelper"))
			{
				androidJavaClass.CallStatic("hideBanner", new object[0]);
			}
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00003624 File Offset: 0x00001824
		public static void Destroy()
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return;
			}
			AndroidJNIHelper.debug = false;
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.heyzap.sdk.extensions.unity3d.UnityHelper"))
			{
				androidJavaClass.CallStatic("destroyBanner", new object[0]);
			}
		}
	}
}
