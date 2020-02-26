using System;
using UnityEngine;

// Token: 0x02000042 RID: 66
[Serializable]
public class ItemDrop
{
	// Token: 0x060000C7 RID: 199 RVA: 0x0000A118 File Offset: 0x00008318
	public ItemDrop()
	{
		this.dropChance = 20;
	}

	// Token: 0x0400016F RID: 367
	public GameObject itemPrefab;

	// Token: 0x04000170 RID: 368
	[Range(0f, 100f)]
	public int dropChance;
}
