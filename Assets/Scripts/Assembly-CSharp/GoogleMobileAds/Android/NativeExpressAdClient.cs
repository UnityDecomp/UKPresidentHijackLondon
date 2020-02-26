using System;
using System.Diagnostics;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	// Token: 0x02000032 RID: 50
	public class NativeExpressAdClient : AndroidJavaProxy, INativeExpressAdClient
	{
		// Token: 0x06000294 RID: 660 RVA: 0x0000905C File Offset: 0x0000745C
		public NativeExpressAdClient() : base("com.google.unity.ads.UnityAdListener")
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			this.nativeExpressAdView = new AndroidJavaObject("com.google.unity.ads.NativeExpressAd", new object[]
			{
				@static,
				this
			});
		}

		// Token: 0x14000061 RID: 97
		// (add) Token: 0x06000295 RID: 661 RVA: 0x000090AC File Offset: 0x000074AC
		// (remove) Token: 0x06000296 RID: 662 RVA: 0x000090E4 File Offset: 0x000074E4
		
		public event EventHandler<EventArgs> OnAdLoaded;

		// Token: 0x14000062 RID: 98
		// (add) Token: 0x06000297 RID: 663 RVA: 0x0000911C File Offset: 0x0000751C
		// (remove) Token: 0x06000298 RID: 664 RVA: 0x00009154 File Offset: 0x00007554
		
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x14000063 RID: 99
		// (add) Token: 0x06000299 RID: 665 RVA: 0x0000918C File Offset: 0x0000758C
		// (remove) Token: 0x0600029A RID: 666 RVA: 0x000091C4 File Offset: 0x000075C4
		
		public event EventHandler<EventArgs> OnAdOpening;

		// Token: 0x14000064 RID: 100
		// (add) Token: 0x0600029B RID: 667 RVA: 0x000091FC File Offset: 0x000075FC
		// (remove) Token: 0x0600029C RID: 668 RVA: 0x00009234 File Offset: 0x00007634
		
		public event EventHandler<EventArgs> OnAdClosed;

		// Token: 0x14000065 RID: 101
		// (add) Token: 0x0600029D RID: 669 RVA: 0x0000926C File Offset: 0x0000766C
		// (remove) Token: 0x0600029E RID: 670 RVA: 0x000092A4 File Offset: 0x000076A4
		
		public event EventHandler<EventArgs> OnAdLeavingApplication;

		// Token: 0x0600029F RID: 671 RVA: 0x000092DA File Offset: 0x000076DA
		public void CreateNativeExpressAdView(string adUnitId, AdSize adSize, AdPosition position)
		{
			this.nativeExpressAdView.Call("create", new object[]
			{
				adUnitId,
				Utils.GetAdSizeJavaObject(adSize),
				(int)position
			});
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x00009308 File Offset: 0x00007708
		public void CreateNativeExpressAdView(string adUnitId, AdSize adSize, int x, int y)
		{
			this.nativeExpressAdView.Call("create", new object[]
			{
				adUnitId,
				Utils.GetAdSizeJavaObject(adSize),
				x,
				y
			});
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x00009340 File Offset: 0x00007740
		public void LoadAd(AdRequest request)
		{
			this.nativeExpressAdView.Call("loadAd", new object[]
			{
				Utils.GetAdRequestJavaObject(request)
			});
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x00009361 File Offset: 0x00007761
		public void SetAdSize(AdSize adSize)
		{
			this.nativeExpressAdView.Call("setAdSize", new object[]
			{
				Utils.GetAdSizeJavaObject(adSize)
			});
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x00009382 File Offset: 0x00007782
		public void ShowNativeExpressAdView()
		{
			this.nativeExpressAdView.Call("show", new object[0]);
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0000939A File Offset: 0x0000779A
		public void HideNativeExpressAdView()
		{
			this.nativeExpressAdView.Call("hide", new object[0]);
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x000093B2 File Offset: 0x000077B2
		public void DestroyNativeExpressAdView()
		{
			this.nativeExpressAdView.Call("destroy", new object[0]);
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x000093CA File Offset: 0x000077CA
		public void onAdLoaded()
		{
			if (this.OnAdLoaded != null)
			{
				this.OnAdLoaded(this, EventArgs.Empty);
			}
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x000093E8 File Offset: 0x000077E8
		public void onAdFailedToLoad(string errorReason)
		{
			if (this.OnAdFailedToLoad != null)
			{
				AdFailedToLoadEventArgs e = new AdFailedToLoadEventArgs
				{
					Message = errorReason
				};
				this.OnAdFailedToLoad(this, e);
			}
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0000941C File Offset: 0x0000781C
		public void onAdOpened()
		{
			if (this.OnAdOpening != null)
			{
				this.OnAdOpening(this, EventArgs.Empty);
			}
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x0000943A File Offset: 0x0000783A
		public void onAdClosed()
		{
			if (this.OnAdClosed != null)
			{
				this.OnAdClosed(this, EventArgs.Empty);
			}
		}

		// Token: 0x060002AA RID: 682 RVA: 0x00009458 File Offset: 0x00007858
		public void onAdLeftApplication()
		{
			if (this.OnAdLeavingApplication != null)
			{
				this.OnAdLeavingApplication(this, EventArgs.Empty);
			}
		}

		// Token: 0x04000126 RID: 294
		private AndroidJavaObject nativeExpressAdView;
	}
}
