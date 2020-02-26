using System;
using UnityEngine;

// Token: 0x02000096 RID: 150
[RequireComponent(typeof(StatusC))]
public class StatusWindowC : MonoBehaviour
{
	// Token: 0x0600047F RID: 1151 RVA: 0x000229D5 File Offset: 0x00020DD5
	private void Start()
	{
		this.originalRect = this.windowRect;
	}

	// Token: 0x06000480 RID: 1152 RVA: 0x000229E3 File Offset: 0x00020DE3
	private void Update()
	{
		if (Input.GetKeyDown("c"))
		{
			this.OnOffMenu();
		}
	}

	// Token: 0x06000481 RID: 1153 RVA: 0x000229FC File Offset: 0x00020DFC
	private void OnGUI()
	{
		StatusC component = base.GetComponent<StatusC>();
		GUI.skin = this.skin;
		if (this.show)
		{
			this.windowRect = GUI.Window(0, this.windowRect, new GUI.WindowFunction(this.StatWindow), "Status");
		}
		if (component.brave)
		{
			GUI.DrawTexture(new Rect(30f, 200f, 60f, 60f), this.braveIcon);
		}
		if (component.barrier)
		{
			GUI.DrawTexture(new Rect(30f, 260f, 60f, 60f), this.barrierIcon);
		}
		if (component.faith)
		{
			GUI.DrawTexture(new Rect(30f, 320f, 60f, 60f), this.faithIcon);
		}
		if (component.mbarrier)
		{
			GUI.DrawTexture(new Rect(30f, 380f, 60f, 60f), this.magicBarrierIcon);
		}
	}

	// Token: 0x06000482 RID: 1154 RVA: 0x00022B08 File Offset: 0x00020F08
	private void OnOffMenu()
	{
		if (!this.show && Time.timeScale != 0f)
		{
			this.show = true;
			Time.timeScale = 0f;
			this.ResetPosition();
			Screen.lockCursor = false;
		}
		else if (this.show)
		{
			this.show = false;
			Time.timeScale = 1f;
			Screen.lockCursor = true;
		}
	}

	// Token: 0x06000483 RID: 1155 RVA: 0x00022B74 File Offset: 0x00020F74
	private void StatWindow(int windowID)
	{
		StatusC component = base.GetComponent<StatusC>();
		GUI.Label(new Rect(20f, 40f, 100f, 50f), "Level", this.textStyle);
		GUI.Label(new Rect(20f, 70f, 100f, 50f), "STR", this.textStyle);
		GUI.Label(new Rect(20f, 100f, 100f, 50f), "DEF", this.textStyle);
		GUI.Label(new Rect(20f, 130f, 100f, 50f), "MATK", this.textStyle);
		GUI.Label(new Rect(20f, 160f, 100f, 50f), "MDEF", this.textStyle);
		GUI.Label(new Rect(20f, 220f, 100f, 50f), "EXP", this.textStyle);
		GUI.Label(new Rect(20f, 250f, 100f, 50f), "Next LV", this.textStyle);
		GUI.Label(new Rect(20f, 280f, 120f, 50f), "Status Point", this.textStyle);
		if (GUI.Button(new Rect(200f, 5f, 30f, 30f), "X"))
		{
			this.OnOffMenu();
		}
		int level = component.level;
		int atk = component.atk;
		int def = component.def;
		int matk = component.matk;
		int mdef = component.mdef;
		int exp = component.exp;
		int num = component.maxExp - exp;
		int statusPoint = component.statusPoint;
		GUI.Label(new Rect(30f, 40f, 100f, 50f), level.ToString(), this.textStyle2);
		GUI.Label(new Rect(70f, 70f, 100f, 50f), atk.ToString(), this.textStyle2);
		GUI.Label(new Rect(70f, 100f, 100f, 50f), def.ToString(), this.textStyle2);
		GUI.Label(new Rect(70f, 130f, 100f, 50f), matk.ToString(), this.textStyle2);
		GUI.Label(new Rect(70f, 160f, 100f, 50f), mdef.ToString(), this.textStyle2);
		GUI.Label(new Rect(95f, 220f, 100f, 50f), exp.ToString(), this.textStyle2);
		GUI.Label(new Rect(95f, 250f, 100f, 50f), num.ToString(), this.textStyle2);
		GUI.Label(new Rect(95f, 280f, 100f, 50f), statusPoint.ToString(), this.textStyle2);
		if (statusPoint > 0)
		{
			if (GUI.Button(new Rect(200f, 70f, 25f, 25f), "+") && statusPoint > 0)
			{
				base.GetComponent<StatusC>().atk++;
				base.GetComponent<StatusC>().statusPoint--;
				base.GetComponent<StatusC>().CalculateStatus();
			}
			if (GUI.Button(new Rect(200f, 100f, 25f, 25f), "+") && statusPoint > 0)
			{
				base.GetComponent<StatusC>().def++;
				base.GetComponent<StatusC>().maxHealth += 5;
				base.GetComponent<StatusC>().statusPoint--;
				base.GetComponent<StatusC>().CalculateStatus();
			}
			if (GUI.Button(new Rect(200f, 130f, 25f, 25f), "+") && statusPoint > 0)
			{
				base.GetComponent<StatusC>().matk++;
				base.GetComponent<StatusC>().maxMana += 3;
				base.GetComponent<StatusC>().statusPoint--;
				base.GetComponent<StatusC>().CalculateStatus();
			}
			if (GUI.Button(new Rect(200f, 160f, 25f, 25f), "+") && statusPoint > 0)
			{
				base.GetComponent<StatusC>().mdef++;
				base.GetComponent<StatusC>().statusPoint--;
				base.GetComponent<StatusC>().CalculateStatus();
			}
		}
		GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
	}

	// Token: 0x06000484 RID: 1156 RVA: 0x00023098 File Offset: 0x00021498
	private void ResetPosition()
	{
		if (this.windowRect.x >= (float)(Screen.width - 30) || this.windowRect.y >= (float)(Screen.height - 30) || this.windowRect.x <= -70f || this.windowRect.y <= -70f)
		{
			this.windowRect = this.originalRect;
		}
	}

	// Token: 0x04000481 RID: 1153
	private bool show;

	// Token: 0x04000482 RID: 1154
	public GUIStyle textStyle;

	// Token: 0x04000483 RID: 1155
	public GUIStyle textStyle2;

	// Token: 0x04000484 RID: 1156
	public Texture2D braveIcon;

	// Token: 0x04000485 RID: 1157
	public Texture2D barrierIcon;

	// Token: 0x04000486 RID: 1158
	public Texture2D faithIcon;

	// Token: 0x04000487 RID: 1159
	public Texture2D magicBarrierIcon;

	// Token: 0x04000488 RID: 1160
	public GUISkin skin;

	// Token: 0x04000489 RID: 1161
	public Rect windowRect = new Rect(180f, 170f, 240f, 320f);

	// Token: 0x0400048A RID: 1162
	private Rect originalRect;
}
