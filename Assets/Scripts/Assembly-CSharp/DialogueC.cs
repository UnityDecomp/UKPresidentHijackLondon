using System;
using UnityEngine;

// Token: 0x02000062 RID: 98
public class DialogueC : MonoBehaviour
{
	// Token: 0x0600037E RID: 894 RVA: 0x00012880 File Offset: 0x00010C80
	private void Update()
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
					string[] array;
					int num;
					(array = this.str)[num = this.line] = array[num] + this.wordComplete[this.line][this.i++];
				}
				this.wait = 0f;
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

	// Token: 0x0600037F RID: 895 RVA: 0x000129AC File Offset: 0x00010DAC
	public void AnimateText(string strComplete, string strComplete2, string strComplete3, string strComplete4)
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

	// Token: 0x06000380 RID: 896 RVA: 0x00012A2E File Offset: 0x00010E2E
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.s = 0;
			this.talkFinish = false;
			this.player = other.gameObject;
			this.enter = true;
		}
	}

	// Token: 0x06000381 RID: 897 RVA: 0x00012A66 File Offset: 0x00010E66
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.s = 0;
			this.enter = false;
			this.CloseTalk();
		}
	}

	// Token: 0x06000382 RID: 898 RVA: 0x00012A91 File Offset: 0x00010E91
	public void CloseTalk()
	{
		this.showGui = false;
		Time.timeScale = 1f;
		Screen.lockCursor = true;
		this.s = 0;
	}

	// Token: 0x06000383 RID: 899 RVA: 0x00012AB4 File Offset: 0x00010EB4
	public void NextPage()
	{
		if (!this.enter)
		{
			return;
		}
		if (this.begin)
		{
			this.str[0] = this.wordComplete[0];
			this.str[1] = this.wordComplete[1];
			this.str[2] = this.wordComplete[2];
			this.str[3] = this.wordComplete[3];
			this.begin = false;
			return;
		}
		this.s++;
		if (this.s > this.message.Length)
		{
			this.showGui = false;
			this.talkFinish = true;
			this.CloseTalk();
			if (this.sendMessageWhenDone != string.Empty)
			{
				base.gameObject.SendMessage(this.sendMessageWhenDone);
			}
		}
		else
		{
			if (this.freezeTime)
			{
				Time.timeScale = 0f;
			}
			this.talkFinish = false;
			Screen.lockCursor = false;
			this.showGui = true;
			this.AnimateText(this.message[this.s - 1].textLine1, this.message[this.s - 1].textLine2, this.message[this.s - 1].textLine3, this.message[this.s - 1].textLine4);
		}
	}

	// Token: 0x06000384 RID: 900 RVA: 0x00012C00 File Offset: 0x00011000
	private void OnGUI()
	{
		if (!this.player)
		{
			return;
		}
		if (this.enter && !this.showGui && GUI.Button(new Rect((float)(Screen.width / 2 - 130), (float)(Screen.height - 180), 260f, 80f), this.button))
		{
			this.NextPage();
		}
		if (this.showGui && this.s <= this.message.Length)
		{
			GUI.DrawTexture(new Rect((float)(Screen.width / 2 - 308), (float)(Screen.height - 255), 615f, 220f), this.textWindow);
			GUI.Label(new Rect((float)(Screen.width / 2 - 263), (float)(Screen.height - 220), 500f, 200f), this.str[0], this.textStyle);
			GUI.Label(new Rect((float)(Screen.width / 2 - 263), (float)(Screen.height - 190), 500f, 200f), this.str[1], this.textStyle);
			GUI.Label(new Rect((float)(Screen.width / 2 - 263), (float)(Screen.height - 160), 500f, 200f), this.str[2], this.textStyle);
			GUI.Label(new Rect((float)(Screen.width / 2 - 263), (float)(Screen.height - 130), 500f, 200f), this.str[3], this.textStyle);
			if (GUI.Button(new Rect((float)(Screen.width / 2 + 150), (float)(Screen.height - 100), 140f, 60f), "Next"))
			{
				this.NextPage();
			}
		}
	}

	// Token: 0x0400028C RID: 652
	public TextDialogue[] message = new TextDialogue[1];

	// Token: 0x0400028D RID: 653
	public Texture2D button;

	// Token: 0x0400028E RID: 654
	public Texture2D textWindow;

	// Token: 0x0400028F RID: 655
	[HideInInspector]
	public bool enter;

	// Token: 0x04000290 RID: 656
	private bool showGui;

	// Token: 0x04000291 RID: 657
	[HideInInspector]
	public int s;

	// Token: 0x04000292 RID: 658
	[HideInInspector]
	public GameObject player;

	// Token: 0x04000293 RID: 659
	[HideInInspector]
	public bool talkFinish;

	// Token: 0x04000294 RID: 660
	public string sendMessageWhenDone = string.Empty;

	// Token: 0x04000295 RID: 661
	public GUIStyle textStyle;

	// Token: 0x04000296 RID: 662
	private string[] str = new string[4];

	// Token: 0x04000297 RID: 663
	private int line;

	// Token: 0x04000298 RID: 664
	private float wait;

	// Token: 0x04000299 RID: 665
	public float delay = 0.05f;

	// Token: 0x0400029A RID: 666
	private bool begin;

	// Token: 0x0400029B RID: 667
	private int i;

	// Token: 0x0400029C RID: 668
	private string[] wordComplete = new string[4];

	// Token: 0x0400029D RID: 669
	public bool freezeTime = true;
}
