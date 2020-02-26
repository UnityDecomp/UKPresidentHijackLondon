using System;

// Token: 0x02000037 RID: 55
[Serializable]
public class CraftData
{
	// Token: 0x060000A8 RID: 168 RVA: 0x00009824 File Offset: 0x00007A24
	public CraftData()
	{
		this.itemName = string.Empty;
		this.ingredient = new Ingredients[2];
	}

	// Token: 0x04000148 RID: 328
	public string itemName;

	// Token: 0x04000149 RID: 329
	public Ingredients[] ingredient;

	// Token: 0x0400014A RID: 330
	public Ingredients gotItem;
}
