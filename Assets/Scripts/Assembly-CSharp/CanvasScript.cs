using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001D8 RID: 472
public class CanvasScript : MonoBehaviour
{
	// Token: 0x06000C3C RID: 3132 RVA: 0x0004D734 File Offset: 0x0004BB34
	private void Start()
	{
		this.tutorialAccess = PlayerPrefs.GetString("tutorialAccess");
		this.playerClass = (UnityEngine.Object.FindObjectOfType(typeof(PlayerInputControllerC)) as PlayerInputControllerC);
		this.qm = (UnityEngine.Object.FindObjectOfType(typeof(QuestManager)) as QuestManager);
	}

	// Token: 0x06000C3D RID: 3133 RVA: 0x0004D788 File Offset: 0x0004BB88
	private void Update()
	{
		if (this.startFlow)
		{
			for (int i = 0; i < 3; i++)
			{
				if (this.playerList[i].gameObject.activeSelf)
				{
					this.player = this.playerList[i];
				}
			}
			this.startFlow = false;
		}
		if (this.tutorialAccess == "true" && this.playerClass.tutorial && this.playerClass.tutorialprogress < 1)
		{
			this.health.gameObject.SetActive(false);
			this.panel.gameObject.SetActive(false);
			this.minimap.SetActive(false);
			this.DialogBox.gameObject.SetActive(false);
			this.notifier.gameObject.SetActive(true);
			this.player.GetComponent<PlayerInputControllerC>().tutorialprogress++;
			this.infoButton.gameObject.SetActive(false);
			base.StartCoroutine(this.WaitForWalk());
		}
	}

	// Token: 0x06000C3E RID: 3134 RVA: 0x0004D89A File Offset: 0x0004BC9A
	public void showEat()
	{
		this.playerClass = (UnityEngine.Object.FindObjectOfType(typeof(PlayerInputControllerC)) as PlayerInputControllerC);
		this.playerClass.eats = true;
		this.Eat.gameObject.SetActive(true);
	}

	// Token: 0x06000C3F RID: 3135 RVA: 0x0004D8D3 File Offset: 0x0004BCD3
	public void hideEat()
	{
		this.Eat.gameObject.SetActive(false);
	}

	// Token: 0x06000C40 RID: 3136 RVA: 0x0004D8E8 File Offset: 0x0004BCE8
	public bool Eatbar()
	{
		if (this.eatProgress > 0.2f)
		{
			this.eatProgress -= 0.2f;
			this.EatBAR.fillAmount = this.eatProgress;
			this.allowEat = true;
		}
		else
		{
			this.hideEat();
			this.eatProgress = 1f;
			this.allowEat = false;
		}
		return this.allowEat;
	}

	// Token: 0x06000C41 RID: 3137 RVA: 0x0004D954 File Offset: 0x0004BD54
	public void StartNewQuest(bool newQuest)
	{
		this.qm = (UnityEngine.Object.FindObjectOfType(typeof(QuestManager)) as QuestManager);
		this.qm.startok = false;
		this.DialogBox.gameObject.SetActive(true);
		Screen.lockCursor = false;
		this.DialogBox.GetComponentInChildren<Text>().text = "Get Ready For New Quest";
		Time.timeScale = 0f;
		this.newQuest = newQuest;
	}

	// Token: 0x06000C42 RID: 3138 RVA: 0x0004D9C4 File Offset: 0x0004BDC4
	public void TimeUpStartAgain()
	{
		this.DialogBox.gameObject.SetActive(true);
		this.DialogBox.GetComponentInChildren<Text>().text = "Time Up ! You have to start Quest from start !";
		this.StartAgain = true;
	}

	// Token: 0x06000C43 RID: 3139 RVA: 0x0004D9F4 File Offset: 0x0004BDF4
	public void closeDialog()
	{
		this.player.GetComponent<PlayerInputControllerC>().tutorialprogress++;
		if (this.StartAgain)
		{
			this.DialogBox.gameObject.SetActive(false);
			this.StartAgain = false;
			this.player.GetComponent<PlayerInputControllerC>().tutorialprogress = 50;
			Time.timeScale = 1f;
		}
		if (this.newQuest)
		{
			this.DialogBox.gameObject.SetActive(false);
			this.newQuest = false;
			Screen.lockCursor = true;
			this.player.GetComponent<PlayerInputControllerC>().tutorialprogress = 50;
			Time.timeScale = 1f;
		}
		if (this.player.GetComponent<PlayerInputControllerC>().tutorialprogress == 2)
		{
			this.Run();
			base.StartCoroutine(this.WaitForMiniMap());
		}
		if (this.player.GetComponent<PlayerInputControllerC>().tutorialprogress == 3)
		{
			this.Run();
			base.StartCoroutine(this.WaitForNotifier());
		}
		if (this.player.GetComponent<PlayerInputControllerC>().tutorialprogress == 4)
		{
			this.notifier.GetComponent<Animation>().Play("Notifier_Close");
			this.Run();
			base.StartCoroutine(this.WaitForPanel());
		}
		if (this.player.GetComponent<PlayerInputControllerC>().tutorialprogress == 5)
		{
			this.Run();
			base.StartCoroutine(this.WaitForInfoButton());
		}
		if (this.player.GetComponent<PlayerInputControllerC>().tutorialprogress == 6)
		{
			this.Run();
			base.StartCoroutine(this.WaitForQuest());
		}
		if (this.player.GetComponent<PlayerInputControllerC>().tutorialprogress == 7)
		{
			this.Run();
			base.StartCoroutine(this.Quest0());
			this.infoButton.gameObject.SetActive(true);
		}
		if (this.player.GetComponent<PlayerInputControllerC>().tutorialprogress == 8)
		{
			this.Run();
			PlayerPrefs.SetString("tutorialAccess", "false");
			this.qm.getQuest(0);
		}
	}

