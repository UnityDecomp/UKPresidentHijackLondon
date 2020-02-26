using System;

// Token: 0x0200005D RID: 93
[Serializable]
public class CraftData
{
	// Token: 0x0400027F RID: 639
	public string itemName = string.Empty;

	// Token: 0x04000280 RID: 640
	public Ingredients[] ingredient = new Ingredients[2];

	// Token: 0x04000281 RID: 641
	public Ingredients gotItem;
}
