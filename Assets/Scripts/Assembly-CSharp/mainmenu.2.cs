using System;
using System.Collections;
using admob;
using Heyzap;
using UnityEngine;
using UnityEngine.Advertisements;

// Token: 0x020001EC RID: 492
public class mainmenu : MonoBehaviour
{
	// Token: 0x06000CB6 RID: 3254 RVA: 0x000502DC File Offset: 0x0004E6DC
	private void Start()
	{
		Time.timeScale = 1f;
		this.audio = base.GetComponent<AudioSource>();
		this.audio.volume = 1f;
		this.defaultClip = this.audio.clip;
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		this.exitscreen = this.exitscreen.GetComponent<Canvas>();
		this.exitscreen.enabled = false;
		base.StartCoroutine(this.StartButtons());
		if (Application.platform == RuntimePlatform.Android && !Application.isEditor)
		{
			Advertisement.Initialize(Adpack.Unity_ID);
			Admob.Instance().removeBanner("defaultBanner");
			Admob.Instance().initAdmob(Adpack.AD_MOB_ID, Adpack.AD_MOB_INTERSTITIAL_ID);
			Admob.Instance().loadInterstitial();
			HeyzapAds.Start("20af69e9c1ecd52279380e39b0c6216f", 0);
			HZInterstitialAd.fetch("default");
			AppLovin.SetSdkKey(Adpack.apploving);
			AppLovin.InitializeSdk();
			AppLovin.SetUnityAdListener(base.gameObject.name);
			AppLovin.PreloadInterstitial(null);
		}
	}

	// Token: 0x06000CB7 RID: 3255 RVA: 0x000503D7 File Offset: 0x0004E7D7
	private void Play_ButtonClickSound()
	{
		base.GetComponent<AudioSource>().PlayOneShot(this.sound_touch);
	}

	// Token: 0x06000CB8 RID: 3256 RVA: 0x000503EC File Offset: 0x0004E7EC
	private IEnumerator waitSeconds()
	{
		yield return new WaitForSeconds(0.1f);
		this.audio.clip = this.defaultClip;
		this.audio.loop = true;
		this.audio.Play();
		yield break;
	}

	// Token: 0x06000CB9 RID: 3257 RVA: 0x00050408 File Offset: 0x0004E808
	private IEnumerator StartButtons()
	{
		for (int i = 0; i < this.menuButtons.Length; i++)
		{
			yield return new WaitForSeconds(0.5f);
			this.menuButtons[i].GetComponent<Animator>().enabled = true;
		}
		yield break;
	}

