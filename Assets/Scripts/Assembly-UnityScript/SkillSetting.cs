using System;
using UnityEngine;

// Token: 0x0200005F RID: 95
[Serializable]
public class SkillSetting
{
	// Token: 0x0600012C RID: 300 RVA: 0x0000F530 File Offset: 0x0000D730
	public SkillSetting()
	{
		this.castTime = 0.5f;
		this.delayTime = 1.5f;
	}

	// Token: 0x04000210 RID: 528
	public string skillName;

	// Token: 0x04000211 RID: 529
	public Transform skillPrefab;

	// Token: 0x04000212 RID: 530
	public AnimationClip skillAnimation;

	// Token: 0x04000213 RID: 531
	public GameObject castEffect;

	// Token: 0x04000214 RID: 532
	public float castTime;

	// Token: 0x04000215 RID: 533
	public float delayTime;
}
