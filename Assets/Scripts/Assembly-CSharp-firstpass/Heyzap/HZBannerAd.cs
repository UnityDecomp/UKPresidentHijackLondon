using System;
using UnityEngine;

namespace Heyzap
{
	// Token: 0x02000016 RID: 22
	public class HZBannerAd : MonoBehaviour
	{
		// Token: 0x0600009C RID: 156 RVA: 0x0000334C File Offset: 0x0000154C
		public static void ShowWithOptions(HZBannerShowOptions showOptions)
		{
			if (showOptions == null)
			{
				showOptions = new HZBannerShowOptions();
			}
			HZBannerAdAndroid.ShowWithOptions(showOptions);
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00003361 File Offset: 0x00001561
		public static bool GetCurrentBannerDimensions(out Rect banner)
		{
			return HZBannerAdAndroid.GetCurrentBannerDimensions(out banner);
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00003369 File Offset: 0x00001569
		public static void Hide()
		{
			HZBannerAdAndroid.Hide();
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00003370 File Offset: 0x00001570
		public static void Destroy()
		{
			HZBannerAdAndroid.Destroy();
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00003377 File Offset: 0x00001577
		public static void SetDisplayListener(HZBannerAd.AdDisplayListener listener)
		{
			HZBannerAd.adDisplayListener = listener;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00003380 File Offset: 0x00001580
		public static void InitReceiver()
		{
			if (HZBannerAd._instance == null)
			{
				GameObject gameObject = new GameObject("HZBannerAd");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				HZBannerAd._instance = gameObject.AddComponent<HZBannerAd>();
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000033BC File Offset: 0x000015BC
		public void SetCallback(string message)
		{
			string[] array = message.Split(new char[]
			{
				','
			});
			HZBannerAd.SetCallbackStateAndTag(array[0], array[1]);
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000033E6 File Offset: 0x000015E6
		protected static void SetCallbackStateAndTag(string state, string tag)
		{
			if (HZBannerAd.adDisplayListener != null)
			{
				HZBannerAd.adDisplayListener(state, tag);
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00003400 File Offset: 0x00001600
		[Obsolete("Use ShowWithOptions() to show ads instead of this deprecated method.")]
		public static void showWithTag(string position, string tag)
		{
			HZBannerAd.ShowWithOptions(new HZBannerShowOptions
			{
				Position = position,
				Tag = tag
			});
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00003428 File Offset: 0x00001628
		[Obsolete("Use ShowWithOptions() to show ads instead of this deprecated method.")]
		public static void show(string position)
		{
			HZBannerAd.ShowWithOptions(new HZBannerShowOptions
			{
				Position = position
			});
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00003448 File Offset: 0x00001648
		[Obsolete("Use the GetCurrentBannerDimensions(out Rect) method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static bool getCurrentBannerDimensions(out Rect banner)
		{
			return HZBannerAd.GetCurrentBannerDimensions(out banner);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00003450 File Offset: 0x00001650
		[Obsolete("Use the Hide() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void hide()
		{
			HZBannerAd.Hide();
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00003457 File Offset: 0x00001657
		[Obsolete("Use the Destroy() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void destroy()
		{
			HZBannerAd.Destroy();
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000345E File Offset: 0x0000165E
		[Obsolete("Use the SetDisplayListener(AdDisplayListener) method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void setDisplayListener(HZBannerAd.AdDisplayListener listener)
		{
			HZBannerAd.SetDisplayListener(listener);
		}

		// Token: 0x04000081 RID: 129
		private static HZBannerAd.AdDisplayListener adDisplayListener;

		// Token: 0x04000082 RID: 130
		private static HZBannerAd _instance;

		// Token: 0x04000083 RID: 131
		[Obsolete("This constant has been relocated to HZBannerShowOptions")]
		public const string POSITION_TOP = "top";

		// Token: 0x04000084 RID: 132
		[Obsolete("This constant has been relocated to HZBannerShowOptions")]
		public const string POSITION_BOTTOM = "bottom";

		// Token: 0x02000017 RID: 23
		// (Invoke) Token: 0x060000AC RID: 172
		public delegate void AdDisplayListener(string state, string tag);
	}
}