	// Token: 0x06000C44 RID: 3140 RVA: 0x0004DBF4 File Offset: 0x0004BFF4
	private IEnumerator WaitForWalk()
	{
		yield return new WaitForSeconds(2f);
		this.health.gameObject.SetActive(true);
		this.Break();
		yield break;
	}

	// Token: 0x06000C45 RID: 3141 RVA: 0x0004DC10 File Offset: 0x0004C010
	private IEnumerator WaitForMiniMap()
	{
		yield return new WaitForSeconds(1f);
		this.minimap.SetActive(true);
		this.Break();
		yield break;
	}

	// Token: 0x06000C46 RID: 3142 RVA: 0x0004DC2C File Offset: 0x0004C02C
	private IEnumerator WaitForNotifier()
	{
		yield return new WaitForSeconds(1f);
		this.notifier.GetComponentInChildren<Text>().text = "Quests Notification will be displayed here";
		this.notifier.GetComponentInChildren<Animation>().Play("Notifier_Open");
		yield return new WaitForSeconds(2f);
		this.Break();
		yield break;
	}

	// Token: 0x06000C47 RID: 3143 RVA: 0x0004DC48 File Offset: 0x0004C048
	private IEnumerator WaitForPanel()
	{
		yield return new WaitForSeconds(1f);
		this.panel.gameObject.SetActive(true);
		this.Break();
		yield break;
	}

	// Token: 0x06000C48 RID: 3144 RVA: 0x0004DC64 File Offset: 0x0004C064
	private IEnumerator WaitForInfoButton()
	{
		yield return new WaitForSeconds(2f);
		this.infoButton.gameObject.SetActive(true);
		this.Break();
		yield break;
	}

	// Token: 0x06000C49 RID: 3145 RVA: 0x0004DC80 File Offset: 0x0004C080
	private IEnumerator WaitForQuest()
	{
		yield return new WaitForSeconds(0.5f);
		this.Break();
		yield break;
	}

	// Token: 0x06000C4A RID: 3146 RVA: 0x0004DC9C File Offset: 0x0004C09C
	private IEnumerator Quest0()
	{
		yield return new WaitForSeconds(0.5f);
		this.Break();
		yield break;
	}

	// Token: 0x06000C4B RID: 3147 RVA: 0x0004DCB8 File Offset: 0x0004C0B8
	private void Break()
	{
		Screen.lockCursor = false;
		this.DialogBox.gameObject.SetActive(true);
		this.showText.text = this.dialogs[this.player.GetComponent<PlayerInputControllerC>().tutorialprogress - 1];
		Time.timeScale = 0f;
	}

	// Token: 0x06000C4C RID: 3148 RVA: 0x0004DD0A File Offset: 0x0004C10A
	private void Run()
	{
		this.DialogBox.gameObject.SetActive(false);
		Time.timeScale = 1f;
		Screen.lockCursor = true;
	}

	// Token: 0x04000CAC RID: 3244
	public GameObject[] playerList = new GameObject[3];

	// Token: 0x04000CAD RID: 3245
	[HideInInspector]
	public GameObject player;

	// Token: 0x04000CAE RID: 3246
	public GameObject minimap;

	// Token: 0x04000CAF RID: 3247
	public Image health;

	// Token: 0x04000CB0 RID: 3248
	public Image panel;

	// Token: 0x04000CB1 RID: 3249
	public Image notifier;

	// Token: 0x04000CB2 RID: 3250
	public Image DialogBox;

	// Token: 0x04000CB3 RID: 3251
	public Button infoButton;

	// Token: 0x04000CB4 RID: 3252
	public Text showText;

	// Token: 0x04000CB5 RID: 3253
	public Image Eat;

	// Token: 0x04000CB6 RID: 3254
	public Image EatBAR;

	// Token: 0x04000CB7 RID: 3255
	private bool allowEat = true;

	// Token: 0x04000CB8 RID: 3256
	private float eatProgress = 1f;

	// Token: 0x04000CB9 RID: 3257
	private bool newQuest;

	// Token: 0x04000CBA RID: 3258
	private bool StartAgain;

	// Token: 0x04000CBB RID: 3259
	public string[] dialogs = new string[8];

	// Token: 0x04000CBC RID: 3260
	private string tutorialAccess = "true";

	// Token: 0x04000CBD RID: 3261
	private bool startFlow = true;

	// Token: 0x04000CBE RID: 3262
	private PlayerInputControllerC playerClass;

	// Token: 0x04000CBF RID: 3263
	public QuestManager qm;
}
