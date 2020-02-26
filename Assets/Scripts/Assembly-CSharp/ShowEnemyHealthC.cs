using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200008C RID: 140
public class ShowEnemyHealthC : MonoBehaviour
{
	// Token: 0x0600044A RID: 1098 RVA: 0x0001FB22 File Offset: 0x0001DF22
	private void Start()
	{
		this.hpBarWidth = 100f * this.barMultiply;
		this.healthCanvas.GetComponent<Canvas>().enabled = false;
	}

	// Token: 0x0600044B RID: 1099 RVA: 0x0001FB48 File Offset: 0x0001DF48
	private void Update()
	{
		if (this.show)
		{
			if (this.wait >= this.duration)
			{
				this.show = false;
				this.hideEnemyHealth();
			}
			else
			{
				this.wait += Time.deltaTime;
				this.showEnemyHealth();
			}
		}
		if (this.show && !this.target)
		{
			this.hp = 0;
		}
		else if (this.show && this.target)
		{
			this.hp = this.target.GetComponent<StatusC>().health;
		}
	}

	// Token: 0x0600044C RID: 1100 RVA: 0x0001FBF3 File Offset: 0x0001DFF3
	private void hideEnemyHealth()
	{
		this.healthCanvas.GetComponent<Canvas>().enabled = false;
	}

	// Token: 0x0600044D RID: 1101 RVA: 0x0001FC08 File Offset: 0x0001E008
	private void showEnemyHealth()
	{
		float fillAmount = (float)this.hp / (float)this.maxHp;
		this.healthCanvas.GetComponent<Canvas>().enabled = true;
		this.barFiller.fillAmount = fillAmount;
	}

	// Token: 0x0600044E RID: 1102 RVA: 0x0001FC44 File Offset: 0x0001E044
	private void checkForImages()
	{
		for (int i = 0; i < 18; i++)
		{
		}
	}

	// Token: 0x0600044F RID: 1103 RVA: 0x0001FC64 File Offset: 0x0001E064
	private void OnGUI()
	{
	}

	// Token: 0x06000450 RID: 1104 RVA: 0x0001FC66 File Offset: 0x0001E066
	public void GetHP(int mhealth, GameObject mon, string monName)
	{
		this.maxHp = mhealth;
		this.target = mon;
		this.enemyName = monName;
		this.wait = 0f;
		this.show = true;
	}

	// Token: 0x04000415 RID: 1045
	public Texture2D border;

	// Token: 0x04000416 RID: 1046
	public Texture2D hpBar;

	// Token: 0x04000417 RID: 1047
	public Canvas healthCanvas;

	// Token: 0x04000418 RID: 1048
	public Image barFiller;

	// Token: 0x04000419 RID: 1049
	private string enemyName = string.Empty;

	// Token: 0x0400041A RID: 1050
	public float duration = 7f;

	// Token: 0x0400041B RID: 1051
	private bool show;

	// Token: 0x0400041C RID: 1052
	public int borderWidth = 200;

	// Token: 0x0400041D RID: 1053
	public int borderHeigh = 26;

	// Token: 0x0400041E RID: 1054
	public int hpBarHeight = 20;

	// Token: 0x0400041F RID: 1055
	public float hpBarY = 28f;

	// Token: 0x04000420 RID: 1056
	public float barMultiply = 1.8f;

	// Token: 0x04000421 RID: 1057
	private float hpBarWidth;

	// Token: 0x04000422 RID: 1058
	public GUIStyle textStyle;

	// Token: 0x04000423 RID: 1059
	private int maxHp;

	// Token: 0x04000424 RID: 1060
	private int hp;

	// Token: 0x04000425 RID: 1061
	private float wait;

	// Token: 0x04000426 RID: 1062
	private GameObject target;
}
