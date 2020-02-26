using System;
using UnityEngine;

// Token: 0x02000052 RID: 82
[Serializable]
public class HealthBar : MonoBehaviour
{
	// Token: 0x060000FA RID: 250 RVA: 0x0000B7C4 File Offset: 0x000099C4
	public HealthBar()
	{
		this.maxHpBarPosition = new Vector2((float)20, (float)20);
		this.hpBarPosition = new Vector2((float)152, (float)48);
		this.mpBarPosition = new Vector2((float)152, (float)71);
		this.expBarPosition = new Vector2((float)152, (float)94);
		this.levelPosition = new Vector2((float)24, (float)86);
		this.maxHpBarWidth = 310;
		this.maxHpBarHeigh = 115;
		this.barHeight = 19;
		this.expBarHeight = 8;
		this.barMultiply = 1.6f;
		this.hptext = 100;
	}

	// Token: 0x060000FB RID: 251 RVA: 0x0000B86C File Offset: 0x00009A6C
	public virtual void Awake()
	{
		if (!this.player)
		{
			this.player = GameObject.FindWithTag("Player");
		}
		this.hptext = (int)((float)100 * this.barMultiply);
	}

	// Token: 0x060000FC RID: 252 RVA: 0x0000B8A0 File Offset: 0x00009AA0
	public virtual void OnGUI()
	{
		if (this.player)
		{
			int maxHealth = ((Status)this.player.GetComponent(typeof(Status))).maxHealth;
			int num = (int)((float)(((Status)this.player.GetComponent(typeof(Status))).health * 100 / maxHealth) * this.barMultiply);
			int maxMana = ((Status)this.player.GetComponent(typeof(Status))).maxMana;
			int num2 = (int)((float)(((Status)this.player.GetComponent(typeof(Status))).mana * 100 / maxMana) * this.barMultiply);
			int maxExp = ((Status)this.player.GetComponent(typeof(Status))).maxExp;
			int num3 = (int)((float)(((Status)this.player.GetComponent(typeof(Status))).exp * 100 / maxExp) * this.barMultiply);
			int level = ((Status)this.player.GetComponent(typeof(Status))).level;
			int health = ((Status)this.player.GetComponent(typeof(Status))).health;
			int mana = ((Status)this.player.GetComponent(typeof(Status))).mana;
			GUI.DrawTexture(new Rect(this.maxHpBarPosition.x, this.maxHpBarPosition.y, (float)this.maxHpBarWidth, (float)this.maxHpBarHeigh), this.maxHpBar);
			GUI.DrawTexture(new Rect(this.hpBarPosition.x, this.hpBarPosition.y, (float)num, (float)this.barHeight), this.hpBar);
			GUI.DrawTexture(new Rect(this.mpBarPosition.x, this.mpBarPosition.y, (float)num2, (float)this.barHeight), this.mpBar);
			GUI.DrawTexture(new Rect(this.expBarPosition.x, this.expBarPosition.y, (float)num3, (float)this.expBarHeight), this.expBar);
			GUI.Label(new Rect(this.levelPosition.x, this.levelPosition.y, (float)50, (float)50), level.ToString(), this.textStyle);
			GUI.Label(new Rect(this.hpBarPosition.x, this.hpBarPosition.y, (float)this.hptext, (float)this.barHeight), health.ToString() + "/" + maxHealth.ToString(), this.hpTextStyle);
			GUI.Label(new Rect(this.mpBarPosition.x, this.mpBarPosition.y, (float)this.hptext, (float)this.barHeight), mana.ToString() + "/" + maxMana.ToString(), this.hpTextStyle);
		}
	}

	// Token: 0x060000FD RID: 253 RVA: 0x0000BBAC File Offset: 0x00009DAC
	public virtual void Main()
	{
	}

	// Token: 0x040001B8 RID: 440
	public Texture2D maxHpBar;

	// Token: 0x040001B9 RID: 441
	public Texture2D hpBar;

	// Token: 0x040001BA RID: 442
	public Texture2D mpBar;

	// Token: 0x040001BB RID: 443
	public Texture2D expBar;

	// Token: 0x040001BC RID: 444
	public Vector2 maxHpBarPosition;

	// Token: 0x040001BD RID: 445
	public Vector2 hpBarPosition;

	// Token: 0x040001BE RID: 446
	public Vector2 mpBarPosition;

	// Token: 0x040001BF RID: 447
	public Vector2 expBarPosition;

	// Token: 0x040001C0 RID: 448
	public Vector2 levelPosition;

	// Token: 0x040001C1 RID: 449
	public int maxHpBarWidth;

	// Token: 0x040001C2 RID: 450
	public int maxHpBarHeigh;

	// Token: 0x040001C3 RID: 451
	public int barHeight;

	// Token: 0x040001C4 RID: 452
	public int expBarHeight;

	// Token: 0x040001C5 RID: 453
	public GUIStyle textStyle;

	// Token: 0x040001C6 RID: 454
	public GUIStyle hpTextStyle;

	// Token: 0x040001C7 RID: 455
	public float barMultiply;

	// Token: 0x040001C8 RID: 456
	public GameObject player;

	// Token: 0x040001C9 RID: 457
	private int hptext;
}
