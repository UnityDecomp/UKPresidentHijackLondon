using System;
using UnityEngine;

// Token: 0x02000059 RID: 89
[Serializable]
public class ItemData : MonoBehaviour
{
	// Token: 0x0600011A RID: 282 RVA: 0x0000F264 File Offset: 0x0000D464
	public ItemData()
	{
		this.usableItem = new Usable[3];
		this.equipment = new Equip[3];
	}

	// Token: 0x0600011B RID: 283 RVA: 0x0000F284 File Offset: 0x0000D484
	public virtual void Main()
	{
	}

	// Token: 0x04000207 RID: 519
	public Usable[] usableItem;

	// Token: 0x04000208 RID: 520
	public Equip[] equipment;
}
