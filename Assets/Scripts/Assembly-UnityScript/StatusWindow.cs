using System;
using UnityEngine;

// Token: 0x020000A1 RID: 161
[RequireComponent(typeof(Status))]
[Serializable]
public class StatusWindow : MonoBehaviour
{
	// Token: 0x06000228 RID: 552 RVA: 0x0001B5E0 File Offset: 0x000197E0
	public StatusWindow()
	{
		this.windowRect = new Rect((float)180, (float)170, (float)240, (float)320);
	}

	// Token: 0x06000229 RID: 553 RVA: 0x0001B60C File Offset: 0x0001980C
	public virtual void Start()
	{
		this.originalRect = this.windowRect;
	}

	// Token: 0x0600022A RID: 554 RVA: 0x0001B61C File Offset: 0x0001981C
	public virtual void Update()
	{
		if (Input.GetKeyDown("c"))
		{
			this.OnOffMenu();
		}
	}

	// Token: 0x0600022B RID: 555 RVA: 0x0001B634 File Offset: 0x00019834
	public virtual void OnGUI()
	{
		GUI.skin = this.skin;
		Status status = (Status)this.GetComponent(typeof(Status));
		if (this.show)
		{
			this.windowRect = GUI.Window(0, this.windowRect, new GUI.WindowFunction(this.StatWindow), "Status");
		}
		if (status.brave)
		{
			GUI.DrawTexture(new Rect((float)30, (float)200, (float)60, (float)60), this.braveIcon);
		}
		if (status.barrier)
		{
			GUI.DrawTexture(new Rect((float)30, (float)260, (float)60, (float)60), this.barrierIcon);
		}
		if (status.faith)
		{
			GUI.DrawTexture(new Rect((float)30, (float)320, (float)60, (float)60), this.faithIcon);
		}
		if (status.mbarrier)
		{
			GUI.DrawTexture(new Rect((float)30, (float)380, (float)60, (float)60), this.magicBarrierIcon);
		}
	}

