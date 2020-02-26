using System;
using UnityEngine;

// Token: 0x02000043 RID: 67
public class AddItemC : MonoBehaviour
{
	// Token: 0x06000311 RID: 785 RVA: 0x0000BC50 File Offset: 0x0000A050
	private void Start()
	{
		this.itemEffect = (UnityEngine.Object.FindObjectOfType(typeof(NewHealthBarC)) as NewHealthBarC);
		this.master = base.transform.root;
		if (this.duration > 0f)
		{
			UnityEngine.Object.Destroy(base.gameObject, this.duration);
		}
	}

	// Token: 0x06000312 RID: 786 RVA: 0x0000BCAC File Offset: 0x0000A0AC
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (base.gameObject.name == "PotionC" || base.gameObject.name == "PotionC(Clone)")
			{
			}
			this.AddItemToPlayer(other.gameObject);
		}
	}

	// Token: 0x06000313 RID: 787 RVA: 0x0000BD14 File Offset: 0x0000A114
	private void AddItemToPlayer(GameObject other)
	{
		bool flag;
		if (this.itemType == ItType.Usable)
		{
			flag = other.GetComponent<InventoryC>().AddItem(this.itemID, this.itemQuantity);
		}
		else
		{
			flag = other.GetComponent<InventoryC>().AddEquipment(this.itemID);
		}
		if (!flag)
		{
			this.master = base.transform.root;
			UnityEngine.Object.Destroy(this.master.gameObject);
		}
	}

	// Token: 0x04000174 RID: 372
	public int itemID;

	// Token: 0x04000175 RID: 373
	public int itemQuantity = 1;

	// Token: 0x04000176 RID: 374
	public string textPopup = string.Empty;

	// Token: 0x04000177 RID: 375
	public bool InventorySystem;

	// Token: 0x04000178 RID: 376
	public ItType itemType;

	// Token: 0x04000179 RID: 377
	[HideInInspector]
	public NewHealthBarC itemEffect;

	// Token: 0x0400017A RID: 378
	public float duration = 30f;

	// Token: 0x0400017B RID: 379
	private Transform master;

	// Token: 0x0400017C RID: 380
	public Transform popup;
}
