using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000204 RID: 516
public class QuestTriggerNewC : MonoBehaviour
{
	// Token: 0x06000D6A RID: 3434 RVA: 0x00055EE0 File Offset: 0x000542E0
	private void Update()
	{
		if (Input.GetKeyDown("e") && this.enter)
		{
			this.showWindow = true;
			Time.timeScale = 0f;
			Screen.lockCursor = false;
		}
		if (Input.GetKeyDown("u"))
		{
			this.questDescription = "Congratz you won\nwithout any hussle !";
			this.showWindow = true;
			this.showSuccess = true;
			Time.timeScale = 0f;
		}
	}

	// Token: 0x06000D6B RID: 3435 RVA: 0x00055F50 File Offset: 0x00054350
	private void OnGUI()
	{
		if (!this.player)
		{
			return;
		}
		if (this.showWindow)
		{
			if (!this.showQuest && !this.showSuccess)
			{
				GUI.DrawTexture(new Rect(80f, (float)(Screen.height - 255), 615f, 220f), this.textWindow);
				GUI.Label(new Rect(125f, (float)(Screen.height - 220), 500f, 200f), "Are you ready to start a quest ?", this.textStyle);
				if (GUI.Button(new Rect(200f, (float)(Screen.height - 100), 80f, 30f), "Yes"))
				{
					this.questDescription = string.Empty;
					this.showQuest = true;
				}
				if (GUI.Button(new Rect(400f, (float)(Screen.height - 100), 80f, 30f), "No"))
				{
					Time.timeScale = 1f;
					Screen.lockCursor = true;
					this.showWindow = false;
				}
			}
			if (this.showQuest)
			{
				GUI.DrawTexture(new Rect(80f, (float)(Screen.height - 255), 615f, 220f), this.textWindow);
				GUI.Label(new Rect(125f, (float)(Screen.height - 220), 500f, 200f), this.questDescription, this.textStyle);
				if (GUI.Button(new Rect(300f, (float)(Screen.height - 100), 80f, 30f), "Ok"))
				{
					this.showQuest = false;
					this.showWindow = false;
					Time.timeScale = 1f;
				}
			}
			if (this.showSuccess)
			{
				GUI.DrawTexture(new Rect(80f, (float)(Screen.height - 255), 615f, 220f), this.textWindow);
				GUI.Label(new Rect(125f, (float)(Screen.height - 220), 500f, 200f), this.questDescription, this.textStyle);
				if (GUI.Button(new Rect(300f, (float)(Screen.height - 100), 80f, 30f), "Ok"))
				{
					this.showSuccess = false;
					this.showWindow = false;
					Time.timeScale = 1f;
				}
			}
		}
		if (this.enter)
		{
			GUI.DrawTexture(new Rect((float)(Screen.width / 2 - 130), (float)(Screen.height - 120), 260f, 80f), this.button);
		}
	}

	// Token: 0x06000D6C RID: 3436 RVA: 0x000561FD File Offset: 0x000545FD
	private void activateGui()
	{
	}

	// Token: 0x06000D6D RID: 3437 RVA: 0x000561FF File Offset: 0x000545FF
	private void deactivateGui()
	{
		this.showWindow = false;
	}

	// Token: 0x06000D6E RID: 3438 RVA: 0x00056208 File Offset: 0x00054608
	private void getQuest()
	{
		Time.timeScale = 1f;
		Screen.lockCursor = true;
	}

	// Token: 0x06000D6F RID: 3439 RVA: 0x0005621A File Offset: 0x0005461A
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.player = other.gameObject;
			this.enter = true;
		}
	}

	// Token: 0x06000D70 RID: 3440 RVA: 0x00056244 File Offset: 0x00054644
	private void OnTriggerExit(Collider other)
	{
		this.enter = false;
	}

	// Token: 0x06000D71 RID: 3441 RVA: 0x00056250 File Offset: 0x00054650
	public void CheckQuestSequence()
	{
		bool flag = true;
		while (flag)
		{
			int num = this.questClients[this.questStep].GetComponent<QuestClientC>().questId;
			this.questData = this.questClients[this.questStep].GetComponent<QuestClientC>().questData;
			int num2 = this.player.GetComponent<QuestStatC>().questProgress[num];
			int finishProgress = this.questData.GetComponent<QuestDataC>().questData[num].finishProgress;
			if (num2 >= finishProgress + 9)
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

	// Token: 0x04000E15 RID: 3605
	public GameObject[] questClients = new GameObject[2];

	// Token: 0x04000E16 RID: 3606
	public int questStep;

	// Token: 0x04000E17 RID: 3607
	private bool enter;

	// Token: 0x04000E18 RID: 3608
	public Image questPanel;

	// Token: 0x04000E19 RID: 3609
	public GUIStyle textStyle;

	// Token: 0x04000E1A RID: 3610
	public GameObject QuestPrefab;

	// Token: 0x04000E1B RID: 3611
	public Texture2D button;

	// Token: 0x04000E1C RID: 3612
	public Texture2D textWindow;

	// Token: 0x04000E1D RID: 3613
	private GameObject player;

	// Token: 0x04000E1E RID: 3614
	private GameObject questData;

	// Token: 0x04000E1F RID: 3615
	private int questId;

	// Token: 0x04000E20 RID: 3616
	private bool showWindow;

	// Token: 0x04000E21 RID: 3617
	private bool showQuest;

	// Token: 0x04000E22 RID: 3618
	private bool showSuccess;

	// Token: 0x04000E23 RID: 3619
	private string questDescription = string.Empty;
}
