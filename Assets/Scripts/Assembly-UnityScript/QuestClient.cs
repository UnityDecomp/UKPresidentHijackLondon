using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

// Token: 0x02000071 RID: 113
[Serializable]
public class QuestClient : MonoBehaviour
{
	// Token: 0x0600016F RID: 367 RVA: 0x000117B0 File Offset: 0x0000F9B0
	public QuestClient()
	{
		this.questId = 1;
		this.talkText = new string[3];
		this.ongoingQuestText = new string[1];
		this.finishQuestText = new string[1];
		this.alreadyFinishText = new string[1];
		this.errorLog = "Quest Full...";
		this.trigger = true;
		this.showText = string.Empty;
		this.sendMsgWhenTakeQuest = string.Empty;
	}

	// Token: 0x06000170 RID: 368 RVA: 0x00011824 File Offset: 0x0000FA24
	public virtual void Update()
	{
		if (Input.GetKeyDown("e") && this.enter && this.thisActive && !this.showError)
		{
			this.NextPage();
		}
	}

	// Token: 0x06000171 RID: 369 RVA: 0x00011868 File Offset: 0x0000FA68
	public virtual void NextPage()
	{
		int num = ((QuestStat)this.player.GetComponent(typeof(QuestStat))).CheckQuestProgress(this.questId);
		int num2 = ((QuestData)this.questData.GetComponent(typeof(QuestData))).questData[this.questId].finishProgress;
		int num3 = ((QuestStat)this.player.GetComponent(typeof(QuestStat))).questProgress[this.questId];
		if (num3 >= num2 + 9)
		{
			this.textLength = this.alreadyFinishText.Length;
			if (this.s < this.textLength)
			{
				this.showText = this.alreadyFinishText[this.s];
			}
			this.s++;
			this.TalkOnly();
			MonoBehaviour.print("Already Clear");
		}
		else if (this.acceptQuest)
		{
			if (num >= num2)
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

	// Token: 0x06000172 RID: 370 RVA: 0x00011A48 File Offset: 0x0000FC48
	public virtual void TakeQuest()
	{
		if (this.s > this.textLength)
		{
			this.showGui = false;
			this.StartCoroutine(this.AcceptQuest());
			this.CloseTalk();
		}
		else
		{
			this.Talking();
		}
	}

	// Token: 0x06000173 RID: 371 RVA: 0x00011A8C File Offset: 0x0000FC8C
	public virtual void TalkOnly()
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

	// Token: 0x06000174 RID: 372 RVA: 0x00011AB8 File Offset: 0x0000FCB8
	public virtual void FinishQuest()
	{
		if (this.s > this.textLength)
		{
			this.showGui = false;
			((QuestData)this.questData.GetComponent(typeof(QuestData))).QuestClear(this.questId, this.player);
			((QuestStat)this.player.GetComponent(typeof(QuestStat))).Clear(this.questId);
			MonoBehaviour.print("Clear");
			this.questFinish = true;
			this.CloseTalk();
		}
		else
		{
			this.Talking();
		}
	}

	// Token: 0x06000175 RID: 373 RVA: 0x00011B50 File Offset: 0x0000FD50
	public virtual IEnumerator AcceptQuest()
	{
		return new QuestClient.$AcceptQuest$205(this).GetEnumerator();
	}

	// Token: 0x06000176 RID: 374 RVA: 0x00011B60 File Offset: 0x0000FD60
	public virtual void CheckQuestCondition()
	{
		QuestData questData = (QuestData)this.questData.GetComponent(typeof(QuestData));
		int num = ((QuestStat)this.player.GetComponent(typeof(QuestStat))).CheckQuestProgress(this.questId);
		if (num >= questData.questData[this.questId].finishProgress)
		{
			questData.QuestClear(this.questId, this.player);
		}
	}

	// Token: 0x06000177 RID: 375 RVA: 0x00011BD8 File Offset: 0x0000FDD8
	public virtual void OnGUI()
	{
		if (this.player)
		{
			if (this.enter && !this.showGui && !this.showError)
			{
				GUI.DrawTexture(new Rect((float)(Screen.width / 2 - 130), (float)(Screen.height - 120), (float)260, (float)80), this.button);
			}
			if (this.showError)
			{
				GUI.DrawTexture(new Rect((float)80, (float)(Screen.height - 255), (float)615, (float)220), this.textWindow);
				GUI.Label(new Rect((float)125, (float)(Screen.height - 220), (float)500, (float)200), this.errorLog, this.textStyle);
				if (GUI.Button(new Rect((float)590, (float)(Screen.height - 100), (float)80, (float)30), "OK"))
				{
					this.showError = false;
				}
			}
			if (this.showGui && !this.showError && this.s <= this.textLength)
			{
				GUI.DrawTexture(new Rect((float)80, (float)(Screen.height - 255), (float)615, (float)220), this.textWindow);
				GUI.Label(new Rect((float)125, (float)(Screen.height - 220), (float)500, (float)200), this.showText, this.textStyle);
				if (GUI.Button(new Rect((float)590, (float)(Screen.height - 100), (float)80, (float)30), "Next"))
				{
					this.NextPage();
				}
			}
		}
	}

	// Token: 0x06000178 RID: 376 RVA: 0x00011D94 File Offset: 0x0000FF94
	public virtual void OnTriggerEnter(Collider other)
	{
		if (this.trigger)
		{
			if (other.tag == "Player")
			{
				this.s = 0;
				this.player = other.gameObject;
				this.acceptQuest = ((QuestStat)this.player.GetComponent(typeof(QuestStat))).CheckQuestSlot(this.questId);
				this.enter = true;
				this.thisActive = true;
			}
		}
	}

	// Token: 0x06000179 RID: 377 RVA: 0x00011E14 File Offset: 0x00010014
	public virtual void OnTriggerExit(Collider other)
	{
		if (this.trigger)
		{
			if (other.tag == "Player")
			{
				this.s = 0;
				this.enter = false;
				this.CloseTalk();
			}
			this.thisActive = false;
			this.showError = false;
		}
	}

	// Token: 0x0600017A RID: 378 RVA: 0x00011E68 File Offset: 0x00010068
	public virtual void Talking()
	{
		if (this.enter)
		{
			Time.timeScale = (float)0;
			Screen.lockCursor = false;
			this.showGui = true;
		}
	}

	// Token: 0x0600017B RID: 379 RVA: 0x00011E9C File Offset: 0x0001009C
	public virtual void CloseTalk()
	{
		this.showGui = false;
		Time.timeScale = 1f;
		Screen.lockCursor = true;
		this.s = 0;
	}

	// Token: 0x0600017C RID: 380 RVA: 0x00011EBC File Offset: 0x000100BC
	public virtual bool ActivateQuest(GameObject p)
	{
		this.player = p;
		this.acceptQuest = ((QuestStat)this.player.GetComponent(typeof(QuestStat))).CheckQuestSlot(this.questId);
		this.thisActive = false;
		this.trigger = false;
		this.NextPage();
		return this.questFinish;
	}

	// Token: 0x0600017D RID: 381 RVA: 0x00011F18 File Offset: 0x00010118
	public virtual void Main()
	{
	}

	// Token: 0x04000287 RID: 647
	public int questId;

	// Token: 0x04000288 RID: 648
	public GameObject questData;

	// Token: 0x04000289 RID: 649
	private int finishProgress;

	// Token: 0x0400028A RID: 650
	public Texture2D button;

	// Token: 0x0400028B RID: 651
	public Texture2D textWindow;

	// Token: 0x0400028C RID: 652
	[HideInInspector]
	public bool enter;

	// Token: 0x0400028D RID: 653
	private bool showGui;

	// Token: 0x0400028E RID: 654
	private bool showError;

	// Token: 0x0400028F RID: 655
	[HideInInspector]
	public int s;

	// Token: 0x04000290 RID: 656
	private GameObject player;

	// Token: 0x04000291 RID: 657
	public string[] talkText;

	// Token: 0x04000292 RID: 658
	public string[] ongoingQuestText;

	// Token: 0x04000293 RID: 659
	public string[] finishQuestText;

	// Token: 0x04000294 RID: 660
	public string[] alreadyFinishText;

	// Token: 0x04000295 RID: 661
	private string errorLog;

	// Token: 0x04000296 RID: 662
	public GUIStyle textStyle;

	// Token: 0x04000297 RID: 663
	private bool acceptQuest;

	// Token: 0x04000298 RID: 664
	public bool trigger;

	// Token: 0x04000299 RID: 665
	private bool activateQuest;

	// Token: 0x0400029A RID: 666
	private int textLength;

	// Token: 0x0400029B RID: 667
	public string showText;

	// Token: 0x0400029C RID: 668
	private bool thisActive;

	// Token: 0x0400029D RID: 669
	private bool questFinish;

	// Token: 0x0400029E RID: 670
	public string sendMsgWhenTakeQuest;

	// Token: 0x02000072 RID: 114
	[CompilerGenerated]
	[Serializable]
	internal sealed class $AcceptQuest$205 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x0600017E RID: 382 RVA: 0x00011F1C File Offset: 0x0001011C
		public $AcceptQuest$205(QuestClient self_)
		{
			this.$self_$208 = self_;
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00011F2C File Offset: 0x0001012C
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new QuestClient.$AcceptQuest$205.$(this.$self_$208);
		}

		// Token: 0x0400029F RID: 671
		internal QuestClient $self_$208;
	}
}
