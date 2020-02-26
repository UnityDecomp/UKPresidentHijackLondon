using System;
using System.Collections.Generic;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Api
{
	// Token: 0x0200001C RID: 28
	public class CustomNativeTemplateAd
	{
		// Token: 0x0600017F RID: 383 RVA: 0x00007053 File Offset: 0x00005453
		internal CustomNativeTemplateAd(ICustomNativeTemplateClient client)
		{
			this.client = client;
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00007062 File Offset: 0x00005462
		public List<string> GetAvailableAssetNames()
		{
			return this.client.GetAvailableAssetNames();
		}

		// Token: 0x06000181 RID: 385 RVA: 0x0000706F File Offset: 0x0000546F
		public string GetCustomTemplateId()
		{
			return this.client.GetTemplateId();
		}

		// Token: 0x06000182 RID: 386 RVA: 0x0000707C File Offset: 0x0000547C
		public Texture2D GetTexture2D(string key)
		{
			byte[] imageByteArray = this.client.GetImageByteArray(key);
			if (imageByteArray == null)
			{
				return null;
			}
			return Utils.GetTexture2DFromByteArray(imageByteArray);
		}

		// Token: 0x06000183 RID: 387 RVA: 0x000070A4 File Offset: 0x000054A4
		public string GetText(string key)
		{
			return this.client.GetText(key);
		}

		// Token: 0x06000184 RID: 388 RVA: 0x000070B2 File Offset: 0x000054B2
		public void PerformClick(string assetName)
		{
			this.client.PerformClick(assetName);
		}

		// Token: 0x06000185 RID: 389 RVA: 0x000070C0 File Offset: 0x000054C0
		public void RecordImpression()
		{
			this.client.RecordImpression();
		}

		// Token: 0x040000EE RID: 238
		private ICustomNativeTemplateClient client;
	}
}
