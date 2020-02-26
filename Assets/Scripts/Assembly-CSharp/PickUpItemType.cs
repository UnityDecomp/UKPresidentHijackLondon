using System;
using UnityEngine;

// Token: 0x020001F6 RID: 502
public class PickUpItemType : MonoBehaviour
{
	// Token: 0x06000CE7 RID: 3303 RVA: 0x000514F8 File Offset: 0x0004F8F8
	private void Start()
	{
	}

	// Token: 0x06000CE8 RID: 3304 RVA: 0x000514FA File Offset: 0x0004F8FA
	private void Update()
	{
	}

	// Token: 0x04000D6E RID: 3438
	public int itemID;

	// Token: 0x04000D6F RID: 3439
	public PickUpItemType.ItemType itemType;

	// Token: 0x020001F7 RID: 503
	public enum ItemType
	{
		// Token: 0x04000D71 RID: 3441
		Weapon,
		// Token: 0x04000D72 RID: 3442
		Food,
		// Token: 0x04000D73 RID: 3443
		Water,
		// Token: 0x04000D74 RID: 3444
		Wood,
		// Token: 0x04000D75 RID: 3445
		Ingredient
	}
}
