using System;
using UnityEngine;

// Token: 0x02000083 RID: 131
[Serializable]
public class ShowEnemyHealth : MonoBehaviour
{
	// Token: 0x060001C6 RID: 454 RVA: 0x00017A90 File Offset: 0x00015C90
	public ShowEnemyHealth()
	{
		this.enemyName = string.Empty;
		this.duration = 7f;
		this.borderWidth = 200;
		this.borderHeigh = 26;
		this.hpBarHeight = 20;
		this.hpBarY = 28f;
		this.barMultiply = 1.8f;
	}

	// Token: 0x060001C7 RID: 455 RVA: 0x00017AEC File Offset: 0x00015CEC
	public virtual void Start()
	{
		this.hpBarWidth = (float)100 * this.barMultiply;
	}

	// Token: 0x060001C8 RID: 456 RVA: 0x00017B00 File Offset: 0x00015D00
	public virtual void Update()
	{
		if (this.show)
		{
			if (this.wait >= this.duration)
			{
				this.show = false;
			}
			else
			{
				this.wait += Time.deltaTime;
			}
		}
		if (this.show && !this.target)
		{
			this.hp = 0;
		}
		else if (this.show && this.target)
		{
			this.hp = ((Status)this.target.GetComponent(typeof(Status))).health;
		}
	}

	// Token: 0x060001C9 RID: 457 RVA: 0x00017BB0 File Offset: 0x00015DB0
	public virtual void OnGUI()
	{
		if (this.show)
		{
			int num = (int)((float)(this.hp * 100 / this.maxHp) * this.barMultiply);
			GUI.DrawTexture(new Rect((float)(Screen.width / 2 - this.borderWidth / 2), (float)25, (float)this.borderWidth, (float)this.borderHeigh), this.border);
			GUI.DrawTexture(new Rect((float)(Screen.width / 2) - this.hpBarWidth / (float)2, this.hpBarY, (float)num, (float)this.hpBarHeight), this.hpBar);
			GUI.Label(new Rect((float)(Screen.width / 2) - this.hpBarWidth / (float)2, this.hpBarY, this.hpBarWidth, (float)this.hpBarHeight), this.enemyName, this.textStyle);
		}
	}

	// Token: 0x060001CA RID: 458 RVA: 0x00017C80 File Offset: 0x00015E80
	public virtual void GetHP(int mhealth, GameObject mon, string monName)
	{
		this.maxHp = mhealth;
		this.target = mon;
		this.enemyName = monName;
		this.wait = (float)0;
		this.show = true;
	}

	// Token: 0x060001CB RID: 459 RVA: 0x00017CB4 File Offset: 0x00015EB4
	public virtual void Main()
	{
	}

	// Token: 0x040002F4 RID: 756
	public Texture2D border;

	// Token: 0x040002F5 RID: 757
	public Texture2D hpBar;

	// Token: 0x040002F6 RID: 758
	private string enemyName;

	// Token: 0x040002F7 RID: 759
	public float duration;

	// Token: 0x040002F8 RID: 760
	private bool show;

	// Token: 0x040002F9 RID: 761
	public int borderWidth;

	// Token: 0x040002FA RID: 762
	public int borderHeigh;

	// Token: 0x040002FB RID: 763
	public int hpBarHeight;

	// Token: 0x040002FC RID: 764
	public float hpBarY;

	// Token: 0x040002FD RID: 765
	public float barMultiply;

	// Token: 0x040002FE RID: 766
	private float hpBarWidth;

	// Token: 0x040002FF RID: 767
	public GUIStyle textStyle;

	// Token: 0x04000300 RID: 768
	private int maxHp;

	// Token: 0x04000301 RID: 769
	private int hp;

	// Token: 0x04000302 RID: 770
	private float wait;

	// Token: 0x04000303 RID: 771
	private GameObject target;
}
