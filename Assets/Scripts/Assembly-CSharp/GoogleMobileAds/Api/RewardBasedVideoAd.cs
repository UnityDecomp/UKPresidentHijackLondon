using System;
using System.Diagnostics;
using System.Reflection;
using GoogleMobileAds.Common;

namespace GoogleMobileAds.Api
{
	// Token: 0x02000023 RID: 35
	public class RewardBasedVideoAd
	{
		// Token: 0x060001BE RID: 446 RVA: 0x00007920 File Offset: 0x00005D20
		private RewardBasedVideoAd()
		{
			Type type = Type.GetType("GoogleMobileAds.GoogleMobileAdsClientFactory,Assembly-CSharp");
			MethodInfo method = type.GetMethod("BuildRewardBasedVideoAdClient", BindingFlags.Static | BindingFlags.Public);
			this.client = (IRewardBasedVideoAdClient)method.Invoke(null, null);
			this.client.CreateRewardBasedVideoAd();
			this.client.OnAdLoaded += delegate(object sender, EventArgs args)
			{
				if (this.OnAdLoaded != null)
				{
					this.OnAdLoaded(this, args);
				}
			};
			this.client.OnAdFailedToLoad += delegate(object sender, AdFailedToLoadEventArgs args)
			{
				if (this.OnAdFailedToLoad != null)
				{
					this.OnAdFailedToLoad(this, args);
				}
			};
			this.client.OnAdOpening += delegate(object sender, EventArgs args)
			{
				if (this.OnAdOpening != null)
				{
					this.OnAdOpening(this, args);
				}
			};
			this.client.OnAdStarted += delegate(object sender, EventArgs args)
			{
				if (this.OnAdStarted != null)
				{
					this.OnAdStarted(this, args);
				}
			};
			this.client.OnAdClosed += delegate(object sender, EventArgs args)
			{
				if (this.OnAdClosed != null)
				{
					this.OnAdClosed(this, args);
				}
			};
			this.client.OnAdLeavingApplication += delegate(object sender, EventArgs args)
			{
				if (this.OnAdLeavingApplication != null)
				{
					this.OnAdLeavingApplication(this, args);
				}
			};
			this.client.OnAdRewarded += delegate(object sender, Reward args)
			{
				if (this.OnAdRewarded != null)
				{
					this.OnAdRewarded(this, args);
				}
			};
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060001BF RID: 447 RVA: 0x00007A0B File Offset: 0x00005E0B
		public static RewardBasedVideoAd Instance
		{
			get
			{
				return RewardBasedVideoAd.instance;
			}
		}

		// Token: 0x1400002E RID: 46
		// (add) Token: 0x060001C0 RID: 448 RVA: 0x00007A14 File Offset: 0x00005E14
		// (remove) Token: 0x060001C1 RID: 449 RVA: 0x00007A4C File Offset: 0x00005E4C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<EventArgs> OnAdLoaded;

		// Token: 0x1400002F RID: 47
		// (add) Token: 0x060001C2 RID: 450 RVA: 0x00007A84 File Offset: 0x00005E84
		// (remove) Token: 0x060001C3 RID: 451 RVA: 0x00007ABC File Offset: 0x00005EBC
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x14000030 RID: 48
		// (add) Token: 0x060001C4 RID: 452 RVA: 0x00007AF4 File Offset: 0x00005EF4
		// (remove) Token: 0x060001C5 RID: 453 RVA: 0x00007B2C File Offset: 0x00005F2C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<EventArgs> OnAdOpening;

		// Token: 0x14000031 RID: 49
		// (add) Token: 0x060001C6 RID: 454 RVA: 0x00007B64 File Offset: 0x00005F64
		// (remove) Token: 0x060001C7 RID: 455 RVA: 0x00007B9C File Offset: 0x00005F9C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<EventArgs> OnAdStarted;

		// Token: 0x14000032 RID: 50
		// (add) Token: 0x060001C8 RID: 456 RVA: 0x00007BD4 File Offset: 0x00005FD4
		// (remove) Token: 0x060001C9 RID: 457 RVA: 0x00007C0C File Offset: 0x0000600C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<EventArgs> OnAdClosed;

		// Token: 0x14000033 RID: 51
		// (add) Token: 0x060001CA RID: 458 RVA: 0x00007C44 File Offset: 0x00006044
		// (remove) Token: 0x060001CB RID: 459 RVA: 0x00007C7C File Offset: 0x0000607C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<Reward> OnAdRewarded;

		// Token: 0x14000034 RID: 52
		// (add) Token: 0x060001CC RID: 460 RVA: 0x00007CB4 File Offset: 0x000060B4
		// (remove) Token: 0x060001CD RID: 461 RVA: 0x00007CEC File Offset: 0x000060EC
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<EventArgs> OnAdLeavingApplication;

		// Token: 0x060001CE RID: 462 RVA: 0x00007D22 File Offset: 0x00006122
		public void LoadAd(AdRequest request, string adUnitId)
		{
			this.client.LoadAd(request, adUnitId);
		}

		// Token: 0x060001CF RID: 463 RVA: 0x00007D31 File Offset: 0x00006131
		public bool IsLoaded()
		{
			return this.client.IsLoaded();
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x00007D3E File Offset: 0x0000613E
		public void Show()
		{
			this.client.ShowRewardBasedVideoAd();
		}

		// Token: 0x04000103 RID: 259
		private IRewardBasedVideoAdClient client;

		// Token: 0x04000104 RID: 260
		private static readonly RewardBasedVideoAd instance = new RewardBasedVideoAd();
	}
}
