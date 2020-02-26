using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using GoogleMobileAds.Common;

namespace GoogleMobileAds.Api
{
	// Token: 0x02000014 RID: 20
	public class AdLoader
	{
		// Token: 0x0600011E RID: 286 RVA: 0x00006650 File Offset: 0x00004A50
		private AdLoader(AdLoader.Builder builder)
		{
			this.AdUnitId = string.Copy(builder.AdUnitId);
			this.CustomNativeTemplateClickHandlers = new Dictionary<string, Action<CustomNativeTemplateAd, string>>(builder.CustomNativeTemplateClickHandlers);
			this.TemplateIds = new HashSet<string>(builder.TemplateIds);
			this.AdTypes = new HashSet<NativeAdType>(builder.AdTypes);
			Type type = Type.GetType("GoogleMobileAds.GoogleMobileAdsClientFactory,Assembly-CSharp");
			MethodInfo method = type.GetMethod("BuildAdLoaderClient", BindingFlags.Static | BindingFlags.Public);
			this.adLoaderClient = (IAdLoaderClient)method.Invoke(null, new object[]
			{
				this
			});
			this.adLoaderClient.OnCustomNativeTemplateAdLoaded += delegate(object sender, CustomNativeEventArgs args)
			{
				if (this.OnCustomNativeTemplateAdLoaded != null)
				{
					this.OnCustomNativeTemplateAdLoaded(this, args);
				}
			};
			this.adLoaderClient.OnAdFailedToLoad += delegate(object sender, AdFailedToLoadEventArgs args)
			{
				if (this.OnAdFailedToLoad != null)
				{
					this.OnAdFailedToLoad(this, args);
				}
			};
		}

		// Token: 0x1400001D RID: 29
		// (add) Token: 0x0600011F RID: 287 RVA: 0x0000670C File Offset: 0x00004B0C
		// (remove) Token: 0x06000120 RID: 288 RVA: 0x00006744 File Offset: 0x00004B44
		
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x1400001E RID: 30
		// (add) Token: 0x06000121 RID: 289 RVA: 0x0000677C File Offset: 0x00004B7C
		// (remove) Token: 0x06000122 RID: 290 RVA: 0x000067B4 File Offset: 0x00004BB4
		
		public event EventHandler<CustomNativeEventArgs> OnCustomNativeTemplateAdLoaded;

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000123 RID: 291 RVA: 0x000067EA File Offset: 0x00004BEA
		// (set) Token: 0x06000124 RID: 292 RVA: 0x000067F2 File Offset: 0x00004BF2
		public Dictionary<string, Action<CustomNativeTemplateAd, string>> CustomNativeTemplateClickHandlers { get; private set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000125 RID: 293 RVA: 0x000067FB File Offset: 0x00004BFB
		// (set) Token: 0x06000126 RID: 294 RVA: 0x00006803 File Offset: 0x00004C03
		public string AdUnitId { get; private set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000127 RID: 295 RVA: 0x0000680C File Offset: 0x00004C0C
		// (set) Token: 0x06000128 RID: 296 RVA: 0x00006814 File Offset: 0x00004C14
		public HashSet<NativeAdType> AdTypes { get; private set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000129 RID: 297 RVA: 0x0000681D File Offset: 0x00004C1D
		// (set) Token: 0x0600012A RID: 298 RVA: 0x00006825 File Offset: 0x00004C25
		public HashSet<string> TemplateIds { get; private set; }

		// Token: 0x0600012B RID: 299 RVA: 0x0000682E File Offset: 0x00004C2E
		public void LoadAd(AdRequest request)
		{
			this.adLoaderClient.LoadAd(request);
		}

		// Token: 0x040000BB RID: 187
		private IAdLoaderClient adLoaderClient;

		// Token: 0x02000015 RID: 21
		public class Builder
		{
			// Token: 0x0600012E RID: 302 RVA: 0x00006870 File Offset: 0x00004C70
			public Builder(string adUnitId)
			{
				this.AdUnitId = adUnitId;
				this.AdTypes = new HashSet<NativeAdType>();
				this.TemplateIds = new HashSet<string>();
				this.CustomNativeTemplateClickHandlers = new Dictionary<string, Action<CustomNativeTemplateAd, string>>();
			}

			// Token: 0x1700000D RID: 13
			// (get) Token: 0x0600012F RID: 303 RVA: 0x000068A0 File Offset: 0x00004CA0
			// (set) Token: 0x06000130 RID: 304 RVA: 0x000068A8 File Offset: 0x00004CA8
			internal string AdUnitId { get; private set; }

			// Token: 0x1700000E RID: 14
			// (get) Token: 0x06000131 RID: 305 RVA: 0x000068B1 File Offset: 0x00004CB1
			// (set) Token: 0x06000132 RID: 306 RVA: 0x000068B9 File Offset: 0x00004CB9
			internal HashSet<NativeAdType> AdTypes { get; private set; }

			// Token: 0x1700000F RID: 15
			// (get) Token: 0x06000133 RID: 307 RVA: 0x000068C2 File Offset: 0x00004CC2
			// (set) Token: 0x06000134 RID: 308 RVA: 0x000068CA File Offset: 0x00004CCA
			internal HashSet<string> TemplateIds { get; private set; }

			// Token: 0x17000010 RID: 16
			// (get) Token: 0x06000135 RID: 309 RVA: 0x000068D3 File Offset: 0x00004CD3
			// (set) Token: 0x06000136 RID: 310 RVA: 0x000068DB File Offset: 0x00004CDB
			internal Dictionary<string, Action<CustomNativeTemplateAd, string>> CustomNativeTemplateClickHandlers { get; private set; }

			// Token: 0x06000137 RID: 311 RVA: 0x000068E4 File Offset: 0x00004CE4
			public AdLoader.Builder ForCustomNativeAd(string templateId)
			{
				this.TemplateIds.Add(templateId);
				this.AdTypes.Add(NativeAdType.CustomTemplate);
				return this;
			}

			// Token: 0x06000138 RID: 312 RVA: 0x00006901 File Offset: 0x00004D01
			public AdLoader.Builder ForCustomNativeAd(string templateId, Action<CustomNativeTemplateAd, string> callback)
			{
				this.TemplateIds.Add(templateId);
				this.CustomNativeTemplateClickHandlers[templateId] = callback;
				this.AdTypes.Add(NativeAdType.CustomTemplate);
				return this;
			}

			// Token: 0x06000139 RID: 313 RVA: 0x0000692B File Offset: 0x00004D2B
			public AdLoader Build()
			{
				return new AdLoader(this);
			}
		}
	}
}
