using System;
using UnityEngine;

// Token: 0x02000055 RID: 85
[Serializable]
public class Usable
{
	// Token: 0x06000118 RID: 280 RVA: 0x0000F1C0 File Offset: 0x0000D3C0
	public Usable()
	{
		this.itemName = string.Empty;
		this.description = string.Empty;
		this.price = 10;
	}

	// Token: 0x040001DD RID: 477
	public string itemName;

	// Token: 0x040001DE RID: 478
	public Texture2D icon;

	// Token: 0x040001DF RID: 479
	public GameObject model;

	// Token: 0x040001E0 RID: 480
	public string description;

	// Token: 0x040001E1 RID: 481
	public int price;

	// Token: 0x040001E2 RID: 482
	public int hpRecover;

	// Token: 0x040001E3 RID: 483
	public int mpRecover;

	// Token: 0x040001E4 RID: 484
	public int atkPlus;

	// Token: 0x040001E5 RID: 485
	public int defPlus;

	// Token: 0x040001E6 RID: 486
	public int matkPlus;

	// Token: 0x040001E7 RID: 487
	public int mdefPlus;

	// Token: 0x040001E8 RID: 488
	public bool unusable;
}
