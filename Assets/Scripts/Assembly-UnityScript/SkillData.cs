using System;
using UnityEngine;

// Token: 0x02000086 RID: 134
[Serializable]
public class SkillData : MonoBehaviour
{
	// Token: 0x060001D1 RID: 465 RVA: 0x00017D6C File Offset: 0x00015F6C
	public SkillData()
	{
		this.skill = new Skil[3];
	}

	// Token: 0x060001D2 RID: 466 RVA: 0x00017D80 File Offset: 0x00015F80
	public virtual void Main()
	{
	}

	// Token: 0x0400030C RID: 780
	public Skil[] skill;
}
