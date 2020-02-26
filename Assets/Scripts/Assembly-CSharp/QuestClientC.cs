using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200007F RID: 127
public class QuestClientC : MonoBehaviour
{
	// Token: 0x06000404 RID: 1028 RVA: 0x0001A288 File Offset: 0x00018688
	private void Update()
	{
		if (Input.GetKeyDown("e") && this.enter && this.thisActive && !this.showError)
		{
			this.NextPage();
		}
		if (this.showGui && !this.showError && this.s <= this.textLength)
		{
			this.panel.GetComponentInChildren<Text>().text = string.Concat(new object[]
			{
				"Quest : ",
				this.questId,
				"\n",
				this.showText
			});
		}
	}

	// Token: 0x06000405 RID: 1029 RVA: 0x0001A334 File Offset: 0x00018734
	private IEnumerator waitForPanel()
	{
		yield return new WaitForSeconds(4f);
		this.panel.GetComponent<Animation>().Play("UIPanel_Close");
		yield break;
	}

	// Token: 0x06000406 RID: 1030 RVA: 0x0001A350 File Offset: 0x00018750
	private void NextPage()
	{
		int num = this.player.GetComponent<QuestStatC>().CheckQuestProgress(this.questId);
		int finishProgress = this.questData.GetComponent<QuestDataC>().questData[this.questId].finishProgress;
		int num2 = this.player.GetComponent<QuestStatC>().questProgress[this.questId];
		if (num2 >= finishProgress + 9)
		{
			this.textLength = this.alreadyFinishText.Length;
			if (this.s < this.textLength)
			{
				this.showText = this.alreadyFinishText[this.s];
			}
			this.s++;
			this.TalkOnly();
			MonoBehaviour.print("Already Clear");
			return;
		}
		if (this.acceptQuest)
		{
			if (num >= finishProgress)
			{
				this.textLength = this.finishQuestText.Length;
				if (this.s < this.textLength)
				{
					this.showText = this.finishQuestText[this.s];
				}
				this.s++;
				this.FinishQuest();
			}
			else
			{
				this.textLength = this.ongoingQuestText.Length;
				if (this.s < this.textLength)
				{
					this.showText = this.ongoingQuestText[this.s];
				}
				this.s++;
				this.TalkOnly();
			}
		}
		else
		{
			this.textLength = this.talkText.Length;
			if (this.s < this.textLength)
			{
				this.showText = this.talkText[this.s];
			}
			this.s++;
			this.TakeQuest();
		}
	}

	// Token: 0x06000407 RID: 1031 RVA: 0x0001A4F2 File Offset: 0x000188F2
	private void TakeQuest()
	{
		if (this.s > this.textLength)
		{
			this.showGui = false;
			base.StartCoroutine(this.AcceptQuest());
			this.CloseTalk();
		}
		else
		{
			this.Talking();
		}
	}

	// Token: 0x06000408 RID: 1032 RVA: 0x0001A52A File Offset: 0x0001892A
	private void TalkOnly()
	{
		if (this.s > this.textLength)
		{
			this.showGui = false;
			this.CloseTalk();
		}
		else
		{
			this.Talking();
		}
	}

	// Token: 0x06000409 RID: 1033 RVA: 0x0001A558 File Offset: 0x00018958
	public void FinishQuest()
	{
		if (this.s > this.textLength)
		{
			this.showGui = false;
			this.questData.GetComponent<QuestDataC>().QuestClear(this.questId, this.player);
			this.player.GetComponent<QuestStatC>().Clear(this.questId);
			MonoBehaviour.print("Clear");
			this.questFinish = true;
			this.CloseTalk();
		}
		else
		{
			this.Talking();
		}
	}

	// Token: 0x0600040A RID: 1034 RVA: 0x0001A5D4 File Offset: 0x000189D4
	public IEnumerator AcceptQuest()
	{
		bool full = this.player.GetComponent<QuestStatC>().AddQuest(this.questId);
		if (full)
		{
			this.showError = true;
			yield return new WaitForSeconds(1f);
			this.showError = false;
		}
		else
		{
			this.acceptQuest = this.player.GetComponent<QuestStatC>().CheckQuestSlot(this.questId);
			if (this.sendMsgWhenTakeQuest != string.Empty)
			{
				base.SendMessage(this.sendMsgWhenTakeQuest);
			}
		}
		yield break;
	}

	// Token: 0x0600040B RID: 1035 RVA: 0x0001A5F0 File Offset: 0x000189F0
	public void CheckQuestCondition()
	{
		QuestDataC component = this.questData.GetComponent<QuestDataC>();
		int num = this.player.GetComponent<QuestStatC>().CheckQuestProgress(this.questId);
		if (num >= component.questData[this.questId].finishProgress)
		{
			component.QuestClear(this.questId, this.player);
		}
	}

