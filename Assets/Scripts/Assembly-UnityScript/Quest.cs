using System;
using UnityEngine;

// Token: 0x02000074 RID: 116
[Serializable]
public class Quest
{
	// Token: 0x06000182 RID: 386 RVA: 0x00012054 File Offset: 0x00010254
	public Quest()
	{
		this.questName = string.Empty;
		this.finishProgress = 5;
		this.rewardCash = 100;
		this.rewardExp = 100;
	}

	// Token: 0x040002A2 RID: 674
	public string questName;

	// Token: 0x040002A3 RID: 675
	public Texture2D icon;

	// Token: 0x040002A4 RID: 676
	public string description;

	// Token: 0x040002A5 RID: 677
	public int finishProgress;

	// Token: 0x040002A6 RID: 678
	public int rewardCash;

	// Token: 0x040002A7 RID: 679
	public int rewardExp;

	// Token: 0x040002A8 RID: 680
	public int[] rewardItemID;

	// Token: 0x040002A9 RID: 681
	public int[] rewardEquipmentID;
}
