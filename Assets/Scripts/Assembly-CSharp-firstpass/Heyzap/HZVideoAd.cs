using System;
using UnityEngine;

namespace Heyzap
{
	// Token: 0x02000022 RID: 34
	public class HZVideoAd : MonoBehaviour
	{
		// Token: 0x060000FD RID: 253 RVA: 0x00003D84 File Offset: 0x00001F84
		public static void Show()
		{
			HZVideoAd.ShowWithOptions(null);
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00003D8C File Offset: 0x00001F8C
		public static void ShowWithOptions(HZShowOptions showOptions)
		{
			if (showOptions == null)
			{
				showOptions = new HZShowOptions();
			}
			HZVideoAdAndroid.ShowWithOptions(showOptions);
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00003DA1 File Offset: 0x00001FA1
		public static void Fetch()
		{
			HZVideoAd.Fetch(null);
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00003DA9 File Offset: 0x00001FA9
		public static void Fetch(string tag)
		{
			tag = HeyzapAds.TagForString(tag);
			HZVideoAdAndroid.Fetch(tag);
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00003DB9 File Offset: 0x00001FB9
		public static bool IsAvailable()
		{
			return HZVideoAd.IsAvailable(null);
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00003DC1 File Offset: 0x00001FC1
		public static bool IsAvailable(string tag)
		{
			tag = HeyzapAds.TagForString(tag);
			return HZVideoAdAndroid.IsAvailable(tag);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00003DD1 File Offset: 0x00001FD1
		public static void SetDisplayListener(HZVideoAd.AdDisplayListener listener)
		{
			HZVideoAd.adDisplayListener = listener;
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00003DDC File Offset: 0x00001FDC
		public static void InitReceiver()
		{
			if (HZVideoAd._instance == null)
			{
				GameObject gameObject = new GameObject("HZVideoAd");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				HZVideoAd._instance = gameObject.AddComponent<HZVideoAd>();
			}
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00003E18 File Offset: 0x00002018
		public void SetCallback(string message)
		{
			string[] array = message.Split(new char[]
			{
				','
			});
			HZVideoAd.SetCallbackStateAndTag(array[0], array[1]);
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00003E42 File Offset: 0x00002042
		protected static void SetCallbackStateAndTag(string state, string tag)
		{
			if (HZVideoAd.adDisplayListener != null)
			{
				HZVideoAd.adDisplayListener(state, tag);
			}
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00003E5A File Offset: 0x0000205A
		[Obsolete("Use the Fetch() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void fetch()
		{
			HZVideoAd.Fetch();
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00003E61 File Offset: 0x00002061
		[Obsolete("Use the Fetch(string) method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void fetch(string tag)
		{
			HZVideoAd.Fetch(tag);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00003E69 File Offset: 0x00002069
		[Obsolete("Use the Show() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void show()
		{
			HZVideoAd.Show();
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00003E70 File Offset: 0x00002070
		[Obsolete("Use ShowWithOptions() to show ads instead of this deprecated method.")]
		public static void show(string tag)
		{
			HZVideoAd.ShowWithOptions(new HZIncentivizedShowOptions
			{
				Tag = tag
			});
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00003E90 File Offset: 0x00002090
		[Obsolete("Use the IsAvailable() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static bool isAvailable()
		{
			return HZVideoAd.IsAvailable();
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00003E97 File Offset: 0x00002097
		[Obsolete("Use the IsAvailable(tag) method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static bool isAvailable(string tag)
		{
			return HZVideoAd.IsAvailable(tag);
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00003E9F File Offset: 0x0000209F
		[Obsolete("Use the SetDisplayListener(AdDisplayListener) method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void setDisplayListener(HZVideoAd.AdDisplayListener listener)
		{
			HZVideoAd.SetDisplayListener(listener);
		}

		// Token: 0x04000090 RID: 144
		private static HZVideoAd.AdDisplayListener adDisplayListener;

		// Token: 0x04000091 RID: 145
		private static HZVideoAd _instance;

		// Token: 0x02000023 RID: 35
		// (Invoke) Token: 0x06000110 RID: 272
		public delegate void AdDisplayListener(string state, string tag);
	}
}
