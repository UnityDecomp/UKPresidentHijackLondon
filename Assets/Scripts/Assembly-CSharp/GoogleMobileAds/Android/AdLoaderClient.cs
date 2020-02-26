using System;
using System.Collections.Generic;
using System.Diagnostics;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	// Token: 0x0200002D RID: 45
	public class AdLoaderClient : AndroidJavaProxy, IAdLoaderClient
	{
		// Token: 0x06000253 RID: 595 RVA: 0x000084AC File Offset: 0x000068AC
		public AdLoaderClient(AdLoader unityAdLoader) : base("com.google.unity.ads.UnityAdLoaderListener")
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			this.adLoader = new AndroidJavaObject("com.google.unity.ads.NativeAdLoader", new object[]
			{
				@static,
				unityAdLoader.AdUnitId,
				this
			});
			this.CustomNativeTemplateCallbacks = unityAdLoader.CustomNativeTemplateClickHandlers;
			if (unityAdLoader.AdTypes.Contains(NativeAdType.CustomTemplate))
			{
				foreach (string text in unityAdLoader.TemplateIds)
				{
					this.adLoader.Call("configureCustomNativeTemplateAd", new object[]
					{
						text,
						this.CustomNativeTemplateCallbacks.ContainsKey(text)
					});
				}
			}
			this.adLoader.Call("create", new object[0]);
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000254 RID: 596 RVA: 0x000085AC File Offset: 0x000069AC
		// (set) Token: 0x06000255 RID: 597 RVA: 0x000085B4 File Offset: 0x000069B4
		private Dictionary<string, Action<CustomNativeTemplateAd, string>> CustomNativeTemplateCallbacks { get; set; }

		// Token: 0x14000055 RID: 85
		// (add) Token: 0x06000256 RID: 598 RVA: 0x000085C0 File Offset: 0x000069C0
		// (remove) Token: 0x06000257 RID: 599 RVA: 0x000085F8 File Offset: 0x000069F8
		
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x14000056 RID: 86
		// (add) Token: 0x06000258 RID: 600 RVA: 0x00008630 File Offset: 0x00006A30
		// (remove) Token: 0x06000259 RID: 601 RVA: 0x00008668 File Offset: 0x00006A68
		
		public event EventHandler<CustomNativeEventArgs> OnCustomNativeTemplateAdLoaded;

		// Token: 0x0600025A RID: 602 RVA: 0x0000869E File Offset: 0x00006A9E
		public void LoadAd(AdRequest request)
		{
			this.adLoader.Call("loadAd", new object[]
			{
				Utils.GetAdRequestJavaObject(request)
			});
		}

		// Token: 0x0600025B RID: 603 RVA: 0x000086C0 File Offset: 0x00006AC0
		public void onCustomTemplateAdLoaded(AndroidJavaObject ad)
		{
			if (this.OnCustomNativeTemplateAdLoaded != null)
			{
				CustomNativeEventArgs e = new CustomNativeEventArgs
				{
					nativeAd = new CustomNativeTemplateAd(new CustomNativeTemplateClient(ad))
				};
				this.OnCustomNativeTemplateAdLoaded(this, e);
			}
		}

		// Token: 0x0600025C RID: 604 RVA: 0x00008700 File Offset: 0x00006B00
		private void onAdFailedToLoad(string errorReason)
		{
			AdFailedToLoadEventArgs e = new AdFailedToLoadEventArgs
			{
				Message = errorReason
			};
			this.OnAdFailedToLoad(this, e);
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0000872C File Offset: 0x00006B2C
		public void onCustomClick(AndroidJavaObject ad, string assetName)
		{
			CustomNativeTemplateAd customNativeTemplateAd = new CustomNativeTemplateAd(new CustomNativeTemplateClient(ad));
			this.CustomNativeTemplateCallbacks[customNativeTemplateAd.GetCustomTemplateId()](customNativeTemplateAd, assetName);
		}

		// Token: 0x04000114 RID: 276
		private AndroidJavaObject adLoader;
	}
}
