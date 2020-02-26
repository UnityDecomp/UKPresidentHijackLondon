using System;
using UnityEngine;

namespace ChartboostSDK
{
	// Token: 0x02000005 RID: 5
	public class CBInPlay
	{
		// Token: 0x0600005E RID: 94 RVA: 0x00003DFC File Offset: 0x000021FC
		public CBInPlay(AndroidJavaObject inPlayAd, AndroidJavaObject plugin)
		{
			this.androidInPlayAd = inPlayAd;
			this.appName = this.androidInPlayAd.Call<string>("getAppName", new object[0]);
			string s = plugin.Call<string>("getBitmapAsString", new object[]
			{
				this.androidInPlayAd.Call<AndroidJavaObject>("getAppIcon", new object[0])
			});
			this.appIcon = new Texture2D(4, 4);
			this.appIcon.LoadImage(Convert.FromBase64String(s));
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00003E7C File Offset: 0x0000227C
		public void show()
		{
			this.androidInPlayAd.Call("show", new object[0]);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00003E94 File Offset: 0x00002294
		public void click()
		{
			this.androidInPlayAd.Call("click", new object[0]);
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00003EAC File Offset: 0x000022AC
		~CBInPlay()
		{
		}

		// Token: 0x04000021 RID: 33
		public Texture2D appIcon;

		// Token: 0x04000022 RID: 34
		public string appName;

		// Token: 0x04000023 RID: 35
		private IntPtr inPlayUniqueId;

		// Token: 0x04000024 RID: 36
		private AndroidJavaObject androidInPlayAd;
	}
}
