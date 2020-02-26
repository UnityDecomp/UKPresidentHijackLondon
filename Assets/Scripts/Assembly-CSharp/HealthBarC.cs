using System;
using UnityEngine;

// Token: 0x0200006C RID: 108
public class HealthBarC : MonoBehaviour
{
	// Token: 0x0600039E RID: 926 RVA: 0x00013CEC File Offset: 0x000120EC
	private void Awake()
	{
		if (!this.player)
		{
			this.player = GameObject.FindWithTag("Player");
		}
		this.hptext = 100f * this.barMultiply;
	}

	// Token: 0x0600039F RID: 927 RVA: 0x00013D20 File Offset: 0x00012120
	private void OnGUI()
	{
		if (!this.player)
		{
			return;
		}
		float num = (float)this.player.GetComponent<StatusC>().maxHealth;
		float width = (float)(this.player.GetComponent<StatusC>().health * 100) / num * this.barMultiply;
		float num2 = (float)this.player.GetComponent<StatusC>().maxMana;
		float width2 = (float)(this.player.GetComponent<StatusC>().mana * 100) / num2 * this.barMultiply;
		float num3 = (float)this.player.GetComponent<StatusC>().maxExp;
		float width3 = (float)(this.player.GetComponent<StatusC>().exp * 100) / num3 * this.barMultiply;
		float num4 = (float)this.player.GetComponent<StatusC>().level;
		int health = this.player.GetComponent<StatusC>().health;
		int mana = this.player.GetComponent<StatusC>().mana;
		GUI.DrawTexture(new Rect(this.maxHpBarPosition.x, this.maxHpBarPosition.y, (float)this.maxHpBarWidth, (float)this.maxHpBarHeigh), this.maxHpBar);
		GUI.DrawTexture(new Rect(this.hpBarPosition.x, this.hpBarPosition.y, width, (float)this.barHeight), this.hpBar);
		GUI.DrawTexture(new Rect(this.mpBarPosition.x, this.mpBarPosition.y, width2, (float)this.barHeight), this.mpBar);
		GUI.DrawTexture(new Rect(this.expBarPosition.x, this.expBarPosition.y, width3, (float)this.expBarHeight), this.expBar);
		GUI.Label(new Rect(this.levelPosition.x, this.levelPosition.y, 50f, 50f), num4.ToString(), this.textStyle);
		GUI.Label(new Rect(this.hpBarPosition.x, this.hpBarPosition.y, this.hptext, (float)this.barHeight), health.ToString() + "/" + num.ToString(), this.hpTextStyle);
		GUI.Label(new Rect(this.mpBarPosition.x, this.mpBarPosition.y, this.hptext, (float)this.barHeight), mana.ToString() + "/" + num2.ToString(), this.hpTextStyle);
	}

	// Token: 0x040002CF RID: 719
	public Texture2D maxHpBar;

	// Token: 0x040002D0 RID: 720
	public Texture2D hpBar;

	// Token: 0x040002D1 RID: 721
	public Texture2D mpBar;

	// Token: 0x040002D2 RID: 722
	public Texture2D expBar;

	// Token: 0x040002D3 RID: 723
	public Texture2D staminaBar;

	// Token: 0x040002D4 RID: 724
	public Vector2 maxHpBarPosition = new Vector2(20f, 20f);

	// Token: 0x040002D5 RID: 725
	public Vector2 hpBarPosition = new Vector2(152f, 48f);

	// Token: 0x040002D6 RID: 726
	public Vector2 mpBarPosition = new Vector2(152f, 71f);

	// Token: 0x040002D7 RID: 727
	public Vector2 expBarPosition = new Vector2(152f, 94f);

	// Token: 0x040002D8 RID: 728
	public Vector2 levelPosition = new Vector2(24f, 86f);

	// Token: 0x040002D9 RID: 729
	public int maxHpBarWidth = 310;

	// Token: 0x040002DA RID: 730
	public int maxHpBarHeigh = 115;

	// Token: 0x040002DB RID: 731
	public int barHeight = 19;

	// Token: 0x040002DC RID: 732
	public int expBarHeight = 8;

	// Token: 0x040002DD RID: 733
	public GUIStyle textStyle;

	// Token: 0x040002DE RID: 734
	public GUIStyle hpTextStyle;

	// Token: 0x040002DF RID: 735
	public float barMultiply = 1.6f;

	// Token: 0x040002E0 RID: 736
	public GameObject player;

	// Token: 0x040002E1 RID: 737
	private float hptext = 100f;
}
