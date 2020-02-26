using System;

// Token: 0x02000038 RID: 56
[Serializable]
public class Ingredients
{
	// Token: 0x060000A9 RID: 169 RVA: 0x00009844 File Offset: 0x00007A44
	public Ingredients()
	{
		this.itemId = 1;
		this.itemType = ItType.Usable;
		this.quantity = 1;
	}

	// Token: 0x0400014B RID: 331
	public int itemId;

	// Token: 0x0400014C RID: 332
	public ItType itemType;

	// Token: 0x0400014D RID: 333
	public int quantity;
}