	// Token: 0x0600022C RID: 556 RVA: 0x0001B73C File Offset: 0x0001993C
	public virtual void StatWindow(int windowID)
	{
		Status status = (Status)this.GetComponent(typeof(Status));
		GUI.Label(new Rect((float)20, (float)40, (float)100, (float)50), "Level", this.textStyle);
		GUI.Label(new Rect((float)20, (float)70, (float)100, (float)50), "STR", this.textStyle);
		GUI.Label(new Rect((float)20, (float)100, (float)100, (float)50), "DEF", this.textStyle);
		GUI.Label(new Rect((float)20, (float)130, (float)100, (float)50), "MATK", this.textStyle);
		GUI.Label(new Rect((float)20, (float)160, (float)100, (float)50), "MDEF", this.textStyle);
		GUI.Label(new Rect((float)20, (float)220, (float)100, (float)50), "EXP", this.textStyle);
		GUI.Label(new Rect((float)20, (float)250, (float)100, (float)50), "Next LV", this.textStyle);
		GUI.Label(new Rect((float)20, (float)280, (float)120, (float)50), "Status Point", this.textStyle);
		if (GUI.Button(new Rect((float)200, (float)5, (float)30, (float)30), "X"))
		{
			this.OnOffMenu();
		}
		int level = status.level;
		int atk = status.atk;
		int def = status.def;
		int matk = status.matk;
		int mdef = status.mdef;
		int exp = status.exp;
		int num = status.maxExp - exp;
		int statusPoint = status.statusPoint;
		GUI.Label(new Rect((float)30, (float)40, (float)100, (float)50), level.ToString(), this.textStyle2);
		GUI.Label(new Rect((float)70, (float)70, (float)100, (float)50), atk.ToString(), this.textStyle2);
		GUI.Label(new Rect((float)70, (float)100, (float)100, (float)50), def.ToString(), this.textStyle2);
		GUI.Label(new Rect((float)70, (float)130, (float)100, (float)50), matk.ToString(), this.textStyle2);
		GUI.Label(new Rect((float)70, (float)160, (float)100, (float)50), mdef.ToString(), this.textStyle2);
		GUI.Label(new Rect((float)95, (float)220, (float)100, (float)50), exp.ToString(), this.textStyle2);
		GUI.Label(new Rect((float)95, (float)250, (float)100, (float)50), num.ToString(), this.textStyle2);
		GUI.Label(new Rect((float)95, (float)280, (float)100, (float)50), statusPoint.ToString(), this.textStyle2);
		if (statusPoint > 0)
		{
			if (GUI.Button(new Rect((float)200, (float)70, (float)25, (float)25), "+") && statusPoint > 0)
			{
				((Status)this.GetComponent(typeof(Status))).atk = ((Status)this.GetComponent(typeof(Status))).atk + 1;
				((Status)this.GetComponent(typeof(Status))).statusPoint = ((Status)this.GetComponent(typeof(Status))).statusPoint - 1;
				((Status)this.GetComponent(typeof(Status))).CalculateStatus();
			}
			if (GUI.Button(new Rect((float)200, (float)100, (float)25, (float)25), "+") && statusPoint > 0)
			{
				((Status)this.GetComponent(typeof(Status))).def = ((Status)this.GetComponent(typeof(Status))).def + 1;
				((Status)this.GetComponent(typeof(Status))).maxHealth = ((Status)this.GetComponent(typeof(Status))).maxHealth + 5;
				((Status)this.GetComponent(typeof(Status))).statusPoint = ((Status)this.GetComponent(typeof(Status))).statusPoint - 1;
				((Status)this.GetComponent(typeof(Status))).CalculateStatus();
			}
			if (GUI.Button(new Rect((float)200, (float)130, (float)25, (float)25), "+") && statusPoint > 0)
			{
				((Status)this.GetComponent(typeof(Status))).matk = ((Status)this.GetComponent(typeof(Status))).matk + 1;
				((Status)this.GetComponent(typeof(Status))).maxMana = ((Status)this.GetComponent(typeof(Status))).maxMana + 3;
				((Status)this.GetComponent(typeof(Status))).statusPoint = ((Status)this.GetComponent(typeof(Status))).statusPoint - 1;
				((Status)this.GetComponent(typeof(Status))).CalculateStatus();
			}
			if (GUI.Button(new Rect((float)200, (float)160, (float)25, (float)25), "+") && statusPoint > 0)
			{
				((Status)this.GetComponent(typeof(Status))).mdef = ((Status)this.GetComponent(typeof(Status))).mdef + 1;
				((Status)this.GetComponent(typeof(Status))).statusPoint = ((Status)this.GetComponent(typeof(Status))).statusPoint - 1;
				((Status)this.GetComponent(typeof(Status))).CalculateStatus();
			}
		}
		GUI.DragWindow(new Rect((float)0, (float)0, (float)10000, (float)10000));
	}

	// Token: 0x0600022D RID: 557 RVA: 0x0001BD60 File Offset: 0x00019F60
	public virtual void OnOffMenu()
	{
		if (!this.show && Time.timeScale != (float)0)
		{
			this.show = true;
			Time.timeScale = (float)0;
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

	// Token: 0x0600022E RID: 558 RVA: 0x0001BDC8 File Offset: 0x00019FC8
	public virtual void ResetPosition()
	{
		if (this.windowRect.x >= (float)(Screen.width - 30) || this.windowRect.y >= (float)(Screen.height - 30) || this.windowRect.x <= (float)-70 || this.windowRect.y <= (float)-70)
		{
			this.windowRect = this.originalRect;
		}
	}

	// Token: 0x0600022F RID: 559 RVA: 0x0001BE3C File Offset: 0x0001A03C
	public virtual void Main()
	{
	}

	// Token: 0x0400039C RID: 924
	private bool show;

	// Token: 0x0400039D RID: 925
	public GUIStyle textStyle;

	// Token: 0x0400039E RID: 926
	public GUIStyle textStyle2;

	// Token: 0x0400039F RID: 927
	public Texture2D braveIcon;

	// Token: 0x040003A0 RID: 928
	public Texture2D barrierIcon;

	// Token: 0x040003A1 RID: 929
	public Texture2D faithIcon;

	// Token: 0x040003A2 RID: 930
	public Texture2D magicBarrierIcon;

	// Token: 0x040003A3 RID: 931
	public GUISkin skin;

	// Token: 0x040003A4 RID: 932
	public Rect windowRect;

	// Token: 0x040003A5 RID: 933
	private Rect originalRect;
}
