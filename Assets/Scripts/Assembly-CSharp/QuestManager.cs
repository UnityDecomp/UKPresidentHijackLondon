using System;
using System.Collections;
using admob;
using ChartboostSDK;
using Heyzap;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

// Token: 0x020001FF RID: 511
public class QuestManager : MonoBehaviour
{
	// Token: 0x06000D0D RID: 3341 RVA: 0x00051E04 File Offset: 0x00050204
	private void Start()
	{
		Time.timeScale = 1f;
		this.questM = base.GetComponent<QuestManager>();
		this.playerClass = base.GetComponent<dogsactive>().germanshepherds.GetComponent<PlayerInputControllerC>();
		this.dtcr = (UnityEngine.Object.FindObjectOfType(typeof(DetectRay)) as DetectRay);
		this.wtchvid = (UnityEngine.Object.FindObjectOfType(typeof(watchvideo)) as watchvideo);
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		this.hideGUI();
		this.death = false;
		this.celebrate = false;
		this.TargetPoint.SetActive(false);
		this.CutSceneCam.SetActive(false);
		this.canvasScript = (UnityEngine.Object.FindObjectOfType(typeof(CanvasScript)) as CanvasScript);
		this.guiFunc = (UnityEngine.Object.FindObjectOfType(typeof(GUIFunctions)) as GUIFunctions);
		this.questProgress = (UnityEngine.Object.FindObjectOfType(typeof(QuestProgress)) as QuestProgress);
		this.statusC = (UnityEngine.Object.FindObjectOfType(typeof(StatusC)) as StatusC);
		this.qp = (UnityEngine.Object.FindObjectOfType(typeof(QuestProgress)) as QuestProgress);
		this.zone1enemies.SetActive(false);
		this.zone2enemies.SetActive(false);
		this.setQuestID(PlayerPrefs.GetInt("Quest"));
		this.Hero1.gameObject.SetActive(false);
		this.Hero1Camera.gameObject.SetActive(false);
		MonoBehaviour.print("ya kya ha :::: " + base.GetComponent<dogsactive>().getActivePlayer());
		if (PlayerPrefs.GetInt("Quest") == 0 || PlayerPrefs.GetInt("Quest") == 1 || PlayerPrefs.GetInt("Quest") == 2 || PlayerPrefs.GetInt("Quest") == 3)
		{
			this.Hero1.gameObject.SetActive(true);
			for (int i = 0; i < this.hero1models.Length; i++)
			{
				this.hero1models[i].gameObject.SetActive(false);
			}
			this.Hero1Camera.gameObject.SetActive(true);
			this.hero1models[gameplay.count].gameObject.SetActive(true);
			this.Hero.gameObject.SetActive(false);
			this.CrossHaire.gameObject.SetActive(false);
			this.Hero1.transform.GetChild(15).gameObject.SetActive(false);
			this.HealthBar.gameObject.SetActive(false);
			this.panelInteract.gameObject.SetActive(false);
			this.CFPP.GetComponent<TouchController>().touchZones[0].Hide(true);
			this.minimap.GetComponent<MapCanvasController>().playerTransform = this.Hero1.transform;
		}
		if (PlayerPrefs.GetInt("Quest") == 2)
		{
			this.hero1models[gameplay.count].gameObject.SetActive(false);
		}
		if (PlayerPrefs.GetInt("Quest") >= 4)
		{
			this.minimap.GetComponent<MapCanvasController>().playerTransform = this.Hero.transform;
		}
		if (PlayerPrefs.GetInt("Quest") == 1)
		{
		}
		if (Application.platform == RuntimePlatform.Android && !Application.isEditor)
		{
			Advertisement.Initialize(Adpack.Unity_ID);
			Admob.Instance().initAdmob(Adpack.AD_MOB_ID, Adpack.AD_MOB_INTERSTITIAL_ID);
			Admob.Instance().showBannerRelative(AdSize.SmartBanner, AdPosition.TOP_CENTER, 0, "defaultBanner");
			Admob.Instance().loadInterstitial();
			HeyzapAds.Start("20af69e9c1ecd52279380e39b0c6216f", 0);
			HZInterstitialAd.fetch("default");
			AppLovin.SetSdkKey(Adpack.apploving);
			AppLovin.InitializeSdk();
			AppLovin.SetUnityAdListener(base.gameObject.name);
			AppLovin.PreloadInterstitial(null);
		}
	}

	// Token: 0x06000D0E RID: 3342 RVA: 0x000521B8 File Offset: 0x000505B8
	private IEnumerator Add1()
	{
		yield return new WaitForSeconds(1.5f);
		if (Application.platform == RuntimePlatform.Android && !Application.isEditor)
		{
			if (AppLovin.HasPreloadedInterstitial(null))
			{
				AppLovin.ShowInterstitial();
			}
			else if (HZInterstitialAd.IsAvailable())
			{
				HZInterstitialAd.Show();
			}
		}
		yield break;
	}

	// Token: 0x06000D0F RID: 3343 RVA: 0x000521CC File Offset: 0x000505CC
	private IEnumerator Add3()
	{
		yield return new WaitForSeconds(1.5f);
		if (Application.platform == RuntimePlatform.Android && !Application.isEditor)
		{
			if (HZInterstitialAd.IsAvailable())
			{
				HZInterstitialAd.Show();
			}
			else if (AppLovin.HasPreloadedInterstitial(null))
			{
				AppLovin.ShowInterstitial();
			}
		}
		yield break;
	}

	// Token: 0x06000D10 RID: 3344 RVA: 0x000521E0 File Offset: 0x000505E0
	private IEnumerator Add2()
	{
		yield return new WaitForSeconds(1.5f);
		if (Application.platform == RuntimePlatform.Android && !Application.isEditor)
		{
			if (Advertisement.IsReady())
			{
				Advertisement.Show();
			}
			else if (Admob.Instance().isInterstitialReady())
			{
				Admob.Instance().showInterstitial();
			}
		}
		yield break;
	}

	// Token: 0x06000D11 RID: 3345 RVA: 0x000521F4 File Offset: 0x000505F4
	private IEnumerator Add4()
	{
		yield return new WaitForSeconds(1.5f);
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
		yield break;
	}

	// Token: 0x06000D12 RID: 3346 RVA: 0x00052208 File Offset: 0x00050608
	private IEnumerator Add5()
	{
		yield return new WaitForSeconds(1.5f);
		if (Application.platform == RuntimePlatform.Android && !Application.isEditor)
		{
			if (Admob.Instance().isInterstitialReady())
			{
				Admob.Instance().showInterstitial();
			}
			else if (AppLovin.HasPreloadedInterstitial(null))
			{
				AppLovin.ShowInterstitial();
			}
		}
		yield break;
	}

