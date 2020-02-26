using System;
using UnityEngine;

// Token: 0x0200003F RID: 63
[RequireComponent(typeof(BulletStatusC))]
public class AbnormalStatAttackC : MonoBehaviour
{
	// Token: 0x06000309 RID: 777 RVA: 0x0000BA20 File Offset: 0x00009E20
	private void Start()
	{
		this.shooterTag = base.GetComponent<BulletStatusC>().shooterTag;
	}

	// Token: 0x0600030A RID: 778 RVA: 0x0000BA34 File Offset: 0x00009E34
	private void OnTriggerEnter(Collider other)
	{
		if (this.shooterTag == "Player" && other.tag == "Enemy")
		{
			this.InflictAbnormalStats(other.gameObject);
		}
		else if (this.shooterTag == "Enemy" && other.tag == "Player")
		{
			this.InflictAbnormalStats(other.gameObject);
		}
	}

	// Token: 0x0600030B RID: 779 RVA: 0x0000BAB4 File Offset: 0x00009EB4
	public void InflictAbnormalStats(GameObject target)
	{
		if (this.chance > 0)
		{
			int num = UnityEngine.Random.Range(0, 100);
			if (num <= this.chance)
			{
				target.GetComponent<StatusC>().ApplyAbnormalStat((int)this.inflictStatus, this.statusDuration);
			}
		}
	}

	// Token: 0x04000163 RID: 355
	public AbnormalStatAttackC.AbStat inflictStatus;

	// Token: 0x04000164 RID: 356
	public int chance = 100;

	// Token: 0x04000165 RID: 357
	public float statusDuration = 5.5f;

	// Token: 0x04000166 RID: 358
	private string shooterTag = "Player";

	// Token: 0x02000040 RID: 64
	public enum AbStat
	{
		// Token: 0x04000168 RID: 360
		Poison,
		// Token: 0x04000169 RID: 361
		Silence,
		// Token: 0x0400016A RID: 362
		Stun,
		// Token: 0x0400016B RID: 363
		WebbedUp
	}
}
