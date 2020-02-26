using System;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x02000003 RID: 3
[RequireComponent(typeof(BulletStatus))]
[Serializable]
public class AbnormalStatAttack : MonoBehaviour
{
	// Token: 0x06000001 RID: 1 RVA: 0x000020EC File Offset: 0x000002EC
	public AbnormalStatAttack()
	{
		this.inflictStatus = AbStat.Poison;
		this.chance = 100;
		this.statusDuration = 5.5f;
		this.shooterTag = "Player";
	}

	// Token: 0x06000002 RID: 2 RVA: 0x0000211C File Offset: 0x0000031C
	public virtual void Start()
	{
		this.shooterTag = ((BulletStatus)this.GetComponent(typeof(BulletStatus))).shooterTag;
	}

	// Token: 0x06000003 RID: 3 RVA: 0x0000214C File Offset: 0x0000034C
	public virtual void OnTriggerEnter(Collider other)
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

	// Token: 0x06000004 RID: 4 RVA: 0x000021CC File Offset: 0x000003CC
	public virtual void InflictAbnormalStats(GameObject target)
	{
		if (this.chance > 0)
		{
			int num = UnityEngine.Random.Range(0, 100);
			if (num <= this.chance)
			{
				((Status)target.GetComponent(typeof(Status))).ApplyAbnormalStat(UnityBuiltins.parseInt((int)this.inflictStatus), this.statusDuration);
			}
		}
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00002228 File Offset: 0x00000428
	public virtual void Main()
	{
	}

	// Token: 0x04000006 RID: 6
	public AbStat inflictStatus;

	// Token: 0x04000007 RID: 7
	public int chance;

	// Token: 0x04000008 RID: 8
	public float statusDuration;

	// Token: 0x04000009 RID: 9
	private string shooterTag;
}
