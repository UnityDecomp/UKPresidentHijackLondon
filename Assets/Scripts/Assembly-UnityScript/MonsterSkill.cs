using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

// Token: 0x02000060 RID: 96
[RequireComponent(typeof(AIset))]
[Serializable]
public class MonsterSkill : MonoBehaviour
{
	// Token: 0x0600012D RID: 301 RVA: 0x0000F550 File Offset: 0x0000D750
	public MonsterSkill()
	{
		this.skillDistance = 4.5f;
		this.delay = 2f;
		this.skillSet = new SkillSetting[1];
	}

	// Token: 0x0600012E RID: 302 RVA: 0x0000F588 File Offset: 0x0000D788
	public virtual IEnumerator Start()
	{
		return new MonsterSkill.$Start$188(this).GetEnumerator();
	}

	// Token: 0x0600012F RID: 303 RVA: 0x0000F598 File Offset: 0x0000D798
	public virtual void Update()
	{
		if (this.begin && !this.onSkill)
		{
			if (this.wait >= this.delay)
			{
				this.StartCoroutine(this.UseSkill());
				this.wait = (float)0;
			}
			else
			{
				this.wait += Time.deltaTime;
			}
		}
	}

	// Token: 0x06000130 RID: 304 RVA: 0x0000F5F8 File Offset: 0x0000D7F8
	public virtual IEnumerator UseSkill()
	{
		return new MonsterSkill.$UseSkill$191(this).GetEnumerator();
	}

	// Token: 0x06000131 RID: 305 RVA: 0x0000F608 File Offset: 0x0000D808
	public virtual void Main()
	{
	}

	// Token: 0x04000216 RID: 534
	public GameObject mainModel;

	// Token: 0x04000217 RID: 535
	public float skillDistance;

	// Token: 0x04000218 RID: 536
	public float delay;

	// Token: 0x04000219 RID: 537
	private bool begin;

	// Token: 0x0400021A RID: 538
	private bool onSkill;

	// Token: 0x0400021B RID: 539
	private float wait;

	// Token: 0x0400021C RID: 540
	public SkillSetting[] skillSet;

	// Token: 0x02000061 RID: 97
	[CompilerGenerated]
	[Serializable]
	internal sealed class $Start$188 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x06000132 RID: 306 RVA: 0x0000F60C File Offset: 0x0000D80C
		public $Start$188(MonsterSkill self_)
		{
			this.$self_$190 = self_;
		}

		// Token: 0x06000133 RID: 307 RVA: 0x0000F61C File Offset: 0x0000D81C
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new MonsterSkill.$Start$188.$(this.$self_$190);
		}

		// Token: 0x0400021D RID: 541
		internal MonsterSkill $self_$190;
	}

	// Token: 0x02000063 RID: 99
	[CompilerGenerated]
	[Serializable]
	internal sealed class $UseSkill$191 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x06000136 RID: 310 RVA: 0x0000F6B8 File Offset: 0x0000D8B8
		public $UseSkill$191(MonsterSkill self_)
		{
			this.$self_$196 = self_;
		}

		// Token: 0x06000137 RID: 311 RVA: 0x0000F6C8 File Offset: 0x0000D8C8
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new MonsterSkill.$UseSkill$191.$(this.$self_$196);
		}

		// Token: 0x0400021F RID: 543
		internal MonsterSkill $self_$196;
	}
}