	// Token: 0x06000CBA RID: 3258 RVA: 0x00050423 File Offset: 0x0004E823
	private void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			this.Exiitscreen();
		}
	}

	// Token: 0x06000CBB RID: 3259 RVA: 0x00050438 File Offset: 0x0004E838
	public void PlayLevel()
	{
		this.Play_ButtonClickSound();
		gameplay.startCrazyLevel = false;
		this.resetButton.SetActive(false);
		for (int i = 0; i < this.menuButtons.Length; i++)
		{
			this.menuButtons[i].SetActive(false);
		}
		if (Application.platform == RuntimePlatform.Android && !Application.isEditor)
		{
			if (Advertisement.IsReady())
			{
				Advertisement.Show();
			}
			else if (HZInterstitialAd.IsAvailable())
			{
				HZInterstitialAd.Show();
			}
		}
		Application.LoadLevel("InAppPurchase");
	}

	// Token: 0x06000CBC RID: 3260 RVA: 0x000504C7 File Offset: 0x0004E8C7
	public void Reset(GameObject button)
	{
		PlayerPrefs.SetInt("Quest", 0);
		PlayerPrefs.SetInt("SavedQuest", 0);
		PlayerPrefs.DeleteKey("Tutorial");
		PlayerPrefs.DeleteKey("FreeModeLock");
		button.SetActive(false);
	}

	// Token: 0x06000CBD RID: 3261 RVA: 0x000504FA File Offset: 0x0004E8FA
	public void Exit()
	{
		this.Play_ButtonClickSound();
		Application.Quit();
	}

	// Token: 0x06000CBE RID: 3262 RVA: 0x00050508 File Offset: 0x0004E908
	public void Exiitscreen()
	{
		this.Play_ButtonClickSound();
		if (Application.platform == RuntimePlatform.Android && !Application.isEditor)
		{
			if (AppLovin.HasPreloadedInterstitial(null))
			{
				AppLovin.ShowInterstitial();
			}
			else if (Admob.Instance().isInterstitialReady())
			{
				Admob.Instance().showInterstitial();
			}
		}
		this.exitscreen.enabled = true;
	}

	// Token: 0x06000CBF RID: 3263 RVA: 0x0005056B File Offset: 0x0004E96B
	public void noexit()
	{
		this.Play_ButtonClickSound();
		this.exitscreen.enabled = false;
	}

	// Token: 0x06000CC0 RID: 3264 RVA: 0x0005057F File Offset: 0x0004E97F
	public void Rateus()
	{
		this.Play_ButtonClickSound();
		Application.OpenURL("market://details?id=" + Adpack.PACKAGE_NAME);
	}

	// Token: 0x06000CC1 RID: 3265 RVA: 0x0005059B File Offset: 0x0004E99B
	public void more()
	{
		this.Play_ButtonClickSound();
		Application.OpenURL(Adpack.MORE_APPS_URL);
	}

	// Token: 0x06000CC2 RID: 3266 RVA: 0x000505AD File Offset: 0x0004E9AD
	public void fb()
	{
		this.Play_ButtonClickSound();
		Application.OpenURL(Adpack.gvprdouctionsfb);
	}

	// Token: 0x06000CC3 RID: 3267 RVA: 0x000505BF File Offset: 0x0004E9BF
	public void twitter()
	{
		this.Play_ButtonClickSound();
		Application.OpenURL(Adpack.gvprdouctionstwitter);
	}

	// Token: 0x06000CC4 RID: 3268 RVA: 0x000505D1 File Offset: 0x0004E9D1
	public void cargame()
	{
		this.Play_ButtonClickSound();
		Application.OpenURL("market://details?id=com.clans.flyingmotorcycle");
	}

	// Token: 0x06000CC5 RID: 3269 RVA: 0x000505E3 File Offset: 0x0004E9E3
	public void war()
	{
		Application.OpenURL("market://details?id=com.clans.flyinglion.wildsimulator");
	}

	// Token: 0x06000CC6 RID: 3270 RVA: 0x000505EF File Offset: 0x0004E9EF
	public void wild()
	{
		Application.OpenURL("market://details?id=com.clans.flying.yachtboat");
	}

	// Token: 0x06000CC7 RID: 3271 RVA: 0x000505FB File Offset: 0x0004E9FB
	public void promo()
	{
		this.Play_ButtonClickSound();
		Application.OpenURL("market://details?id=com.Clans.Warofjungleking");
	}

	// Token: 0x06000CC8 RID: 3272 RVA: 0x0005060D File Offset: 0x0004EA0D
	public void yt()
	{
		Application.OpenURL("https://www.youtube.com/channel/UCAc2gxc9qfzriM_RhEoC6Nw/videos?view_as=subscriber");
	}

	// Token: 0x04000D31 RID: 3377
	public Canvas exitscreen;

	// Token: 0x04000D32 RID: 3378
	public GameObject[] menuButtons;

	// Token: 0x04000D33 RID: 3379
	public GameObject resetButton;

	// Token: 0x04000D34 RID: 3380
	public AudioClip sound_touch;

	// Token: 0x04000D35 RID: 3381
	private AudioSource audio;

	// Token: 0x04000D36 RID: 3382
	private AudioClip defaultClip;
}
