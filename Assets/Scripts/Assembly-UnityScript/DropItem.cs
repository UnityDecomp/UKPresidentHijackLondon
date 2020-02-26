using System;
using UnityEngine;

// Token: 0x02000043 RID: 67
[Serializable]
public class DropItem : MonoBehaviour
{
	// Token: 0x060000C8 RID: 200 RVA: 0x0000A128 File Offset: 0x00008328
	public DropItem()
	{
		this.itemDropSetting = new ItemDrop[1];
		this.randomPosition = 1f;
	}

	// Token: 0x060000C9 RID: 201 RVA: 0x0000A148 File Offset: 0x00008348
	public virtual void Start()
	{
		for (int i = 0; i < this.itemDropSetting.Length; i++)
		{
			int num = UnityEngine.Random.Range(0, 100);
			if (num <= this.itemDropSetting[i].dropChance)
			{
				Vector3 position = this.transform.position;
				position.x += UnityEngine.Random.Range((float)0, this.randomPosition);
				position.z += UnityEngine.Random.Range((float)0, this.randomPosition);
				position.y += this.dropUpward;
				UnityEngine.Object.Instantiate<GameObject>(this.itemDropSetting[i].itemPrefab, position, this.itemDropSetting[i].itemPrefab.transform.rotation);
			}
		}
	}

	// Token: 0x060000CA RID: 202 RVA: 0x0000A214 File Offset: 0x00008414
	public virtual void Main()
	{
	}

	// Token: 0x04000171 RID: 369
	public ItemDrop[] itemDropSetting;

	// Token: 0x04000172 RID: 370
	public float randomPosition;

	// Token: 0x04000173 RID: 371
	public float dropUpward;
}
