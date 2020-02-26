using System;
using System.Diagnostics;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	// Token: 0x02000033 RID: 51
	public class RewardBasedVideoAdClient : AndroidJavaProxy, IRewardBasedVideoAdClient
	{
		// Token: 0x060002AB RID: 683 RVA: 0x00009478 File Offset: 0x00007878
		public RewardBasedVideoAdClient() : base("com.google.unity.ads.UnityRewardBasedVideoAdListener")
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			this.androidRewardBasedVideo = new AndroidJavaObject("com.google.unity.ads.RewardBasedVideo", new object[]
			{
				@static,
				this
			});
		}

		// Token: 0x14000066 RID: 102
		// (add) Token: 0x060002AC RID: 684 RVA: 0x000095BC File Offset: 0x000079BC
		// (remove) Token: 0x060002AD RID: 685 RVA: 0x000095F4 File Offset: 0x000079F4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<EventArgs> OnAdLoaded = delegate(object A_0, EventArgs A_1)
		{
		};

		// Token: 0x14000067 RID: 103
		// (add) Token: 0x060002AE RID: 686 RVA: 0x0000962C File Offset: 0x00007A2C
		// (remove) Token: 0x060002AF RID: 687 RVA: 0x00009664 File Offset: 0x00007A64
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad = delegate(object A_0, AdFailedToLoadEventArgs A_1)
		{
		};

		// Token: 0x14000068 RID: 104
		// (add) Token: 0x060002B0 RID: 688 RVA: 0x0000969C File Offset: 0x00007A9C
		// (remove) Token: 0x060002B1 RID: 689 RVA: 0x000096D4 File Offset: 0x00007AD4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<EventArgs> OnAdOpening = delegate(object A_0, EventArgs A_1)
		{
		};

		// Token: 0x14000069 RID: 105
		// (add) Token: 0x060002B2 RID: 690 RVA: 0x0000970C File Offset: 0x00007B0C
		// (remove) Token: 0x060002B3 RID: 691 RVA: 0x00009744 File Offset: 0x00007B44
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<EventArgs> OnAdStarted = delegate(object A_0, EventArgs A_1)
		{
		};

		// Token: 0x1400006A RID: 106
		// (add) Token: 0x060002B4 RID: 692 RVA: 0x0000977C File Offset: 0x00007B7C
		// (remove) Token: 0x060002B5 RID: 693 RVA: 0x000097B4 File Offset: 0x00007BB4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<EventArgs> OnAdClosed = delegate(object A_0, EventArgs A_1)
		{
		};

		// Token: 0x1400006B RID: 107
		// (add) Token: 0x060002B6 RID: 694 RVA: 0x000097EC File Offset: 0x00007BEC
		// (remove) Token: 0x060002B7 RID: 695 RVA: 0x00009824 File Offset: 0x00007C24
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<Reward> OnAdRewarded = delegate(object A_0, Reward A_1)
		{
		};

		// Token: 0x1400006C RID: 108
		// (add) Token: 0x060002B8 RID: 696 RVA: 0x0000985C File Offset: 0x00007C5C
		// (remove) Token: 0x060002B9 RID: 697 RVA: 0x00009894 File Offset: 0x00007C94
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<EventArgs> OnAdLeavingApplication = delegate(object A_0, EventArgs A_1)
		{
		};

		// Token: 0x060002BA RID: 698 RVA: 0x000098CA File Offset: 0x00007CCA
		public void CreateRewardBasedVideoAd()
		{
			this.androidRewardBasedVideo.Call("create", new object[0]);
		}

		// Token: 0x060002BB RID: 699 RVA: 0x000098E2 File Offset: 0x00007CE2
		public void LoadAd(AdRequest request, string adUnitId)
		{
			this.androidRewardBasedVideo.Call("loadAd", new object[]
			{
				Utils.GetAdRequestJavaObject(request),
				adUnitId
			});
		}

		// Token: 0x060002BC RID: 700 RVA: 0x00009907 File Offset: 0x00007D07
		public bool IsLoaded()
		{
			return this.androidRewardBasedVideo.Call<bool>("isLoaded", new object[0]);
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0000991F File Offset: 0x00007D1F
		public void ShowRewardBasedVideoAd()
		{
			this.androidRewardBasedVideo.Call("show", new object[0]);
		}

		// Token: 0x060002BE RID: 702 RVA: 0x00009937 File Offset: 0x00007D37
		public void DestroyRewardBasedVideoAd()
		{
			this.androidRewardBasedVideo.Call("destroy", new object[0]);
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0000994F File Offset: 0x00007D4F
		private void onAdLoaded()
		{
			if (this.OnAdLoaded != null)
			{
				this.OnAdLoaded(this, EventArgs.Empty);
			}
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x00009970 File Offset: 0x00007D70
		private void onAdFailedToLoad(string errorReason)
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

		// Token: 0x060002C1 RID: 705 RVA: 0x000099A4 File Offset: 0x00007DA4
		private void onAdOpened()
		{
			if (this.OnAdOpening != null)
			{
				this.OnAdOpening(this, EventArgs.Empty);
			}
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x000099C2 File Offset: 0x00007DC2
		private void onAdStarted()
		{
			if (this.OnAdStarted != null)
			{
				this.OnAdStarted(this, EventArgs.Empty);
			}
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x000099E0 File Offset: 0x00007DE0
		private void onAdClosed()
		{
			if (this.OnAdClosed != null)
			{
				this.OnAdClosed(this, EventArgs.Empty);
			}
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x00009A00 File Offset: 0x00007E00
		private void onAdRewarded(string type, float amount)
		{
			if (this.OnAdRewarded != null)
			{
				Reward e = new Reward
				{
					Type = type,
					Amount = (double)amount
				};
				this.OnAdRewarded(this, e);
			}
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x00009A3C File Offset: 0x00007E3C
		private void onAdLeftApplication()
		{
			if (this.OnAdLeavingApplication != null)
			{
				this.OnAdLeavingApplication(this, EventArgs.Empty);
			}
		}

		// Token: 0x0400012C RID: 300
		private AndroidJavaObject androidRewardBasedVideo;
	}
}
