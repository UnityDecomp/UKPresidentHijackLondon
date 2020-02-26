using System;
using UnityEngine;

// Token: 0x02000065 RID: 101
public class DropItemC : MonoBehaviour
{
	// Token: 0x06000389 RID: 905 RVA: 0x00012E60 File Offset: 0x00011260
	private void Start()
	{
		for (int i = 0; i < this.itemDropSetting.Length; i++)
		{
			int num = UnityEngine.Random.Range(0, 100);
			if (num <= this.itemDropSetting[i].dropChance)
			{
				Vector3 position = base.transform.position;
				position.x += UnityEngine.Random.Range(0f, this.randomPosition);
				position.z += UnityEngine.Random.Range(0f, this.randomPosition);
				position.y += this.dropUpward;
				UnityEngine.Object.Instantiate<GameObject>(this.itemDropSetting[i].itemPrefab, position, this.itemDropSetting[i].itemPrefab.transform.rotation);
			}
		}
	}

	// Token: 0x040002A2 RID: 674
	public DropItemC.ItemDrop[] itemDropSetting = new DropItemC.ItemDrop[1];

	// Token: 0x040002A3 RID: 675
	public float randomPosition = 1f;

	// Token: 0x040002A4 RID: 676
	public float dropUpward;

	// Token: 0x02000066 RID: 102
	[Serializable]
	public class ItemDrop
	{
		// Token: 0x040002A5 RID: 677
		public GameObject itemPrefab;

		// Token: 0x040002A6 RID: 678
		[Range(0f, 100f)]
		public int dropChance = 60;
	}
}
