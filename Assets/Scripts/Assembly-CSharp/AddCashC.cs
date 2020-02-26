using System;
using UnityEngine;

// Token: 0x02000041 RID: 65
public class AddCashC : MonoBehaviour
{
	// Token: 0x0600030D RID: 781 RVA: 0x0000BB1C File Offset: 0x00009F1C
	private void Start()
	{
		this.master = base.transform.root;
		base.GetComponent<Collider>().isTrigger = true;
		if (this.duration > 0f)
		{
			UnityEngine.Object.Destroy(base.gameObject, this.duration);
		}
	}

	// Token: 0x0600030E RID: 782 RVA: 0x0000BB5C File Offset: 0x00009F5C
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			this.AddCashToPlayer(other.gameObject);
		}
	}

	// Token: 0x0600030F RID: 783 RVA: 0x0000BB84 File Offset: 0x00009F84
	private void AddCashToPlayer(GameObject other)
	{
		int num = UnityEngine.Random.Range(this.cashMin, this.cashMax);
		other.GetComponent<InventoryC>().cash += num;
		this.master = base.transform.root;
		if (this.popup)
		{
			Transform transform = UnityEngine.Object.Instantiate<Transform>(this.popup, base.transform.position, base.transform.rotation);
			transform.GetComponent<DamagePopupC>().damage = "Money " + num.ToString();
		}
		UnityEngine.Object.Destroy(this.master.gameObject);
	}

	// Token: 0x0400016C RID: 364
	public int cashMin = 10;

	// Token: 0x0400016D RID: 365
	public int cashMax = 50;

	// Token: 0x0400016E RID: 366
	public float duration = 30f;

	// Token: 0x0400016F RID: 367
	private Transform master;

	// Token: 0x04000170 RID: 368
	public Transform popup;
}
