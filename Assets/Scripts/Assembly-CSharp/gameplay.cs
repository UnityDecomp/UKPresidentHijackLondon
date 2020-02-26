using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001E7 RID: 487
[RequireComponent(typeof(PurchaseManager))]
public class gameplay : MonoBehaviour
{
	// Token: 0x06000C97 RID: 3223 RVA: 0x0004FA1C File Offset: 0x0004DE1C
	private void Start()
	{
		this.purchaseManager = base.GetComponent<PurchaseManager>();
		this.crazyLevelCanvas.SetActive(false);
	}

	// Token: 0x06000C98 RID: 3224 RVA: 0x0004FA36 File Offset: 0x0004DE36
	private void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			Application.LoadLevel("MainMenu");
		}
	}

	// Token: 0x06000C99 RID: 3225 RVA: 0x0004FA50 File Offset: 0x0004DE50
	public void initialSetting()
	{
		this.journeyLength = Vector3.Distance(this.cam.position, this.pos2.position);
		this.startTime = Time.time;
		Time.timeScale = 1f;
		gameplay.count = 0;
		this.audio = base.GetComponent<AudioSource>();
		this.audio.volume = 1f;
		this.defaultClip = this.audio.clip;
		this.maincanvas = this.maincanvas.GetComponent<Canvas>();
		this.scorecount = PlayerPrefs.GetInt("TotalScore");
		this.purchaseManager.InitializeItems(this.bikes);
		this.CurrentItemSetting(this.bikes[0]);
		this.score.text = this.scorecount.ToString();
		this.buy.gameObject.SetActive(true);
		this.buy.gameObject.SetActive(false);
	}

	// Token: 0x06000C9A RID: 3226 RVA: 0x0004FB44 File Offset: 0x0004DF44
	private void Play_ButtonClickSound()
	{
		base.GetComponent<AudioSource>().PlayOneShot(this.sound_touch, 0.7f);
	}

	// Token: 0x06000C9B RID: 3227 RVA: 0x0004FB5C File Offset: 0x0004DF5C
	private IEnumerator waitSeconds()
	{
		yield return new WaitForSeconds(0.1f);
		this.audio.clip = this.defaultClip;
		this.audio.loop = true;
		this.audio.Play();
		yield break;
	}

	// Token: 0x06000C9C RID: 3228 RVA: 0x0004FB78 File Offset: 0x0004DF78
	public void nextteam()
	{
		this.Play_ButtonClickSound();
		if (this.p < 1 || this.p == 0)
		{
			this.p++;
			this.q = this.p - 1;
			gameplay.count++;
			Debug.Log("Count : " + gameplay.count);
			this.CurrentItemSetting(this.bikes[this.p]);
			this.bikes[this.p].SetActive(true);
			this.bikes[this.q].SetActive(false);
		}
	}

	// Token: 0x06000C9D RID: 3229 RVA: 0x0004FC1C File Offset: 0x0004E01C
	public void backteam()
	{
		this.Play_ButtonClickSound();
		if (this.p > 0)
		{
			this.p--;
			this.q = this.p + 1;
			gameplay.count--;
			this.CurrentItemSetting(this.bikes[this.p]);
			this.bikes[this.p].SetActive(true);
			this.bikes[this.q].SetActive(false);
		}
	}

	// Token: 0x06000C9E RID: 3230 RVA: 0x0004FC9C File Offset: 0x0004E09C
	public void ifVideoWatched()
	{
		if (!this.buyingCoins)
		{
			this.UnlockItem();
		}
		else
		{
			int num = PlayerPrefs.GetInt("TotalScore");
			num += 500;
			PlayerPrefs.SetInt("TotalScore", num);
			this.score.text = PlayerPrefs.GetInt("TotalScore").ToString();
			this.buyingCoins = false;
		}
	}

	// Token: 0x06000C9F RID: 3231 RVA: 0x0004FD07 File Offset: 0x0004E107
	public void ifVideoNotWatched()
	{
		if (!this.buyingCoins)
		{
			this.UnlockingFailed("Video not available. Try again later");
		}
		else
		{
			this.buyingCoins = false;
		}
	}

	// Token: 0x06000CA0 RID: 3232 RVA: 0x0004FD2B File Offset: 0x0004E12B
	public void watchVideo()
	{
		this.Play_ButtonClickSound();
	}

	// Token: 0x06000CA1 RID: 3233 RVA: 0x0004FD34 File Offset: 0x0004E134
	public void BuyItem()
	{
		bool flag = this.purchaseManager.PurchaseItem(this.bikes[gameplay.count]);
		if (flag)
		{
			this.UpdateItems();
		}
		else
		{
			this.UnlockingFailed("Not enough coins. You can watch a video instead");
		}
	}

	// Token: 0x06000CA2 RID: 3234 RVA: 0x0004FD75 File Offset: 0x0004E175
	public void BuyCoins()
	{
		this.buyingCoins = true;
		this.ifVideoWatched();
	}

	// Token: 0x06000CA3 RID: 3235 RVA: 0x0004FD84 File Offset: 0x0004E184
	public void OK()
	{
		this.Play_ButtonClickSound();
		this.maincanvas.enabled = true;
	}

	// Token: 0x06000CA4 RID: 3236 RVA: 0x0004FD98 File Offset: 0x0004E198
	public void playlevel()
	{
		this.Play_ButtonClickSound();
		this.crazyLevelCanvas.SetActive(true);
		this.maincanvas.gameObject.SetActive(false);
		Time.timeScale = 1f;
	}

	// Token: 0x06000CA5 RID: 3237 RVA: 0x0004FDC7 File Offset: 0x0004E1C7
	public void UnlockItem()
	{
		this.purchaseManager.UnlockItem(this.bikes[gameplay.count]);
		this.UpdateItems();
	}

	// Token: 0x06000CA6 RID: 3238 RVA: 0x0004FDE6 File Offset: 0x0004E1E6
	private void UnlockingFailed(string reason)
	{
		this.unlockingItem.failedText.text = reason;
		this.unlockingItem.failedBuy.SetActive(true);
		this.buy.gameObject.SetActive(false);
	}

	// Token: 0x06000CA7 RID: 3239 RVA: 0x0004FE1B File Offset: 0x0004E21B
	public void CloseFailedBuy()
	{
		this.unlockingItem.failedBuy.gameObject.SetActive(false);
		this.buy.gameObject.SetActive(true);
	}

	// Token: 0x06000CA8 RID: 3240 RVA: 0x0004FE44 File Offset: 0x0004E244
	private void UpdateItems()
	{
		if (this.purchaseManager.GetItemStatus(this.bikes[gameplay.count]) == "YES")
		{
			this.play.gameObject.SetActive(true);
			this.buy.gameObject.SetActive(false);
		}
		else
		{
			this.buy.gameObject.SetActive(true);
			this.play.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000CA9 RID: 3241 RVA: 0x0004FEC0 File Offset: 0x0004E2C0
	private void CurrentItemSetting(GameObject currentItem)
	{
		this.itemPriceText.text = currentItem.GetComponent<ItemEntity>().price.ToString();
		this.itemDescription.text = currentItem.GetComponent<ItemEntity>().description.ToString();
		if (this.purchaseManager.GetItemStatus(currentItem) == "YES")
		{
			this.play.gameObject.SetActive(true);
			this.buy.gameObject.SetActive(false);
			this.itemPriceText.gameObject.SetActive(false);
		}
		else
		{
			this.buy.gameObject.SetActive(true);
			this.play.gameObject.SetActive(false);
			this.itemPriceText.gameObject.SetActive(true);
		}
	}

	// Token: 0x04000D07 RID: 3335
	public static int count;

	// Token: 0x04000D08 RID: 3336
	public static int skipCount;

	// Token: 0x04000D09 RID: 3337
	public static bool startCrazyLevel;

	// Token: 0x04000D0A RID: 3338
	public GameObject[] bikes;

	// Token: 0x04000D0B RID: 3339
	public Transform cam;

	// Token: 0x04000D0C RID: 3340
	public Transform pos1;

	// Token: 0x04000D0D RID: 3341
	public Transform pos2;

	// Token: 0x04000D0E RID: 3342
	public Transform pos3;

	// Token: 0x04000D0F RID: 3343
	private Transform pos4;

	// Token: 0x04000D10 RID: 3344
	public Text score;

	// Token: 0x04000D11 RID: 3345
	public Text itemPriceText;

	// Token: 0x04000D12 RID: 3346
	public Text itemDescription;

	// Token: 0x04000D13 RID: 3347
	public Canvas maincanvas;

	// Token: 0x04000D14 RID: 3348
	public GameObject crazyLevelCanvas;

	// Token: 0x04000D15 RID: 3349
	public GameObject buy;

	// Token: 0x04000D16 RID: 3350
	public GameObject play;

	// Token: 0x04000D17 RID: 3351
	public gameplay.UnlockingItem unlockingItem;

	// Token: 0x04000D18 RID: 3352
	private bool buyingCoins;

	// Token: 0x04000D19 RID: 3353
	public AudioClip sound_touch;

	// Token: 0x04000D1A RID: 3354
	private AudioSource audio;

	// Token: 0x04000D1B RID: 3355
	private AudioClip defaultClip;

	// Token: 0x04000D1C RID: 3356
	public float speed = 0.1f;

	// Token: 0x04000D1D RID: 3357
	private float startTime;

	// Token: 0x04000D1E RID: 3358
	private float journeyLength;

	// Token: 0x04000D1F RID: 3359
	private PurchaseManager purchaseManager;

	// Token: 0x04000D20 RID: 3360
	private int scorecount;

	// Token: 0x04000D21 RID: 3361
	private int i;

	// Token: 0x04000D22 RID: 3362
	private int p;

	// Token: 0x04000D23 RID: 3363
	private int q;

	// Token: 0x020001E8 RID: 488
	[Serializable]
	public class UnlockingItem
	{
		// Token: 0x04000D24 RID: 3364
		public GameObject failedBuy;

		// Token: 0x04000D25 RID: 3365
		public Text failedText;
	}
}
