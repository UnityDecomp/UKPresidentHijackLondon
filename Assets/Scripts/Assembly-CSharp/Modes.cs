using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001F4 RID: 500
public class Modes : MonoBehaviour
{
	// Token: 0x06000CD5 RID: 3285 RVA: 0x00050DFC File Offset: 0x0004F1FC
	private void Start()
	{
		if (PlayerPrefs.GetInt("Quest") >= 11)
		{
			PlayerPrefs.SetString("FreeModeLock", "unlocked");
		}
		if (PlayerPrefs.HasKey("FreeModeLock") && PlayerPrefs.GetString("FreeModeLock") == "unlocked")
		{
			this.lockImage.gameObject.SetActive(false);
		}
		else
		{
			this.lockImage.gameObject.SetActive(true);
		}
	}

	// Token: 0x06000CD6 RID: 3286 RVA: 0x00050E78 File Offset: 0x0004F278
	public void playCareerMode()
	{
		PlayerPrefs.SetString("Scene", "CutScene");
		PlayerPrefs.SetInt("FreeMode", 0);
		MonoBehaviour.print("Career Mode");
		Application.LoadLevel("Loading");
	}

	// Token: 0x06000CD7 RID: 3287 RVA: 0x00050EA8 File Offset: 0x0004F2A8
	public void playFreeMode()
	{
		PlayerPrefs.SetString("Scene", "MainScene");
		PlayerPrefs.SetInt("FreeMode", 1);
		MonoBehaviour.print("Free Mode");
		Application.LoadLevel("Loading");
	}

	// Token: 0x06000CD8 RID: 3288 RVA: 0x00050ED8 File Offset: 0x0004F2D8
	public void showCnvFreeMode()
	{
		this.CnvFreeMode.gameObject.SetActive(true);
	}

	// Token: 0x06000CD9 RID: 3289 RVA: 0x00050EEB File Offset: 0x0004F2EB
	public void hideCnvFreeMode()
	{
		this.CnvFreeMode.gameObject.SetActive(false);
	}

	// Token: 0x06000CDA RID: 3290 RVA: 0x00050EFE File Offset: 0x0004F2FE
	public void watchVideo()
	{
		this.CnvFreeMode.gameObject.SetActive(false);
		this.lockImage.gameObject.SetActive(false);
		base.GetComponent<watchvideo>().watchVideo();
	}

	// Token: 0x04000D51 RID: 3409
	public Canvas CnvFreeMode;

	// Token: 0x04000D52 RID: 3410
	public Image lockImage;
}
