using System;
using UnityEngine;

// Token: 0x02000085 RID: 133
[Serializable]
public class Skil
{
	// Token: 0x060001D0 RID: 464 RVA: 0x00017D38 File Offset: 0x00015F38
	public Skil()
	{
		this.skillName = string.Empty;
		this.manaCost = 10;
		this.description = string.Empty;
	}

	// Token: 0x04000306 RID: 774
	public string skillName;

	// Token: 0x04000307 RID: 775
	public Texture2D icon;

	// Token: 0x04000308 RID: 776
	public Transform skillPrefab;

	// Token: 0x04000309 RID: 777
	public AnimationClip skillAnimation;

	// Token: 0x0400030A RID: 778
	public int manaCost;

	// Token: 0x0400030B RID: 779
	public string description;
}
