using System;
using System.Collections.Generic;

namespace GoogleMobileAds.Common
{
	// Token: 0x02000027 RID: 39
	public interface ICustomNativeTemplateClient
	{
		// Token: 0x06000219 RID: 537
		string GetTemplateId();

		// Token: 0x0600021A RID: 538
		byte[] GetImageByteArray(string key);

		// Token: 0x0600021B RID: 539
		List<string> GetAvailableAssetNames();

		// Token: 0x0600021C RID: 540
		string GetText(string key);

		// Token: 0x0600021D RID: 541
		void PerformClick(string assetName);

		// Token: 0x0600021E RID: 542
		void RecordImpression();
	}
}