	// Token: 0x0600040C RID: 1036 RVA: 0x0001A64C File Offset: 0x00018A4C
	private void OnGUI()
	{
		if (!this.player)
		{
			return;
		}
		if (this.enter && !this.showGui && !this.showError)
		{
			GUI.DrawTexture(new Rect((float)(Screen.width / 2 - 130), (float)(Screen.height - 120), 260f, 80f), this.button);
		}
		if (this.showError)
		{
			GUI.DrawTexture(new Rect(80f, (float)(Screen.height - 255), 615f, 220f), this.textWindow);
			GUI.Label(new Rect(125f, (float)(Screen.height - 220), 500f, 200f), this.errorLog, this.textStyle);
			if (GUI.Button(new Rect(590f, (float)(Screen.height - 100), 80f, 30f), "OK"))
			{
				this.showError = false;
			}
		}
		if (this.showGui && !this.showError && this.s <= this.textLength)
		{
			GUI.DrawTexture(new Rect(80f, (float)(Screen.height - 255), 615f, 220f), this.textWindow);
			GUI.Label(new Rect(125f, (float)(Screen.height - 220), 500f, 200f), this.showText, this.textStyle);
			if (GUI.Button(new Rect(590f, (float)(Screen.height - 100), 80f, 30f), "Next"))
			{
				this.NextPage();
			}
		}
	}

	// Token: 0x0600040D RID: 1037 RVA: 0x0001A80C File Offset: 0x00018C0C
	private void OnTriggerEnter(Collider other)
	{
		if (!this.trigger)
		{
			return;
		}
		if (other.tag == "Player")
		{
			this.s = 0;
			this.player = other.gameObject;
			this.acceptQuest = this.player.GetComponent<QuestStatC>().CheckQuestSlot(this.questId);
			this.enter = true;
			this.thisActive = true;
		}
	}

	// Token: 0x0600040E RID: 1038 RVA: 0x0001A878 File Offset: 0x00018C78
	private void OnTriggerExit(Collider other)
	{
		if (!this.trigger)
		{
			return;
		}
		if (other.tag == "Player")
		{
			this.s = 0;
			this.enter = false;
			this.CloseTalk();
		}
		this.thisActive = false;
		this.showError = false;
	}

	// Token: 0x0600040F RID: 1039 RVA: 0x0001A8C8 File Offset: 0x00018CC8
	private void Talking()
	{
		if (!this.enter)
		{
			return;
		}
		Time.timeScale = 0f;
		Screen.lockCursor = false;
		this.showGui = true;
	}

	// Token: 0x06000410 RID: 1040 RVA: 0x0001A8ED File Offset: 0x00018CED
	private void CloseTalk()
	{
		this.showGui = false;
		Time.timeScale = 1f;
		Screen.lockCursor = true;
		this.s = 0;
	}

	// Token: 0x06000411 RID: 1041 RVA: 0x0001A90D File Offset: 0x00018D0D
	public bool ActivateQuest(GameObject p)
	{
		this.player = p;
		this.acceptQuest = this.player.GetComponent<QuestStatC>().CheckQuestSlot(this.questId);
		this.thisActive = false;
		this.trigger = false;
		this.NextPage();
		return this.questFinish;
	}

	// Token: 0x040003B3 RID: 947
	public int questId = 1;

	// Token: 0x040003B4 RID: 948
	public GameObject questData;

	// Token: 0x040003B5 RID: 949
	public Texture2D button;

	// Token: 0x040003B6 RID: 950
	public Image panel;

	// Token: 0x040003B7 RID: 951
	public Texture2D textWindow;

	// Token: 0x040003B8 RID: 952
	[HideInInspector]
	public bool enter;

	// Token: 0x040003B9 RID: 953
	private bool showGui;

	// Token: 0x040003BA RID: 954
	private bool showError;

	// Token: 0x040003BB RID: 955
	[HideInInspector]
	public int s;

	// Token: 0x040003BC RID: 956
	private GameObject player;

	// Token: 0x040003BD RID: 957
	public string[] talkText = new string[3];

	// Token: 0x040003BE RID: 958
	public string[] ongoingQuestText = new string[1];

	// Token: 0x040003BF RID: 959
	public string[] finishQuestText = new string[1];

	// Token: 0x040003C0 RID: 960
	public string[] alreadyFinishText = new string[1];

	// Token: 0x040003C1 RID: 961
	private string errorLog = "Quest Full...";

	// Token: 0x040003C2 RID: 962
	public GUIStyle textStyle;

	// Token: 0x040003C3 RID: 963
	private bool acceptQuest;

	// Token: 0x040003C4 RID: 964
	public bool trigger = true;

	// Token: 0x040003C5 RID: 965
	private int textLength;

	// Token: 0x040003C6 RID: 966
	public string showText = string.Empty;

	// Token: 0x040003C7 RID: 967
	private bool thisActive;

	// Token: 0x040003C8 RID: 968
	private bool questFinish;

	// Token: 0x040003C9 RID: 969
	public string sendMsgWhenTakeQuest = string.Empty;

	// Token: 0x040003CA RID: 970
	private bool questShow;
}
