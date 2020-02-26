using System;
using UnityEngine;

// Token: 0x02000079 RID: 121
[Serializable]
public class QuestTrigger : MonoBehaviour
{
	// Token: 0x06000196 RID: 406 RVA: 0x00012CE0 File Offset: 0x00010EE0
	public QuestTrigger()
	{
		this.questClients = new GameObject[2];
	}

	// Token: 0x06000197 RID: 407 RVA: 0x00012CF4 File Offset: 0x00010EF4
	public virtual void Start()
	{
	}

	// Token: 0x06000198 RID: 408 RVA: 0x00012CF8 File Offset: 0x00010EF8
	public virtual void Update()
	{
		if (Input.GetKeyDown("e") && this.enter)
		{
			bool flag = ((QuestClient)this.questClients[this.questStep].GetComponent(typeof(QuestClient))).ActivateQuest(this.player);
			if (flag && this.questStep < this.questClients.Length)
			{
				((QuestClient)this.questClients[this.questStep].GetComponent(typeof(QuestClient))).enter = false;
				this.questStep++;
				if (this.questStep >= this.questClients.Length)
				{
					this.questStep = this.questClients.Length - 1;
				}
				else
				{
					((QuestClient)this.questClients[this.questStep].GetComponent(typeof(QuestClient))).s = 0;
					this.enter = true;
					((QuestClient)this.questClients[this.questStep].GetComponent(typeof(QuestClient))).enter = true;
				}
			}
		}
	}

	// Token: 0x06000199 RID: 409 RVA: 0x00012E20 File Offset: 0x00011020
	public virtual void OnGUI()
	{
		if (this.player)
		{
			if (this.enter)
			{
				GUI.DrawTexture(new Rect((float)(Screen.width / 2 - 130), (float)(Screen.height - 120), (float)260, (float)80), this.button);
			}
		}
	}

	// Token: 0x0600019A RID: 410 RVA: 0x00012E80 File Offset: 0x00011080
	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.player = other.gameObject;
			this.CheckQuestSequence();
			((QuestClient)this.questClients[this.questStep].GetComponent(typeof(QuestClient))).s = 0;
			this.enter = true;
			((QuestClient)this.questClients[this.questStep].GetComponent(typeof(QuestClient))).enter = true;
		}
	}

	// Token: 0x0600019B RID: 411 RVA: 0x00012F0C File Offset: 0x0001110C
	public virtual void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			((QuestClient)this.questClients[this.questStep].GetComponent(typeof(QuestClient))).s = 0;
			this.enter = false;
			((QuestClient)this.questClients[this.questStep].GetComponent(typeof(QuestClient))).enter = false;
		}
	}

	// Token: 0x0600019C RID: 412 RVA: 0x00012F84 File Offset: 0x00011184
	public virtual void CheckQuestSequence()
	{
		bool flag = true;
		while (flag)
		{
			int questId = ((QuestClient)this.questClients[this.questStep].GetComponent(typeof(QuestClient))).questId;
			this.questData = ((QuestClient)this.questClients[this.questStep].GetComponent(typeof(QuestClient))).questData;
			int num = ((QuestStat)this.player.GetComponent(typeof(QuestStat))).questProgress[questId];
			int finishProgress = ((QuestData)this.questData.GetComponent(typeof(QuestData))).questData[questId].finishProgress;
			if (num >= finishProgress + 9)
			{
				this.questStep++;
				if (this.questStep >= this.questClients.Length)
				{
					this.questStep = this.questClients.Length - 1;
					flag = false;
				}
			}
			else
			{
				flag = false;
			}
		}
	}

	// Token: 0x0600019D RID: 413 RVA: 0x00013088 File Offset: 0x00011288
	public virtual void Main()
	{
	}

	// Token: 0x040002B7 RID: 695
	public GameObject[] questClients;

	// Token: 0x040002B8 RID: 696
	public int questStep;

	// Token: 0x040002B9 RID: 697
	private bool enter;

	// Token: 0x040002BA RID: 698
	public Texture2D button;

	// Token: 0x040002BB RID: 699
	private GameObject player;

	// Token: 0x040002BC RID: 700
	private GameObject questData;
}
