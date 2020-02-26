using System;
using UnityEngine;

// Token: 0x02000004 RID: 4
[AddComponentMenu("Action-RPG Kit/Create Pickup Cash")]
[Serializable]
public class AddCash : MonoBehaviour
{
	// Token: 0x06000006 RID: 6 RVA: 0x0000222C File Offset: 0x0000042C
	public AddCash()
	{
		this.cashMin = 10;
		this.cashMax = 50;
		this.duration = 30f;
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00002250 File Offset: 0x00000450
	public virtual void Start()
	{
		this.master = this.transform.root;
		((Collider)this.GetComponent(typeof(Collider))).isTrigger = true;
		if (this.duration > (float)0)
		{
			UnityEngine.Object.Destroy(this.master.gameObject, this.duration);
		}
	}

	// Token: 0x06000008 RID: 8 RVA: 0x000022AC File Offset: 0x000004AC
	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			this.AddCashToPlayer(other.gameObject);
		}
	}

	// Token: 0x06000009 RID: 9 RVA: 0x000022E0 File Offset: 0x000004E0
	public virtual void AddCashToPlayer(GameObject other)
	{
		int num = UnityEngine.Random.Range(this.cashMin, this.cashMax);
		((Inventory)other.GetComponent(typeof(Inventory))).cash = ((Inventory)other.GetComponent(typeof(Inventory))).cash + num;
		this.master = this.transform.root;
		if (this.popup)
		{
			Transform transform = UnityEngine.Object.Instantiate<Transform>(this.popup, this.transform.position, this.transform.rotation);
			((DamagePopup)transform.GetComponent(typeof(DamagePopup))).damage = "Money " + num.ToString();
		}
		UnityEngine.Object.Destroy(this.master.gameObject);
	}

	// Token: 0x0600000A RID: 10 RVA: 0x000023B4 File Offset: 0x000005B4
	public virtual void Main()
	{
	}

	// Token: 0x0400000A RID: 10
	public int cashMin;

	// Token: 0x0400000B RID: 11
	public int cashMax;

	// Token: 0x0400000C RID: 12
	public float duration;

	// Token: 0x0400000D RID: 13
	private Transform master;

	// Token: 0x0400000E RID: 14
	public Transform popup;
}
