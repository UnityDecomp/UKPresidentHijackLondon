using System;
using UnityEngine;


// Token: 0x02000051 RID: 81
[RequireComponent(typeof(BulletStatus))]
[Serializable]
public class HealingSkill : MonoBehaviour
{
	// Token: 0x060000F6 RID: 246 RVA: 0x0000B5F4 File Offset: 0x000097F4
	public HealingSkill()
	{
		this.variance = 15;
		this.buffs = buff.None;
		this.statusDuration = 5.5f;
		this.shooterTag = "Player";
	}

	// Token: 0x060000F7 RID: 247 RVA: 0x0000B624 File Offset: 0x00009824
	public virtual void Start()
	{
		this.target = ((BulletStatus)this.GetComponent(typeof(BulletStatus))).shooter;
		this.ApplyEffect();
	}

	// Token: 0x060000F8 RID: 248 RVA: 0x0000B658 File Offset: 0x00009858
	public virtual void ApplyEffect()
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
			((Status)this.target.GetComponent(typeof(Status))).Heal(this.hpRestore, 0);
			Transform transform = UnityEngine.Object.Instantiate<Transform>(this.Popup, this.target.transform.position, this.transform.rotation);
			((DamagePopup)transform.GetComponent(typeof(DamagePopup))).damage = this.hpRestore.ToString();
		}
		if (this.hitEffect)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.hitEffect, this.target.transform.position, this.hitEffect.transform.rotation);
		}
		if (this.buffs != buff.None)
		{
			((Status)this.target.GetComponent(typeof(Status))).ApplyBuff(UnityBuiltins.parseInt((int)this.buffs), this.statusDuration, this.statusAmount);
		}
		UnityEngine.Object.Destroy(this.gameObject);
	}

	// Token: 0x060000F9 RID: 249 RVA: 0x0000B7C0 File Offset: 0x000099C0
	public virtual void Main()
	{
	}

	// Token: 0x040001AF RID: 431
	public int hpRestore;

	// Token: 0x040001B0 RID: 432
	public int variance;

	// Token: 0x040001B1 RID: 433
	public Transform Popup;

	// Token: 0x040001B2 RID: 434
	public buff buffs;

	// Token: 0x040001B3 RID: 435
	public int statusAmount;

	// Token: 0x040001B4 RID: 436
	public float statusDuration;

	// Token: 0x040001B5 RID: 437
	public string shooterTag;

	// Token: 0x040001B6 RID: 438
	public GameObject hitEffect;

	// Token: 0x040001B7 RID: 439
	private GameObject target;
}
