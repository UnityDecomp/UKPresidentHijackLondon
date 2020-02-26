using System;
using UnityEngine;

namespace Heyzap
{
	// Token: 0x0200001B RID: 27
	public class HZIncentivizedAdAndroid : MonoBehaviour
	{
		// Token: 0x060000CC RID: 204 RVA: 0x000037BC File Offset: 0x000019BC
		public static void ShowWithOptions(HZIncentivizedShowOptions showOptions)
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return;
			}
			AndroidJNIHelper.debug = false;
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.heyzap.sdk.extensions.unity3d.UnityHelper"))
			{
				androidJavaClass.CallStatic("showIncentivized", new object[]
				{
					showOptions.Tag,
					showOptions.IncentivizedInfo
				});
			}
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000382C File Offset: 0x00001A2C
		public static void Fetch(string tag)
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return;
			}
			AndroidJNIHelper.debug = false;
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.heyzap.sdk.extensions.unity3d.UnityHelper"))
			{
				androidJavaClass.CallStatic("fetchIncentivized", new object[]
				{
					tag
				});
			}
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00003890 File Offset: 0x00001A90
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
				result = androidJavaClass.CallStatic<bool>("isIncentivizedAvailable", new object[]
				{
					tag
				});
			}
			return result;
		}
	}
}
