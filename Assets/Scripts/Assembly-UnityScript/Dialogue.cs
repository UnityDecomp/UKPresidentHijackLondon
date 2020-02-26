using System;
using UnityEngine;

// Token: 0x02000040 RID: 64
[Serializable]
public class Dialogue : MonoBehaviour
{
	// Token: 0x060000BB RID: 187 RVA: 0x00009B00 File Offset: 0x00007D00
	public Dialogue()
	{
		this.message = new TextDialogue[1];
		this.sendMessageWhenDone = string.Empty;
		this.str = new string[4];
		this.delay = 0.05f;
		this.wordComplete = new string[4];
		this.freezeTime = true;
	}

	// Token: 0x060000BC RID: 188 RVA: 0x00009B54 File Offset: 0x00007D54
	public virtual void Update()
	{
		if (Input.GetKeyDown("e") && this.enter)
		{
			this.NextPage();
		}
		if (this.begin)
		{
			if (this.wait >= this.delay)
			{
				if (this.wordComplete[this.line].Length > 0)
				{
					string[] array = this.str;
					int num = this.line;
					string lhs = this.str[this.line];
					string text = this.wordComplete[this.line];
					int index;
					int num2 = this.i = (index = this.i) + 1;
					array[num] = lhs + text[index];
				}
				this.wait = (float)0;
				if (this.i >= this.wordComplete[this.line].Length && this.line > 2)
				{
					this.begin = false;
				}
				else if (this.i >= this.wordComplete[this.line].Length)
				{
					this.i = 0;
					this.line++;
				}
			}
			else
			{
				this.wait += Time.unscaledDeltaTime;
			}
		}
	}

	// Token: 0x060000BD RID: 189 RVA: 0x00009C88 File Offset: 0x00007E88
	public virtual void AnimateText(string strComplete, string strComplete2, string strComplete3, string strComplete4)
	{
		this.begin = false;
		this.i = 0;
		this.str[0] = string.Empty;
		this.str[1] = string.Empty;
		this.str[2] = string.Empty;
		this.str[3] = string.Empty;
		this.line = 0;
		this.wordComplete[0] = strComplete;
		this.wordComplete[1] = strComplete2;
		this.wordComplete[2] = strComplete3;
		this.wordComplete[3] = strComplete4;
		this.begin = true;
	}

	// Token: 0x060000BE RID: 190 RVA: 0x00009D10 File Offset: 0x00007F10
	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.s = 0;
			this.talkFinish = false;
			this.player = other.gameObject;
			this.enter = true;
		}
	}

	// Token: 0x060000BF RID: 191 RVA: 0x00009D54 File Offset: 0x00007F54
	public virtual void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.s = 0;
			this.enter = false;
			this.CloseTalk();
		}
	}

	// Token: 0x060000C0 RID: 192 RVA: 0x00009D80 File Offset: 0x00007F80
	public virtual void CloseTalk()
	{
		this.showGui = false;
		Time.timeScale = 1f;
		Screen.lockCursor = true;
		this.s = 0;
	}

	// Token: 0x060000C1 RID: 193 RVA: 0x00009DA0 File Offset: 0x00007FA0
	public virtual void NextPage()
	{
		if (this.enter)
		{
			if (this.begin)
			{
				this.str[0] = this.wordComplete[0];
				this.str[1] = this.wordComplete[1];
				this.str[2] = this.wordComplete[2];
				this.str[3] = this.wordComplete[3];
				this.begin = false;
			}
			else
			{
				this.s++;
				if (this.s > this.message.Length)
				{
					this.showGui = false;
					this.talkFinish = true;
					this.CloseTalk();
					if (this.sendMessageWhenDone != string.Empty)
					{
						this.gameObject.SendMessage(this.sendMessageWhenDone);
					}
				}
				else
				{
					if (this.freezeTime)
					{
						Time.timeScale = (float)0;
					}
					this.talkFinish = false;
					Screen.lockCursor = false;
					this.showGui = true;
					this.AnimateText(this.message[this.s - 1].textLine1, this.message[this.s - 1].textLine2, this.message[this.s - 1].textLine3, this.message[this.s - 1].textLine4);
				}
			}
		}
	}

	// Token: 0x060000C2 RID: 194 RVA: 0x00009EF4 File Offset: 0x000080F4
	public virtual void OnGUI()
	{
		if (this.player)
		{
			if (this.enter && !this.showGui && GUI.Button(new Rect((float)(Screen.width / 2 - 130), (float)(Screen.height - 180), (float)260, (float)80), this.button))
			{
				this.NextPage();
			}
			if (this.showGui && this.s <= this.message.Length)
			{
				GUI.DrawTexture(new Rect((float)(Screen.width / 2 - 308), (float)(Screen.height - 255), (float)615, (float)220), this.textWindow);
				GUI.Label(new Rect((float)(Screen.width / 2 - 263), (float)(Screen.height - 220), (float)500, (float)200), this.str[0], this.textStyle);
				GUI.Label(new Rect((float)(Screen.width / 2 - 263), (float)(Screen.height - 190), (float)500, (float)200), this.str[1], this.textStyle);
				GUI.Label(new Rect((float)(Screen.width / 2 - 263), (float)(Screen.height - 160), (float)500, (float)200), this.str[2], this.textStyle);
				GUI.Label(new Rect((float)(Screen.width / 2 - 263), (float)(Screen.height - 130), (float)500, (float)200), this.str[3], this.textStyle);
				if (GUI.Button(new Rect((float)(Screen.width / 2 + 150), (float)(Screen.height - 100), (float)140, (float)60), "Next"))
				{
					this.NextPage();
				}
			}
		}
	}

	// Token: 0x060000C3 RID: 195 RVA: 0x0000A0F4 File Offset: 0x000082F4
	public virtual void Main()
	{
	}

	// Token: 0x0400015D RID: 349
	public TextDialogue[] message;

	// Token: 0x0400015E RID: 350
	public Texture2D button;

	// Token: 0x0400015F RID: 351
	public Texture2D textWindow;

	// Token: 0x04000160 RID: 352
	[HideInInspector]
	public bool enter;

	// Token: 0x04000161 RID: 353
	private bool showGui;

	// Token: 0x04000162 RID: 354
	[HideInInspector]
	public int s;

	// Token: 0x04000163 RID: 355
	[HideInInspector]
	public GameObject player;

	// Token: 0x04000164 RID: 356
	[HideInInspector]
	public bool talkFinish;

	// Token: 0x04000165 RID: 357
	public string sendMessageWhenDone;

	// Token: 0x04000166 RID: 358
	public GUIStyle textStyle;

	// Token: 0x04000167 RID: 359
	private string[] str;

	// Token: 0x04000168 RID: 360
	private int line;

	// Token: 0x04000169 RID: 361
	private float wait;

	// Token: 0x0400016A RID: 362
	public float delay;

	// Token: 0x0400016B RID: 363
	private bool begin;

	// Token: 0x0400016C RID: 364
	private int i;

	// Token: 0x0400016D RID: 365
	private string[] wordComplete;

	// Token: 0x0400016E RID: 366
	public bool freezeTime;
}
