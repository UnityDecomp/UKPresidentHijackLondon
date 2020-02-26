using System;
using UnityEngine;

// Token: 0x02000039 RID: 57
[Serializable]
public class CraftingData : MonoBehaviour
{
	// Token: 0x060000AA RID: 170 RVA: 0x00009864 File Offset: 0x00007A64
	public CraftingData()
	{
		this.craftingData = new CraftData[3];
	}

	// Token: 0x060000AB RID: 171 RVA: 0x00009878 File Offset: 0x00007A78
	public virtual void Main()
	{
	}

	// Token: 0x0400014E RID: 334
	public CraftData[] craftingData;
}
