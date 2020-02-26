using System;
using UnityEngine;

// Token: 0x02000085 RID: 133
public class QuestTriggerC : MonoBehaviour
{
	// Token: 0x06000424 RID: 1060 RVA: 0x0001B6B8 File Offset: 0x00019AB8
	private void Update()
	{
		if (Input.GetKeyDown("e") && this.enter)
		{
			bool flag = this.questClients[this.questStep].GetComponent<QuestClientC>().ActivateQuest(this.player);
			if (flag && this.questStep < this.questClients.Length)
			{
				this.questClients[this.questStep].GetComponent<QuestClientC>().enter = false;
				this.questStep++;
				if (this.questStep >= this.questClients.Length)
				{
					this.questStep = this.questClients.Length - 1;
					return;
				}
				this.questClients[this.questStep].GetComponent<QuestClientC>().s = 0;
				this.enter = true;
				this.questClients[this.questStep].GetComponent<QuestClientC>().enter = true;
			}
		}
	}

	// Token: 0x06000425 RID: 1061 RVA: 0x0001B798 File Offset: 0x00019B98
	private void OnGUI()
	{
		if (!this.player)
		{
			return;
		}
		if (this.enter)
		{
			GUI.DrawTexture(new Rect((float)(Screen.width / 2 - 130), (float)(Screen.height - 120), 260f, 80f), this.button);
		}
	}

	// Token: 0x06000426 RID: 1062 RVA: 0x0001B7F4 File Offset: 0x00019BF4
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.player = other.gameObject;
			this.CheckQuestSequence();
			this.questClients[this.questStep].GetComponent<QuestClientC>().s = 0;
			this.enter = true;
			this.questClients[this.questStep].GetComponent<QuestClientC>().enter = true;
		}
	}

	// Token: 0x06000427 RID: 1063 RVA: 0x0001B860 File Offset: 0x00019C60
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.questClients[this.questStep].GetComponent<QuestClientC>().s = 0;
			this.enter = false;
			this.questClients[this.questStep].GetComponent<QuestClientC>().enter = false;
		}
	}

	// Token: 0x06000428 RID: 1064 RVA: 0x0001B8BC File Offset: 0x00019CBC
	public void CheckQuestSequence()
	{
		bool flag = true;
		while (flag)
		{
			int questId = this.questClients[this.questStep].GetComponent<QuestClientC>().questId;
			this.questData = this.questClients[this.questStep].GetComponent<QuestClientC>().questData;
			int num = this.player.GetComponent<QuestStatC>().questProgress[questId];
			int finishProgress = this.questData.GetComponent<QuestDataC>().questData[questId].finishProgress;
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

	// Token: 0x040003DF RID: 991
	public GameObject[] questClients = new GameObject[2];

	// Token: 0x040003E0 RID: 992
	public int questStep;

	// Token: 0x040003E1 RID: 993
	private bool enter;

	// Token: 0x040003E2 RID: 994
	public Texture2D button;

	// Token: 0x040003E3 RID: 995
	private GameObject player;

	// Token: 0x040003E4 RID: 996
	private GameObject questData;
}
