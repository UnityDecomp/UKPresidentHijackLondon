using System;
using UnityEngine;

// Token: 0x0200003A RID: 58
[Serializable]
public class DamageArea : MonoBehaviour
{
	// Token: 0x060000AC RID: 172 RVA: 0x0000987C File Offset: 0x00007A7C
	public DamageArea()
	{
		this.damage = 50;
	}

	// Token: 0x060000AD RID: 173 RVA: 0x0000988C File Offset: 0x00007A8C
	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			((Status)other.GetComponent(typeof(Status))).OnDamage(this.damage, 0);
		}
	}

	// Token: 0x060000AE RID: 174 RVA: 0x000098D8 File Offset: 0x00007AD8
	public virtual void Main()
	{
	}

	// Token: 0x0400014F RID: 335
	public int damage;
}
