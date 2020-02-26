using System;
using UnityEngine;

namespace Heyzap
{
	// Token: 0x0200001C RID: 28
	public class HZInterstitialAd : MonoBehaviour
	{
		// Token: 0x060000D0 RID: 208 RVA: 0x00003900 File Offset: 0x00001B00
		public static void Show()
		{
			HZInterstitialAd.ShowWithOptions(null);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00003908 File Offset: 0x00001B08
		public static void ShowWithOptions(HZShowOptions showOptions)
		{
			if (showOptions == null)
			{
				showOptions = new HZShowOptions();
			}
			HZInterstitialAdAndroid.ShowWithOptions(showOptions);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000391D File Offset: 0x00001B1D
		public static void Fetch()
		{
			HZInterstitialAd.Fetch(null);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00003925 File Offset: 0x00001B25
		public static void Fetch(string tag)
		{
			tag = HeyzapAds.TagForString(tag);
			HZInterstitialAdAndroid.Fetch(tag);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00003935 File Offset: 0x00001B35
		public static bool IsAvailable()
		{
			return HZInterstitialAd.IsAvailable(null);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000393D File Offset: 0x00001B3D
		public static bool IsAvailable(string tag)
		{
			tag = HeyzapAds.TagForString(tag);
			return HZInterstitialAdAndroid.IsAvailable(tag);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000394D File Offset: 0x00001B4D
		public static void SetDisplayListener(HZInterstitialAd.AdDisplayListener listener)
		{
			HZInterstitialAd.adDisplayListener = listener;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00003955 File Offset: 0x00001B55
		public static void ChartboostFetchForLocation(string location)
		{
			HZInterstitialAdAndroid.chartboostFetchForLocation(location);
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000395D File Offset: 0x00001B5D
		public static bool ChartboostIsAvailableForLocation(string location)
		{
			return HZInterstitialAdAndroid.chartboostIsAvailableForLocation(location);
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00003965 File Offset: 0x00001B65
		public static void ChartboostShowForLocation(string location)
		{
			HZInterstitialAdAndroid.chartboostShowForLocation(location);
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00003970 File Offset: 0x00001B70
		public static void InitReceiver()
		{
			if (HZInterstitialAd._instance == null)
			{
				GameObject gameObject = new GameObject("HZInterstitialAd");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				HZInterstitialAd._instance = gameObject.AddComponent<HZInterstitialAd>();
			}
		}

		// Token: 0x060000DB RID: 219 RVA: 0x000039AC File Offset: 0x00001BAC
		public void SetCallback(string message)
		{
			string[] array = message.Split(new char[]
			{
				','
			});
			HZInterstitialAd.SetCallbackStateAndTag(array[0], array[1]);
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000039D6 File Offset: 0x00001BD6
		protected static void SetCallbackStateAndTag(string state, string tag)
		{
			if (HZInterstitialAd.adDisplayListener != null)
			{
				HZInterstitialAd.adDisplayListener(state, tag);
			}
		}

		// Token: 0x060000DD RID: 221 RVA: 0x000039EE File Offset: 0x00001BEE
		[Obsolete("Use the Fetch() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void fetch()
		{
			HZInterstitialAd.Fetch();
		}

		// Token: 0x060000DE RID: 222 RVA: 0x000039F5 File Offset: 0x00001BF5
		[Obsolete("Use the Fetch(string) method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void fetch(string tag)
		{
			HZInterstitialAd.Fetch(tag);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x000039FD File Offset: 0x00001BFD
		[Obsolete("Use the Show() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void show()
		{
			HZInterstitialAd.Show();
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00003A04 File Offset: 0x00001C04
		[Obsolete("Use ShowWithOptions() to show ads instead of this deprecated method.")]
		public static void show(string tag)
		{
			HZInterstitialAd.ShowWithOptions(new HZIncentivizedShowOptions
			{
				Tag = tag
			});
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00003A24 File Offset: 0x00001C24
		[Obsolete("Use the IsAvailable() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static bool isAvailable()
		{
			return HZInterstitialAd.IsAvailable();
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00003A2B File Offset: 0x00001C2B
		[Obsolete("Use the IsAvailable(tag) method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static bool isAvailable(string tag)
		{
			return HZInterstitialAd.IsAvailable(tag);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00003A33 File Offset: 0x00001C33
		[Obsolete("Use the SetDisplayListener(AdDisplayListener) method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void setDisplayListener(HZInterstitialAd.AdDisplayListener listener)
		{
			HZInterstitialAd.SetDisplayListener(listener);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00003A3B File Offset: 0x00001C3B
		[Obsolete("Use the ChartboostFetchForLocation(string) method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void chartboostFetchForLocation(string location)
		{
			HZInterstitialAd.ChartboostFetchForLocation(location);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00003A43 File Offset: 0x00001C43
		[Obsolete("Use the ChartboostIsAvailableForLocation(string) method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static bool chartboostIsAvailableForLocation(string location)
		{
			return HZInterstitialAd.ChartboostIsAvailableForLocation(location);
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00003A4B File Offset: 0x00001C4B
		[Obsolete("Use the ChartboostShowForLocation(string) method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void chartboostShowForLocation(string location)
		{
			HZInterstitialAd.ChartboostShowForLocation(location);
		}

		// Token: 0x04000087 RID: 135
		private static HZInterstitialAd.AdDisplayListener adDisplayListener;

		// Token: 0x04000088 RID: 136
		private static HZInterstitialAd _instance;

		// Token: 0x0200001D RID: 29
		// (Invoke) Token: 0x060000E9 RID: 233
		public delegate void AdDisplayListener(string state, string tag);
	}
}
