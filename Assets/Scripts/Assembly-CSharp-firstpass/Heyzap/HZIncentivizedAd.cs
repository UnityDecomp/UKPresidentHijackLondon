using System;
using UnityEngine;

namespace Heyzap
{
	// Token: 0x02000019 RID: 25
	public class HZIncentivizedAd : MonoBehaviour
	{
		// Token: 0x060000B5 RID: 181 RVA: 0x0000368C File Offset: 0x0000188C
		public static void Fetch()
		{
			HZIncentivizedAd.Fetch(null);
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00003694 File Offset: 0x00001894
		public static void Fetch(string tag)
		{
			tag = HeyzapAds.TagForString(tag);
			HZIncentivizedAdAndroid.Fetch(tag);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x000036A4 File Offset: 0x000018A4
		public static void Show()
		{
			HZIncentivizedAd.ShowWithOptions(null);
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x000036AC File Offset: 0x000018AC
		public static void ShowWithOptions(HZIncentivizedShowOptions showOptions)
		{
			if (showOptions == null)
			{
				showOptions = new HZIncentivizedShowOptions();
			}
			HZIncentivizedAdAndroid.ShowWithOptions(showOptions);
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x000036C1 File Offset: 0x000018C1
		public static bool IsAvailable()
		{
			return HZIncentivizedAd.IsAvailable(null);
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000036C9 File Offset: 0x000018C9
		public static bool IsAvailable(string tag)
		{
			tag = HeyzapAds.TagForString(tag);
			return HZIncentivizedAdAndroid.IsAvailable(tag);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x000036D9 File Offset: 0x000018D9
		public static void SetDisplayListener(HZIncentivizedAd.AdDisplayListener listener)
		{
			HZIncentivizedAd.adDisplayListener = listener;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x000036E4 File Offset: 0x000018E4
		public static void InitReceiver()
		{
			if (HZIncentivizedAd._instance == null)
			{
				GameObject gameObject = new GameObject("HZIncentivizedAd");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				HZIncentivizedAd._instance = gameObject.AddComponent<HZIncentivizedAd>();
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00003720 File Offset: 0x00001920
		public void SetCallback(string message)
		{
			string[] array = message.Split(new char[]
			{
				','
			});
			HZIncentivizedAd.SetCallbackStateAndTag(array[0], array[1]);
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000374A File Offset: 0x0000194A
		protected static void SetCallbackStateAndTag(string state, string tag)
		{
			if (HZIncentivizedAd.adDisplayListener != null)
			{
				HZIncentivizedAd.adDisplayListener(state, tag);
			}
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00003762 File Offset: 0x00001962
		[Obsolete("Use the Fetch() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void fetch()
		{
			HZIncentivizedAd.Fetch();
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00003769 File Offset: 0x00001969
		[Obsolete("Use the Fetch(string) method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void fetch(string tag)
		{
			HZIncentivizedAd.Fetch(tag);
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00003771 File Offset: 0x00001971
		[Obsolete("Use the Show() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void show()
		{
			HZIncentivizedAd.Show();
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00003778 File Offset: 0x00001978
		[Obsolete("Use ShowWithOptions() to show ads instead of this deprecated method.")]
		public static void show(string tag)
		{
			HZIncentivizedAd.ShowWithOptions(new HZIncentivizedShowOptions
			{
				Tag = tag
			});
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00003798 File Offset: 0x00001998
		[Obsolete("Use the IsAvailable() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static bool isAvailable()
		{
			return HZIncentivizedAd.IsAvailable();
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000379F File Offset: 0x0000199F
		[Obsolete("Use the IsAvailable(tag) method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static bool isAvailable(string tag)
		{
			return HZIncentivizedAd.IsAvailable(tag);
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x000037A7 File Offset: 0x000019A7
		[Obsolete("Use the SetDisplayListener(AdDisplayListener) method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void setDisplayListener(HZIncentivizedAd.AdDisplayListener listener)
		{
			HZIncentivizedAd.SetDisplayListener(listener);
		}

		// Token: 0x04000085 RID: 133
		private static HZIncentivizedAd.AdDisplayListener adDisplayListener;

		// Token: 0x04000086 RID: 134
		private static HZIncentivizedAd _instance;

		// Token: 0x0200001A RID: 26
		// (Invoke) Token: 0x060000C8 RID: 200
		public delegate void AdDisplayListener(string state, string tag);
	}
}
