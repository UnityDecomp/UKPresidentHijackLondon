using System;
using UnityEngine;

// Token: 0x02000006 RID: 6
[AddComponentMenu("Action-RPG Kit/Create Pickup Item")]
[Serializable]
public class AddItem : MonoBehaviour
{
	// Token: 0x0600000B RID: 11 RVA: 0x000023B8 File Offset: 0x000005B8
	public AddItem()
	{
		this.itemQuantity = 1;
		this.textPopup = string.Empty;
		this.itemType = ItType.Usable;
		this.duration = 30f;
	}

	// Token: 0x0600000C RID: 12 RVA: 0x000023F0 File Offset: 0x000005F0
	public virtual void Start()
	{
		this.master = this.transform.root;
		((Collider)this.GetComponent(typeof(Collider))).isTrigger = true;
		if (this.duration > (float)0)
		{
			UnityEngine.Object.Destroy(this.master.gameObject, this.duration);
		}
	}

	// Token: 0x0600000D RID: 13 RVA: 0x0000244C File Offset: 0x0000064C
	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			this.AddItemToPlayer(other.gameObject);
		}
	}

	// Token: 0x0600000E RID: 14 RVA: 0x00002480 File Offset: 0x00000680
	public virtual void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player")
		{
			this.AddItemToPlayer(other.gameObject);
		}
	}

	// Token: 0x0600000F RID: 15 RVA: 0x000024B4 File Offset: 0x000006B4
	public virtual void AddItemToPlayer(GameObject other)
	{
		bool flag;
		if (this.itemType == ItType.Usable)
		{
			flag = ((Inventory)other.GetComponent(typeof(Inventory))).AddItem(this.itemID, this.itemQuantity);
		}
		else
		{
			flag = ((Inventory)other.GetComponent(typeof(Inventory))).AddEquipment(this.itemID);
		}
		if (!flag)
		{
			this.master = this.transform.root;
			if (this.popup && this.textPopup != string.Empty)
			{
				Transform transform = UnityEngine.Object.Instantiate<Transform>(this.popup, this.transform.position, this.transform.rotation);
				((DamagePopup)transform.GetComponent(typeof(DamagePopup))).damage = this.textPopup;
			}
			UnityEngine.Object.Destroy(this.master.gameObject);
		}
	}

	// Token: 0x06000010 RID: 16 RVA: 0x000025A8 File Offset: 0x000007A8
	public virtual void Main()
	{
	}

	// Token: 0x04000012 RID: 18
	public int itemID;

	// Token: 0x04000013 RID: 19
	public int itemQuantity;

	// Token: 0x04000014 RID: 20
	public string textPopup;

	// Token: 0x04000015 RID: 21
	private Transform master;

	// Token: 0x04000016 RID: 22
	public Transform popup;

	// Token: 0x04000017 RID: 23
	public ItType itemType;

	// Token: 0x04000018 RID: 24
	public float duration;
}
