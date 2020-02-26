using System;
using System.Diagnostics;
using System.Reflection;
using GoogleMobileAds.Api;
using UnityEngine;

namespace GoogleMobileAds.Common
{
	// Token: 0x02000024 RID: 36
	public class DummyClient : IBannerClient, IInterstitialClient, IRewardBasedVideoAdClient, IAdLoaderClient, INativeExpressAdClient, IMobileAdsClient
	{
		// Token: 0x060001D9 RID: 473 RVA: 0x00007E0D File Offset: 0x0000620D
		public DummyClient()
		{
			UnityEngine.Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		// Token: 0x14000035 RID: 53
		// (add) Token: 0x060001DA RID: 474 RVA: 0x00007E30 File Offset: 0x00006230
		// (remove) Token: 0x060001DB RID: 475 RVA: 0x00007E68 File Offset: 0x00006268
		
		public event EventHandler<EventArgs> OnAdLoaded;

		// Token: 0x14000036 RID: 54
		// (add) Token: 0x060001DC RID: 476 RVA: 0x00007EA0 File Offset: 0x000062A0
		// (remove) Token: 0x060001DD RID: 477 RVA: 0x00007ED8 File Offset: 0x000062D8
		
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x14000037 RID: 55
		// (add) Token: 0x060001DE RID: 478 RVA: 0x00007F10 File Offset: 0x00006310
		// (remove) Token: 0x060001DF RID: 479 RVA: 0x00007F48 File Offset: 0x00006348
		
		public event EventHandler<EventArgs> OnAdOpening;

		// Token: 0x14000038 RID: 56
		// (add) Token: 0x060001E0 RID: 480 RVA: 0x00007F80 File Offset: 0x00006380
		// (remove) Token: 0x060001E1 RID: 481 RVA: 0x00007FB8 File Offset: 0x000063B8
		
		public event EventHandler<EventArgs> OnAdStarted;

		// Token: 0x14000039 RID: 57
		// (add) Token: 0x060001E2 RID: 482 RVA: 0x00007FF0 File Offset: 0x000063F0
		// (remove) Token: 0x060001E3 RID: 483 RVA: 0x00008028 File Offset: 0x00006428
		
		public event EventHandler<EventArgs> OnAdClosed;

		// Token: 0x1400003A RID: 58
		// (add) Token: 0x060001E4 RID: 484 RVA: 0x00008060 File Offset: 0x00006460
		// (remove) Token: 0x060001E5 RID: 485 RVA: 0x00008098 File Offset: 0x00006498
		
		public event EventHandler<Reward> OnAdRewarded;

		// Token: 0x1400003B RID: 59
		// (add) Token: 0x060001E6 RID: 486 RVA: 0x000080D0 File Offset: 0x000064D0
		// (remove) Token: 0x060001E7 RID: 487 RVA: 0x00008108 File Offset: 0x00006508
		
		public event EventHandler<EventArgs> OnAdLeavingApplication;

		// Token: 0x1400003C RID: 60
		// (add) Token: 0x060001E8 RID: 488 RVA: 0x00008140 File Offset: 0x00006540
		// (remove) Token: 0x060001E9 RID: 489 RVA: 0x00008178 File Offset: 0x00006578
		
		public event EventHandler<CustomNativeEventArgs> OnCustomNativeTemplateAdLoaded;

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060001EA RID: 490 RVA: 0x000081AE File Offset: 0x000065AE
		// (set) Token: 0x060001EB RID: 491 RVA: 0x000081CE File Offset: 0x000065CE
		public string UserId
		{
			get
			{
				UnityEngine.Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
				return "UserId";
			}
			set
			{
				UnityEngine.Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
			}
		}

		// Token: 0x060001EC RID: 492 RVA: 0x000081E9 File Offset: 0x000065E9
		public void Initialize(string appId)
		{
			UnityEngine.Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		// Token: 0x060001ED RID: 493 RVA: 0x00008204 File Offset: 0x00006604
		public void CreateBannerView(string adUnitId, AdSize adSize, AdPosition position)
		{
			UnityEngine.Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		// Token: 0x060001EE RID: 494 RVA: 0x0000821F File Offset: 0x0000661F
		public void CreateBannerView(string adUnitId, AdSize adSize, int positionX, int positionY)
		{
			UnityEngine.Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		// Token: 0x060001EF RID: 495 RVA: 0x0000823A File Offset: 0x0000663A
		public void LoadAd(AdRequest request)
		{
			UnityEngine.Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x00008255 File Offset: 0x00006655
		public void ShowBannerView()
		{
			UnityEngine.Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x00008270 File Offset: 0x00006670
		public void HideBannerView()
		{
			UnityEngine.Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x0000828B File Offset: 0x0000668B
		public void DestroyBannerView()
		{
			UnityEngine.Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x000082A6 File Offset: 0x000066A6
		public void CreateInterstitialAd(string adUnitId)
		{
			UnityEngine.Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x000082C1 File Offset: 0x000066C1
		public bool IsLoaded()
		{
			UnityEngine.Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
			return true;
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x000082DD File Offset: 0x000066DD
		public void ShowInterstitial()
		{
			UnityEngine.Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x000082F8 File Offset: 0x000066F8
		public void DestroyInterstitial()
		{
			UnityEngine.Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x00008313 File Offset: 0x00006713
		public void CreateRewardBasedVideoAd()
		{
			UnityEngine.Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x0000832E File Offset: 0x0000672E
		public void SetUserId(string userId)
		{
			UnityEngine.Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x00008349 File Offset: 0x00006749
		public void LoadAd(AdRequest request, string adUnitId)
		{
			UnityEngine.Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00008364 File Offset: 0x00006764
		public void DestroyRewardBasedVideoAd()
		{
			UnityEngine.Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0000837F File Offset: 0x0000677F
		public void ShowRewardBasedVideoAd()
		{
			UnityEngine.Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		// Token: 0x060001FC RID: 508 RVA: 0x0000839A File Offset: 0x0000679A
		public void CreateAdLoader(AdLoader.Builder builder)
		{
			UnityEngine.Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		// Token: 0x060001FD RID: 509 RVA: 0x000083B5 File Offset: 0x000067B5
		public void Load(AdRequest request)
		{
			UnityEngine.Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		// Token: 0x060001FE RID: 510 RVA: 0x000083D0 File Offset: 0x000067D0
		public void CreateNativeExpressAdView(string adUnitId, AdSize adSize, AdPosition position)
		{
			UnityEngine.Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		// Token: 0x060001FF RID: 511 RVA: 0x000083EB File Offset: 0x000067EB
		public void CreateNativeExpressAdView(string adUnitId, AdSize adSize, int positionX, int positionY)
		{
			UnityEngine.Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		// Token: 0x06000200 RID: 512 RVA: 0x00008406 File Offset: 0x00006806
		public void SetAdSize(AdSize adSize)
		{
			UnityEngine.Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		// Token: 0x06000201 RID: 513 RVA: 0x00008421 File Offset: 0x00006821
		public void ShowNativeExpressAdView()
		{
			UnityEngine.Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		// Token: 0x06000202 RID: 514 RVA: 0x0000843C File Offset: 0x0000683C
		public void HideNativeExpressAdView()
		{
			UnityEngine.Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		// Token: 0x06000203 RID: 515 RVA: 0x00008457 File Offset: 0x00006857
		public void DestroyNativeExpressAdView()
		{
			UnityEngine.Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}
	}
}
