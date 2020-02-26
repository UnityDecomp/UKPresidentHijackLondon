using System;
using UnityEngine;
using UnityEngine.Advertisements;

// Token: 0x0200021A RID: 538
public class watchvideo : MonoBehaviour
{
	// Token: 0x06000DD3 RID: 3539 RVA: 0x000583B4 File Offset: 0x000567B4
	private void Start()
	{
		if (Application.platform == RuntimePlatform.Android && !Application.isEditor)
		{
			Advertisement.Initialize(Adpack.Unity_ID);
			AppLovin.SetSdkKey(Adpack.apploving);
			AppLovin.InitializeSdk();
			AppLovin.SetUnityAdListener(base.gameObject.name);
			AppLovin.PreloadInterstitial(null);
		}
		this.levelname = Application.loadedLevelName;
	}

	// Token: 0x06000DD4 RID: 3540 RVA: 0x00058411 File Offset: 0x00056811
	private void Update()
	{
	}

	// Token: 0x06000DD5 RID: 3541 RVA: 0x00058413 File Offset: 0x00056813
	public void ifVideoWatched()
	{
		if (base.GetComponent<QuestManager>())
		{
			base.GetComponent<QuestManager>().skipVideoWatched();
		}
	}

	// Token: 0x06000DD6 RID: 3542 RVA: 0x00058430 File Offset: 0x00056830
	public void ifVideoNotWatched()
	{
		if (base.GetComponent<QuestManager>())
		{
			base.GetComponent<QuestManager>().skipVideoNotWatched();
		}
	}

	// Token: 0x06000DD7 RID: 3543 RVA: 0x0005844D File Offset: 0x0005684D
	public void watchVideo()
	{
		this.ShowAd("rewardedVideo");
	}

	// Token: 0x06000DD8 RID: 3544 RVA: 0x0005845C File Offset: 0x0005685C
	public void ShowAd(string zone = "rewardedVideo")
	{
		ShowOptions showOptions = new ShowOptions();
		showOptions.resultCallback = new Action<ShowResult>(this.AdCallbackhanler);
		if (Advertisement.isReady(zone))
		{
			Advertisement.Show(zone, showOptions);
		}
		else if (AppLovin.HasPreloadedInterstitial(null))
		{
			AppLovin.ShowInterstitial();
			this.ifVideoWatched();
		}
	}

	// Token: 0x06000DD9 RID: 3545 RVA: 0x000584B0 File Offset: 0x000568B0
	private void AdCallbackhanler(ShowResult result)
	{
		if (result != ShowResult.Finished)
		{
			if (result != ShowResult.Skipped)
			{
				if (result == ShowResult.Failed)
				{
					Debug.Log("Ad failed");
					this.ifVideoNotWatched();
				}
			}
			else
			{
				Debug.Log("Ad Skipped");
				this.ifVideoNotWatched();
			}
		}
		else
		{
			this.ifVideoWatched();
		}
	}

	// Token: 0x04000E91 RID: 3729
	private string levelname;

	// Token: 0x04000E92 RID: 3730
	private bool completed;
}
