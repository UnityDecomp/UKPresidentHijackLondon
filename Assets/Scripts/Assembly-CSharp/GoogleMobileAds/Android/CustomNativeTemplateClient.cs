using System;
using System.Collections.Generic;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	// Token: 0x0200002F RID: 47
	internal class CustomNativeTemplateClient : ICustomNativeTemplateClient
	{
		// Token: 0x06000274 RID: 628 RVA: 0x00008B5A File Offset: 0x00006F5A
		public CustomNativeTemplateClient(AndroidJavaObject customNativeAd)
		{
			this.customNativeAd = customNativeAd;
		}

		// Token: 0x06000275 RID: 629 RVA: 0x00008B69 File Offset: 0x00006F69
		public List<string> GetAvailableAssetNames()
		{
			return new List<string>(this.customNativeAd.Call<string[]>("getAvailableAssetNames", new object[0]));
		}

		// Token: 0x06000276 RID: 630 RVA: 0x00008B86 File Offset: 0x00006F86
		public string GetTemplateId()
		{
			return this.customNativeAd.Call<string>("getTemplateId", new object[0]);
		}

		// Token: 0x06000277 RID: 631 RVA: 0x00008BA0 File Offset: 0x00006FA0
		public byte[] GetImageByteArray(string key)
		{
			byte[] array = this.customNativeAd.Call<byte[]>("getImage", new object[]
			{
				key
			});
			if (array.Length == 0)
			{
				return null;
			}
			return array;
		}

		// Token: 0x06000278 RID: 632 RVA: 0x00008BD4 File Offset: 0x00006FD4
		public string GetText(string key)
		{
			string text = this.customNativeAd.Call<string>("getText", new object[]
			{
				key
			});
			if (text.Equals(string.Empty))
			{
				return null;
			}
			return text;
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00008C0F File Offset: 0x0000700F
		public void PerformClick(string assetName)
		{
			this.customNativeAd.Call("performClick", new object[]
			{
				assetName
			});
		}

		// Token: 0x0600027A RID: 634 RVA: 0x00008C2B File Offset: 0x0000702B
		public void RecordImpression()
		{
			this.customNativeAd.Call("recordImpression", new object[0]);
		}

		// Token: 0x0400011E RID: 286
		private AndroidJavaObject customNativeAd;
	}
}