	// Token: 0x06000D13 RID: 3347 RVA: 0x0005221C File Offset: 0x0005061C
	private void Update()
	{
		if (!this.startok)
		{
			this.startok = true;
		}
		if (this.Hero1.GetComponent<DetectRay>().playerfail && this.testfail)
		{
			this.testfail = false;
			this.Hero1.GetComponent<DetectRay>().playerfail = false;
			this.GameOver();
			if (this.players1[0].transform.GetChild(17).GetChild(0).gameObject.activeSelf)
			{
				MonoBehaviour.print("Perachute off hu gya ha");
				this.players1[0].transform.GetChild(17).GetChild(0).gameObject.SetActive(false);
			}
		}
		if (Input.GetKey(KeyCode.Escape))
		{
			this.PauseMenu();
		}
		if (this.startQuest)
		{
			for (int i = 0; i < this.Amount.Length; i++)
			{
				if (this.Amount[i] == 0)
				{
					this.counter++;
				}
			}
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				if (Application.platform == RuntimePlatform.Android && !Application.isEditor)
				{
					if (HZInterstitialAd.IsAvailable())
					{
						HZInterstitialAd.Show();
					}
					else if (Admob.Instance().isInterstitialReady())
					{
						Admob.Instance().showInterstitial();
					}
				}
				if (!this.pause && this.counter < 2)
				{
					this.pause = true;
					this.PauseMenu();
				}
				else
				{
					this.pause = false;
				}
			}
			if (this.allowTimer)
			{
				if (this.timerCount > 0)
				{
					base.StartCoroutine(this.timer());
					this.timerText.text = this.timerCount.ToString();
					this.allowTimer = false;
				}
				else
				{
					this.allowTimer = false;
					base.GetComponent<CollectionQuest>().removeOnTimeUp();
					this.timerLabel.gameObject.SetActive(false);
					this.TimeUp();
					this.timerCount = 140;
				}
			}
			if (!this.pause && this.decreaseTime)
			{
				if (this.time <= 1.0)
				{
					this.TimeUp();
					this.decreaseTime = false;
				}
			}
			if (Input.GetKeyDown(KeyCode.L))
			{
				this.counter = this.Amount.Length;
				this.startQuest = true;
			}
			if (this.counter == this.Amount.Length && this.questId == 0)
			{
				this.startQuest = false;
				this.questSuccessfull();
				base.StartCoroutine(this.Add1());
			}
			if (this.counter == this.Amount.Length && this.questId == 1)
			{
				this.startQuest = false;
				this.questSuccessfull();
				base.StartCoroutine(this.Add2());
			}
			if (this.counter == this.Amount.Length && this.questId == 2)
			{
				this.startQuest = false;
				this.questSuccessfull();
				base.StartCoroutine(this.Add3());
			}
			if (this.counter == this.Amount.Length && this.questId == 3)
			{
				this.startQuest = false;
				this.questSuccessfull();
				base.StartCoroutine(this.Add4());
			}
			if (this.counter == this.Amount.Length && this.questId == 4)
			{
				this.startQuest = false;
				this.questSuccessfull();
				base.StartCoroutine(this.Add5());
			}
			if (this.counter == this.Amount.Length && this.questId == 5)
			{
				this.startQuest = false;
				this.questSuccessfull();
				base.StartCoroutine(this.Add1());
			}
			if (this.counter == this.Amount.Length && this.questId == 6)
			{
				this.startQuest = false;
				this.questSuccessfull();
				base.StartCoroutine(this.Add2());
			}
			if (this.counter == this.Amount.Length && this.questId == 7)
			{
				this.startQuest = false;
				this.questSuccessfull();
				base.StartCoroutine(this.Add3());
			}
			if (this.counter == this.Amount.Length && this.questId == 8)
			{
				this.startQuest = false;
				this.timerLabel.gameObject.SetActive(false);
				this.allowTimer = false;
				this.questSuccessfull();
				base.StartCoroutine(this.Add4());
			}
			if (this.counter == this.Amount.Length && this.questId == 9)
			{
				this.startQuest = false;
				this.allowTimer = false;
				this.questSuccessfull();
				base.StartCoroutine(this.Add5());
			}
			if (this.counter == this.Amount.Length && this.questId == 10)
			{
				this.startQuest = false;
				this.questSuccessfull();
				base.StartCoroutine(this.Add1());
			}
			if (this.counter == this.Amount.Length && this.questId == 11)
			{
				this.startQuest = false;
				this.questSuccessfull();
				base.StartCoroutine(this.Add2());
			}
			if (this.counter == this.Amount.Length && this.questId == 12)
			{
				this.startQuest = false;
				this.questSuccessfull();
				base.StartCoroutine(this.Add3());
			}
			if (this.counter == this.Amount.Length && this.questId == 13)
			{
				this.startQuest = false;
				this.questSuccessfull();
			}
			if (this.counter == this.Amount.Length && this.questId == 14)
			{
				this.startQuest = false;
				this.questSuccessfull();
			}
			if (this.counter == this.Amount.Length && this.questId == 15)
			{
				this.startQuest = false;
				this.questSuccessfull();
			}
			this.counter = 0;
		}
	}

	// Token: 0x06000D14 RID: 3348 RVA: 0x00052814 File Offset: 0x00050C14
	private IEnumerator TimeRoutine()
	{
		this.decreaseTime = false;
		if (this.questId > 1)
		{
			yield return new WaitForSeconds((float)this.questId);
		}
		else
		{
			yield return new WaitForSeconds(1f);
		}
		this.time -= 1.0;
		this.decreaseTime = true;
		yield break;
	}

	// Token: 0x06000D15 RID: 3349 RVA: 0x00052830 File Offset: 0x00050C30
	private IEnumerator IdleWait()
	{
		string show = string.Empty;
		yield return new WaitForSeconds(2f);
		if (this.questId != 0)
		{
			show = "Quest " + this.questId + "\nYour Targets are : \n";
			for (int i = 0; i < this.target.Length; i++)
			{
				show = show + this.target[i] + " , ";
			}
			show = string.Empty;
		}
		yield break;
	}

	// Token: 0x06000D16 RID: 3350 RVA: 0x0005284C File Offset: 0x00050C4C
	private IEnumerator WaitNotifier()
	{
		yield return new WaitForSeconds(0f);
		yield break;
	}

	// Token: 0x06000D17 RID: 3351 RVA: 0x00052860 File Offset: 0x00050C60
	public bool questStarted()
	{
		return this.startQuest;
	}

	// Token: 0x06000D18 RID: 3352 RVA: 0x00052868 File Offset: 0x00050C68
	public void ResetTime()
	{
		this.time = 100.0;
	}

	// Token: 0x06000D19 RID: 3353 RVA: 0x00052879 File Offset: 0x00050C79
	public double getTime()
	{
		return this.time;
	}

	// Token: 0x06000D1A RID: 3354 RVA: 0x00052881 File Offset: 0x00050C81
	public void questSuccessfull()
	{
		base.StartCoroutine(this.QuestSuccessRoutine());
		this.arrow[gameplay.count].gameObject.SetActive(false);
	}

	// Token: 0x06000D1B RID: 3355 RVA: 0x000528A8 File Offset: 0x00050CA8
	public void questProgression()
	{
		int @int = PlayerPrefs.GetInt("TotalScore");
		PlayerPrefs.SetInt("TotalScore", @int + 500);
		this.leavingImage.gameObject.SetActive(true);
		base.GetComponent<CLProgress>().updateLevel("Quest", this.questId);
		gameplay.startCrazyLevel = true;
		Application.LoadLevel("InAppPurchase");
		this.ResetTime();
	}

	// Token: 0x06000D1C RID: 3356 RVA: 0x00052910 File Offset: 0x00050D10
	private IEnumerator QuestSuccessRoutine()
	{
		yield return new WaitForSeconds(0.5f);
		this.hideGUI();
		yield return new WaitForSeconds(1.5f);
		if (this.successType == "celebrate")
		{
			this.questProgress.StartCelebration();
			if (this.successSound)
			{
				base.GetComponent<AudioSource>().PlayOneShot(this.successSound);
			}
			yield return new WaitForSeconds(5f);
			this.questProgress.StopCelebration();
		}
		this.showSuccessBox();
		this.players[gameplay.count].GetComponent<StatusC>().health = 200;
		yield break;
	}

	// Token: 0x06000D1D RID: 3357 RVA: 0x0005292B File Offset: 0x00050D2B
	public void startNext()
	{
		this.questProgression();
	}

	// Token: 0x06000D1E RID: 3358 RVA: 0x00052933 File Offset: 0x00050D33
	private Vector3 setPivot(float X)
	{
		this.pivot = new Vector3(X, this.pivotPoint - 87.36f);
		this.pivotPoint -= 87.36f;
		return this.pivot;
	}

	// Token: 0x06000D1F RID: 3359 RVA: 0x00052968 File Offset: 0x00050D68
	private void showTargets()
	{
		for (int i = 0; i < this.animals.Length; i++)
		{
			for (int j = 0; j < this.target.Length; j++)
			{
				if (this.animals[i].gameObject.name.Equals(this.target[j]))
				{
					this.animals[i].SetActive(true);
					this.animals[i].gameObject.transform.localPosition = this.setPivot(this.animals[i].gameObject.transform.localPosition.x);
					this.animals[i].gameObject.GetComponentInChildren<Text>().text = this.Amount[j].ToString();
				}
			}
		}
		this.setPanel(this.pivotPoint);
	}

	// Token: 0x06000D20 RID: 3360 RVA: 0x00052A4F File Offset: 0x00050E4F
	public void GameOver()
	{
		this.death = true;
		base.StartCoroutine(this.WaitForGameOver());
	}

	// Token: 0x06000D21 RID: 3361 RVA: 0x00052A65 File Offset: 0x00050E65
	public void GameOver(string argument)
	{
		this.death = true;
		this.gameOverPanel.GetComponentInChildren<Text>().text = argument;
		Debug.Log("Game Over Called");
		base.StartCoroutine(this.WaitForGameOver());
	}

	// Token: 0x06000D22 RID: 3362 RVA: 0x00052A98 File Offset: 0x00050E98
	private IEnumerator WaitForGameOver()
	{
		if (this.failureSound)
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.failureSound);
		}
		this.hideGUI();
		yield return new WaitForSeconds(2f);
		if (QuestManager.skipcounter == 0)
		{
			MonoBehaviour.print(QuestManager.skipcounter);
			this.failedBox.gameObject.SetActive(true);
			QuestManager.skipcounter++;
		}
		else
		{
			MonoBehaviour.print("ya ah" + QuestManager.skipcounter);
			this.skipPanel.gameObject.SetActive(true);
			QuestManager.skipcounter = 0;
		}
		Time.timeScale = 0f;
		yield break;
	}

	// Token: 0x06000D23 RID: 3363 RVA: 0x00052AB4 File Offset: 0x00050EB4
	public void TimeUp()
	{
		this.pause = true;
		this.gameOverPanel.GetComponentInChildren<Text>().text = "TIME UP !";
		this.gameOverPanel.GetComponent<Animation>().Play("GameOver_Open");
		base.StartCoroutine(this.TimeUpRoutine());
	}

	// Token: 0x06000D24 RID: 3364 RVA: 0x00052B00 File Offset: 0x00050F00
	private IEnumerator TimeUpRoutine()
	{
		yield return new WaitForSeconds(2f);
		this.gameOverPanel.GetComponent<Animation>().Play("GameOver_Close");
		yield return new WaitForSeconds(1f);
		this.canvasScript.TimeUpStartAgain();
		this.ResetTime();
		this.pivotPoint = 190.13f;
		this.pause = false;
		this.decreaseTime = true;
		this.getQuest(this.questId);
		yield break;
	}

	// Token: 0x06000D25 RID: 3365 RVA: 0x00052B1B File Offset: 0x00050F1B
	public void setQuestID(int questId)
	{
		this.getQuest(questId);
	}

	// Token: 0x06000D26 RID: 3366 RVA: 0x00052B24 File Offset: 0x00050F24
	public int getQuestID()
	{
		return this.questId;
	}

	// Token: 0x06000D27 RID: 3367 RVA: 0x00052B2C File Offset: 0x00050F2C
	private void disableEnemies()
	{
		this.zone1enemies.SetActive(false);
		this.zone2enemies.SetActive(false);
		this.zone3enemies.SetActive(false);
		this.zone4enemies.SetActive(false);
		this.zone5enemies.SetActive(false);
		this.zone6enemies.SetActive(false);
		this.zone7enemies.SetActive(false);
		this.zone8enemies.SetActive(false);
		this.zone9enemies.SetActive(false);
		this.zone10enemies.SetActive(false);
		this.zone11enemies.SetActive(false);
		this.zone12enemies.SetActive(false);
		this.zone13enemies.SetActive(false);
		this.zone14enemies.SetActive(false);
		this.freeQuestenemies.SetActive(false);
		this.arrow[gameplay.count].gameObject.SetActive(false);
		this.players[gameplay.count].GetComponent<NewHealthBarC>().hunger = 100f;
		this.players[gameplay.count].GetComponent<NewHealthBarC>().thirst = 100f;
	}

	// Token: 0x06000D28 RID: 3368 RVA: 0x00052C3C File Offset: 0x0005103C
	private void activatingEnemies(int quest)
	{
		if (quest == 0)
		{
			this.zone1enemies.SetActive(true);
			this.Enemies = this.zone1enemies;
		}
		if (quest == 1)
		{
			this.zone2enemies.SetActive(true);
		}
		if (quest == 2)
		{
			this.zone3enemies.SetActive(true);
		}
		if (quest == 3)
		{
			this.zone4enemies.SetActive(true);
		}
		if (quest == 4)
		{
			this.zone5enemies.SetActive(true);
		}
		if (quest == 5)
		{
			this.zone6enemies.SetActive(true);
		}
		if (quest == 6)
		{
			this.zone7enemies.SetActive(true);
		}
		if (quest == 7)
		{
			this.zone8enemies.SetActive(true);
		}
		if (quest == 8)
		{
			this.zone9enemies.SetActive(true);
		}
		if (quest == 9)
		{
			this.zone10enemies.SetActive(true);
		}
		if (quest == 10)
		{
			this.zone11enemies.SetActive(true);
		}
		if (quest == 11)
		{
			this.zone12enemies.SetActive(true);
		}
		if (quest == 12)
		{
			this.zone13enemies.SetActive(true);
		}
		if (quest == 13)
		{
			this.zone12enemies.SetActive(true);
		}
		if (quest == 14)
		{
			this.zone13enemies.SetActive(true);
		}
		if (quest == 15)
		{
		}
		if (quest == 16)
		{
			this.zone13enemies.SetActive(true);
		}
		if (quest == 17)
		{
			this.zone14enemies.SetActive(true);
		}
		if (quest == 18)
		{
			this.freeQuestenemies.SetActive(true);
		}
	}

	// Token: 0x06000D29 RID: 3369 RVA: 0x00052DBC File Offset: 0x000511BC
	private void settingPositions(int quest)
	{
		float x = this.players[gameplay.count].gameObject.transform.eulerAngles.x;
		float y = this.players[gameplay.count].gameObject.transform.eulerAngles.y;
		float z = this.players[gameplay.count].gameObject.transform.eulerAngles.z;
		if (quest == 0)
		{
			this.players[gameplay.count].gameObject.transform.position = this.zonePositions[0].transform.position;
			this.players[gameplay.count].gameObject.transform.rotation = this.zonePositions[0].transform.rotation;
			this.players1[gameplay.count].gameObject.transform.position = this.zonePositions[0].transform.position;
			this.players1[gameplay.count].gameObject.transform.rotation = this.zonePositions[0].transform.rotation;
		}
		if (quest == 1)
		{
			this.players[gameplay.count].gameObject.transform.position = this.zonePositions[1].transform.position;
			this.players[gameplay.count].gameObject.transform.rotation = this.zonePositions[1].transform.rotation;
			this.players1[gameplay.count].gameObject.transform.position = this.zonePositions[1].transform.position;
			this.players1[gameplay.count].gameObject.transform.rotation = this.zonePositions[1].transform.rotation;
		}
		if (quest == 2)
		{
			this.players[gameplay.count].gameObject.transform.position = this.zonePositions[2].transform.position;
			this.players[gameplay.count].gameObject.transform.rotation = this.zonePositions[2].transform.rotation;
			this.players1[gameplay.count].gameObject.transform.position = this.zonePositions[2].transform.position;
			this.players1[gameplay.count].gameObject.transform.rotation = this.zonePositions[2].transform.rotation;
		}
		if (quest == 3)
		{
			this.players[gameplay.count].gameObject.transform.position = this.zonePositions[3].transform.position;
			this.players[gameplay.count].gameObject.transform.rotation = this.zonePositions[3].transform.rotation;
			this.players1[gameplay.count].gameObject.transform.position = this.zonePositions[3].transform.position;
			this.players1[gameplay.count].gameObject.transform.rotation = this.zonePositions[3].transform.rotation;
		}
		if (quest == 4)
		{
			this.players[gameplay.count].gameObject.transform.position = this.zonePositions[4].transform.position;
			this.players[gameplay.count].gameObject.transform.rotation = this.zonePositions[4].transform.rotation;
		}
		if (quest == 5)
		{
			this.players[gameplay.count].gameObject.transform.position = this.zonePositions[5].transform.position;
			this.players[gameplay.count].gameObject.transform.rotation = this.zonePositions[5].transform.rotation;
		}
		if (quest == 6)
		{
			this.players[gameplay.count].gameObject.transform.position = this.zonePositions[6].transform.position;
			this.players[gameplay.count].gameObject.transform.rotation = this.zonePositions[6].transform.rotation;
			this.players1[gameplay.count].gameObject.transform.position = this.zonePositions[6].transform.position;
			this.players1[gameplay.count].gameObject.transform.rotation = this.zonePositions[6].transform.rotation;
		}
		if (quest == 7)
		{
			this.players[gameplay.count].gameObject.transform.position = this.zonePositions[7].transform.position;
			this.players[gameplay.count].gameObject.transform.rotation = this.zonePositions[7].transform.rotation;
		}
		if (quest == 8)
		{
			this.players[gameplay.count].gameObject.transform.position = this.zonePositions[8].transform.position;
			this.players[gameplay.count].gameObject.transform.rotation = this.zonePositions[8].transform.rotation;
		}
		if (quest == 9)
		{
			this.players[gameplay.count].gameObject.transform.position = this.zonePositions[9].transform.position;
			this.players[gameplay.count].gameObject.transform.rotation = this.zonePositions[9].transform.rotation;
		}
		if (quest == 10)
		{
			this.players[gameplay.count].gameObject.transform.position = this.zonePositions[10].transform.position;
			this.players[gameplay.count].gameObject.transform.rotation = this.zonePositions[10].transform.rotation;
		}
		if (quest == 11)
		{
			this.players[gameplay.count].gameObject.transform.position = this.zonePositions[10].transform.position;
		}
		if (quest == 12)
		{
			this.players[gameplay.count].gameObject.transform.position = this.zonePositions[7].transform.position;
		}
		if (quest == 13)
		{
			this.players[gameplay.count].gameObject.transform.position = this.zonePositions[7].transform.position;
		}
		if (quest == 14)
		{
			this.players[gameplay.count].gameObject.transform.position = this.zonePositions[2].transform.position;
		}
	}

	// Token: 0x06000D2A RID: 3370 RVA: 0x00053500 File Offset: 0x00051900
	public void getQuest(int questId)
	{
		if (PlayerPrefs.GetInt("FreeMode") == 1)
		{
			questId = 11;
		}
		this.questId = questId;
		bool flag = base.GetComponent<Quests>().setQuest(questId);
		this.disableEnemies();
		this.activatingEnemies(questId);
		this.settingPositions(questId);
		if (questId == 0)
		{
			this.Hero.gameObject.SetActive(false);
			this.Hero1.GetComponent<PlayerMecanimAnimationC>().animator = this.hero1models[gameplay.count].GetComponent<Animator>();
			base.StartCoroutine(this.waitForCutScene(2f));
		}
		if (questId >= 0)
		{
			this.players[gameplay.count].GetComponent<AttackTriggerC>().gunMode();
		}
		if (questId == 1)
		{
			this.minimap.GetComponent<MapCanvasController>().playerTransform = this.Hero.transform;
			base.StartCoroutine(this.waitForCutScene(2f));
		}
		if (questId == 2)
		{
			base.StartCoroutine(this.waitForCutScene(2f));
		}
		if (questId == 3)
		{
			this.Hero1.GetComponent<PlayerMecanimAnimationC>().animator = this.hero1models[gameplay.count].GetComponent<Animator>();
			base.StartCoroutine(this.waitForCutScene(2f));
		}
		if (questId > 3)
		{
		}
		if (questId == 4)
		{
			this.Hero1Camera.gameObject.SetActive(false);
			base.StartCoroutine(this.waitForCutScene(3f));
		}
		if (questId == 5)
		{
			this.Hero1Camera.gameObject.SetActive(false);
			base.StartCoroutine(this.waitForCutScene(4f));
		}
		if (questId == 6)
		{
			this.Hero1Camera.gameObject.SetActive(false);
			base.StartCoroutine(this.waitForCutScene(2f));
		}
		if (questId == 7)
		{
			this.Hero1Camera.gameObject.SetActive(false);
			base.StartCoroutine(this.waitForCutScene(4f));
		}
		if (questId == 8)
		{
			this.Hero1Camera.gameObject.SetActive(false);
			base.StartCoroutine(this.waitForCutScene(4f));
		}
		if (questId == 9)
		{
			this.Hero1Camera.gameObject.SetActive(false);
			base.StartCoroutine(this.waitForCutScene(2f));
		}
		if (questId == 10)
		{
			this.Hero1Camera.gameObject.SetActive(false);
			base.StartCoroutine(this.waitForCutScene(4f));
		}
		if (questId == 11)
		{
			base.StartCoroutine(this.waitForCutScene(4f));
		}
		if (questId > 11)
		{
		}
		if (questId == 12)
		{
			base.StartCoroutine(this.waitForCutScene(4f));
		}
		if (questId == 13)
		{
			base.StartCoroutine(this.waitForCutScene(4f));
		}
		if (questId == 14)
		{
			base.StartCoroutine(this.waitForCutScene(4f));
		}
		if (flag)
		{
			base.StartCoroutine(this.IdleWait());
			this.startQuest = true;
			this.target = base.GetComponent<Quests>().getQuestTarget();
			this.Amount = base.GetComponent<Quests>().getQuestTargetAmount();
			this.showTargets();
		}
		else
		{
			this.gameOverPanel.GetComponentInChildren<Text>().text = "Game Completed !";
			this.gameOverPanel.GetComponent<Animation>().Play("GameOver_Open");
			base.StartCoroutine(this.GameComplete());
		}
	}

	// Token: 0x06000D2B RID: 3371 RVA: 0x00053855 File Offset: 0x00051C55
	public void hideGUI()
	{
		this.canvas.gameObject.SetActive(false);
		this.joystick2.gameObject.SetActive(false);
		base.GetComponent<dogsactive>().disableComponents();
		this.CFPP.gameObject.SetActive(false);
	}

	// Token: 0x06000D2C RID: 3372 RVA: 0x00053898 File Offset: 0x00051C98
	public void showGUI()
	{
		this.CFPP.gameObject.SetActive(true);
		base.GetComponent<dogsactive>().enableComponents();
		this.joystick1.gameObject.SetActive(true);
		this.joystick2.gameObject.SetActive(true);
		this.canvas.gameObject.SetActive(true);
		if (PlayerPrefs.GetInt("Quest") == 2)
		{
			this.Hero1.transform.GetChild(15).gameObject.SetActive(false);
		}
	}

	// Token: 0x06000D2D RID: 3373 RVA: 0x00053924 File Offset: 0x00051D24
	private IEnumerator playerWaterPositionJugaar(int pos)
	{
		yield return new WaitForSeconds(1f);
		this.players[gameplay.count].gameObject.transform.position = this.zonePositions[pos].transform.position;
		yield break;
	}

	// Token: 0x06000D2E RID: 3374 RVA: 0x00053948 File Offset: 0x00051D48
	private IEnumerator jugaarForQuest(int pos)
	{
		yield return new WaitForSeconds(1f);
		this.players[gameplay.count].gameObject.transform.position = this.zonePositions[pos].transform.position;
		yield break;
	}

	// Token: 0x06000D2F RID: 3375 RVA: 0x0005396C File Offset: 0x00051D6C
	private IEnumerator timer()
	{
		this.timerCount--;
		yield return new WaitForSeconds(1f);
		this.allowTimer = true;
		yield break;
	}

	// Token: 0x06000D30 RID: 3376 RVA: 0x00053988 File Offset: 0x00051D88
	private IEnumerator waitForCutScene(float sceneTime)
	{
		this.players[gameplay.count].tag = "Dragable";
		this.CutSceneCam.GetComponent<CutsceneManager>().StartCutscene(this.questId, sceneTime);
		base.GetComponent<dogsactive>().getActiveCamera().SetActive(false);
		this.hideGUI();
		yield return new WaitForSeconds(sceneTime);
		base.GetComponent<dogsactive>().getActiveCamera().SetActive(true);
		this.showInfoBox(base.GetComponent<Quests>().getStatement(), this.questId);
		yield break;
	}

	// Token: 0x06000D31 RID: 3377 RVA: 0x000539AC File Offset: 0x00051DAC
	private IEnumerator GameComplete()
	{
		yield return new WaitForSeconds(3f);
		this.panel.gameObject.SetActive(false);
		this.gameOverPanel.GetComponentInChildren<Text>().text = "FROM NOW, HORSE RULES !";
		yield return new WaitForSeconds(2f);
		this.gameOverPanel.GetComponent<Animation>().Play("GameOver_Close");
		yield return new WaitForSeconds(2f);
		yield break;
	}

	// Token: 0x06000D32 RID: 3378 RVA: 0x000539C7 File Offset: 0x00051DC7
	public void setArrowDirection(Transform pos)
	{
		this.arrow[gameplay.count].GetComponent<arrow>().setTarget(pos);
	}

	// Token: 0x06000D33 RID: 3379 RVA: 0x000539E0 File Offset: 0x00051DE0
	public void reached(string targetName)
	{
		for (int i = 0; i < this.target.Length; i++)
		{
			if (targetName.Equals(this.target[i]) && this.Amount[i] > 0)
			{
				this.Amount[i]--;
				for (int j = 0; j < this.animals.Length; j++)
				{
					if (this.animals[j].gameObject.name.ToString().Equals(targetName))
					{
						this.animals[j].gameObject.GetComponentInChildren<Text>().text = this.Amount[i].ToString();
						break;
					}
				}
			}
		}
	}

	// Token: 0x06000D34 RID: 3380 RVA: 0x00053AA8 File Offset: 0x00051EA8
	public void consumed(string targetName)
	{
		for (int i = 0; i < this.target.Length; i++)
		{
			if (targetName.Equals(this.target[i]) && this.Amount[i] > 0)
			{
				this.Amount[i]--;
				for (int j = 0; j < this.animals.Length; j++)
				{
					if (this.animals[j].gameObject.name.ToString().Equals(targetName))
					{
						this.animals[j].gameObject.GetComponentInChildren<Text>().text = this.Amount[i].ToString();
						break;
					}
				}
			}
		}
	}

	// Token: 0x06000D35 RID: 3381 RVA: 0x00053B70 File Offset: 0x00051F70
	public void targetKilled(string targetName)
	{
		for (int i = 0; i < this.target.Length; i++)
		{
			if (targetName.Equals(this.target[i]) && this.Amount[i] > 0)
			{
				this.Amount[i]--;
				for (int j = 0; j < this.animals.Length; j++)
				{
					if (this.animals[j].gameObject.name.ToString().Equals(targetName))
					{
						this.animals[j].gameObject.GetComponentInChildren<Text>().text = this.Amount[i].ToString();
						break;
					}
				}
			}
		}
	}

	// Token: 0x06000D36 RID: 3382 RVA: 0x00053C38 File Offset: 0x00052038
	public void setPanel(float pivot)
	{
		if (pivot == -206.67f)
		{
			this.panel.rectTransform.sizeDelta = new Vector3(this.panel.rectTransform.sizeDelta.x, this.panel.rectTransform.sizeDelta.y + 125f);
			this.panel.transform.localPosition = new Vector3(this.panel.transform.localPosition.x, this.panel.transform.localPosition.y - 25f);
		}
		if (pivot == -294.03f)
		{
			this.panel.rectTransform.sizeDelta = new Vector3(this.panel.rectTransform.sizeDelta.x, this.panel.rectTransform.sizeDelta.y + 150f);
			this.panel.transform.localPosition = new Vector3(this.panel.transform.localPosition.x, this.panel.transform.localPosition.y - 25f);
		}
	}

	// Token: 0x06000D37 RID: 3383 RVA: 0x00053D95 File Offset: 0x00052195
	public string[] getTargets()
	{
		return this.target;
	}

	// Token: 0x06000D38 RID: 3384 RVA: 0x00053D9D File Offset: 0x0005219D
	public int[] getTargetsAmount()
	{
		return this.Amount;
	}

	// Token: 0x06000D39 RID: 3385 RVA: 0x00053DA5 File Offset: 0x000521A5
	public void enableChild1()
	{
		this.childHorse1.SetActive(true);
		this.childHorse1.GetComponent<AIfriendC>().allowFollowing = true;
	}

	// Token: 0x06000D3A RID: 3386 RVA: 0x00053DC4 File Offset: 0x000521C4
	public void enableChild2()
	{
		this.childHorse2.SetActive(true);
		this.childHorse2.GetComponent<AIfriendC>().allowFollowing = true;
	}

	// Token: 0x06000D3B RID: 3387 RVA: 0x00053DE3 File Offset: 0x000521E3
	public void startFuriousAttack()
	{
		this.players[gameplay.count].GetComponent<FuriousAttack>().showTargets();
	}

	// Token: 0x06000D3C RID: 3388 RVA: 0x00053DFB File Offset: 0x000521FB
	private void startStoryScene(int qid)
	{
		qid--;
		if (qid == 2 || qid == 10)
		{
			PlayerPrefs.SetString("Scene", "CutScene");
			Application.LoadLevel("Loading");
		}
	}

	// Token: 0x06000D3D RID: 3389 RVA: 0x00053E2C File Offset: 0x0005222C
	public void PauseMenu()
	{
		if (Application.platform == RuntimePlatform.Android && !Application.isEditor)
		{
			if (HZInterstitialAd.IsAvailable())
			{
				HZInterstitialAd.Show();
			}
			else if (Admob.Instance().isInterstitialReady())
			{
				Admob.Instance().showInterstitial();
			}
		}
		this.Play_ButtonClickSound();
		if (!this.showWindow && Time.timeScale != 0f)
		{
			Time.timeScale = 0f;
			this.hideGUI();
			this.showWindow = true;
			this.questM.pause = true;
			this.pauseWindow.gameObject.SetActive(true);
		}
		else
		{
			this.showWindow = false;
			this.showGUI();
			Time.timeScale = 1f;
			this.questM.pause = false;
			this.pauseWindow.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000D3E RID: 3390 RVA: 0x00053F0C File Offset: 0x0005230C
	public void Resume()
	{
		this.Play_ButtonClickSound();
		this.showWindow = false;
		Time.timeScale = 1f;
		Screen.lockCursor = true;
		this.questM.pause = false;
		this.pauseWindow.gameObject.SetActive(false);
		this.showGUI();
	}

	// Token: 0x06000D3F RID: 3391 RVA: 0x00053F59 File Offset: 0x00052359
	public void RateUs()
	{
		Application.OpenURL("market://details?id=" + Adpack.PACKAGE_NAME);
		this.rateBox.gameObject.SetActive(false);
		Time.timeScale = 1f;
		this.questM.startNext();
	}

	// Token: 0x06000D40 RID: 3392 RVA: 0x00053F98 File Offset: 0x00052398
	public void Restart()
	{
		if (Application.platform == RuntimePlatform.Android && !Application.isEditor)
		{
			if (AppLovin.HasPreloadedInterstitial(null))
			{
				AppLovin.ShowInterstitial();
			}
			else if (HZInterstitialAd.IsAvailable())
			{
				HZInterstitialAd.Show();
			}
		}
		PlayerPrefs.SetString("Scene", "MainScene");
		Application.LoadLevel("Loading");
	}

	// Token: 0x06000D41 RID: 3393 RVA: 0x00053FF8 File Offset: 0x000523F8
	public void Home()
	{
		PlayerPrefs.SetInt("Quest", this.questM.getQuestID());
		if (this.player)
		{
			UnityEngine.Object.Destroy(this.player);
		}
		Application.LoadLevel("MainMenu");
		Admob.Instance().removeBanner("defaultBanner");
		if (AppLovin.HasPreloadedInterstitial(null))
		{
			AppLovin.ShowInterstitial();
		}
		else if (Admob.Instance().isInterstitialReady())
		{
			Admob.Instance().showInterstitial();
		}
	}

	// Token: 0x06000D42 RID: 3394 RVA: 0x0005407C File Offset: 0x0005247C
	public void showInfoBox(string statement, int quest)
	{
		this.infoBox.gameObject.SetActive(true);
		this.infoBox.GetComponentInChildren<Text>().text = statement;
		base.StartCoroutine(this.showOk());
	}

	// Token: 0x06000D43 RID: 3395 RVA: 0x000540B0 File Offset: 0x000524B0
	private IEnumerator showOk()
	{
		this.infoBoxOk.gameObject.SetActive(false);
		yield return new WaitForSeconds(2f);
		this.infoBoxOk.gameObject.SetActive(true);
		yield break;
	}

	// Token: 0x06000D44 RID: 3396 RVA: 0x000540CB File Offset: 0x000524CB
	public void skip()
	{
		base.GetComponent<watchvideo>().watchVideo();
	}

	// Token: 0x06000D45 RID: 3397 RVA: 0x000540D8 File Offset: 0x000524D8
	public void skipVideoWatched()
	{
		this.skipPanel.gameObject.SetActive(false);
		Time.timeScale = 1f;
		this.questProgression();
	}

	// Token: 0x06000D46 RID: 3398 RVA: 0x000540FB File Offset: 0x000524FB
	public void skipVideoNotWatched()
	{
		this.noVideoPanel.gameObject.SetActive(true);
		this.skipPanel.gameObject.SetActive(false);
	}

	// Token: 0x06000D47 RID: 3399 RVA: 0x0005411F File Offset: 0x0005251F
	public void CloseNoVideo()
	{
		this.noVideoPanel.gameObject.SetActive(false);
		this.failedBox.gameObject.SetActive(true);
	}

	// Token: 0x06000D48 RID: 3400 RVA: 0x00054144 File Offset: 0x00052544
	public void StartOk()
	{
		Chartboost.showInterstitial(CBLocation.HomeScreen);
		this.Play_ButtonClickSound();
		if (this.questId == 0)
		{
			this.AllScene1Object.gameObject.SetActive(false);
			this.SceneCanves.gameObject.SetActive(false);
		}
		this.showGUI();
		this.infoBox.gameObject.SetActive(false);
		this.players[gameplay.count].tag = "Player";
		Time.timeScale = 1f;
	}

	// Token: 0x06000D49 RID: 3401 RVA: 0x000541C8 File Offset: 0x000525C8
	public void showSuccessBox()
	{
		int questID = base.GetComponent<QuestManager>().getQuestID();
		if (questID == 2 || questID == 9)
		{
			this.rateBox.gameObject.SetActive(true);
			Time.timeScale = 0f;
		}
		else
		{
			this.successBox.gameObject.SetActive(true);
			Time.timeScale = 0f;
		}
		QuestManager.skipcounter = 0;
	}

	// Token: 0x06000D4A RID: 3402 RVA: 0x00054234 File Offset: 0x00052634
	public void hideSuccessStartNext()
	{
		Admob.Instance().removeBanner("defaultBanner");
		this.Play_ButtonClickSound();
		Time.timeScale = 1f;
		this.successBox.gameObject.SetActive(false);
		this.rateBox.gameObject.SetActive(false);
		this.questM.startNext();
	}

	// Token: 0x06000D4B RID: 3403 RVA: 0x0005428D File Offset: 0x0005268D
	public void HomeSuccess()
	{
		this.Play_ButtonClickSound();
		Time.timeScale = 1f;
		this.successBox.gameObject.SetActive(false);
		this.rateBox.gameObject.SetActive(false);
		this.questM.startNext();
	}

	// Token: 0x06000D4C RID: 3404 RVA: 0x000542CC File Offset: 0x000526CC
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

	// Token: 0x06000D4D RID: 3405 RVA: 0x00054336 File Offset: 0x00052736
	public void showEat()
	{
		this.playerClass = (UnityEngine.Object.FindObjectOfType(typeof(PlayerInputControllerC)) as PlayerInputControllerC);
		this.playerClass.eats = true;
		this.Eat.gameObject.SetActive(true);
	}

	// Token: 0x06000D4E RID: 3406 RVA: 0x0005436F File Offset: 0x0005276F
	public void hideEat()
	{
		this.Eat.gameObject.SetActive(false);
	}

	// Token: 0x06000D4F RID: 3407 RVA: 0x00054382 File Offset: 0x00052782
	public void changeWeapon()
	{
		this.players[gameplay.count].GetComponent<WeaponSwitch>().nextWeapon();
	}

	// Token: 0x06000D50 RID: 3408 RVA: 0x0005439A File Offset: 0x0005279A
	public void drink()
	{
		base.StartCoroutine(this.drinkdelay());
	}

	// Token: 0x06000D51 RID: 3409 RVA: 0x000543AC File Offset: 0x000527AC
	private IEnumerator drinkdelay()
	{
		this.players[gameplay.count].GetComponent<WeaponSwitch>().activateEquipmentForTime(0, 2f, true);
		base.GetComponent<dogsactive>().getActiveJoystick().GetComponent<EasyJoystick>().speed.y = 0f;
		base.GetComponent<dogsactive>().getActivePlayer().GetComponent<PlayerMecanimAnimationC>().PlayDrinkAnim();
		this.panelInteract.gameObject.SetActive(false);
		if (base.GetComponent<SoundContainer>().drinkSound)
		{
			base.GetComponent<AudioSource>().PlayOneShot(base.GetComponent<SoundContainer>().drinkSound, 0.9f);
		}
		yield return new WaitForSeconds(2f);
		base.GetComponent<dogsactive>().getActiveJoystick().GetComponent<EasyJoystick>().speed.y = 8f;
		base.GetComponent<dogsactive>().getActivePlayer().GetComponent<NewHealthBarC>().fillThirst(100f);
		this.panelInteract.gameObject.SetActive(true);
		yield break;
	}

	// Token: 0x06000D52 RID: 3410 RVA: 0x000543C7 File Offset: 0x000527C7
	public void CloseInfoPanel()
	{
		this.Play_ButtonClickSound();
		this.questInfoPanel.gameObject.SetActive(false);
	}

	// Token: 0x06000D53 RID: 3411 RVA: 0x000543E0 File Offset: 0x000527E0
	private void Play_ButtonClickSound()
	{
		if (this.sound_touch)
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.sound_touch, 0.7f);
		}
	}

	// Token: 0x06000D54 RID: 3412 RVA: 0x00054408 File Offset: 0x00052808
	public void OpenInfoPanel()
	{
		this.Play_ButtonClickSound();
		this.questInfoPanel.gameObject.SetActive(true);
		this.questInfoPanel.GetComponentInChildren<Text>().text = base.GetComponent<Quests>().getStatement();
	}

	// Token: 0x06000D55 RID: 3413 RVA: 0x0005443C File Offset: 0x0005283C
	private IEnumerator waitForCutScenelevel1()
	{
		this.players[gameplay.count].tag = "Dragable";
		base.StartCoroutine(this.Scene1());
		yield return null;
		yield break;
	}

	// Token: 0x06000D56 RID: 3414 RVA: 0x00054458 File Offset: 0x00052858
	private IEnumerator Scene1()
	{
		for (int i = 0; i < this.SceneCamera.Length; i++)
		{
			this.SceneCamera[i].gameObject.SetActive(false);
		}
		base.GetComponent<dogsactive>().getActiveCamera().SetActive(false);
		this.hideGUI();
		this.AllScene1Object.gameObject.SetActive(true);
		this.SceneCanves.gameObject.SetActive(true);
		this.SceneCamera[0].gameObject.SetActive(true);
		this.InstructionPanel[0].gameObject.SetActive(true);
		yield return new WaitForSeconds(4f);
		base.StartCoroutine(this.Scene2());
		yield break;
	}

	// Token: 0x06000D57 RID: 3415 RVA: 0x00054474 File Offset: 0x00052874
	private IEnumerator Scene2()
	{
		this.SceneCamera[0].gameObject.SetActive(false);
		this.InstructionPanel[0].gameObject.SetActive(false);
		this.SceneCamera[1].gameObject.SetActive(true);
		this.InstructionPanel[1].gameObject.SetActive(true);
		yield return new WaitForSeconds(4f);
		base.StartCoroutine(this.Scene3());
		yield break;
	}

	// Token: 0x06000D58 RID: 3416 RVA: 0x00054490 File Offset: 0x00052890
	private IEnumerator Scene3()
	{
		this.SceneCamera[1].gameObject.SetActive(false);
		this.InstructionPanel[1].gameObject.SetActive(false);
		this.SceneCamera[2].gameObject.SetActive(true);
		this.InstructionPanel[2].gameObject.SetActive(true);
		yield return new WaitForSeconds(4f);
		base.StartCoroutine(this.Scene4());
		yield break;
	}

	// Token: 0x06000D59 RID: 3417 RVA: 0x000544AC File Offset: 0x000528AC
	private IEnumerator Scene4()
	{
		this.SceneCamera[2].gameObject.SetActive(false);
		this.InstructionPanel[2].gameObject.SetActive(false);
		this.SceneCamera[3].gameObject.SetActive(true);
		this.InstructionPanel[3].gameObject.SetActive(true);
		yield return new WaitForSeconds(4f);
		this.SceneCamera[3].gameObject.SetActive(false);
		this.InstructionPanel[3].gameObject.SetActive(false);
		base.GetComponent<dogsactive>().getActiveCamera().SetActive(true);
		this.SceneCanves.gameObject.SetActive(false);
		if (!this.stopCoroutine)
		{
			this.showInfoBox(base.GetComponent<Quests>().getStatement(), this.questId);
		}
		yield break;
	}

	// Token: 0x06000D5A RID: 3418 RVA: 0x000544C7 File Offset: 0x000528C7
	public void SkipScene()
	{
		this.stopCoroutine = true;
		base.StartCoroutine(this.waitForCutScene(4f));
		this.SceneCanves.gameObject.SetActive(false);
		this.AllScene1Object.gameObject.SetActive(false);
	}

	// Token: 0x04000D8C RID: 3468
	[Header("GUIFunctions Variables")]
	public Image pauseWindow;

	// Token: 0x04000D8D RID: 3469
	public Image infoBox;

	// Token: 0x04000D8E RID: 3470
	public Button infoBoxOk;

	// Token: 0x04000D8F RID: 3471
	public Image successBox;

	// Token: 0x04000D90 RID: 3472
	public Image failedBox;

	// Token: 0x04000D91 RID: 3473
	public Image skipPanel;

	// Token: 0x04000D92 RID: 3474
	public Image noVideoPanel;

	// Token: 0x04000D93 RID: 3475
	public Image rateBox;

	// Token: 0x04000D94 RID: 3476
	public Image questInfoPanel;

	// Token: 0x04000D95 RID: 3477
	public Image Eat;

	// Token: 0x04000D96 RID: 3478
	public Image panelInteract;

	// Token: 0x04000D97 RID: 3479
	public Image EatBAR;

	// Token: 0x04000D98 RID: 3480
	public Image fader;

	// Token: 0x04000D99 RID: 3481
	public Image leavingImage;

	// Token: 0x04000D9A RID: 3482
	public Text LandingText;

	// Token: 0x04000D9B RID: 3483
	public AudioClip sound_touch;

	// Token: 0x04000D9C RID: 3484
	private PlayerInputControllerC playerClass;

	// Token: 0x04000D9D RID: 3485
	private bool showWindow;

	// Token: 0x04000D9E RID: 3486
	private GameObject player;

	// Token: 0x04000D9F RID: 3487
	private bool allowEat = true;

	// Token: 0x04000DA0 RID: 3488
	private float eatProgress = 1f;

	// Token: 0x04000DA1 RID: 3489
	[HideInInspector]
	public QuestManager questM;

	// Token: 0x04000DA2 RID: 3490
	private bool startFlow = true;

	// Token: 0x04000DA3 RID: 3491
	[Header("QuestManager Variables")]
	public int QID;

	// Token: 0x04000DA4 RID: 3492
	public bool tutorial;

	// Token: 0x04000DA5 RID: 3493
	public GameObject zone1enemies;

	// Token: 0x04000DA6 RID: 3494
	public GameObject zone2enemies;

	// Token: 0x04000DA7 RID: 3495
	public GameObject zone3enemies;

	// Token: 0x04000DA8 RID: 3496
	public GameObject zone4enemies;

	// Token: 0x04000DA9 RID: 3497
	public GameObject zone5enemies;

	// Token: 0x04000DAA RID: 3498
	public GameObject zone6enemies;

	// Token: 0x04000DAB RID: 3499
	public GameObject zone7enemies;

	// Token: 0x04000DAC RID: 3500
	public GameObject zone8enemies;

	// Token: 0x04000DAD RID: 3501
	public GameObject zone9enemies;

	// Token: 0x04000DAE RID: 3502
	public GameObject zone10enemies;

	// Token: 0x04000DAF RID: 3503
	public GameObject zone11enemies;

	// Token: 0x04000DB0 RID: 3504
	public GameObject zone12enemies;

	// Token: 0x04000DB1 RID: 3505
	public GameObject zone13enemies;

	// Token: 0x04000DB2 RID: 3506
	public GameObject zone14enemies;

	// Token: 0x04000DB3 RID: 3507
	public GameObject freeQuestenemies;

	// Token: 0x04000DB4 RID: 3508
	public GameObject[] raftPositions;

	// Token: 0x04000DB5 RID: 3509
	public GameObject[] randomObjects;

	// Token: 0x04000DB6 RID: 3510
	private string successType = "celebrate";

	// Token: 0x04000DB7 RID: 3511
	private GameObject Enemies;

	// Token: 0x04000DB8 RID: 3512
	public GameObject home2;

	// Token: 0x04000DB9 RID: 3513
	public GameObject mate;

	// Token: 0x04000DBA RID: 3514
	public GameObject mate2;

	// Token: 0x04000DBB RID: 3515
	public GameObject minimap;

	// Token: 0x04000DBC RID: 3516
	public GameObject childHorse1;

	// Token: 0x04000DBD RID: 3517
	public GameObject childHorse2;

	// Token: 0x04000DBE RID: 3518
	public GameObject CFPP;

	// Token: 0x04000DBF RID: 3519
	public GameObject[] arrow;

	// Token: 0x04000DC0 RID: 3520
	public Text timerLabel;

	// Token: 0x04000DC1 RID: 3521
	public Text timerText;

	// Token: 0x04000DC2 RID: 3522
	public GameObject TargetPoint;

	// Token: 0x04000DC3 RID: 3523
	public GameObject[] points;

	// Token: 0x04000DC4 RID: 3524
	public GameObject[] zonePositions;

	// Token: 0x04000DC5 RID: 3525
	public Transform[] matePositions;

	// Token: 0x04000DC6 RID: 3526
	public GameObject[] players;

	// Token: 0x04000DC7 RID: 3527
	public GameObject[] players1;

	// Token: 0x04000DC8 RID: 3528
	public Canvas canvas;

	// Token: 0x04000DC9 RID: 3529
	public GameObject CutSceneCam;

	// Token: 0x04000DCA RID: 3530
	private int timerCount = 140;

	// Token: 0x04000DCB RID: 3531
	private bool allowTimer;

	// Token: 0x04000DCC RID: 3532
	private int questId;

	// Token: 0x04000DCD RID: 3533
	private string[] target = new string[9];

	// Token: 0x04000DCE RID: 3534
	public Image gameOverPanel;

	// Token: 0x04000DCF RID: 3535
	[HideInInspector]
	public int[] Amount = new int[12];

	// Token: 0x04000DD0 RID: 3536
	public Image Notifier;

	// Token: 0x04000DD1 RID: 3537
	public Image panel;

	// Token: 0x04000DD2 RID: 3538
	private string questStatement = string.Empty;

	// Token: 0x04000DD3 RID: 3539
	private Vector3 pivot;

	// Token: 0x04000DD4 RID: 3540
	private float pivotPoint = 190.13f;

	// Token: 0x04000DD5 RID: 3541
	public GameObject[] animals = new GameObject[3];

	// Token: 0x04000DD6 RID: 3542
	public GameObject[] PointToTrigger;

	// Token: 0x04000DD7 RID: 3543
	private StatusC statusC;

	// Token: 0x04000DD8 RID: 3544
	[HideInInspector]
	public int counter;

	// Token: 0x04000DD9 RID: 3545
	private CanvasScript canvasScript;

	// Token: 0x04000DDA RID: 3546
	private QuestProgress qp;

	// Token: 0x04000DDB RID: 3547
	private double time = 100.0;

	// Token: 0x04000DDC RID: 3548
	private bool decreaseTime = true;

	// Token: 0x04000DDD RID: 3549
	[HideInInspector]
	public bool pause;

	// Token: 0x04000DDE RID: 3550
	[HideInInspector]
	public bool celebrate;

	// Token: 0x04000DDF RID: 3551
	[HideInInspector]
	public bool death;

	// Token: 0x04000DE0 RID: 3552
	[HideInInspector]
	public bool timeDeath;

	// Token: 0x04000DE1 RID: 3553
	public bool startok = true;

	// Token: 0x04000DE2 RID: 3554
	[HideInInspector]
	public bool startQuest;

	// Token: 0x04000DE3 RID: 3555
	private QuestProgress questProgress;

	// Token: 0x04000DE4 RID: 3556
	private GUIFunctions guiFunc;

	// Token: 0x04000DE5 RID: 3557
	public AudioClip successSound;

	// Token: 0x04000DE6 RID: 3558
	public AudioClip failureSound;

	// Token: 0x04000DE7 RID: 3559
	public Transform Hero;

	// Token: 0x04000DE8 RID: 3560
	public Transform Hero1;

	// Token: 0x04000DE9 RID: 3561
	public Camera RotationCamera;

	// Token: 0x04000DEA RID: 3562
	public Camera RotationCamera1;

	// Token: 0x04000DEB RID: 3563
	public Camera Hero1Camera;

	// Token: 0x04000DEC RID: 3564
	public EasyJoystick joystick1;

	// Token: 0x04000DED RID: 3565
	public EasyJoystick joystick2;

	// Token: 0x04000DEE RID: 3566
	public GameObject VanIn;

	// Token: 0x04000DEF RID: 3567
	public GameObject CrossHaire;

	// Token: 0x04000DF0 RID: 3568
	public GameObject[] hero1models;

	// Token: 0x04000DF1 RID: 3569
	public Camera[] SceneCamera;

	// Token: 0x04000DF2 RID: 3570
	public Image[] InstructionPanel;

	// Token: 0x04000DF3 RID: 3571
	public Canvas SceneCanves;

	// Token: 0x04000DF4 RID: 3572
	public GameObject AllScene1Object;

	// Token: 0x04000DF5 RID: 3573
	public bool stopCoroutine;

	// Token: 0x04000DF6 RID: 3574
	public GameObject PlayerHeliPosition;

	// Token: 0x04000DF7 RID: 3575
	public GameObject CutSceneModels;

	// Token: 0x04000DF8 RID: 3576
	public GameObject OthersObjects;

	// Token: 0x04000DF9 RID: 3577
	public Button HeliJumpButton;

	// Token: 0x04000DFA RID: 3578
	public Button ParachuteOpen;

	// Token: 0x04000DFB RID: 3579
	public Image HealthBar;

	// Token: 0x04000DFC RID: 3580
	private DetectRay dtcr;

	// Token: 0x04000DFD RID: 3581
	public static int skipcounter;

	// Token: 0x04000DFE RID: 3582
	private watchvideo wtchvid;

	// Token: 0x04000DFF RID: 3583
	public bool testfail = true;
}
