using System;
using UnityEngine;

// Token: 0x0200006A RID: 106
[RequireComponent(typeof(BulletStatusC))]
public class HealingSkillC : MonoBehaviour
{
	// Token: 0x0600039B RID: 923 RVA: 0x00013AE1 File Offset: 0x00011EE1
	private void Start()
	{
		this.target = base.GetComponent<BulletStatusC>().shooter;
		this.ApplyEffect();
	}

	// Token: 0x0600039C RID: 924 RVA: 0x00013AFC File Offset: 0x00011EFC
	private void ApplyEffect()
	{
		if (this.hpRestore > 0)
		{
			if (this.variance >= 100)
			{
				this.variance = 100;
			}
			if (this.variance <= 1)
			{
				this.variance = 1;
			}
			int min = 100 - this.variance;
			int max = 100 + this.variance;
			this.hpRestore = this.hpRestore * UnityEngine.Random.Range(min, max) / 100;
			this.target.GetComponent<StatusC>().Heal(this.hpRestore, 0);
			Transform transform = UnityEngine.Object.Instantiate<Transform>(this.Popup, this.target.transform.position, base.transform.rotation);
			transform.GetComponent<DamagePopupC>().damage = this.hpRestore.ToString();
		}
		if (this.hitEffect)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.hitEffect, this.target.transform.position, this.hitEffect.transform.rotation);
		}
		if (this.buffs != HealingSkillC.buff.None)
		{
			this.target.GetComponent<StatusC>().ApplyBuff((int)this.buffs, this.statusDuration, this.statusAmount);
		}
		UnityEngine.Object.Destroy(base.gameObject);
	}

	// Token: 0x040002C0 RID: 704
	public int hpRestore;

	// Token: 0x040002C1 RID: 705
	public int variance = 15;

	// Token: 0x040002C2 RID: 706
	public Transform Popup;

	// Token: 0x040002C3 RID: 707
	public HealingSkillC.buff buffs;

	// Token: 0x040002C4 RID: 708
	public int statusAmount;

	// Token: 0x040002C5 RID: 709
	public float statusDuration = 5.5f;

	// Token: 0x040002C6 RID: 710
	public string shooterTag = "Player";

	// Token: 0x040002C7 RID: 711
	public GameObject hitEffect;

	// Token: 0x040002C8 RID: 712
	private GameObject target;

	// Token: 0x0200006B RID: 107
	public enum buff
	{
		// Token: 0x040002CA RID: 714
		None,
		// Token: 0x040002CB RID: 715
		Barrier,
		// Token: 0x040002CC RID: 716
		MagicBarrier,
		// Token: 0x040002CD RID: 717
		Brave,
		// Token: 0x040002CE RID: 718
		Faith
	}
}
